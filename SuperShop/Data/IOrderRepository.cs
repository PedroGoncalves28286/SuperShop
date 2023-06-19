using System.Threading.Tasks;

namespace SuperShop.Data
using global::SuperShop.Data.Entities;
using global::SuperShop.Web.Data.Entities;
using global::SuperShop.Web.Models;
using SuperShop.Web.Data.Entities;
using SuperShop.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Data
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrderAsync(string userName);

        Task<IQueryable<OrderDetailTemp>> GetDetailsTempsAsync(string userName);

        



    }
}