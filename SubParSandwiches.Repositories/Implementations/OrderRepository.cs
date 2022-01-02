using Microsoft.EntityFrameworkCore;
using SubParSandwiches.Entities;
using SubParSandwiches.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SubParSandwiches.Repositories.Implementations
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private AppDbContext appContext => _dbContext as AppDbContext;

        public OrderRepository(DbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Order> GetUserOrders(int UserId)
        {
            return appContext.Orders
                .Include(o => o.OrderItems)
                .Where(x => x.UserId == UserId).ToList();
        }
    }
}
