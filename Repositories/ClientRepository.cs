using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace bicycleRent.Repositories
{
    public class ClientRepository
    {
        private readonly MySqlConnection _Connection;

        public ClientRepository(MySqlConnection _connection)
        {
            _Connection = _connection;
        }
    }
}
