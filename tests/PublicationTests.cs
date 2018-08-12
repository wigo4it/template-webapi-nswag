using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KellermanSoftware.CompareNetObjects;
using MessagePack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rebus.Activation;
using Rebus.Bus;
using Rebus.Handlers;
using Rebus.Transport;
using Rebus.Transport.InMem;
using template_identifier.PublicationMessage;
using Rebus.Bus.Advanced;
using Rebus.Tests.Contracts.Extensions;
using Rebus.TestHelpers;
using Rebus.TestHelpers.Events;
using System.Linq;
using Rebus.Config;
using Rebus.Logging;

namespace Tests {
    [TestClass]
    public class PublicationTests {

        private CompareLogic obj = new CompareLogic();
        const LogLevel MinimumLogLevel = LogLevel.Error;
        const string ConnectionString = "amqp://localhost";

         [TestMethod]
        public void can_serialize_publication_message()
        {
            PublicationMessage target = GetPublicationMessag1();
            var wire = MessagePackSerializer.Serialize(target);
            var result = MessagePackSerializer.Deserialize<PublicationMessage>(wire);
            Assert.IsTrue(obj.Compare(target, result).AreEqual);
            // make sure something got set/serialized.
            target.Date = DateTime.UtcNow;
            Assert.IsFalse(obj.Compare(target, result).AreEqual);
        }

        private static PublicationMessage GetPublicationMessag1()
        {
            return new PublicationMessage()
            {
                CorrelationId = "correlationId",
                AccountingToken = "accountingToken",
                Data = "data",
                Date = DateTime.Now
            };
        }

        static void ConfigureSubscriber(BuiltinHandlerActivator activator, InMemNetwork network, string inputQueueName)
        {
            activator.Handle<string>(async str =>
            {
                Console.WriteLine("{0} => '{1}'", str, inputQueueName);
            });
            Configure.With(activator)
                .Logging(l => l.ColoredConsole(MinimumLogLevel))
                .Transport(t => t.UseRabbitMq(ConnectionString, inputQueueName))
                .Start();
        }

        [TestMethod]
        public void can_publish_and_subscribe_to_events()
        {
            var network = new InMemNetwork();
            using (var publisher = new BuiltinHandlerActivator())
            using (var subscriber1 = new BuiltinHandlerActivator())
            using (var subscriber2 = new BuiltinHandlerActivator())
            using (var subscriber3 = new BuiltinHandlerActivator())
            {
                ConfigureSubscriber(subscriber1, network, "endpoint1");
                ConfigureSubscriber(subscriber2, network, "endpoint2");
                ConfigureSubscriber(subscriber3, network, "endpoint3");
                subscriber1.Bus.Advanced.Topics.Subscribe("get.book").Wait();
                subscriber2.Bus.Advanced.Topics.Subscribe("get.books").Wait();
                subscriber3.Bus.Advanced.Topics.Subscribe("get#").Wait();
                 var publisherBus = Configure.With(publisher)
                    .Logging(l => l.ColoredConsole(MinimumLogLevel))
                    .Transport(t => t.UseRabbitMqAsOneWayClient(ConnectionString))
                    .Start();
                var topic = publisherBus.Advanced.Topics;
                topic.Publish("get.books", "This one should be received by 2,3").Wait();
                topic.Publish("get.book", "This one should be received by 1,3").Wait();
                topic.Publish("get", "This one should be received by 3").Wait();
            }
        }
    }
}