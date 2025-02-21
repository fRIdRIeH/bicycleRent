using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace bicycleRent.Repositories
{
    public class UserRepository
    {
        private readonly MySqlConnection _Connection;

        public UserRepository(MySqlConnection connection)
        {
            _Connection = connection;
        }
    }
}
