using SubParSandwiches.Entities;
using SubParSandwiches.Repositories.Models;
using System.Collections.Generic;

namespace SubParSandwiches.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetUserOrders(int UserId);
        OrderModel GetOrderDetails(string id);
        PagingListModel<OrderModel> GetOrderList(int page, int pageSize);
    }
}
