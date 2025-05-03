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

        public InventoryRepository(MySqlConnection _connection)
        {
            _Connection = _connection;
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
                            InventoryType_Id = reader.GetInt32("Inventory_Type_Id"),
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
    }
}
