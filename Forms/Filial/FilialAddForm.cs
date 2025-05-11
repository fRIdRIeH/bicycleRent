using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bicycleRent.Repositories;
using MySql.Data.MySqlClient;

namespace bicycleRent.Forms.Filial
{
    public partial class FilialAddForm : Form
    {
        private readonly MySqlConnection _connection;
        private FilialRepository _repository;

        int _id;
        string _key;
        public FilialAddForm(MySqlConnection connection, int id, string key)
        {
            InitializeComponent();
            this.TopMost = true;

            _connection = connection;

            _repository = new FilialRepository(_connection);

            _id = id;
            _key = key;

            if(_key == "edit")
            {
                LoadData();
            }
            if(_key == "add")
            {
                this.Text = "Добавление филиала";
                btnAddOrEdit.Text = "Добавить филиал";
            }
        }

        public void LoadData()
        {
            var filialToFill = _repository.Get(_id);

            txtFilialName.Text = filialToFill.Name;
            txtFilialAddress.Text = filialToFill.Address;

            this.Text = "Редактирование филиала";
            btnAddOrEdit.Text = "Редактировать филиал";
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            if (txtFilialName.Text == "") { MessageBox.Show("Поле 'Название филиала' не должно быть пустым!"); return; }
            if (txtFilialAddress.Text == "") { MessageBox.Show("Поле 'Адрес филиала' не должно быть пустым!"); return; }

            if (txtFilialName.Text.Length > 20) { MessageBox.Show("Поле 'Название филиала' не должно быть превышать 20 символов!"); return; }
            if (txtFilialAddress.Text.Length > 50) { MessageBox.Show("Поле 'Адресс филиала' не должно быть превышать 20 символов!"); return; }

            try
            {
                if(_key == "edit")
                {
                    Models.Filial filial = new Models.Filial()
                    {
                        Id = _id,
                        Name = txtFilialName.Text,
                        Address = txtFilialAddress.Text,
                    };

                    _repository.Update(filial);
                    MessageBox.Show("Филиал успешно обновлен!");
                    this.Close();
                }
                if (_key == "add")
                {
                    Models.Filial filial = new Models.Filial()
                    {
                        Name = txtFilialName.Text,
                        Address = txtFilialAddress.Text,
                    };

                    _repository.Add(filial);
                    MessageBox.Show("Филиал успешно добавлен!");
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
