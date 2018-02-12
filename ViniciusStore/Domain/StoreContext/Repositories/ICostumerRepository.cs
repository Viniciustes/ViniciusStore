using Domain.StoreContext.Entities;
using Domain.StoreContext.Queries;
using System;
using System.Collections.Generic;

namespace Domain.StoreContext.Repositories
{
    public interface ICostumerRepository
    {
        IEnumerable<ListCustomerQueryResult> GetAllCustomer();
        bool CheckCustomerExistsByDocument(string document);
        bool CheckCustomerExistsByEmail(string email);
        void SaveCustomer(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCountResult(string document);
        GetCustomerQueryResult GetCustomerById(Guid id);
        IEnumerable<ListCustomerOrderQueryResult> GetCustomerOrdersById(Guid id);
    }
}