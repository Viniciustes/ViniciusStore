using Domain.StoreContext.Entities;
using Domain.StoreContext.Repositories;

namespace Infra.StoreContext.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public bool CheckProductExistsByTitle(string title)
        {
            DbContext.Dispose();
            throw new System.NotImplementedException();
        }

        public void SaveProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
