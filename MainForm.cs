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
            //���������� �������� ��� ��� �����, id ������������
            RentAddForm rentAddForm = new RentAddForm(_rentRepository);
            rentAddForm.ShowDialog();
        }

        private void GoToRentsListBtn_Click(object sender, EventArgs e)
        {
            //��� ����� �������� ������� rents � ����������� ��� �����
            ForAllListForm forAllListForm = new ForAllListForm("rents");
            forAllListForm.ShowDialog();
        }

        private void GoToClientsListBtn_Click(object sender, EventArgs e)
        {
            //��� �������� �������� ������� clietns � ����������� ��� ��������
            ForAllListForm forAllListForm = new ForAllListForm("clients");
            forAllListForm.ShowDialog();
        }
        private void GoToInventoryListBtn_Click(object sender, EventArgs e)
        {
            //��� ��������� �������� ������� inventory � ����������� ��� ���������
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
