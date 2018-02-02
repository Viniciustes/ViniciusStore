﻿namespace Domain.StoreContext.Entities
{
    public class Product
    {
        #region Constructor
        public Product(string title, string description, string image, decimal price, decimal quantityOnHand)
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            QuantityOnHand = quantityOnHand;
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
        public override string ToString() => Title;
        #endregion
    }
}