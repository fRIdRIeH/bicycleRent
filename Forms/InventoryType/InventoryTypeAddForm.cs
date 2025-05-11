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

namespace bicycleRent.Forms.InventoryType
{
    public partial class InventoryTypeAddForm : Form
    {
        private readonly MySqlConnection _connection;

        int _id;
        string _key;

        private InventoryTypeRepository _repository;
        public InventoryTypeAddForm(MySqlConnection connection, int id, string key)
        {
            InitializeComponent();
            this.TopMost = true;

            this._connection = connection;

            _repository = new InventoryTypeRepository(_connection);

            _id = id;
            _key = key;

            if(_key == "edit")
            {
                LoadData();
            }
            if(_key == "add")
            {
                this.Text = "Добавление типа инвентаря";
                btnAddOrEdit.Text = "Добавить";
            }

        }

        public void LoadData()
        {
            Models.InventoryType inventoryType = _repository.Get(_id);

            txtInventoryTypeName.Text = inventoryType.Name;

            this.Text = "Редактирование типа инвентаря";
            btnAddOrEdit.Text = "Редактировать";
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            if (btnAddOrEdit.Text == "") { MessageBox.Show("Поле 'Название типа инвентаря' не должно быть пустым!"); return; }
            if( btnAddOrEdit.Text.Length > 15) { MessageBox.Show("Введеное значение в поле 'Название типа инвентаря' не должно быть больше 15 символов!"); return; }

            try
            {
                if(_key == "edit")
                {
                    Models.InventoryType inventoryType = new Models.InventoryType()
                    {
                        Id = _id,
                        Name = txtInventoryTypeName.Text,
                    };

                    _repository.Update(inventoryType);
                    MessageBox.Show("Тип инвентаря обновлен!");
                    this.Close();
                }

                if( _key == "add")
                {
                    Models.InventoryType inventoryType = new Models.InventoryType()
                    {
                        Id = _id,
                        Name = txtInventoryTypeName.Text,
                    };

                    _repository.Add(inventoryType);
                    MessageBox.Show("Тип инвентаря добавлен!");
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
