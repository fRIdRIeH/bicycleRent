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
            string query = "SELECT * FROM Rent";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rent rent = new Rent() 
                        {
                            RentId = reader.GetInt32("Rent_Id"),
                            FilialId = reader.GetInt32("Filial_Id"),
                            ClientId = reader.GetInt32("Client_Id"),
                            InventoryId = reader.GetInt32("Inventory_Id"),
                            TimeStart = reader.GetDateTime("Time_Start"),
                            TimeEnd = reader.GetDateTime("Time_End"),
                            Total = reader.GetInt32("Total"),
                            UserId = reader.GetInt32("User_Id"),
                            DepositId = reader.GetInt32("Deposit_Id"),
                        };
                        rents.Add(rent);
                    }
                }
            }
            return rents;
        }
    }
}
