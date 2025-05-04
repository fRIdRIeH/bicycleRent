using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycleRent.Models
{
    public class Deposit
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Deposit() { }

        public Deposit(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
}
