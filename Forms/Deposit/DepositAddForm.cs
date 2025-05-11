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

namespace bicycleRent.Forms.Deposit
{
    public partial class DepositAddForm : Form
    {
        private readonly MySqlConnection _connection;

        int _id;
        string _key;

        private DepositRepository _repository;
        public DepositAddForm(MySqlConnection connection, int id, string key)
        {
            InitializeComponent();
            this.TopMost = true;

            _connection = connection;

            _id = id;
            _key = key;

            _repository = new DepositRepository(_connection);

            if (_key == "edit")
            {
                LoadData();
            }
            if( _key == "add")
            {
                this.Text = "Добавление залога";
                btnAddOrEdit.Text = "Добавить";
            }
        }

        public void LoadData()
        {
            var depositToFill = _repository.Get(_id);

            txtDepositName.Text = depositToFill.Name;
            
            this.Text = "Редактирование залога";
            btnAddOrEdit.Text = "Редактировать";
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            if(txtDepositName.Text == "") { MessageBox.Show("Поле 'Название залога' не должно быть пустым"); return; }

            if (txtDepositName.Text.Length > 15) { MessageBox.Show("Поле 'Название залога' не должно быть больше 15 символов по длине"); return; }

            try
            {
                Models.Deposit deposit = new Models.Deposit()
                {
                    Id = _id,
                    Name = txtDepositName.Text,
                };

                if (_key == "edit") 
                {
                    _repository.Update(deposit);
                    MessageBox.Show("Залог успешно обновлен!");
                    this.Close();
                }
                if (_key != "edit") 
                {
                    _repository.Add(deposit);
                    MessageBox.Show("Залог успешно добавлен!");
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
