using System;
using System.Collections.Generic;
using Domain.StoreContext.Entities;
using Domain.StoreContext.Queries;
using Domain.StoreContext.Repositories;

namespace Testes.Mocks
{
    public class MockCustomerRepository : ICostumerRepository
    {
        public bool CheckCustomerExistsByDocument(string document) => false;

        public bool CheckCustomerExistsByEmail(string email) => false;

        public IEnumerable<ListCustomerQueryResult> GetAllCustomer()
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryResult GetCustomerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomerOrderQueryResult> GetCustomerOrdersById(Guid id)
        {
            throw new NotImplementedException();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCountResult(string document)
        {
            throw new NotImplementedException();
        }

        public void SaveCustomer(Customer customer) { }
    }
}
