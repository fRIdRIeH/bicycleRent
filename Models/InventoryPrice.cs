using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycleRent.Models
{
    public class InventoryPrice
    {
        public int InventoryPriceId { get; set; }
        public int PriceId { get; set; }
        public decimal Price { get; set; }
        public int TimeId { get; set; }
        public string TimeName { get; set; }
        public int InventoryId { get; set; }

        public InventoryPrice() { }

        // Для добавления
        public InventoryPrice(int priceId, int timeId, int inventoryId)
        {
            PriceId = priceId;
            TimeId = timeId;
            InventoryId = inventoryId;
        }

        public InventoryPrice(int id, int priceId, decimal price, int timeId, string timeName)
        {
            InventoryPriceId = id;
            PriceId = priceId;
            Price = price;
            TimeId = timeId;
            TimeName = timeName;
        }
    }
}
