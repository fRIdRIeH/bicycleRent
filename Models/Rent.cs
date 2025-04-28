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
        public string FilialName { get; set; }
        public int ClientId { get; set; }
        public string ClientSurname { get; set; }
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Total { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public string UserSurname { get; set; }
        public int DepositId { get; set; }
        public string DepositName { get; set; }

        public Rent() { }

        public Rent(int rentId, int filialId, int clientId, int inventoryId, DateTime timeStart, DateTime timeEnd, int total, string status, int userId, int depositId)
        { 
            RentId = rentId;
            FilialId = filialId;
            ClientId = clientId;
            InventoryId = inventoryId;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Total = total;
            Status = status;
            UserId = userId;
            DepositId = depositId;
        }

        //Для красивого вывода
        public Rent(int rentId, string filialName, string clientSurname, string inventoryName, DateTime timeStart, DateTime timeEnd, int total, string status, string userSurname, string depositName)
        {
            RentId = rentId;
            FilialName = filialName;
            ClientSurname = clientSurname;
            InventoryName = inventoryName;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Total = total;
            Status = status;
            UserSurname = userSurname;
            DepositName = depositName;
        }
    }
}
