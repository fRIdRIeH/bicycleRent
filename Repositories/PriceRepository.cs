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
    }
}
