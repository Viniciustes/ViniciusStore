using Shared.Commands;
using System;

namespace Domain.StoreContext.Commands.ProductCommands.Outputs
{
    public class CreateProductCommandResult : ICommandResult
    {
        #region Constructors
        public CreateProductCommandResult() { }

        public CreateProductCommandResult(Guid id,string title, decimal price, decimal quantityOnHand)
        {
            Id = id;
            Title = title;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }
        #endregion

        #region Properties
        public Guid Id { get; set; }
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityOnHand { get; private set; }
        #endregion
    }
}
