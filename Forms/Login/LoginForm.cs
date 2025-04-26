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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using bicycleRent.Repositories;

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
            //проверка пустых строк
            if (loginInput.Text == "") { MessageBox.Show("Поле 'Логин' не должно быть пустым!"); return; }
            if (passwordInput.Text == "") { MessageBox.Show("Поле 'Пароль' не должно быть пустым!"); return; }

            //запись в переменные значений из textbox
            string login = loginInput.Text;
            string password = passwordInput.Text;

            if (AuthenticateUser(login, password))
            {
                //Уведомление об успешной авторизации
                MessageBox.Show("Авторизация успешна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                //Получение данных пользователя
                Models.User user = GetUser(login, password);

                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MainForm mainForm = new MainForm(_connection, user);
                    mainForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordInput.Clear();
                passwordInput.Focus();
            }
        }

        //Поиск юзера в бд по логину и паролю
        private bool AuthenticateUser(string login, string password)
        {
            try
            {

                string query = "SELECT COUNT(*) FROM User WHERE User_Login = @username AND User_Password = @password";

                MySqlCommand cmd = new MySqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@username", login);
                cmd.Parameters.AddWithValue("@password", password);

                object result = cmd.ExecuteScalar();
                int count = Convert.ToInt32(result);

                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //Получение класса юзер для передачи в MainForm
        private Models.User GetUser(string login, string password)
        {
            try
            {
                string query = "SELECT * FROM User WHERE User_Login = @login AND User_Password = @password";
                MySqlCommand cmd = new MySqlCommand(query, _connection);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Models.User worker = new Models.User(
                            reader.GetInt32("User_Id"),
                            reader.GetString("User_Surname"),
                            reader.GetString("User_Name"),
                            reader.GetString("User_Patronymic"),
                            reader.GetString("User_Telephone"),
                            reader.GetString("User_Address"),
                            reader.GetString("User_Role"),
                            reader.GetString("User_Login"),
                            reader.GetString("User_Password")
                        );
                        return worker; 
                    }
                    else
                    {
                        return null; // Пользователь не найден
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
