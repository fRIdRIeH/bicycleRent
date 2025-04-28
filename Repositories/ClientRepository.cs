using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using bicycleRent.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.Sig;

namespace bicycleRent.Repositories
{
    public class ClientRepository
    {
        private readonly MySqlConnection _connection;

        public ClientRepository(MySqlConnection connection)
        {
            _connection = connection;
        }

        public List<Client> GetAll()
        {
            List<Client> clients = new List<Client>();
            string query = "SELECT * FROM Client ";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client client = new Client() 
                        {
                            Id = reader.GetInt32("Client_Id"),
                            Surname = reader.GetString("Client_Surname"),
                            Name = reader.GetString("Client_Name"),
                            Patronymic = reader.GetString("Client_Patronymic"),
                            Telephone = reader.GetString("Client_Telephone"),
                            Address = reader.GetString("Client_Address"),
                            Features = reader.GetString("Client_Features"),
                            VisitCount = reader.GetInt32("Client_Visit_Count"),
                        };
                        clients.Add(client);
                    }
                }
            }
            return clients;
        }
    }
}
