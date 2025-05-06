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

        public Client? GetByTelephone(string telephone)
        {
            string query = "SELECT Client_Id, Client_Surname, Client_Name, Client_Patronymic FROM Client WHERE Client_Telephone = @Telephone";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Telephone", telephone);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Client client = new Client() 
                        {
                            Id = reader.GetInt32("Client_Id"),
                            Surname = reader.GetString("Client_Surname"),
                            Name = reader.GetString("Client_Name"),
                            Patronymic = reader.GetString("Client_Patronymic")
                        };
                        return client;
                    }
                }
            }
            return null;
        }

        public Client? Get(int id)
        {
            string query = "SELECT Client_Id, Client_Surname, Client_Name, Client_Patronymic FROM Client WHERE Client_Id = @Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Client client = new Client()
                        {
                            Id = reader.GetInt32("Client_Id"),
                            Surname = reader.GetString("Client_Surname"),
                            Name = reader.GetString("Client_Name"),
                            Patronymic = reader.GetString("Client_Patronymic")
                        };
                        return client;
                    }
                }
            }
            return null;
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
