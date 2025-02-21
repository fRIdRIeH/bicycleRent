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
    }
}
