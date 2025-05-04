using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace bicycleRent.Repositories
{
    public class DepositRepository
    {
        private readonly MySqlConnection _Connection;

        public DepositRepository(MySqlConnection _connection)
        {
            _Connection = _connection;
        }

        public List<Models.Deposit> GetAll() 
        {
            List<Models.Deposit> deposits = new List<Models.Deposit>();
            string query = "SELECT * FROM Deposit";

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection)) 
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Models.Deposit deposit = new Models.Deposit() 
                        {
                            Id = reader.GetInt32("Deposit_Id"),
                            Name = reader.GetString("Deposit_Name")
                        };
                        deposits.Add(deposit);
                    }
                }
            }
            return deposits;
        }
    }
}
