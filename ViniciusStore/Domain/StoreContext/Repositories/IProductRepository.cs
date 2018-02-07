using Domain.StoreContext.Entities;

namespace Domain.StoreContext.Repositories
{
    public interface IProductRepository
    {
        bool CheckProductExistsByTitle(string title);
        void SaveProduct(Product product);
    }
}