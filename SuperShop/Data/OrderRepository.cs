using Microsoft.EntityFrameworkCore;
using SuperShop.Data;
using SuperShop.Data.Entities;
using SuperShop.Helpers;
using SuperShop.Web.Data.Entities;
using SuperShop.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.Data
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public OrderRepository(DataContext context, IUserHelper userHelper) : base(context)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task AddItemToOrderAsync(AddItemViewModel model, string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return;
            }
            var product = await _context.Products.FindAsync(model.ProductId);
            if (product == null)
            {
                return;

            }
            var orderDetailTemp = _context.OrderDetailTemp
                .Where(odt => odt.User == user && odt.Product == product)
                .FirstOrDefault();

            if (orderDetailTemp == null)
            {
                orderDetailTemp = new OrderDetailTemp
                {
                    Product = product,
                    Price = product.Price,
                    Quantity = model.Quantity,
                    User = user

                };
                _context.OrderDetailTemp.Add(orderDetailTemp);

            }
            else
            {
                orderDetailTemp.Quantity += model.Quantity;
                _context.OrderDetailTemp.Update(orderDetailTemp);
            }
            await _context.SaveChangesAsync();
        }

        public Task<bool> ConfirmOrderAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public async Task DeleteDetailTempAsync(int id)
        {
            var orderDetailTemp = await _context.OrderDetailTemp.FindAsync(id);
            if (orderDetailTemp == null)
            {
                return;

            }
            _context.OrderDetailTemp.Remove(orderDetailTemp);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<OrderDetailTemp>> GetDetailsTempsAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;

            }
            return _context.OrderDetailTemp
                .Include(p => p.Product)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.Product.Name);


        }

        public async Task<IQueryable<Order>> GetOrderAsync(string userName)
        {
            var user = await _userHelper.GetUserByEmailAsync(userName);

            if (user == null)
            {
                return null;

            }
            if (await _userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return _context.Orders.
                     Include(o => o.Items)
                    .ThenInclude(p => p.Product)
                    .OrderByDescending(o => o.OrderDate);
            }
            return _context.Orders.
                 Include(o => o.Items)
                .ThenInclude(p => p.Product)
                .OrderByDescending(o => o.OrderDate)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.OrderDate);


        }

        public async Task ModifyOrderDetailTempQuantityAsync(int id, double quantity)
        {
            var orderDetailTemp = await _context.OrderDetailTemp.FindAsync(id);
            if (orderDetailTemp == null)
            {
                return;
            }
            orderDetailTemp.Quantity += quantity;
            if (orderDetailTemp.Quantity > 0)
            {
                _context.OrderDetailTemp.Update(orderDetailTemp);
                await _context.SaveChangesAsync();

            }
        }
    }
}