using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace bicycleRent.Repositories
{
    public class FilialRepository
    {
        private readonly MySqlConnection _Connection;

        public FilialRepository(MySqlConnection _connection)
        {
            _Connection = _connection;
        }

        public int GetFilialFromInventory(int inventoryId)
        {
            string query = "SELECT Filial_Id FROM Inventory WHERE Inventory.Inventory_Id = @inventoryId";

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection)) 
            {
                cmd.Parameters.AddWithValue("@inventoryId", inventoryId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
            }
            return 0;
        }
    }
}
