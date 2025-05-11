using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycleRent.Models
{
    public class InventoryType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public InventoryType() { }

        public InventoryType(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}
