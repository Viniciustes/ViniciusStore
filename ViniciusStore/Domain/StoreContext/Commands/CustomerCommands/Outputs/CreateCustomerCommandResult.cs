using Shared.Commands;
using System;

namespace Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class CreateCustomerCommandResult : ICommandResult
    {
        #region Constructors
        public CreateCustomerCommandResult() { }

        public CreateCustomerCommandResult(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
        #endregion

        #region Properties
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        #endregion
    }
}