using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bicycleRent.Models;
using MySql.Data.MySqlClient;

namespace bicycleRent.Repositories
{
    public class InventoryPriceRepository
    {
        MySqlConnection _connection;
        public InventoryPriceRepository(MySqlConnection Connection) 
        {
            _connection = Connection;
        }

        public List<InventoryPrice> GetAll(int inventoryId)
        {
            string query = "SELECT " +
                "ip.Inventory_Price_Id, " +
                "ip.Inventory_Id, " +
                "t.Time_Label, " +
                "p.Amount " +
                "FROM Inventory_Price ip " +
                "JOIN Time t ON ip.Time_Id = t.Time_Id " +
                "JOIN Price p ON ip.Price_Id = p.Price_Id " +
                "WHERE ip.Inventory_Id = @InventoryId;";

            List<InventoryPrice> list = new List<InventoryPrice>();

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@InventoryId", inventoryId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Models.InventoryPrice inventoryPrice = new Models.InventoryPrice() 
                        {
                            InventoryPriceId = reader.GetInt32("Inventory_Price_Id"),
                            Price = reader.GetDecimal("Amount"),
                            TimeName = reader.GetString("Time_Label")
                        };
                        list.Add(inventoryPrice);
                    }
                }
            }
            return list;
        }

        public InventoryPrice? Get(int inventoryPriceId) 
        {
            string query = "SELECT " +
            "ip.Inventory_Price_Id, " +
            "ip.Inventory_Id, " +
            "t.Time_Label, " +
            "p.Amount " +
            "FROM Inventory_Price ip " +
            "JOIN Time t ON ip.Time_Id = t.Time_Id " +
            "JOIN Price p ON ip.Price_Id = p.Price_Id " +
            "WHERE ip.Inventory_Price_Id = @InventoryPriceId;";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@InventoryPriceId", inventoryPriceId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Models.InventoryPrice inventoryPrice = new Models.InventoryPrice()
                        {
                            InventoryPriceId = reader.GetInt32("Inventory_Price_Id"),
                            Price = reader.GetDecimal("Amount"),
                            TimeName = reader.GetString("Time_Label")
                        };
                        return inventoryPrice;
                    }
                }
            }
            return null;
        }

    }
}
