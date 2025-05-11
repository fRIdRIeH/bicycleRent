using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bicycleRent.Models;
using MySql.Data.MySqlClient;

namespace bicycleRent.Repositories
{
    public class InventoryTypeRepository
    {
        private readonly MySqlConnection _connection;

        public InventoryTypeRepository(MySqlConnection connection)
        {
            _connection = connection;
        }

        public bool Add(InventoryType inventoryType)
        {
            string query = "INSERT INTO Inventory_Type (Inventory_Type_Name) VALUES (@Inventory_Type_Name)";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection)) 
            {
                cmd.Parameters.AddWithValue("@Inventory_Type_Name", inventoryType.Name);

                int rowsInserted = cmd.ExecuteNonQuery();

                if(rowsInserted > 0)
                    return true;
                return false;
            }
        }

        public bool Update(InventoryType inventoryType)
        {
            string query = "UPDATE Inventory_Type SET Inventory_Type_Name = @Inventory_Type_Name WHERE Inventory_Type_Id = @Inventory_Type_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Inventory_Type_Id", inventoryType.Id);
                cmd.Parameters.AddWithValue("@Inventory_Type_Name", inventoryType.Name);

                int rowsUpdated = cmd.ExecuteNonQuery();

                if(rowsUpdated > 0) 
                    return true;
                return false;
            }
        }

        public bool Delete(int inventoryTypeId)
        {
            string query = "DELETE FORM Inventory_Type WHERE Inventory_Type_Id = @Inventory_Type_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Inventory_Type_Id", inventoryTypeId);

                int rowsDeleted = cmd.ExecuteNonQuery();

                if( rowsDeleted > 0)
                    return true;
                return false;
            }
        }

        public InventoryType? Get(int inventoryTypeId)
        {
            string query = "SELECT * FROM Inventory_Type WHERE Inventory_Type_Id = @Inventory_Type_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Inventory_Type_Id", inventoryTypeId);

                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        InventoryType inventoryType = new InventoryType() 
                        {
                            Id = reader.GetInt32("Inventory_Type_Id"),
                            Name = reader.GetString("Inventory_Type_Name")
                        };
                        return inventoryType;
                    }
                }
            }

            return null;
        }

        public List<Models.InventoryType> GetAll()
        {
            List<Models.InventoryType> types = new List<Models.InventoryType>();
            string query = "SELECT * FROM Inventory_Type";

            using(MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                using(MySqlDataReader reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        InventoryType type = new InventoryType() 
                        {
                            Id = reader.GetInt32("Inventory_Type_Id"),
                            Name = reader.GetString("Inventory_Type_Name")
                        };
                        types.Add(type);
                    }
                }
            }
            return types;
        }
    }
}
