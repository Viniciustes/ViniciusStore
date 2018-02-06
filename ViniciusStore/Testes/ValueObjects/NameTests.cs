using Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ShouldReturnNotificationWhenFirstNameIsNotValid()
        {
            var name = new Name("","MyLastName");
            Assert.AreEqual(false, name.IsValid);
            Assert.AreEqual(1, name.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenLastNameIsNotValid()
        {
            var name = new Name("MyFirstName", "");
            Assert.AreEqual(false, name.IsValid);
            Assert.AreEqual(1, name.Notifications.Count);
        }
    }
}
