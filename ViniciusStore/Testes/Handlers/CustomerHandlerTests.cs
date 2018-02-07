using Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Domain.StoreContext.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testes.Mocks;

namespace Testes.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        private readonly CreateCustomerCommand createCustomerCommand;
        private readonly CustomerHandler customerHandler;

        public CustomerHandlerTests()
        {
            createCustomerCommand = new CreateCustomerCommand
            {
                FirstName = "myFirstName",
                LastName = "myLastName",
                Document = "99999999999",
                Email = "myEmail@email.com",
                Phone = "999999999"
            };

            customerHandler = new CustomerHandler(new MockCustomerRepository(), new MockEmailService());
        }

        [TestMethod]
        public void ShouldRegisterCustomerWhenHandlerIsValid()
        {
            Assert.AreNotEqual(null, customerHandler.Handle(createCustomerCommand));
            Assert.AreEqual(true, customerHandler.IsValid);
        }

        [TestMethod]
        public void NotShouldRegisterCustomerWhenDocumentHandleIsInvalid()
        {
            createCustomerCommand.Document = "12563254412";

            Assert.AreEqual(null, customerHandler.Handle(createCustomerCommand));
            Assert.AreEqual(false, customerHandler.IsValid);
        }
    }
}