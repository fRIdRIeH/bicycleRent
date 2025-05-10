using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bicycleRent.Repositories;
using MySql.Data.MySqlClient;

namespace bicycleRent.Forms.Client
{
    public partial class ClientAddForm : Form
    {
        private readonly ClientRepository _clientRepository;
        private readonly int _clientId;
        private readonly string _key;
        public ClientAddForm(ClientRepository clientRepository, int clientId, string key)
        {
            InitializeComponent();
            this.TopMost = true;

            this._clientId = clientId;
            this._clientRepository = clientRepository;
            this._key = key;

            if (clientId == 0 && _key == "add")
            {
                this.Text = "Добавление клиента";
                btnAddOrEdit.Text = "Добавить";
            }
            if (clientId != 0 && _key == "edit")
            {
                this.Text = "Редактирование клиента";
                btnAddOrEdit.Text = "Редактировать";

                LoadData();
            }
        }

        public void LoadData()
        {
            var clientToFill = _clientRepository.GetFullClientInfo(_clientId);

            txtSurname.Text = clientToFill.Surname;
            txtName.Text = clientToFill.Name;
            txtPatronymic.Text = clientToFill.Patronymic;
            txtTelephone.Text = clientToFill.Telephone;
            txtAddress.Text = clientToFill.Address;
            txtFeatures.Text = clientToFill.Features;
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            //Недовалидация
            if (txtSurname.Text == "") { MessageBox.Show("Поле 'Фамилия' не должно быть пустым!"); return; }
            if (txtName.Text == "") { MessageBox.Show("Поле 'Имя' не должно быть пустым!"); return; }
            if (txtPatronymic.Text == "") { MessageBox.Show("Поле 'Отчество' не должно быть пустым!"); return; }
            if (txtTelephone.Text == "") { MessageBox.Show("Поле 'Телефон' не должно быть пустым!"); return; }
            if (txtAddress.Text == "") { MessageBox.Show("Поле 'Адрес' не должно быть пустым!"); return; }
            if (txtFeatures.Text == "") { MessageBox.Show("Поле 'Особые черты' не должно быть пустым!"); return; }

            if (txtSurname.Text.Length >= 17) { MessageBox.Show("Длина поля 'Фамилия' не должна превышать 17 символов!"); return; }
            if (txtName.Text.Length >= 17) { MessageBox.Show("Длина поля 'Имя' не должна превышать 17 символов!"); return; }
            if (txtPatronymic.Text.Length >= 17) { MessageBox.Show("Длина поля 'Отчество' не должна превышать 17 символов!"); return; }
            if (txtTelephone.Text.Length >= 17) { MessageBox.Show("Длина поля 'Телефон' не должна превышать 17 символов!"); return; }

            try
            {
                Models.Client client = new Models.Client() 
                {
                    Surname = txtSurname.Text,
                    Name = txtName.Text,
                    Patronymic = txtPatronymic.Text,
                    Telephone = txtTelephone.Text,
                    Address = txtAddress.Text,
                    Features = txtFeatures.Text
                };

                if (_key == "add")
                {
                    _clientRepository.Add(client);
                    MessageBox.Show("Клиент добавлен!");
                    this.Close();
                }
                if (_key == "edit")
                {
                    _clientRepository.Update(client, _clientId);
                    MessageBox.Show("Клиент обновлен!");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка! {ex.Message}");
            }
        }
    }
}
