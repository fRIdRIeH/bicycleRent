using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bicycleRent.Models;
using MySql.Data.MySqlClient;

namespace bicycleRent.Repositories
{
    public class TimeRepository
    {
        MySqlConnection _connection;
        public TimeRepository(MySqlConnection connection)
        {
            _connection = connection;
        }

        public List<Time> GetAll()
        {
            List<Time> times = new List<Time>();
            string query = "SELECT * FROM Time";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                using(MySqlDataReader reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        Time time = new Time() 
                        {
                            Id = reader.GetInt32("Time_Id"),
                            TimeLabel = reader.GetString("Time_Label")
                        };
                        times.Add(time);
                    }
                }
            }
            return times;
        }
    }
}
