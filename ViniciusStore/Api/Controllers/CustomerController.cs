using Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Domain.StoreContext.Entities;
using Domain.StoreContext.Handlers;
using Domain.StoreContext.Queries;
using Domain.StoreContext.Repositories;
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
        [ResponseCache(Duration = 60)]
        public IEnumerable<ListCustomerQueryResult> Get() => costumerRepository.GetAllCustomer();

        [HttpGet]
        [Route("customers/{id:Guid}")]
        public GetCustomerQueryResult GetById(Guid id) => costumerRepository.GetCustomerById(id);

        [HttpGet]
        [Route("customers/{id:Guid}/orders")]
        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id) => costumerRepository.GetCustomerOrdersById(id);

        [HttpPost]
        [Route("customers")]
        public object Post([FromBody]CreateCustomerCommand customerCommand)
        {
            var commandResult = (CreateCustomerCommandResult)customerHandler.Handle(customerCommand);
            if (customerHandler.Invalid)
                return BadRequest(customerHandler.Notifications);

            return commandResult;
        }

        [HttpPut]
        [Route("customers/{id:Guid}")]
        public Customer Put([FromBody]Customer customer) => null;

        [HttpDelete]
        [Route("customers/{id:Guid}")]
        public object Delete(Guid id) => new { message = "Cliente removido com sucesso" };
    }
}