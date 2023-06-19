using System.Threading.Tasks;

namespace SuperShop.Data
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQuerayable<Order>> GetOrderAsync(string userName); 
    }

