using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using bicycleRent.Models;
using MySql.Data.MySqlClient;

namespace bicycleRent.Repositories
{
    public class UserRepository
    {
        private readonly MySqlConnection _сonnection;

        public UserRepository(MySqlConnection connection)
        {
            _сonnection = connection;
        }

        public bool Add(User user)
        {
            string query = "INSERT INTO User " +
                "(User_Surname, User_Name, User_Patronymic, User_Telephone, User_Address, User_Role, User_Login, User_Password) " +
                "VALUES " +
                "(@User_Surname, @User_Name, @User_Patronymic, @User_Telephone, @User_Address, @User_Role, @User_Login, @User_Password)";

            using (MySqlCommand cmd = new MySqlCommand(query, _сonnection)) 
            {
                cmd.Parameters.AddWithValue("@User_Surname", user.Surname);
                cmd.Parameters.AddWithValue("@User_Name", user.Name);
                cmd.Parameters.AddWithValue("@User_Patronymic", user.Patronymic);
                cmd.Parameters.AddWithValue("@User_Telephone", user.Telephone);
                cmd.Parameters.AddWithValue("@User_Address", user.Address);
                cmd.Parameters.AddWithValue("@User_Role", user.Role);
                cmd.Parameters.AddWithValue("@User_Login", user.Login);
                cmd.Parameters.AddWithValue("@User_Password", user.Password);

                int rowsInserted = cmd.ExecuteNonQuery();

                if (rowsInserted > 0)
                    return true;
                return false;
            }
        }

        public bool Update(User user) 
        {
            string query = "UPDATE User SET " +
                "User_Surname = @User_Surname, " +
                "User_Name = @User_Name, " +
                "User_Patronymic = @User_Patronymic, " +
                "User_Telephone = @User_Telephone, " +
                "User_Address = @User_Address, " +
                "User_Role = @User_Role, " +
                "User_Login = @User_Login, " +
                "User_Password = @User_Password " +
                "WHERE User_Id = @User_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _сonnection))
            {
                cmd.Parameters.AddWithValue("@User_Id", user.Id);
                cmd.Parameters.AddWithValue("@User_Surname", user.Surname);
                cmd.Parameters.AddWithValue("@User_Name", user.Name);
                cmd.Parameters.AddWithValue("@User_Patronymic", user.Patronymic);
                cmd.Parameters.AddWithValue("@User_Telephone", user.Telephone);
                cmd.Parameters.AddWithValue("@User_Address", user.Address);
                cmd.Parameters.AddWithValue("@User_Role", user.Role);
                cmd.Parameters.AddWithValue("@User_Login", user.Login);
                cmd.Parameters.AddWithValue("@User_Password", user.Password);

                int rowsUpdated = cmd.ExecuteNonQuery();

                if(rowsUpdated > 0) 
                    return true;
                return false;
            }
        }

        public bool Delete(int userId) 
        {
            string query = "DELETE FROM User WHERE User_Id = @User_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _сonnection))
            {
                cmd.Parameters.AddWithValue("@User_Id", userId);

                int rowsDeleted = cmd.ExecuteNonQuery();

                if (rowsDeleted > 0) 
                    return true;
                return false;
            }
        }

        public User? Get(int userId) 
        {
            string query = "SELECT * FROM User WHERE User_Id = @User_Id";

            using (MySqlCommand cmd = new MySqlCommand(query, _сonnection))
            {
                cmd.Parameters.AddWithValue("@User_Id", userId);

                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User user = new User() 
                        {
                            Id = reader.GetInt32("User_Id"),
                            Surname = reader.GetString("User_Surname"),
                            Name = reader.GetString("User_Name"),
                            Patronymic = reader.GetString("User_Patronymic"),
                            Telephone = reader.GetString("User_Telephone"),
                            Address = reader.GetString("User_Address"),
                            Role = reader.GetString("User_Role"),
                            Login = reader.GetString("User_Login"),
                            Password = reader.GetString("User_Password"),
                        };
                        return user;
                    }
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
            string query = "SELECT * FROM User";
            List<User> users = new List<User>();

            using (MySqlCommand cmd = new MySqlCommand(query, _сonnection))
            {

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        User user = new User()
                        {
                            Id = reader.GetInt32("User_Id"),
                            Surname = reader.GetString("User_Surname"),
                            Name = reader.GetString("User_Name"),
                            Patronymic = reader.GetString("User_Patronymic"),
                            Telephone = reader.GetString("User_Telephone"),
                            Address = reader.GetString("User_Address"),
                            Role = reader.GetString("User_Role"),
                            Login = reader.GetString("User_Login"),
                            Password = reader.GetString("User_Password"),
                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }
    }
}
