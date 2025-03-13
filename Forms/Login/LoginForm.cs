using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bicycleRent.Models;

namespace bicycleRent.Forms.Login
{
    public partial class LoginForm : Form
    {
        MySqlConnection _connection;
        public LoginForm(MySqlConnection connection)
        {
            InitializeComponent();
            _connection = connection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (loginInput.Text == "") { MessageBox.Show("Поле 'Логин' не должно быть пустым!"); return; }
            if (passwordInput.Text == "") { MessageBox.Show("Поле 'Пароль' не должно быть пустым!"); return; }

            try
            {
                Models.User user = new()
                {
                    Login = loginInput.Text,
                    Password = passwordInput.Text,
                };

                string loginQuery = "SELECT * FROM User WHERE User_Login = @User_Login AND User_Password = @User_Password;";
                
                using(MySqlCommand cmd = new MySqlCommand(loginQuery, _connection)) 
                {
                    cmd.Parameters.AddWithValue("@User_Login", user.Login);
                    cmd.Parameters.AddWithValue("@User_Password", user.Password);

                    using(MySqlDataReader reader = cmd.ExecuteReader()) 
                    {
                        if(reader.Read())
                        {
                            Models.User foundedUser = new()
                            {
                                Id = reader.GetInt32("User_Id"),
                                Surname = reader.GetString("User_Surname"),
                                Name = reader.GetString("User_Name"),
                                Patronymic = reader.GetString("User_Patronymic"),
                                Telephone = reader.GetString("User_Telephone"),
                                Address = reader.GetString("User_Address"),
                                Role = reader.GetString("User_Role")
                            };

                            try
                            {
                                MainForm mainForm = new MainForm(_connection, foundedUser);
                                mainForm.Show();
                                this.Close();
                            }
                            catch(Exception ex) 
                            {
                                MessageBox.Show("Ошибка! " + ex.Message);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! " + ex.Message);
            }
        }
    }
}
