﻿using System;
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
        public int InventoryTypeId { get; set; }
        public string InventoryTypeName { get; set; }
        public int InventoryNumber { get; set; }
        public int InventoryRentsCount { get; set; }
        public decimal InventoryTotal { get; set; }
        public string Status { get; set; }
        public int FilialId { get; set; }
        public string FilialName { get; set; }

        public Inventory() { }

        public Inventory(int inventoryId, string inventoryName, int inventoryType_Id, int inventoryNumber, int inventoryRentsCount, decimal inventoryTotal, string status, int filialId, string filialName)
        {
            InventoryId = inventoryId;
            InventoryName = inventoryName;
            InventoryTypeId = inventoryType_Id;
            InventoryNumber = inventoryNumber;
            InventoryRentsCount = inventoryRentsCount;
            InventoryTotal = inventoryTotal;
            Status = status;
            FilialId = filialId;
            FilialName = filialName;
        }

    }
}
