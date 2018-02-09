using Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Domain.StoreContext.Entities;
using Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name = new Name("myFirtName", "myLastName");
            var document = new Document("99999999999");
            var email = new Email("myEmail@email.com");
            var customer = new Customer(name, document, email, "99999-9999");

            return new List<Customer> { customer };
        }

        [HttpGet]
        [Route("customers/{id:Guid}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("myFirtName", "myLastName");
            var document = new Document("99999999999");
            var email = new Email("myEmail@email.com");
            var customer = new Customer(name, document, email, "99999-9999");

            return customer;
        }

        [HttpGet]
        [Route("customers/{id:Guid}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            return null;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]CreateCustomerCommand customerCommand)
        {
            var name = new Name(customerCommand.FirstName, customerCommand.LastName);
            var document = new Document(customerCommand.Document);
            var email = new Email(customerCommand.Email);
            var customer = new Customer(name, document, email, customerCommand.Phone);

            return customer;
        }

        [HttpPut]
        [Route("customers/{id:Guid}")]
        public Customer Put([FromBody]Customer customer)
        {
            return null;
        }

        [HttpDelete]
        [Route("customers/{id:Guid}")]
        public object Delete(Guid id)
        {
            return new { message = "Cliente removido com sucesso" };
        }
    }
}