using FluentValidator;

namespace Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {
        #region Constructor
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (product.QuantityOnHand < quantity)
                AddNotification("Quantity", "Produto fora de estoque");

            product.DecreaseQuantity(quantity);

            //Exemplo de Validação de regras de negócio
            //Notifications = new Dictionary<string, string>();
            //if (product.QuantityOnHand < quantity)
            //    Notifications.Add("Quantidade", "Quantidade do produto insuficiente");

            //if (product.Price == 0)
            //    Notifications.Add("Preco", "Preço não pode ser 0");
        }
        #endregion

        #region Properties
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        //public IDictionary<string,string> Notifications { get; set; }
        #endregion
    }
}