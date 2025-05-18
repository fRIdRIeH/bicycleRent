using bicycleRent.Repositories;
using MySql.Data.MySqlClient;
using bicycleRent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bicycleRent.Forms.Inventory;
using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI;
using bicycleRent.Forms.Client;

namespace bicycleRent.Forms.Rent
{
    public partial class RentAddForm : Form
    {
        private readonly RentRepository _rentRepository;
        private readonly Models.User _user;
        private readonly MySqlConnection _connection;
        private readonly ClientRepository _clientRepository;
        Models.Client selectedClient;
        List<int> inventoryIds = new List<int>();
        TimeSpan duration;
        decimal total = 0;
        int clientId = 0;
        int _idFromMainForm;
        string _key;
        List<Models.Client> clients;

        public RentAddForm(RentRepository rentRepository, Models.User user, MySqlConnection connection, int idFormMain, string key)
        {
            InitializeComponent();
            this.TopMost = true;
            this._rentRepository = rentRepository;
            this._clientRepository = new ClientRepository(_connection);
            this._user = user;
            this._connection = connection;
            this._idFromMainForm = idFormMain;
            this._key = key;

            btnCreateRent.Enabled = false;

            LoadData();
        }

        private void RentAddForm_Load(object sender, EventArgs e)
        {
            //Установка кастомного формата для отображения и даты и времени
            dtpStart.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            dtpEnd.CustomFormat = "dd.MM.yyyy HH:mm:ss";
        }

        private void AddInventoryCard(Models.Inventory inventory)
        {
            Panel inventoryPanel = new Panel()
            {
                Tag = inventory.InventoryId,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Size = new Size(1220, 130),
            };

            //
            // Ярлыки для карточки инвентаря
            //

            int invLblPosY = 10;

            //для id инвентаря
            Label lblInventoryName = new Label()
            {
                Text = $"{inventory.InventoryId} - {inventory.InventoryTypeName} {inventory.InventoryName} {inventory.InventoryNumber}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, invLblPosY),
                AutoSize = true,
            };
            //заголовок филиала
            Label lblFilial = new Label()
            {
                Text = "Пункт проката:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 35),
                AutoSize = true
            };
            //заголовок статуса инвентаря
            Label lblStatus = new Label()
            {
                Text = "Статус:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(200, 35),
                AutoSize = true
            };

            //
            // Данные филиала и статуса
            //

            //Название филиала
            Label lblFilialName = new Label()
            {
                Text = $"{inventory.FilialName}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 55),
                AutoSize = true
            };
            //Статус велосипеда
            Label lblStatusName = new Label()
            {
                Text = $"{inventory.Status}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(200, 55),
                AutoSize = true
            };

            //Заголовок тарифа
            Label lblPrice = new Label()
            {
                Text = "Тариф: ",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 85),
                AutoSize = true
            };
            //combobox для тарифа
            ComboBox cbPrice = new ComboBox()
            {
                Name = "cbPrice",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(100, 82),
                Size = new Size(250, 33),
                AutoSize = true,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            //Заполнение cbPrice по inventoryId

            InventoryPriceRepository _inventoryPriceRepository = new InventoryPriceRepository(_connection);

            var prices = _inventoryPriceRepository.GetAll(inventory.InventoryId);

            cbPrice.DataSource = null;
            cbPrice.DataSource = prices;
            cbPrice.DisplayMember = "TimeName";         // Показываемое имя (например, "Свыше часа")
            cbPrice.ValueMember = "InventoryPriceId";   // Id, по которому мы будем тянуть цену для расчета

            //Кнопка на удаление инвентаря из списка выбранных
            Button btnRemove = new Button()
            {
                Text = "❌",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Cursor = Cursors.Hand,
                Size = new Size(30, 30),
                Location = new Point(1180, 10),
            };

            // Подписка на событие нажатия
            btnRemove.Click += (sender, e) =>
            {
                flpSelectedInventory.Controls.Remove(inventoryPanel);
                // Дополнительно: если у тебя есть список с selectedInventoryIds — удаляй оттуда
                inventoryIds.Remove(inventory.InventoryId);

                Count();
            };

            // Добавляем ярлыки в панель
            inventoryPanel.Controls.Add(lblInventoryName);
            inventoryPanel.Controls.Add(lblFilial);
            inventoryPanel.Controls.Add(lblStatus);
            // Добавляем данные в панель
            inventoryPanel.Controls.Add(lblFilialName);
            inventoryPanel.Controls.Add(lblStatusName);
            // Добавляем ярлык и данные для выбора тарифа
            inventoryPanel.Controls.Add(lblPrice);
            inventoryPanel.Controls.Add(cbPrice);
            // Добавляем кнопку в панель
            inventoryPanel.Controls.Add(btnRemove);

            flpSelectedInventory.Controls.Add(inventoryPanel);
        }

