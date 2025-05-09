using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bicycleRent.Models;
using MySql.Data.MySqlClient;

namespace bicycleRent.Repositories
{
    public class InventoryRepository
    {
        private readonly MySqlConnection _Connection;

        public InventoryRepository(MySqlConnection connection)
        {
            _Connection = connection;
        }

        public List<Inventory> GetAll()
        {
            string query = "SELECT * FROM Inventory";
            List<Inventory> list = new List<Inventory>();

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inventory inventory = new Inventory() 
                        {
                            InventoryId = reader.GetInt32("Inventory_Id"),
                            InventoryName = reader.GetString("Inventory_Name"),
                            InventoryTypeId = reader.GetInt32("Inventory_Type_Id"),
                            InventoryNumber = reader.GetInt32("Inventory_Number"),
                            InventoryRentsCount = reader.GetInt32("Inventory_Rents_Count"),
                            InventoryTotal = reader.GetDecimal("Inventory_Total")
                        };
                        list.Add(inventory);
                    }
                }
            }
            return list;
        }

        public List<Inventory> GetInventoryForRent(int RentId) 
        {
            List<Inventory> list = new List<Inventory>();

            string query = "SELECT " +
                "i.Inventory_Id, " +
                "i.Inventory_Name," +
                "it.Inventory_Type_Name," +
                "i.Inventory_Number " +
                "FROM Inventory i " +
                "JOIN Rent_has_Inventory rhi ON i.Inventory_Id = rhi.Inventory_Inventory_Id " +
                "JOIN Inventory_Type it ON i.Inventory_Type_Id = it.Inventory_Type_Id " +
                "WHERE rhi.Rent_Rent_Id = @RentId;";

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection)) 
            {
                cmd.Parameters.AddWithValue("@RentId", RentId);

                using (MySqlDataReader reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        Inventory inventory = new Inventory()
                        {
                            InventoryId = reader.GetInt32("Inventory_Id"),
                            InventoryName = reader.GetString("Inventory_Name"),
                            InventoryTypeName = reader.GetString("Inventory_Type_Name"),
                            InventoryNumber = reader.GetInt32("Inventory_Number")
                        };
                        list.Add(inventory);
                    }
                }
            }
            return list;
        }

        public List<int> GetInventoryIdsForRent(int RentId)
        {
            string query = "SELECT Inventory_Inventory_Id FROM Rent_Has_Inventory WHERE Rent_Rent_Id = @RentId";
            List<int> list = new List<int>();

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection))
            {
                cmd.Parameters.AddWithValue("@RentId", RentId);

                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetInt32("Inventory_Inventory_Id"));
                    }
                }
                return list;
            }
        }

        public List<Inventory> GetAllInventory()
        {
            List<Inventory> list = new List<Inventory>();

            string query = "SELECT " +
                "i.Inventory_Id, " +
                "i.Inventory_Name, " +
                "it.Inventory_Type_Name, " +
                "i.Inventory_Number, " +
                "i.Status, " +
                "f.Filial_Name " +
                "FROM Inventory i " +
                "JOIN Inventory_Type it ON i.Inventory_Type_Id = it.Inventory_Type_Id " +
                "JOIN Filial f ON i.Filial_Id = f.Filial_Id";


            using (MySqlCommand cmd = new MySqlCommand(query, _Connection))
            {

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inventory inventory = new Inventory()
                        {
                            InventoryId = reader.GetInt32("Inventory_Id"),
                            InventoryName = reader.GetString("Inventory_Name"),
                            InventoryTypeName = reader.GetString("Inventory_Type_Name"),
                            InventoryNumber = reader.GetInt32("Inventory_Number"),
                            Status = reader.GetString("Status"),
                            FilialName = reader.GetString("Filial_Name")
                        };
                        list.Add(inventory);
                    }
                }
            }
            return list;
        }

        public Inventory? GetInventory(int id)
        {
            string query = "SELECT " +
                "i.Inventory_Id, " +
                "i.Inventory_Name, " +
                "it.Inventory_Type_Name, " +
                "i.Inventory_Number, " +
                "i.Status, " +
                "f.Filial_Name " +
                "FROM Inventory i " +
                "JOIN Inventory_Type it ON i.Inventory_Type_Id = it.Inventory_Type_Id " +
                "JOIN Filial f ON i.Filial_Id = f.Filial_Id " +
                "WHERE i.Inventory_Id = @InventoryId;";


            using (MySqlCommand cmd = new MySqlCommand(query, _Connection))
            {
                cmd.Parameters.AddWithValue("@InventoryId", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        Inventory inventory = new Inventory()
                        {
                            InventoryId = reader.GetInt32("Inventory_Id"),
                            InventoryName = reader.GetString("Inventory_Name"),
                            InventoryTypeName = reader.GetString("Inventory_Type_Name"),
                            InventoryNumber = reader.GetInt32("Inventory_Number"),
                            Status = reader.GetString("Status"),
                            FilialName = reader.GetString("Filial_Name")
                        };
                        return inventory;
                    }
                }
            }
            return null;
        }

        public bool ChangeInventoryStatus(int inventoryId, string status)
        {
            string query = "UPDATE Inventory SET Status = @Status WHERE Inventory_Id = @Inventory_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection))
            {
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Inventory_Id", inventoryId);

                int rowsUpdated = cmd.ExecuteNonQuery();

                if (rowsUpdated > 0)
                    return true;
                return false;
            }
        }
    }
}
