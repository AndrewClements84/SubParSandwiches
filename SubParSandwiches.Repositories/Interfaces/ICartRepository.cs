using SubParSandwiches.Entities;
using SubParSandwiches.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubParSandwiches.Repositories.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetCart(Guid CartId);
        CartModel GetCartDetails(Guid CartId);
        int DeleteItem(Guid cartId, int itemId);
        int UpdateQuantity(Guid cartId, int itemId, int Quantity);
        int UpdateCart(Guid cartId, int userId);
    }
}
