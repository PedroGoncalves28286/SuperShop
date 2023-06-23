using System.Linq;
using System.Threading.Tasks;
using SuperShop.Data;
using SuperShop.Data.Entities;
using SuperShop.Models;


namespace SuperShop.Data
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IQueryable<Order>> GetOrderAsync(string userName);

        Task<IQueryable<OrderDetailTemp>> GetDetailsTempsAsync(string userName);

        Task AddItemToOrderAsync(AddItemViewModel model, string userName);

        Task ModifyOrderDetailTempQuantityAsync(int id, double quantity);

        Task DeleteDetailTempAsync(int id);

        Task<bool> ConfirmOrderAsync(string userName);

        Task DeliverOrder(DeliveryViewModel Model);

        Task<Order> GetOrderAsync(int id);



    }
}