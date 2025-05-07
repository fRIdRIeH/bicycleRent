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
using bicycleRent.Repositories;
using MySql.Data.MySqlClient;

namespace bicycleRent.Forms.Rent
{
    public partial class RentEditForm : Form
    {
        private readonly RentRepository _rentRepository;
        private readonly Models.User _user;
        private readonly MySqlConnection _connection;
        Models.Client selectedClient;
        List<int> inventoryIds = new List<int>();
        TimeSpan duration;
        decimal total = 0;
        int clientId = 0;
        int _idFromMainForm;
        string _key;
        private List<int> _selectedInventoryIds = new();
        private Dictionary<int, int> _selectedPrices = new(); // key = InventoryId, value = InventoryPriceId

        public RentEditForm(RentRepository rentRepository, Models.User user, MySqlConnection connection, int idFormMain, string key)
        {
            InitializeComponent();
            this.TopMost = true;
            this._rentRepository = rentRepository;
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

        private void AddInventoryCard(Models.Inventory inventory, int selectedPriceId)
        {
            Panel inventoryPanel = new Panel()
            {
                Tag = inventory.InventoryId,
                BorderStyle = BorderStyle.FixedSingle,
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

            //foreach (var price in prices)
            //    MessageBox.Show($"InventoryPriceId: {price.InventoryPriceId} — {price.TimeName}");

            //оно должно подставлять выбранный ранее тариф, но оно этого не делает
            cbPrice.SelectedValue = selectedPriceId;

            //bool found = prices.Any(p => p.InventoryPriceId == selectedPriceId);
            //MessageBox.Show($"Найдено: {found} ТарифId: {selectedPriceId}");


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

            cbPrice.SelectedValue = selectedPriceId;

            // Добавляем кнопку в панель
            inventoryPanel.Controls.Add(btnRemove);

            flpSelectedInventory.Controls.Add(inventoryPanel);
        }

        public void LoadData()
        {
            //заполнение combobox клиентов

            ClientRepository _clientRepository = new ClientRepository(_connection);
            var clients = _clientRepository.GetAll();

            cbClients.DataSource = null;
            cbClients.DataSource = clients;
            cbClients.DisplayMember = "Telephone";
            cbClients.ValueMember = "Id";

            cbClients.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbClients.AutoCompleteSource = AutoCompleteSource.ListItems;

            //заполнение combobox залогов

            DepositRepository _depositRepository = new DepositRepository(_connection);
            var deposits = _depositRepository.GetAll();

            cbDeposit.DataSource = null;
            cbDeposit.DataSource = deposits;
            cbDeposit.DisplayMember = "Name";
            cbDeposit.ValueMember = "Id";

            //Заполнение ячеек на форме из аренды
            if (_key == "editRent")
            {
                //Заполнение списка инвентарей
                Models.Rent rent = _rentRepository.Get(_idFromMainForm);

                InventoryRepository _inventoryRepository = new InventoryRepository(_connection);
                var inventoryList = _inventoryRepository.GetInventoryIdsForRent(rent.RentId);
                _selectedPrices = _rentRepository.GetSelectedPricesByRentId(rent.RentId);

                ShowSelectedInventories(inventoryList);
                

                //Заполнение клиента
                var client = _clientRepository.Get(rent.ClientId);

                cbClients.SelectedValue = client.Id;

                //Заполнение времени
                dtpStart.Value = rent.TimeStart;
                dtpEnd.Value = rent.TimeEnd;


                //Подсчеты
                Count();
            }
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

            //foreach (int id in selectedIds)
            //{
            //    var inv = _inventoryRepository.GetInventory(id);

            //    AddInventoryCard(inv);
            //}

            foreach (int id in selectedIds)
            {
                if (!_selectedInventoryIds.Contains(id))
                    _selectedInventoryIds.Add(id); // добавляем только новые

                var inv = _inventoryRepository.GetInventory(id);
                if (_selectedPrices.TryGetValue(inv.InventoryId, out int selectedPriceId))
                {
                    //MessageBox.Show($"{inv.InventoryId} = {selectedPriceId}");
                    AddInventoryCard(inv, selectedPriceId);
                }
                else
                {
                    AddInventoryCard(inv, 0); // для новых
                }
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

        private void btnCount_Click(object sender, EventArgs e)
        {
            total = 0;
            int totalMinutes = (int)(dtpEnd.Value - dtpStart.Value).TotalMinutes;
            totalMinutes += 1;

            MessageBox.Show($"totalMinutes: {totalMinutes}");

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

            MessageBox.Show($"Total: {total}");

            lblForPrice.Text = $"{total} ₽";

            // Подсчёт времени
            TimeSpan duration = dtpEnd.Value - dtpStart.Value;
            lblForTimePeriod.Text = $"{totalMinutes} минут";

            btnCreateRent.Enabled = true;
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
            string status = "";
            if (dtpStart.Value > DateTime.Now)
            {
                status = "Забронирована";
            }
            if (dtpStart.Value <= DateTime.Now)
            {
                status = "В процессе";
            }

            FilialRepository _filialRepository = new FilialRepository(_connection);


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
                    Status = status,
                    UserId = _user.Id,
                    DepositId = (int)cbDeposit.SelectedValue,
                };

                _rentRepository.Add(rent);
                int rentId = _rentRepository.GetRentId(rent);

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

                    _rentRepository.AddRentHasInventory(rentId, inventoryId, priceId);
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

        private void ApplySelectedPrices()
        {
            foreach (Panel inventoryPanel in flpSelectedInventory.Controls)
            {
                if (inventoryPanel.Tag is int inventoryId &&
                    _selectedPrices.TryGetValue(inventoryId, out int selectedPriceId))
                {
                    var cbPrice = inventoryPanel.Controls
                        .OfType<ComboBox>()
                        .FirstOrDefault(cb => cb.Name == "cbPrice");

                    if (cbPrice != null)
                    {
                        cbPrice.BeginInvoke((MethodInvoker)(() =>
                        {
                            cbPrice.SelectedValue = selectedPriceId;
                        }));
                    }
                }
            }
        }

        private void RentEditForm_Shown(object sender, EventArgs e)
        {
            ApplySelectedPrices();
        }


    }
}