        public void LoadData()
        {
            //заполнение combobox клиентов

            ClientRepository _clientRepository = new ClientRepository(_connection);
            var clients = _clientRepository.GetAll();

            // Отображение в ComboBox
            cbClients.DataSource = null;
            cbClients.DataSource = clients;
            cbClients.DisplayMember = "Display";
            cbClients.ValueMember = "Id";
            cbClients.DropDownStyle = ComboBoxStyle.DropDown; // чтобы можно было вводить

            // Подсказки с поиском по вхождению
            AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(clients.Select(c => c.Display).ToArray());

            cbClients.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbClients.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbClients.AutoCompleteCustomSource = autoSource;



            //заполнение combobox залогов

            DepositRepository _depositRepository = new DepositRepository(_connection);
            var deposits = _depositRepository.GetAll();

            cbDeposit.DataSource = null;
            cbDeposit.DataSource = deposits;
            cbDeposit.DisplayMember = "Name";
            cbDeposit.ValueMember = "Id";


        }

        private void btnChooseInventory_Click(object sender, EventArgs e)
        {
            InventoryRepository _inventoryRepository = new InventoryRepository(_connection);
            InventorySelectForm inventorySelectForm = new InventorySelectForm(_inventoryRepository);

            //подписка на событие после открытия формы выбора
            inventorySelectForm.OnInventoriesChosen += ShowSelectedInventories;
            inventorySelectForm.ShowDialog();
        }

        private void ShowSelectedInventories(List<int> selectedIds)
        {
            InventoryRepository _inventoryRepository = new InventoryRepository(_connection);
            inventoryIds = selectedIds;
            foreach (int id in selectedIds)
            {
                var inv = _inventoryRepository.GetInventory(id);

                AddInventoryCard(inv);
            }
        }

        private void cbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show($"{cbClients.SelectedValue}");

            ClientRepository _clientRepository = new ClientRepository(_connection);

            selectedClient = cbClients.SelectedItem as Models.Client;

            lblForClient.Text = $"{selectedClient.Surname} {selectedClient.Name[0]}. {selectedClient.Patronymic[0]}.";

            clientId = selectedClient.Id;
        }

        private void cbClients_Leave(object sender, EventArgs e)
        {
            var text = cbClients.Text.ToLower();

            var matchedClient = clients
                .FirstOrDefault(c => c.Display.ToLower().Contains(text));

            if (matchedClient != null)
            {
                cbClients.SelectedItem = matchedClient;

                lblForClient.Text = $"{matchedClient.Surname} {matchedClient.Name[0]}. {matchedClient.Patronymic[0]}.";
                clientId = matchedClient.Id;
            }
            else
            {
                MessageBox.Show("Клиент не найден");
                cbClients.SelectedItem = null;
            }
        }


        private void btnCount_Click(object sender, EventArgs e)
        {
            total = 0;
            int totalMinutes = (int)(dtpEnd.Value - dtpStart.Value).TotalMinutes;
            totalMinutes += 1;

            InventoryPriceRepository _inventoryPriceRepository = new InventoryPriceRepository(_connection);

            foreach (Panel inventoryPanel in flpSelectedInventory.Controls)
            {
                var cbPrice = inventoryPanel.Controls.OfType<ComboBox>().FirstOrDefault(cb => cb.Name == "cbPrice");
                if (cbPrice?.SelectedValue is int inventoryPriceId)
                {
                    var selectedPrice = _inventoryPriceRepository.Get(inventoryPriceId);
                    if (selectedPrice != null)
                    {
                        if (selectedPrice.TimeName.ToLower().Contains("свыше часа"))
                        {
                            total += selectedPrice.Price * totalMinutes;
                        }
                        else
                        {
                            total += selectedPrice.Price;
                        }
                    }
                }
            }

            lblForPrice.Text = $"{total} ₽";

            // Подсчёт времени
            TimeSpan duration = dtpEnd.Value - dtpStart.Value;
            lblForTimePeriod.Text = $"{totalMinutes} минут";

            btnCreateRent.Enabled = true;
            btnCreateRent.BackColor = Color.LimeGreen;
        }

