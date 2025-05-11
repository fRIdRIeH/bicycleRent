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

namespace bicycleRent.Forms.Time
{
    public partial class TimeAddForm : Form
    {
        private readonly MySqlConnection _connection;
        TimeRepository _timeRepository;

        public TimeAddForm(MySqlConnection connection)
        {
            InitializeComponent();

            _connection = connection;

            _timeRepository = new TimeRepository(_connection);

            this.TopMost = true;
        }

        private void btnAddOrEdit_Click(object sender, EventArgs e)
        {
            if (txtTimeLabel.Text == "") { MessageBox.Show("Введи название временного периода!"); return; }

            try
            {
                Models.Time time = new Models.Time()
                {
                    TimeLabel = txtTimeLabel.Text,
                };

                _timeRepository.Add(time);
                MessageBox.Show("Время добавлено!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникла ошибка! {ex.Message}");
            }
        }
    }
}
