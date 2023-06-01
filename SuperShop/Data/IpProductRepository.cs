using SuperShop.Data.Entities;
using System.Linq;

namespace SuperShop.Data
{
    public interface IpProductRepository :IGenericRepository<Product>
    {
        public IQueryable GetAllWithUsers();
    }
}
