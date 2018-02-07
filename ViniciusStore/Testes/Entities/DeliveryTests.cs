using Domain.StoreContext.Entities;
using Domain.StoreContext.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testes.Entities
{
    [TestClass]
    public class DeliveryTests
    {
        private Delivery _delivery;

        public DeliveryTests()
        {
            _delivery = new Delivery(DateTime.Now.AddDays(7));
        }

        [TestMethod]
        public void StatusShoudReturnShippedWhenDeliveryChip()
        {
            _delivery.Ship();
            Assert.AreEqual(EDeliveryStatus.Shipped, _delivery.Status);
        }

        [TestMethod]
        public void StatusShoudReturnCanceledWhenDeliveryCancel()
        {
            _delivery.Cancel();
            Assert.AreEqual(EDeliveryStatus.Canceled, _delivery.Status);
        }
    }
}
