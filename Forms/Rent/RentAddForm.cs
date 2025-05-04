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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using MySqlX.XDevAPI;

namespace bicycleRent.Forms.Rent
{
    public partial class RentAddForm : Form
    {
        private readonly RentRepository _rentRepository;
        private readonly Models.User _user;
        private readonly MySqlConnection _connection;
        public RentAddForm(RentRepository rentRepository, Models.User user, MySqlConnection connection)
        {
            InitializeComponent();
            this.TopMost = true;
            this._rentRepository = rentRepository;
            this._user = user;
            this._connection = connection;

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
            cbPrice.DisplayMember = "TimeName";    // Показываемое имя (например, "Свыше часа")
            cbPrice.ValueMember = "Price";         // Значение, которое будем использовать в расчётах

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
            foreach (int id in selectedIds)
            {
                var inv = _inventoryRepository.GetInventory(id);

                AddInventoryCard(inv);
            }
        }

        private void cbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show($"{cbClients.SelectedValue}");
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            int totalMinutes = (int)(dtpEnd.Value - dtpStart.Value).TotalMinutes;

            //MessageBox.Show(totalMinutes.ToString());

            foreach (Panel inventoryPanel in flpSelectedInventory.Controls)
            {
                var cbPrice = inventoryPanel.Controls.OfType<ComboBox>().FirstOrDefault(cb => cb.Name == "cbPrice");
                if (cbPrice?.SelectedItem is InventoryPrice selectedPrice)
                {
                    if (selectedPrice.TimeName.ToLower().Contains("свыше часа"))
                        total += selectedPrice.Price * totalMinutes;
                    else
                        total += selectedPrice.Price;
                }
            }

            lblForPrice.Text = $"{total} ₽";

            lblForClient.Text = $"fsdfsdfsd";
        }
    }
}
