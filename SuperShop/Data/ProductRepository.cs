using SuperShop.Data.Entities;

namespace SuperShop.Data
{
    public class ProductRepository : GenericRepository<Product>,IpProductRepository
    {
        public ProductRepository(DataContext context) :base(context)
        {

        }
       

    }
}
