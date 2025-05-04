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

        public InventoryPrice() { }

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
