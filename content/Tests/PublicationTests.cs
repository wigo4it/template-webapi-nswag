using System;
using MessagePack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using template_identifier.PublicationMessage;

namespace Tests {
    [TestClass]
    public class PublicationTests {
         [TestMethod]
        public void can_serialize_publication_message() {
            var date = DateTime.Now;
            var target = MessagePackSerializer.Serialize(new PublicationMessage(){
                CorrelationId = "correlationId",
                AccountingToken = "accountingToken",
                Data = "data",
                Date = date
            });
            var result = MessagePackSerializer.Deserialize<PublicationMessage>(target);
            Assert.AreSame(target,result);
        }
    }
}