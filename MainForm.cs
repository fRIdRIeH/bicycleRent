using bicycleRent.Forms.Admin;
using bicycleRent.Forms.Client;
using bicycleRent.Forms.Inventory;
using bicycleRent.Forms.Rent;
using bicycleRent.Repositories;
using MySql.Data.MySqlClient;

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
        private readonly MySqlConnection _Connection;
        public MainForm(MySqlConnection _connection)
        {
            InitializeComponent();
            _Connection = _connection;
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
            //RentAddForm rentAddForm = new RentAddForm(_rentRepository);
            //rentAddForm.ShowDialog();
        }

        private void GoToRentsListBtn_Click(object sender, EventArgs e)
        {
            RentRepository _rentRepository = new(_Connection);
            RentListForm rentListForm = new RentListForm(_rentRepository);
            rentListForm.ShowDialog();
        }

        private void GoToClientsListBtn_Click(object sender, EventArgs e)
        {
            ClientRepository _clientRepository = new(_Connection);
            ClientListForm clientListForm = new ClientListForm(_clientRepository);
            clientListForm.ShowDialog();
        }
        private void GoToInventoryListBtn_Click(object sender, EventArgs e)
        {
            InventoryRepository _inventoryRepository = new(_Connection);
            InventoryListForm inventoryListForm = new InventoryListForm(_inventoryRepository);
            inventoryListForm.ShowDialog();
        }

        private void GoToAdminPanelBtn_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
        }
    }
}
