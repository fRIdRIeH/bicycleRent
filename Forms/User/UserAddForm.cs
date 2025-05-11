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
using bicycleRent.Repositories;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace bicycleRent.Forms.User
{
    public partial class UserAddForm : Form
    {
        MySqlConnection _connection;

        int _id;
        string _key;

        private UserRepository _repository;
        public UserAddForm(MySqlConnection connection, int id, string key)
        {
            InitializeComponent();
            this.TopMost = true;

            _connection = connection;

            _repository = new UserRepository(connection);

            _id = id;
            _key = key;

            if (_key == "edit")
            {
                LoadData();
            }
            if (_key == "add")
            {
                this.Text = "Добавление менеджера/администратора";
                btnAddOrEdit.Text = "Добавить";
            }

            cbRole.Items.Add("Администратор");
            cbRole.Items.Add("Менеджер");
        }

        public void LoadData()
        {
            var userToFill = _repository.Get(_id);

            txtSurname.Text = userToFill.Surname;
            txtName.Text = userToFill.Name;
            txtPatronymic.Text = userToFill.Patronymic;
            txtTelephone.Text = userToFill.Telephone;
            txtAddress.Text = userToFill.Address;
            cbRole.Text = userToFill.Role;
            txtLogin.Text = userToFill.Login;
            txtPassword.Text = userToFill.Password;

            this.Text = "Редактирование менеджера/администратора";
            btnAddOrEdit.Text = "Редактировать";

            groupBox1.Text = "Данные о менеджере/администраторе";
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            if (txtSurname.Text == "") { MessageBox.Show("Поле 'Фамилия' не должно быть пустым!"); return; }
            if (txtName.Text == "") { MessageBox.Show("Поле 'Имя' не должно быть пустым!"); return; }
            if (txtPatronymic.Text == "") { MessageBox.Show("Поле 'Отчество' не должно быть пустым!"); return; }
            if (txtTelephone.Text == "") { MessageBox.Show("Поле 'Телефон' не должно быть пустым!"); return; }
            if (txtAddress.Text == "") { MessageBox.Show("Поле 'Адрес' не должно быть пустым!"); return; }
            if (cbRole.Text == "") { MessageBox.Show("Поле 'Роль' не должно быть пустым! Выбери роль из выпадающего списка"); return; }
            if (txtLogin.Text == "") { MessageBox.Show("Поле 'Логин' не должно быть пустым!"); return; }
            if (txtPassword.Text == "") { MessageBox.Show("Поле 'Пароль' не должно быть пустым!"); return; }

            try
            {
                if(_key == "edit")
                {
                    Models.User user = new Models.User()
                    {
                        Id = _id,
                        Surname = txtSurname.Text,
                        Name = txtName.Text,
                        Patronymic = txtPatronymic.Text,
                        Telephone = txtTelephone.Text,
                        Address = txtAddress.Text,
                        Role = cbRole.Text,
                        Login = txtLogin.Text,
                        Password = txtPassword.Text,
                    };

                    _repository.Update(user);
                    MessageBox.Show("Пользователь обновлен!");
                    this.Close();
                }
                if(_key == "add")
                {
                    Models.User user = new Models.User()
                    {
                        Surname = txtSurname.Text,
                        Name = txtName.Text,
                        Patronymic = txtPatronymic.Text,
                        Telephone = txtTelephone.Text,
                        Address = txtAddress.Text,
                        Role = cbRole.Text,
                        Login = txtLogin.Text,
                        Password = txtPassword.Text,
                    };

                    _repository.Add(user);
                    MessageBox.Show("Пользователь добавлен!");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Возникла ошибка! {ex.Message}");
            }
        }
    }
}
