using bicycleRent.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bicycleRent.Forms.Rent
{
    public partial class RentAddForm : Form
    {
        private readonly RentRepository _rentRepository;
        private readonly Models.User _user;
        public RentAddForm(RentRepository rentRepository, Models.User user)
        {
            InitializeComponent();
            this.TopMost = true;
            this._rentRepository = rentRepository;
            this._user = user;
        }

        private void RentAddForm_Load(object sender, EventArgs e)
        {
            //Установка кастомного формата для отображения и даты и времени
            dtpStart.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            dtpEnd.CustomFormat = "dd.MM.yyyy HH:mm:ss";
        }

        public void LoadData()
        {

        }
    }
}
