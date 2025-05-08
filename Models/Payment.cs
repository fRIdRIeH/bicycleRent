using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycleRent.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Type { get; set; }
        public int RentId { get; set; }
        public DateTime Created_At { get; set; }

        public Payment() { }
        
        //Для добавления
        public Payment(decimal paymentAmount, string type, int rentId, DateTime createdAt)
        {
            PaymentAmount = paymentAmount;
            Type = type;
            RentId = rentId;
            Created_At = createdAt;
        }

        public Payment(int id, decimal paymentAmount, string type, int rentId, DateTime createdAt) 
        {
            Id = id;
            PaymentAmount = paymentAmount;
            Type = type;
            RentId = rentId;
            Created_At = createdAt;
        }
    }
}
