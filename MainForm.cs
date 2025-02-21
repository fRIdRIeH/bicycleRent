using bicycleRent.Forms.Admin;
using bicycleRent.Forms.Client;
using bicycleRent.Forms.Generic;
using bicycleRent.Forms.Inventory;
using bicycleRent.Forms.Rent;
using bicycleRent.Repositories;

namespace bicycleRent
{
    public partial class MainForm : Form
    {
        //ClientRepository _clientRepository;
        //DepositRepository _depositRepository;
        //FilialRepository _filialRepository;
        //InventoryRepository _inventoryRepository;
        //InventoryTypeRepository _inventoryTypeRepository;
        //RentRepository _rentRepository;
        //UserRepository _userRepository;


        //НЕОБХОДИМО ПЕРЕДАТЬ КОННЕКШН ИЗ PROGRAM.CS В ЭТУ ФОРМУ, ЧТОБЫ РЕПЫ УЖЕ ОТСЮДА ОТПРАВЛЯТЬ В ФОРМЫ
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
            
        }

        private void GoToClientsListBtn_Click(object sender, EventArgs e)
        {
            
        }
        private void GoToInventoryListBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void GoToAdminPanelBtn_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
        }
    }
}
