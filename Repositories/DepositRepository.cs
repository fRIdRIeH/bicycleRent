using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bicycleRent.Models;
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

        public bool Add(Deposit deposit)
        {
            string query = "INSERT INTO Deposit (Deposit_Name) VALUES (@Deposit_Name)";

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection)) 
            {
                cmd.Parameters.AddWithValue("@Deposit_Name", deposit.Name);

                int rowsInserted = cmd.ExecuteNonQuery();

                if(rowsInserted > 0 )
                    return true;
                return false;
            }
        }

        public bool Update(Deposit deposit)
        {
            string query = "UPDATE Deposit SET Deposit_Name = @Deposit_Name WHERE Deposit_Id = @Deposit_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection))
            {
                cmd.Parameters.AddWithValue("@Deposit_Id", deposit.Id);
                cmd.Parameters.AddWithValue("@Deposit_Name", deposit.Name);

                int rowsUpdated = cmd.ExecuteNonQuery();

                if(rowsUpdated > 0 ) 
                    return true;
                return false;
            }
        }

        public bool Delete(int depositId)
        {
            string query = "DELETE FROM Deposit WHERE Deposit_Id = @Deposit_Id ";

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection))
            {
                cmd.Parameters.AddWithValue("@Deposit_Id", depositId);

                int rowsDeleted = cmd.ExecuteNonQuery();

                if( rowsDeleted > 0 )
                    return true;
                return false;
            }
        }

        public Deposit? Get(int depositId)
        {
            string query = "SELECT * FROM Deposit WHERE Deposit_Id = @Deposit_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection))
            {
                cmd.Parameters.AddWithValue("@Deposit_Id", depositId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Deposit deposit = new Deposit()
                        {
                            Id = reader.GetInt32("Deposit_Id"),
                            Name = reader.GetString("Deposit_Name")
                        };
                        return deposit;
                    }
                }
            }
            return null;
        }

        public List<Deposit> GetAll() 
        {
            List<Deposit> deposits = new List<Models.Deposit>();
            string query = "SELECT * FROM Deposit";

            using (MySqlCommand cmd = new MySqlCommand(query, _Connection)) 
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Deposit deposit = new Deposit() 
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