        public void Count()
        {
            total = 0;
            int totalMinutes = (int)(dtpEnd.Value - dtpStart.Value).TotalMinutes;

            InventoryPriceRepository _inventoryPriceRepository = new InventoryPriceRepository(_connection);

            foreach (Panel inventoryPanel in flpSelectedInventory.Controls)
            {
                var cbPrice = inventoryPanel.Controls.OfType<ComboBox>().FirstOrDefault(cb => cb.Name == "cbPrice");
                if (cbPrice?.SelectedValue is int inventoryPriceId)
                {
                    var selectedPrice = _inventoryPriceRepository.Get(inventoryPriceId);
                    if (selectedPrice != null)
                    {
                        if (selectedPrice.TimeName.ToLower().Contains("свыше часа"))
                            total += selectedPrice.Price * totalMinutes;
                        else
                            total += selectedPrice.Price;
                    }
                }
            }

            lblForPrice.Text = $"{total} ₽";

            // Подсчёт времени
            TimeSpan duration = dtpEnd.Value - dtpStart.Value;
            lblForTimePeriod.Text = $"{(int)duration.TotalMinutes} минут";

        }

        private void btnCreateRent_Click(object sender, EventArgs e)
        {
            string rentStatus = "";
            string inventoryStatus = "";
            if (dtpStart.Value > DateTime.Now)
            {
                rentStatus = "Забронирована";
                inventoryStatus = "Забронирован";
            }
            if (dtpStart.Value <= DateTime.Now)
            {
                rentStatus = "В процессе";
                inventoryStatus = "В аренде";
            }

            //Инициализация необходимых репозиториев
            FilialRepository _filialRepository = new FilialRepository(_connection);
            InventoryRepository _inventoryRepository = new InventoryRepository(_connection);

            int filialId = _filialRepository.GetFilialFromInventory(inventoryIds[0]);

            //Подсчет времени аренды в минутах
            int totalMinutes = (int)(dtpEnd.Value - dtpStart.Value).TotalMinutes;

            //Проверка правильности заполнения 
            if (totalMinutes == 0) { MessageBox.Show("Введено некорректное время."); return; }
            if (total <= 0) { MessageBox.Show("Указана некорректная сумма."); return; }
            if (inventoryIds.Count == 0) { MessageBox.Show("Не выбран ни один инвентарь."); return; }
            if (dtpEnd.Value == dtpStart.Value) { MessageBox.Show("Время начала и время конца аренды совпадают"); return; }
            if (clientId == 0) { MessageBox.Show("Не выбран клиент."); return; }
            if (filialId == 0) { MessageBox.Show("Филиал не выбран."); return; }
            if (cbDeposit.SelectedValue == null) { MessageBox.Show("Залог не выбран."); return; }

            try
            {
                Models.Rent rent = new Models.Rent()
                {
                    FilialId = filialId,
                    ClientId = clientId,
                    TimeStart = dtpStart.Value,
                    TimeEnd = dtpEnd.Value,
                    Total = total,
                    Status = rentStatus,
                    UserId = _user.Id,
                    DepositId = (int)cbDeposit.SelectedValue,
                };

                _rentRepository.Add(rent);
                int rentId = _rentRepository.GetRentId(rent);

                //
                // Создание в бд записей инвентарей связанных с арендой
                //

                foreach (Panel inventoryPanel in flpSelectedInventory.Controls)
                {
                    int inventoryId = (int)inventoryPanel.Tag;

                    var cbPrice = inventoryPanel.Controls
                        .OfType<ComboBox>()
                        .FirstOrDefault(cb => cb.Name == "cbPrice");

                    if (cbPrice?.SelectedValue == null)
                    {
                        MessageBox.Show($"Не выбран тариф для инвентаря с ID {inventoryId}.");
                        continue;
                    }

                    int priceId = (int)cbPrice.SelectedValue;

                    //Добавляем записть в Rent_Has_Inventory
                    _rentRepository.AddRentHasInventory(rentId, inventoryId, priceId);

                    //Обновляем статус инвентаря связанного с арендой
                    _inventoryRepository.ChangeInventoryStatus(inventoryId, inventoryStatus);
                }

                MessageBox.Show("Аренда добавлена!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return;
            }
        }

        private void cbClients_DropDown(object sender, EventArgs e)
        {
            ((ComboBox)sender).DroppedDown = false;
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            
            ClientAddForm clientAddForm = new ClientAddForm(_clientRepository, 0, "add");
            clientAddForm.ShowDialog();
        }
    }
}
