using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bicycleRent.Models;
using MySql.Data.MySqlClient;

namespace bicycleRent.Repositories
{
    public class PriceRepository
    {
        MySqlConnection _connection;
        public PriceRepository(MySqlConnection connection) 
        {
            _connection = connection;
        }

        public List<Price> GetAll() 
        {
            List<Price> prices = new List<Price>();
            string query = "SELECT * FROM Price";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Price price = new Price() 
                        {
                            Id = reader.GetInt32("Price_Id"),
                            Amount = reader.GetInt32("Amount"),
                        };
                        prices.Add(price);
                    }
                }
            }
            return prices;
        }

        public bool Add(Price price) 
        {
            string query = "INSERT INTO Price (Amount) VALUES (@Amount)";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection)) 
            {
                cmd.Parameters.AddWithValue("@Amount", price.Amount);

                int rowsInserted = cmd.ExecuteNonQuery();

                if(rowsInserted > 0)
                    return true;
                return false;
            }
        }

        public bool Update(Price price) 
        {
            string query = "UPDATE Price SET Amount = @Amount WHERE Price_Id = @Price_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Price_Id", price.Id);
                cmd.Parameters.AddWithValue("@Amount", price.Amount);

                int rowsUpdated = cmd.ExecuteNonQuery();

                if (rowsUpdated > 0)
                    return true;
                return false;
            }
        }
    }
}
