using Domain.StoreContext.Entities;
using Domain.StoreContext.Queries;

namespace Domain.StoreContext.Repositories
{
    public interface ICostumerRepository
    {
        bool CheckCustomerExistsByDocument(string document);
        bool CheckCustomerExistsByEmail(string email);
        void SaveCustomer(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCountResult(string document);
    }
}