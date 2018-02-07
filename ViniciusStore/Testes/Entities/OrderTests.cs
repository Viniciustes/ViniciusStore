using Domain.StoreContext.Entities;
using Domain.StoreContext.Enums;
using Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Order _order;
        private Product _product1;
        private Product _product2;
        private Product _product3;

        public OrderTests()
        {
            var name = new Name("myFirtName", "myLastName");
            var document = new Document("99999999999");
            var email = new Email("myEmail@email.com");
            var customer = new Customer(name, document, email, "99999-9999");

            _product1 = new Product("myProduct1", "Description for product 1", "product1.image", 1.99M, 11);

            _product2 = new Product("myProduct2", "Description for product 2", "product2.image", 11.77M, 3);

            _product3 = new Product("myProduct3", "Description for product 3", "product3.image", 25.33M, 8);

            _order = new Order(customer);
        }

        // Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        // Ao criar o pedido, o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // Ao adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_product1, 2);
            _order.AddItem(_product2, 1);

            Assert.AreEqual(2, _order.Items.Count);
        }

        // Ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_product1, 6);
            Assert.AreEqual(_product1.QuantityOnHand, 5);
        }

        // Ao confirmar pedido, deve gerar um número
        [TestMethod]
        public void ShouldReturnNumberWhenOrderPlaced()
        {
            _order.GenerateOrder();
            Assert.IsNotNull(_order.Number);
            Assert.AreNotEqual("", _order.Number);
        }

        // Ao pagar um pedido,  o status deve ser pago
        [TestMethod]
        public void StatusShouldReturnPaidWhenOrderPaid()
        {
            _order.PayOrder();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        [DataRow(1, 1)]
        [DataRow(2, 1)]
        [DataRow(3, 1)]
        [DataRow(4, 1)]
        [DataRow(5, 1)]
        [DataRow(6, 2)]
        [DataRow(10, 2)]
        [DataRow(15, 3)]
        [DataRow(16, 4)]
        [DataRow(19, 4)]
        [DataRow(20, 4)]
        [DataRow(21, 5)]
        [DataRow(30, 6)]
        [DataRow(31, 7)]
        [DataRow(35, 7)]
        [DataRow(36, 8)]
        [DataRow(39, 8)]
        [DataRow(55, 11)]
        [DataRow(56, 12)]
        [DataRow(60, 12)]
        [DataRow(61, 13)]
        [DataTestMethod]
        public void ShouldYShippingsWhenPurchasedXProducts(int qtdProducts, int qtdShippings)
        {
            for (int i = 0; i < qtdProducts; i++)
            {
                _order.AddItem(_product1, i + 1);
            }
            _order.ShipOrder();

            Assert.AreEqual(qtdShippings, _order.Deliveries.Count);
        }

        // Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.CancelOrder();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {
            _order.AddItem(_product1, 1);
            _order.AddItem(_product2, 2);
            _order.AddItem(_product3, 3);
            _order.AddItem(_product1, 4);
            _order.AddItem(_product2, 5);
            _order.AddItem(_product3, 6);
            _order.AddItem(_product1, 7);
            _order.AddItem(_product2, 8);
            _order.AddItem(_product3, 9);
            _order.AddItem(_product1, 10);
            _order.CancelOrder();

            foreach (var item in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, item.Status);
            }
        }
    }
}
