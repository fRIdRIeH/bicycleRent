using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycleRent.Models
{
    public class Filial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Total { get; set; }

        public Filial() { }

        public Filial(int id, string name, string address, decimal total)
        {
            Id = id;
            Name = name;
            Address = address;
            Total = total;
        }

        public Filial(int id)
        {
            Id = id;
        }
    }
}
