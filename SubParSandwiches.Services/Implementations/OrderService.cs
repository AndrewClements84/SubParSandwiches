using SubParSandwiches.Entities;
using SubParSandwiches.Repositories.Interfaces;
using SubParSandwiches.Repositories.Models;
using SubParSandwiches.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SubParSandwiches.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderModel GetOrderDetails(string OrderId)
        {
            var model = _orderRepository.GetOrderDetails(OrderId);
            if (model != null && model.Items.Count > 0)
            {
                decimal subTotal = 0;
                foreach (var item in model.Items)
                {
                    item.Total = item.UnitPrice * item.Quantity;
                    subTotal += item.Total;
                }
                model.Total = subTotal;
                //5% tax
                model.Tax = Math.Round((model.Total * 5) / 100, 2);
                model.GrandTotal = model.Tax + model.Total;
            }
            return model;
        }

        public PagingListModel<OrderModel> GetOrderList(int page = 1, int pageSize = 10)
        {
            return _orderRepository.GetOrderList(page, pageSize);
        }

        public IEnumerable<Order> GetUserOrders(int UserId)
        {
            return _orderRepository.GetUserOrders(UserId);
        }

        public int PlaceOrder(int userId, string orderId, string paymentId, CartModel cart, Address address)
        {
            Order order = new Order
            {
                PaymentId = paymentId,
                UserId = userId,

                CreatedDate = DateTime.Now,
                Id = orderId,
                Street = address.Street,
                County = address.County,
                City = address.City,
                PostCode = address.Postcode,
                PhoneNumber = address.PhoneNumber
            };

            foreach (var item in cart.Items)
            {
                OrderItem orderItem = new OrderItem(item.ItemId, item.UnitPrice, item.Quantity, item.Total);
                order.OrderItems.Add(orderItem);
            }

            _orderRepository.Add(order);
            return _orderRepository.SaveChanges();
        }
    }
}
