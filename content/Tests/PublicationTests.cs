using System;
using KellermanSoftware.CompareNetObjects;
using MessagePack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using template_identifier.PublicationMessage;

namespace Tests {
    [TestClass]
    public class PublicationTests {

        private CompareLogic obj = new CompareLogic();
         [TestMethod]
        public void can_serialize_publication_message() {
            var target = new PublicationMessage(){
                CorrelationId = "correlationId",
                AccountingToken = "accountingToken",
                Data = "data",
                Date = DateTime.Now
            };
            var wire = MessagePackSerializer.Serialize(target);
            var result = MessagePackSerializer.Deserialize<PublicationMessage>(wire);
            Assert.IsTrue(obj.Compare(target,result).AreEqual);
            // make sure something got set/serialized.
            target.Date = DateTime.UtcNow;
            Assert.IsFalse(obj.Compare(target,result).AreEqual);
        }
    }
}