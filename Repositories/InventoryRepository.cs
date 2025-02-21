using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace bicycleRent.Repositories
{
    public class InventoryRepository
    {
        private readonly MySqlConnection _Connection;

        public InventoryRepository(MySqlConnection _connection)
        {
            _Connection = _connection;
        }
    }
}
