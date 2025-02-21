using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace bicycleRent.Repositories
{
    public class InventoryTypeRepository
    {
        private readonly MySqlConnection _Connection;

        public InventoryTypeRepository(MySqlConnection _connection)
        {
            _Connection = _connection;
        }
    }
}
