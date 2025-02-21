using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bicycleRent.Forms.Deposit;
using bicycleRent.Forms.Filial;
using bicycleRent.Forms.Inventory;
using bicycleRent.Forms.InventoryType;
using bicycleRent.Forms.User;

namespace bicycleRent.Forms.Admin
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            this.TopMost = true;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void GoToInventoryAddFormBtn_Click(object sender, EventArgs e)
        {
            InventoryAddForm inventoryAddForm = new InventoryAddForm();
            inventoryAddForm.ShowDialog();
        }

        private void GoToUserAddFormBtn_Click(object sender, EventArgs e)
        {
            UserAddForm userAddForm = new UserAddForm();
            userAddForm.ShowDialog();
        }

        private void GoToDepositAddFormAdd_Click(object sender, EventArgs e)
        {
            DepositAddForm depositAddForm = new DepositAddForm();
            depositAddForm.ShowDialog();
        }

        private void GoToInventoryTypeAddFormBtn_Click(object sender, EventArgs e)
        {
            InventoryTypeAddForm inventoryTypeAddForm = new InventoryTypeAddForm();
            inventoryTypeAddForm.ShowDialog();
        }

        private void GoToFilialAddFormBtn_Click(object sender, EventArgs e)
        {
            FilialAddForm filialAddForm = new FilialAddForm();
            filialAddForm.ShowDialog();
        }

        private void ShowMeInventoryBtn_Click(object sender, EventArgs e)
        {

        }

        private void ShowMeClientsBtn_Click(object sender, EventArgs e)
        {

        }

        private void ShowMeRentForTodayBtn_Click(object sender, EventArgs e)
        {

        }

        private void ShowMeFilialsBtn_Click(object sender, EventArgs e)
        {

        }

        private void ShowMeWorkersBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
