using System;
using System.Text.Json.Serialization;

namespace SubParSandwiches.Entities
{
    public class CartItem
    {
        public CartItem()
        {

        }

        public CartItem(int itemId, int quantity, decimal unitPrice)
        {
            ItemId = itemId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public int Id { get; set; }

        public Guid CartId { get; set; }

        public int ItemId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        [JsonIgnore]
        public Cart Cart { get; set; }
    }
}
