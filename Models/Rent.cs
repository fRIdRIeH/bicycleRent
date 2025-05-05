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
        public string ClientTelehone { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public string UserSurname { get; set; }
        public int DepositId { get; set; }
        public string DepositName { get; set; }
        public DateTime CreatedAt { get; set; }

        public Rent() { }

        public Rent(int rentId, int filialId, int clientId, DateTime timeStart, DateTime timeEnd, int total, string status, int userId, int depositId)
        { 
            RentId = rentId;
            FilialId = filialId;
            ClientId = clientId;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Total = total;
            Status = status;
            UserId = userId;
            DepositId = depositId;
        }

        //Для красивого вывода
        public Rent(int rentId, string filialName, string clientSurname, string clientTelephone, DateTime timeStart, DateTime timeEnd, int total, string status, string userSurname, string depositName, DateTime createdAt)
        {
            RentId = rentId;
            FilialName = filialName;
            ClientSurname = clientSurname;
            ClientTelehone = clientTelephone;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            Total = total;
            Status = status;
            UserSurname = userSurname;
            DepositName = depositName;
            CreatedAt = createdAt;
        }
    }
}
