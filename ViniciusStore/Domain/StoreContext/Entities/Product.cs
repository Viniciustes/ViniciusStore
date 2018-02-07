using FluentValidator.Validation;
using Shared.Entities;

namespace Domain.StoreContext.Entities
{
    public class Product : Entity
    {
        #region Constructor
        public Product(string title, string description, string image, decimal price, decimal quantityOnHand)
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            QuantityOnHand = quantityOnHand;

            CallNotifications();
        }
        #endregion

        #region Properties
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityOnHand { get; private set; }
        #endregion

        #region Methods
        public void DecreaseQuantity(decimal quantity) => QuantityOnHand -= quantity;

        private void CallNotifications() =>
            AddNotifications(new ValidationContract()
               .Requires()
               .HasMinLen(Title, 3, "Title", "O nome do produto deve conter pelo menos 3 caracteres")
               .HasMaxLen(Title, 100, "Title", "O nome do produto deve conter no máximo 100 caracteres")
                .IsGreaterThan(Price, 0, "Price", "O valor do produto deve ser maior que 0")
               );

        public override string ToString() => Title;
        #endregion
    }
}