using Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private Document _validDocument;
        private Document _invalidDocument;

        public DocumentTests()
        {
            _validDocument = new Document("28659170377");
            _invalidDocument = new Document("12345678901");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, _invalidDocument.IsValid);
            Assert.AreEqual(1, _invalidDocument.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, _validDocument.IsValid);
            Assert.AreEqual(0, _validDocument.Notifications.Count);
        }
    }
}
