using Domain.StoreContext.Entities;

namespace Domain.StoreContext.Repositories
{
    public interface ICostumerRepository
    {
        bool CheckCustomerExistsByDocument(string document);
        bool CheckCustomerExistsByEmail(string email);
        void SaveCustomer(Customer customer);
    }
}