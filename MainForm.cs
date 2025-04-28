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
        private readonly User _user;
        public MainForm(MySqlConnection connection, User foundedUser)
        {
            InitializeComponent();
            _connection = connection;
            _user = foundedUser;
            LoadData();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;

            labelForUserSNP.Text = $"Удачной смены, {_user.Name}! Сегодня {DateOnly.FromDateTime(DateTime.Now)}";

            //Проверка на роль админа, для отображения кнопки админ-панели
            if(_user.Role != "Администратор")
            {
                GoToAdminPanelBtn.Visible = false;
            }

        }

        private void GoToAddRentBtn_Click(object sender, EventArgs e)
        {
            RentRepository _rentRepository = new RentRepository(_connection);
            RentAddForm rentAddForm = new RentAddForm(_rentRepository, _user);
            rentAddForm.ShowDialog();
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
                Size = new Size(1330, 120),
                Margin = new Padding(10),
                BackColor = Color.LightGray,
            };

            if (rent.Status == "В процессе")
            {
                rentPanel.BackColor = Color.Green;
            }
            if (rent.Status == "Завершена")
            {
                rentPanel.BackColor = Color.LightGray;
            }
            if (rent.Status == "Отменена")
            {
                rentPanel.BackColor = Color.Yellow;
            }
            if (rent.Status == "В процессе" && rent.TimeEnd < DateTime.Now)
            {
                rentPanel.BackColor = Color.Red;
                rent.Status = "Просрок!";
            }

            //Ярлыки

            //Для id аренды
            Label lblRentId = new Label()
            {
                Text = "#",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };
            //Для id филиала
            Label lblFiflialId = new Label()
            {
                Text = "Филиал:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(50, 10),
                AutoSize = true
            };
            //Для фамилии клиента
            Label lblClientId = new Label()
            {
                Text = "Клиент:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(210, 10),
                AutoSize = true
            };
            //Для инвентаря
            Label lblInventoryId = new Label()
            {
                Text = "Инвентарь:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(350, 10),
                AutoSize = true
            };
            //Для времени начала
            Label lblTimeStart = new Label()
            {
                Text = "Время начала:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(500, 10),
                AutoSize = true
            };
            //Для времени конца
            Label lblTimeEnd = new Label()
            {
                Text = "Время конца:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(700, 10),
                AutoSize = true
            };
            //Для суммы за аренду
            Label lblTotal = new Label()
            {
                Text = "К оплате:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(900, 10),
                AutoSize = true
            };
            //Для статуса
            Label lblStatus = new Label()
            {
                Text = "Статус:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(1000, 10),
                AutoSize = true
            };
            //Для фамилии И.О. сотрудника
            Label lblUserId = new Label()
            {
                Text = "Сотрудник:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(1120, 10),
                AutoSize = true
            };
            //Для залога
            Label lblDepositId = new Label()
            {
                Text = "Залог:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(1250, 10),
                AutoSize = true
            };

            //
            //      Данные под ярлыками
            //

            //Для id аренды
            Label lblRentData = new Label()
            {
                Text = $"{rent.RentId}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 50),
                AutoSize = true
            };
            //Для id филиала
            Label lblFiflialData = new Label()
            {
                Text = $"{rent.FilialName}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(50, 50),
                AutoSize = true
            };
            //Для фамилии клиента
            Label lblClientData = new Label()
            {
                Text = $"{rent.ClientSurname}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(210, 50),
                AutoSize = true
            };
            //Для инвентаря
            Label lblInventoryData = new Label()
            {
                Text = $"{rent.InventoryName}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(350, 50),
                AutoSize = true
            };
            //Для времени начала
            Label lblTimeStartData = new Label()
            {
                Text = $"{rent.TimeStart}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(500, 50),
                AutoSize = true
            };
            //Для времени конца
            Label lblTimeEndData = new Label()
            {
                Text = $"{rent.TimeEnd}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(700, 50),
                AutoSize = true
            };
            //Для суммы за аренду
            Label lblTotalData = new Label()
            {
                Text = $"{rent.Total}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(900, 50),
                AutoSize = true
            };
            //Для статуса
            Label lblStatusData = new Label()
            {
                Text = $"{rent.Status}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(1000, 50),
                AutoSize = true
            };
            //Для фамилии И.О. сотрудника
            Label lblUserData = new Label()
            {
                Text = $"{rent.UserSurname}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(1120, 50),
                AutoSize = true
            };
            //Для залога
            Label lblDepositData = new Label()
            {
                Text = $"{rent.DepositName}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(1250, 50),
                AutoSize = true
            };

            //
            // Кнопки управления
            //

            Button btnEdit = new Button
            {
                Text = "Редактировать",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 80),
                AutoSize = true,
                BackColor = Color.LightGray
            };

            Button btnDelete = new Button
            {
                Text = "Удалить",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(1237, 80),
                AutoSize = true,
                BackColor = Color.LightGray
            };

            //добавление в панель ярлыков
            rentPanel.Controls.Add(lblRentId);
            rentPanel.Controls.Add(lblFiflialId);
            rentPanel.Controls.Add(lblClientId);
            rentPanel.Controls.Add(lblInventoryId);
            rentPanel.Controls.Add(lblTimeStart);
            rentPanel.Controls.Add(lblTimeEnd);
            rentPanel.Controls.Add(lblTotal);
            rentPanel.Controls.Add(lblStatus);
            rentPanel.Controls.Add(lblUserId);
            rentPanel.Controls.Add(lblDepositId);

            //добавление в панель данных о аренде
            rentPanel.Controls.Add(lblRentData);
            rentPanel.Controls.Add(lblFiflialData);
            rentPanel.Controls.Add(lblClientData);
            rentPanel.Controls.Add(lblInventoryData);
            rentPanel.Controls.Add(lblTimeStartData);
            rentPanel.Controls.Add(lblTimeEndData);
            rentPanel.Controls.Add(lblTotalData);
            rentPanel.Controls.Add(lblStatusData);
            rentPanel.Controls.Add(lblUserData);
            rentPanel.Controls.Add(lblDepositData);

            //добавление в панель кнопок управления
            rentPanel.Controls.Add(btnEdit);
            rentPanel.Controls.Add(btnDelete);

            flowLayoutPanel1.Controls.Add(rentPanel);
        }

        private void LoadData()
        {
            RentRepository _rentRepository = new RentRepository(_connection);
            var rentsData = _rentRepository.GetAll();

            foreach (var oneRent in rentsData)
            {
                AddRentCard(oneRent);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            LoadData();
        }
    }
}
