using Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Domain.StoreContext.Entities;
using Domain.StoreContext.Handlers;
using Domain.StoreContext.Queries;
using Domain.StoreContext.Repositories;
using Domain.StoreContext.ValueObjects;
using Infra.StoreContext.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICostumerRepository costumerRepository;
        private readonly CustomerHandler customerHandler;

        public CustomerController(ICostumerRepository costumerRepository, CustomerHandler customerHandler)
        {
            this.costumerRepository = costumerRepository;
            this.customerHandler = customerHandler;
        }

        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return costumerRepository.GetAllCustomer();
        }

        [HttpGet]
        [Route("customers/{id:Guid}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return costumerRepository.GetCustomerById(id);
        }

        [HttpGet]
        [Route("customers/{id:Guid}/orders")]
        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            return costumerRepository.GetCustomerOrdersById(id);
        }

        [HttpPost]
        [Route("customers")]
        public CreateCustomerCommandResult Post([FromBody]CreateCustomerCommand customerCommand)
        {

            return customerHandler.Handle(customerCommand);
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