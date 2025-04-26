using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bicycleRent.Models
{
    public class Rent
    {
        public int RentId { get; set; }
        public int FilialId { get; set; }
        public int ClientId { get; set; }
        public int InventoryId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Total { get; set; }
        public int UserId { get; set; }
        public int DepositId { get; set; }

        public Rent() { }

        public Rent(int rentId, int filialId, int clientId, int inventoryId, DateTime timeStart, DateTime timeEnd, int total, int userId, int depositId)
        { 
            RentId = rentId;
            FilialId = filialId;
            ClientId = clientId;
            InventoryId = inventoryId;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Total = total;
            UserId = userId;
            DepositId = depositId;
        }
    }
}
