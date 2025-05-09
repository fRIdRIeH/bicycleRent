using bicycleRent.Forms.Admin;
using bicycleRent.Forms.Client;
using bicycleRent.Forms.Inventory;
using bicycleRent.Forms.Rent;
using bicycleRent.Repositories;
using bicycleRent.Models;
using MySql.Data.MySqlClient;
using System.Data.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
            if (_user.Role != "Администратор")
            {
                GoToAdminPanelBtn.Visible = false;
            }

        }

        private void GoToAddRentBtn_Click(object sender, EventArgs e)
        {
            RentRepository _rentRepository = new RentRepository(_connection);
            RentAddForm rentAddForm = new RentAddForm(_rentRepository, _user, _connection, 0, "addRent");
            rentAddForm.ShowDialog();
        }

        private void GoToRentsListBtn_Click(object sender, EventArgs e)
        {
            RentRepository _rentRepository = new(_connection);
            RentListForm rentListForm = new RentListForm(_rentRepository, _user, _connection);
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
            //Обьявление переменной для длины панели rentPanel
            int panelLenght = 120;

            Panel rentPanel = new Panel()
            {
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(1330, panelLenght),
                Margin = new Padding(10),
                BackColor = Color.LightGray,
                Tag = rent.RentId,
            };

            if (rent.Status == "В процессе")
            {
                rentPanel.BackColor = Color.LightGreen;
            }
            if (rent.Status == "Отменена")
            {
                rentPanel.BackColor = Color.GreenYellow;
            }
            if(rent.Status == "Забронирована")
            {
                rentPanel.BackColor = Color.Aquamarine;
            }
            if (rent.Status == "В процессе" && rent.TimeEnd < DateTime.Now)
            {
                //#FF6347FF
                rentPanel.BackColor = Color.IndianRed;
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
            //Для периода аренды
            Label lblTimeStart = new Label()
            {
                Text = "Период:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(600, 10),
                AutoSize = true
            };
            //Для суммы за аренду
            Label lblTotal = new Label()
            {
                Text = "К оплате:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(770, 10),
                AutoSize = true
            };
            //Для статуса
            Label lblStatus = new Label()
            {
                Text = "Статус:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(900, 10),
                AutoSize = true
            };
            //Для фамилии И.О. сотрудника
            Label lblUserId = new Label()
            {
                Text = "Сотрудник:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(1050, 10),
                AutoSize = true
            };
            //Для залога
            Label lblDepositId = new Label()
            {
                Text = "Залог:",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(1200, 10),
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
            //Для телефона клиента
            Label lblClientTelephoneData = new Label()
            {
                Text = $"т. {rent.ClientTelehone}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(210, 70),
                AutoSize = true
            };
            //Для времени начала
            Label lblTimeStartData = new Label()
            {
                Text = $"{rent.TimeStart}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(600, 50),
                AutoSize = true
            };
            //Для времени конца
            Label lblTimeEndData = new Label()
            {
                Text = $"{rent.TimeEnd}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(600, 70),
                AutoSize = true
            };
            //Для суммы за аренду
            Label lblTotalData = new Label()
            {
                Text = $"{rent.Total}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(770, 50),
                AutoSize = true
            };
            //Для статуса
            Label lblStatusData = new Label()
            {
                Text = $"{rent.Status}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(900, 50),
                AutoSize = true
            };
            //Для фамилии И.О. сотрудника
            Label lblUserData = new Label()
            {
                Text = $"{rent.UserSurname}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(1050, 50),
                AutoSize = true
            };
            //Для залога
            Label lblDepositData = new Label()
            {
                Text = $"{rent.DepositName}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(1200, 50),
                AutoSize = true
            };


            //
            // Кнопки управления
            //

            //обьявление переменной для Y положения кнопки редактирования
            int btnPosY = 85;

            Button btnEdit = new Button
            {
                Text = "Редактировать",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, btnPosY),
                AutoSize = true,
                BackColor = Color.LightGray,
                Tag = rentPanel
            };

            Button btnDelete = new Button()
            {
                Text = "❌",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Cursor = Cursors.Hand,
                Size = new Size(35, 35),
                Location = new Point(1290, 3),
                BackColor = Color.LightGray,
                Tag = rentPanel
            };

            //Привязка события нажатия на кнопки btnEdit и btnDelete
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;


            int lblCreatedAtPosY = 95;

            Label lblCreatedAtId = new Label()
            {
                Text = "Создано:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(1080, lblCreatedAtPosY),
                AutoSize = true
            };

            Label lblCreatedAtData = new Label()
            {
                Text = $"{rent.CreatedAt}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(1170, lblCreatedAtPosY),
                AutoSize = true
            };

            //
            // Момент с выводом инвентаря, который принадлежит к определенной аренде
            //

            InventoryRepository _inventoryRepository = new InventoryRepository(_connection);
            var inventoryList = _inventoryRepository.GetInventoryForRent(rent.RentId);

            //Обьявление переменной для Y положения наименований инвентаря
            int InventoriesPosY = 50;

            foreach (var inventory in inventoryList)
            {
                Label lblInventoryData = new Label()
                {
                    Text = $"{inventory.InventoryName}" + " " + $"{inventory.InventoryTypeName}" + " " + $"{inventory.InventoryNumber}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Location = new Point(350, InventoriesPosY),
                    AutoSize = true
                };
                //Добавление 20 пикселей к Y положению инвентаря, чтобы каждая единица друг на друга не накладывалась
                InventoriesPosY += 20;

                //Добавление 20 пикселей к длине панели rentPanel, чтобы входящий в нее инвентарь не вылезал из границ
                panelLenght += 20;
                rentPanel.Size = new Size(1330, panelLenght);

                //Добавление 20 пикселей к Y положению кнопок, чтобы они держались края панели rentPanel
                btnPosY += 20;
                btnEdit.Location = new Point(10, btnPosY);

                //Добавление 20 пикселей к Y положению отображаения даты создания, чтобы они держались края панели rentPanel
                lblCreatedAtPosY += 20;
                lblCreatedAtId.Location = new Point(1080, lblCreatedAtPosY);
                lblCreatedAtData.Location = new Point(1170, lblCreatedAtPosY);

                //Добавление наименование инвентаря в панель rentPanel
                rentPanel.Controls.Add(lblInventoryData);
            }

            if (rent.Status == "Закрыта" && _user.Role != "Администратор")
            {
                rentPanel.BackColor = Color.LightGray;
                btnEdit.Enabled = false;
            }

            //добавление в панель ярлыков
            rentPanel.Controls.Add(lblRentId);
            rentPanel.Controls.Add(lblFiflialId);
            rentPanel.Controls.Add(lblClientId);
            rentPanel.Controls.Add(lblInventoryId);
            rentPanel.Controls.Add(lblTimeStart);
            rentPanel.Controls.Add(lblTotal);
            rentPanel.Controls.Add(lblStatus);
            rentPanel.Controls.Add(lblUserId);
            rentPanel.Controls.Add(lblDepositId);
            rentPanel.Controls.Add(lblCreatedAtId);

            //добавление в панель данных о аренде
            rentPanel.Controls.Add(lblRentData);
            rentPanel.Controls.Add(lblFiflialData);
            rentPanel.Controls.Add(lblClientData);
            rentPanel.Controls.Add(lblTimeStartData);
            rentPanel.Controls.Add(lblTimeEndData);
            rentPanel.Controls.Add(lblTotalData);
            rentPanel.Controls.Add(lblStatusData);
            rentPanel.Controls.Add(lblUserData);
            rentPanel.Controls.Add(lblDepositData);
            rentPanel.Controls.Add(lblCreatedAtData);
            rentPanel.Controls.Add(lblClientTelephoneData);

            //добавление в панель кнопок управления
            rentPanel.Controls.Add(btnEdit);

            if (_user.Role == "Администратор")
            {
                rentPanel.Controls.Add(btnDelete);
            }

            flowLayoutPanel1.Controls.Add(rentPanel);
        }

        private void LoadData()
        {
            flowLayoutPanel1.Controls.Clear();

            RentRepository _rentRepository = new RentRepository(_connection);
            var rentsData = _rentRepository.GetAllBy7days();

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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Panel rentPanel && rentPanel.Tag is int rId)
            {
                //MessageBox.Show($"Открываем аренду с ID = {rId}");

                RentRepository _rentRepository = new RentRepository(_connection);
                RentEditForm rentEditForm = new RentEditForm(_rentRepository, _user, _connection, rId, "editRent");
                rentEditForm.ShowDialog();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button btn && btn.Tag is Panel rentPanel && rentPanel.Tag is int rId)
                {
                    RentRepository _rentRepository = new RentRepository(_connection);

                    //удаляем связанные аренды
                    _rentRepository.DeleteAllRentHasInventory(rId);

                    //удаляем оплаты
                    PaymentRepository _paymentRepository = new PaymentRepository(_connection);
                    _paymentRepository.DeleteAllPaymentsForRent(rId);

                    //удаляем саму аренду
                    _rentRepository.DeleteRent(rId);

                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
