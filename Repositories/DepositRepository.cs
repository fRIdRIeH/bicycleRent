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
    }
}
