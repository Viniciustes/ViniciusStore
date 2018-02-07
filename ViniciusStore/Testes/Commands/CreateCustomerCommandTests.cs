using Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        private readonly CreateCustomerCommand createCustomerCommand;

        public CreateCustomerCommandTests()
        {
            createCustomerCommand = new CreateCustomerCommand
            {
                FirstName = "myFirstName",
                LastName = "myLastName",
                Document = "99999999999",
                Email = "myEmail@email.com",
                Phone = "999999999"
            };
        }

        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            Assert.AreEqual(true, createCustomerCommand.Valid());
        }
    }
}