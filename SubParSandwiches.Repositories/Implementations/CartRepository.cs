using Microsoft.EntityFrameworkCore;
using SubParSandwiches.Entities;
using SubParSandwiches.Repositories.Interfaces;
using SubParSandwiches.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubParSandwiches.Repositories.Implementations
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private AppDbContext appContext => _dbContext as AppDbContext;
        public CartRepository(DbContext dbContext) : base(dbContext)
        {

        }
        public Cart GetCart(Guid CartId)
        {
            return appContext.Carts.Include("Items").Where(c => c.Id == CartId && c.IsActive == true).FirstOrDefault();
        }

        public int DeleteItem(Guid cartId, int itemId)
        {
            var item = appContext.CartItems.Where(ci => ci.CartId == cartId && ci.Id == itemId).FirstOrDefault();
            if (item != null)
            {
                appContext.CartItems.Remove(item);
                return appContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public int UpdateQuantity(Guid cartId, int itemId, int Quantity)
        {
            bool flag = false;
            var cart = GetCart(cartId);
            if (cart != null)
            {
                for (int i = 0; i < cart.Items.Count; i++)
                {
                    if (cart.Items[i].Id == itemId)
                    {
                        flag = true;
                        //for minus quantity
                        if (Quantity < 0 && cart.Items[i].Quantity > 1)
                            cart.Items[i].Quantity += (Quantity);
                        else if (Quantity > 0)
                            cart.Items[i].Quantity += (Quantity);
                        break;
                    }
                }
                if (flag)
                    return appContext.SaveChanges();
            }
            return 0;
        }

        public int UpdateCart(Guid cartId, int userId)
        {
            Cart cart = GetCart(cartId);
            cart.UserId = userId;
            return appContext.SaveChanges();
        }

        public CartModel GetCartDetails(Guid CartId)
        {
            var model = (from cart in appContext.Carts
                         where cart.Id == CartId && cart.IsActive == true
                         select new CartModel
                         {
                             Id = cart.Id,
                             UserId = cart.UserId,
                             CreatedDate = cart.CreatedDate,
                             Items = (from cartItem in appContext.CartItems
                                      join item in appContext.Items
                                      on cartItem.ItemId equals item.Id
                                      where cartItem.CartId == CartId
                                      select new ItemModel
                                      {
                                          Id = cartItem.Id,
                                          Name = item.Name,
                                          Description = item.Description,
                                          ImageUrl = item.ImageUrl,
                                          Quantity = cartItem.Quantity,
                                          ItemId = item.Id,
                                          UnitPrice = cartItem.UnitPrice
                                      }).ToList()
                         }).FirstOrDefault();
            return model;
        }
    }
}
