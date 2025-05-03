using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycleRent.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public int InventoryType_Id { get; set; }
        public int InventoryNumber { get; set; }
        public int InventoryRentsCount { get; set; }
        public decimal InventoryTotal { get; set; }

        public Inventory() { }

        public Inventory(int inventoryId, string inventoryName, int inventoryType_Id, int inventoryNumber, int inventoryRentsCount, decimal inventoryTotal)
        {
            InventoryId = inventoryId;
            InventoryName = inventoryName;
            InventoryType_Id = inventoryType_Id;
            InventoryNumber = inventoryNumber;
            InventoryRentsCount = inventoryRentsCount;
            InventoryTotal = inventoryTotal;
        }
    }
}
