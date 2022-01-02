using SubParSandwiches.Entities;
using System.Collections.Generic;

namespace SubParSandwiches.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetUserOrders(int UserId);
    }
}
