using Domain.StoreContext.Entities;
using Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Vinícius", "Barreira");
            var document = new Document("12345678912");
            var email = new Email("viniciustes@gmail.com");
            var customer = new Customer(name, document, email, "99999-9999");

            var order = new Order(customer);

            var mouse = new Product("Mouse", "Mouse para notebook", "Mouse.jpg", 1, 5);
            var tv = new Product("TV", "TV de plasma 23 polegadas", "TV.jpg", 1524.80M, 3);
            var celular = new Product("Celular", "Celular android", "Celular.jpg", 299.36M, 1);

            var orderItem = new OrderItem(mouse, 5);




            //Exemplo de Validação de regras de negócio.
            //if (orderItem.Notifications.Count > 0)
            //{
            //    var msg = string.Empty;
            //    foreach (var item in orderItem.Notifications)
            //    {
            //        msg += item.Value.ToString() + " / ";
            //    }
            //    throw new System.Exception(msg);
            //}

            order.AddItem(orderItem);
            order.AddItem(new OrderItem(tv, 2));
            order.AddItem(new OrderItem(celular, 1));

            order.GenerateOrder();
            var valid = order.IsValid;


            order.PayOrder();

            order.ShipOrder();

            order.CancelOrder();
        }
    }
}
