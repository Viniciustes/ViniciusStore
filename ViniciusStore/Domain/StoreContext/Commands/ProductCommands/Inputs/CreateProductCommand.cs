using FluentValidator;
using FluentValidator.Validation;
using Shared.Commands;
using System;

namespace Domain.StoreContext.Commands.ProductCommands.Inputs
{
    public class CreateProductCommand : Notifiable, ICommand
    {
        #region Properties
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal QuantityOnHand { get; set; }
        #endregion

        #region Methodos
        public bool Valid()
        {
            AddNotifications(new ValidationContract()
               .Requires()
               .HasMinLen(Title, 3, "Title", "O nome do produto deve conter pelo menos 3 caracteres")
               .HasMaxLen(Title, 100, "Title", "O nome do produto deve conter no máximo 100 caracteres")
               );
            return IsValid;
        }
        #endregion
    }
}
