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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                "Client.Client_Telephone, " +
                "Rent.Time_Start, " +
                "Rent.Time_End, " +
                "Rent.Total, " +
                "Rent.Status, " +
                "User.User_Surname, " +
                "Deposit.Deposit_Name, " +
                "Rent.Created_At " +
                "FROM Rent " +
                "INNER JOIN Filial ON Rent.Filial_Id = Filial.Filial_Id " +
                "INNER JOIN Client ON Rent.Client_Id = Client.Client_Id " +
                "INNER JOIN User ON Rent.User_Id = User.User_Id " +
                "INNER JOIN Deposit ON Rent.Deposit_Id = Deposit.Deposit_Id " +
                "WHERE Rent.Created_At > NOW() - INTERVAL 7 DAY " +
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
                            ClientTelehone = reader.GetString("Client_Telephone"),
                            TimeStart = reader.GetDateTime("Time_Start"),
                            TimeEnd = reader.GetDateTime("Time_End"),
                            Total = reader.GetInt32("Total"),
                            Status = reader.GetString("Status"),
                            UserSurname = reader.GetString("User_Surname"),
                            DepositName = reader.GetString("Deposit_Name"),
                            CreatedAt = reader.GetDateTime("Created_At"),
                        };
                        rents.Add(rent);
                    }
                }
            }
            return rents;
        }

        public bool Add(Rent rent)
        {
            string query = "INSERT INTO Rent " +
                "(Filial_Id, Client_Id, Time_Start, Time_End, Total, Status, User_Id, Deposit_Id) " +
                "VALUES " +
                "(@Filial_Id, @Client_Id, @Time_Start, @Time_End, @Total, @Status, @User_Id, @Deposit_Id)";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Filial_Id", rent.FilialId);
                cmd.Parameters.AddWithValue("@Client_Id", rent.ClientId);
                cmd.Parameters.AddWithValue("@Time_Start", rent.TimeStart);
                cmd.Parameters.AddWithValue("@Time_End", rent.TimeEnd);
                cmd.Parameters.AddWithValue("@Total", rent.Total);
                cmd.Parameters.AddWithValue("@Status", rent.Status);
                cmd.Parameters.AddWithValue("@User_Id", rent.UserId);
                cmd.Parameters.AddWithValue("@Deposit_Id", rent.DepositId);

                int rowsInserted = cmd.ExecuteNonQuery();

                if (rowsInserted > 0)
                    return true;
                return false;
            }
        }

        public int GetRentId(Rent rent)
        {
            string query = "SELECT * FROM Rent ORDER BY Rent_Id DESC LIMIT 1";
            int rentId = 0;

            using (MySqlCommand cmd = new MySqlCommand(query, _connection)) 
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        rentId = reader.GetInt32("Rent_Id");
                    }
                    return rentId;
                }
            }
            return rentId;
        }

        public bool AddRentHasInventory(int RentId, int inventoryId, int priceId)
        {
            string query = "INSERT INTO Rent_Has_Inventory (Rent_Rent_Id, Inventory_Inventory_Id, Selected_Price_Id) VALUES (@Rent_Rent_Id, @Inventory_Inventory_Id, @Selected_Price_Id)";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Rent_Rent_Id", RentId);
                cmd.Parameters.AddWithValue("@Inventory_Inventory_Id", inventoryId);
                cmd.Parameters.AddWithValue("@Selected_Price_Id", priceId);

                int rowsInserted = cmd.ExecuteNonQuery();

                if (rowsInserted > 0)
                    return true;
                return false;
            }
        }

        public Rent? Get(int rentId) 
        {
            string query = "SELECT * FROM Rent WHERE Rent_Id = @Rent_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Rent_Id", rentId);

                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Rent rent = new Rent() 
                        {
                            RentId = reader.GetInt32("Rent_Id"),
                            FilialId = reader.GetInt32("Filial_Id"),
                            ClientId = reader.GetInt32("Client_Id"),
                            TimeStart = reader.GetDateTime("Time_Start"),
                            TimeEnd = reader.GetDateTime("Time_End"),
                            Total = reader.GetInt32("Total"),
                            Status = reader.GetString("Status"),
                            UserId = reader.GetInt32("User_Id"),
                            DepositId = reader.GetInt32("Deposit_Id"),
                        };
                        return rent;
                    }
                }
            }
            return null;
        }

        public List<(int InventoryId, int PriceId)> GetInventoriesWithPriceForRent(int rentId)
        {
            var result = new List<(int, int)>();
            string query = @"SELECT Inventory_Inventory_Id, Selected_Price_Id
                     FROM Rent_Has_Inventory
                     WHERE Rent_Rent_Id = @RentId;";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@RentId", rentId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int inventoryId = reader.GetInt32("Inventory_Inventory_Id");
                        int priceId = reader.GetInt32("Selected_Price_Id");

                        result.Add((inventoryId, priceId));
                    }
                }
            }

            return result;
        }

        public Dictionary<int, int> GetSelectedPricesByRentId(int rentId)
        {
            var dict = new Dictionary<int, int>();

            string query = @"SELECT Inventory_Inventory_Id, Selected_Price_Id 
                     FROM Rent_has_Inventory 
                     WHERE Rent_Rent_Id = @RentId";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@RentId", rentId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int inventoryId = reader.GetInt32("Inventory_Inventory_Id");
                        int priceId = reader.GetInt32("Selected_Price_Id");
                        dict[inventoryId] = priceId;
                    }
                }
            }

            return dict;
        }

    }
}
