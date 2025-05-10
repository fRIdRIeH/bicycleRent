using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycleRent.Models
{
    public class Price
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public Price() { }

        public Price(int id, decimal amount) 
        {
            Id = id;
            Amount = amount;
        }
    }
}
