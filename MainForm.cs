using bicycleRent.Forms.Admin;
using bicycleRent.Forms.Client;
using bicycleRent.Forms.Inventory;
using bicycleRent.Forms.Rent;
using bicycleRent.Repositories;
using bicycleRent.Models;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace bicycleRent
{
    public partial class MainForm : Form
    {
        //ClientRepository _clientRepository;
        //DepositRepository _depositRepository;
        //FilialRepository _filialRepository;
        //InventoryRepository _inventoryRepository;
        //InventoryTypeRepository _inventoryTypeRepository;
        //private readonly RentRepository _rentRepository;
        //UserRepository _userRepository;

        private readonly MySqlConnection _connection;
        private readonly User _User;
        public MainForm(MySqlConnection connection, User foundedUser)
        {
            InitializeComponent();
            _connection = connection;
            _User = foundedUser;
            LoadData();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;

            labelForUserSNP.Text = $"������� �����, {_User.Name}!";
        }

        private void GoToAddRentBtn_Click(object sender, EventArgs e)
        {
            //���������� �������� ��� ��� �����, id ������������
            //RentAddForm rentAddForm = new RentAddForm(_rentRepository);
            //rentAddForm.ShowDialog();
        }

        private void GoToRentsListBtn_Click(object sender, EventArgs e)
        {
            RentRepository _rentRepository = new(_connection);
            RentListForm rentListForm = new RentListForm(_rentRepository);
            rentListForm.ShowDialog();
        }

        private void GoToClientsListBtn_Click(object sender, EventArgs e)
        {
            ClientRepository _clientRepository = new(_connection);
            ClientListForm clientListForm = new ClientListForm(_clientRepository);
            clientListForm.ShowDialog();
        }
        private void GoToInventoryListBtn_Click(object sender, EventArgs e)
        {
            InventoryRepository _inventoryRepository = new(_connection);
            InventoryListForm inventoryListForm = new InventoryListForm(_inventoryRepository);
            inventoryListForm.ShowDialog();
        }

        private void GoToAdminPanelBtn_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
        }

        private void AddRentCard(Rent rent)
        {
            Panel rentPanel = new Panel()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(1200, 100),
                Margin = new Padding(10),
                BackColor = Color.Red,
            };

            //��� id ������
            Label lblRentId = new Label() 
            {
            
            };
            //��� id �������
            Label lblFiflialId = new Label() 
            {
            
            };
            //��� ������� �������
            Label lblClientId = new Label()
            {

            };
            //��� ���������
            Label lblInventoryId = new Label()
            {

            };
            //��� ������� ������
            Label lblTimeStart = new Label()
            {

            };
            //��� ������� �����
            Label lblTimeEnd = new Label()
            {

            };
            //��� ����� �� ������
            Label lblTotal = new Label()
            {

            };
            //��� ������� �.�. ����������
            Label lblUserId = new Label()
            {

            };
            //��� ������
            Label lblDepositId = new Label() 
            {
            
            };
        }

        private void LoadData()
        {
            RentRepository _rentRepository = new RentRepository(_connection);
            var rentsData = _rentRepository.GetAll();

            foreach(var oneRent in rentsData)
            {
                AddRentCard(oneRent);
            }
        }
    }
}
