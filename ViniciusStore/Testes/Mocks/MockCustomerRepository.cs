using Domain.StoreContext.Entities;
using Domain.StoreContext.Repositories;

namespace Testes.Mocks
{
    public class MockCustomerRepository : ICostumerRepository
    {
        public bool CheckCustomerExistsByDocument(string document) => false;

        public bool CheckCustomerExistsByEmail(string email) => false;

        public void SaveCustomer(Customer customer) { }
    }
}
