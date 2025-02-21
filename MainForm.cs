using bicycleRent.Forms.Admin;
using bicycleRent.Forms.Client;
using bicycleRent.Forms.Generic;
using bicycleRent.Forms.Inventory;
using bicycleRent.Forms.Rent;

namespace bicycleRent
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
        }

        private void GoToAddRentBtn_Click(object sender, EventArgs e)
        {
            //необходимо передать реп для аренд, id пользователя
            RentAddForm rentAddForm = new RentAddForm(_rentRepository);
            rentAddForm.ShowDialog();
        }

        private void GoToRentsListBtn_Click(object sender, EventArgs e)
        {
            //для аренд передаем стороку rents и репозиторий для аренд
            ForAllListForm forAllListForm = new ForAllListForm("rents");
            forAllListForm.ShowDialog();
        }

        private void GoToClientsListBtn_Click(object sender, EventArgs e)
        {
            //для клиентов передаем стороку clietns и репозиторий для клиентов
            ForAllListForm forAllListForm = new ForAllListForm("clients");
            forAllListForm.ShowDialog();
        }
        private void GoToInventoryListBtn_Click(object sender, EventArgs e)
        {
            //для инвентаря передаем стороку inventory и репозиторий для инвентаря
            ForAllListForm forAllListForm = new ForAllListForm("inventory");
            forAllListForm.ShowDialog();
        }

        private void GoToAdminPanelBtn_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
        }
    }
}
