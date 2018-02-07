using FluentValidator;
using FluentValidator.Validation;
using Shared.Commands;
using System;
using System.Collections.Generic;

namespace Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class GenerateOrderCommand : Notifiable, ICommand
    {
        public GenerateOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }

        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
               .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente inválido")
               .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido foi encontrado")
                );
            return IsValid;
        }
    }
}
