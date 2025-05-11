using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bicycleRent.Models;
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

        public bool Add(Filial filial)
        {
            string query = "INSERT INTO Filial " +
                "(Filial_Name, Filial_Address) " +
                "VALUES " +
                "(@Filial_Name, @Filial_Address)";

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection)) 
            {
                cmd.Parameters.AddWithValue("@Filial_Name", filial.Name);
                cmd.Parameters.AddWithValue("@Filial_Address", filial.Address);

                int rowsInserted = cmd.ExecuteNonQuery();

                if(rowsInserted > 0)
                    return true;
                return false;
            }
        }

        public bool Update(Filial filial)
        {
            string query = "UPDATE Filial SET " +
                "Filial_Name = @Filial_Name, " +
                "Filial_Address = @Filial_Address " +
                "WHERE Filial_Id = @Filial_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection))
            {
                cmd.Parameters.AddWithValue("@Filial_Id", filial.Id);
                cmd.Parameters.AddWithValue("@Filial_Name", filial.Name);
                cmd.Parameters.AddWithValue("@Filial_Address", filial.Address);

                int rowsUpdated = cmd.ExecuteNonQuery();

                if( rowsUpdated > 0 ) 
                    return true;
                return false;
            }
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Filial WHERE Filial_Id = @Filial_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection))
            {
                cmd.Parameters.AddWithValue("@Filial_Id", id);

                int rowsDeleted = cmd.ExecuteNonQuery();

                if(rowsDeleted > 0 )
                    return true;
                return false;
            }
        }

        public Filial? Get(int id)
        {
            string query = "SELECT * FROM Filial WHERE Filial_Id = @Filial_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection))
            {
                cmd.Parameters.AddWithValue("@Filial_Id", id);

                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Filial filial = new Filial() 
                        {
                            Id = reader.GetInt32("Filial_Id"),
                            Name = reader.GetString("Filial_Name"),
                            Address = reader.GetString("Filial_Address"),
                            Total = reader.GetInt32("Filial_Total")
                        };
                        return filial;
                    }
                }
            }
            return null;
        }

        public List<Filial> GetAll()
        {
            string query = "SELECT * FROM Filial";
            List<Filial> filials = new List<Filial>();

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection))
            {
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Filial filial = new Filial()
                        {
                            Id = reader.GetInt32("Filial_Id"),
                            Name = reader.GetString("Filial_Name"),
                            Address = reader.GetString("Filial_Address"),
                            Total = reader.GetInt32("Filial_Total")
                        };
                        filials.Add(filial);
                    }
                }
            }
            return filials;
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
