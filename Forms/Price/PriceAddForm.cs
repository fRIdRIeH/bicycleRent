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

namespace bicycleRent.Forms.Price
{
    public partial class PriceAddForm : Form
    {
        private readonly MySqlConnection _connection;
        PriceRepository _priceRepository;
        public PriceAddForm(MySqlConnection connection)
        {
            InitializeComponent();

            _connection = connection;

            _priceRepository = new PriceRepository(_connection);

            this.TopMost = true;
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            if (numPrice.Value == 0) { MessageBox.Show("Введи корректную стоимость!"); return; }
            if (numPrice.Value >= 999999999) { MessageBox.Show("Максимальная стоимость не может быть 999999999 и больше!"); return; }

            try
            {
                Models.Price price = new Models.Price()
                {
                    Amount = numPrice.Value,
                };

                _priceRepository.Add(price);
                MessageBox.Show("Цена добавлена!");
                this.Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Возникла ошибка! {ex.Message}");
            }
        }
    }
}
