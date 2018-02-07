using FluentValidator;
using Shared.Commands;
using System;

namespace Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class OrderItemCommand : Notifiable, ICommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }

        public bool Valid()
        {
            return IsValid;
        }
    }
}
