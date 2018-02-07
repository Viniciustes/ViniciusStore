using Domain.StoreContext.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes.Entities
{
    [TestClass]
    public class ProductTests
    {
        [DataRow(10, 3, 7)]
        [DataRow(7, 2, 5)]
        [DataRow(62, 50, 12)]
        [DataRow(3, 1, 2)]
        [DataRow(36, 23, 13)]
        [DataTestMethod]
        public void ShouldBeCurrentQuantityinStock(int qtdProductOnHand, int qtdDecreaseProduct, int qtdCurrentProduct)
        {
            var product = new Product("myProduct1", "Description for product 1", "product1.image", 1.99M, qtdProductOnHand);

            product.DecreaseQuantity(qtdDecreaseProduct);
            Assert.AreEqual(qtdCurrentProduct, product.QuantityOnHand);
        }
    }
}
