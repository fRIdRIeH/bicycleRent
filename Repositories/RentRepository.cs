using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bicycleRent.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace bicycleRent.Repositories
{
    public class RentRepository
    {
        private readonly MySqlConnection _connection;

        public RentRepository(MySqlConnection connection)
        {
            _connection = connection;
        }

        public List<Rent> GetAll()
        {
            List<Rent> rents = new List<Rent>();
            string query = "SELECT " +
                "Rent.Rent_Id, " +
                "Filial.Filial_Name, " +
                "Client.Client_Surname, " +
                "Inventory.Inventory_Name, " +
                "Rent.Time_Start, " +
                "Rent.Time_End, " +
                "Rent.Total, " +
                "Rent.Status, " +
                "User.User_Surname, " +
                "Deposit.Deposit_Name " +
                "FROM Rent " +
                "INNER JOIN Filial ON Rent.Filial_Id = Filial.Filial_Id " +
                "INNER JOIN Client ON Rent.Client_Id = Client.Client_Id " +
                "INNER JOIN Inventory ON Rent.Inventory_Id = Inventory.Inventory_Id " +
                "INNER JOIN User ON Rent.User_Id = User.User_Id " +
                "INNER JOIN Deposit ON Rent.Deposit_Id = Deposit.Deposit_Id " +
                "WHERE (DATE(Rent.Time_Start) = CURDATE() OR DATE(Rent.Time_End) = CURDATE())" +
                "ORDER BY Rent.Rent_Id DESC;";
                

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rent rent = new Rent() 
                        {
                            RentId = reader.GetInt32("Rent_Id"),
                            FilialName = reader.GetString("Filial_Name"),
                            ClientSurname = reader.GetString("Client_Surname"),
                            InventoryName = reader.GetString("Inventory_Name"),
                            TimeStart = reader.GetDateTime("Time_Start"),
                            TimeEnd = reader.GetDateTime("Time_End"),
                            Total = reader.GetInt32("Total"),
                            Status = reader.GetString("Status"),
                            UserSurname = reader.GetString("User_Surname"),
                            DepositName = reader.GetString("Deposit_Name"),
                        };
                        rents.Add(rent);
                    }
                }
            }
            return rents;
        }
    }
}
