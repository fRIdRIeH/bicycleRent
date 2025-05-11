using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bicycleRent.Repositories;
using bicycleRent.Models;
using MySql.Data.MySqlClient;
using bicycleRent.Forms.Price;
using bicycleRent.Forms.Time;

namespace bicycleRent.Forms.InventoryPrice
{
    public partial class AddInventoryPrice : Form
    {
        private readonly MySqlConnection _connection;

        //инициируем репозитории
        private readonly InventoryRepository _inventoryRepository;
        private readonly PriceRepository _priceRepository;
        private readonly TimeRepository _timeRepository;
        private readonly InventoryPriceRepository _inventoryPriceRepository;

        int inventoryId = 0, priceId = 0, timeId = 0;

        private Panel _selectedInventoryPanel = null;
        private Panel _selectedPricePanel = null;
        private Panel _selectedTimePanel = null;

        public AddInventoryPrice(MySqlConnection connection)
        {
            InitializeComponent();

            this.TopMost = true;

            _connection = connection;

            _inventoryRepository = new InventoryRepository(_connection);
            _priceRepository = new PriceRepository(_connection);
            _timeRepository = new TimeRepository(_connection);
            _inventoryPriceRepository = new InventoryPriceRepository(_connection);

            LoadData();

            //
            // Настройки всех flowLayoutPanel
            //

            flpInventory.AutoScroll = true;
            flpInventory.WrapContents = false;
            flpInventory.FlowDirection = FlowDirection.TopDown;

            flpPrices.AutoScroll = true;
            flpPrices.WrapContents = false;
            flpPrices.FlowDirection = FlowDirection.TopDown;

            flpTimes.AutoScroll = true;
            flpTimes.WrapContents = false;
            flpTimes.FlowDirection = FlowDirection.TopDown;
        }

        public void LoadData()
        {
            //
            // До заполнения необходимо почистить, так как эта функция будет использоваться как обновление
            //

            flpInventory.Controls.Clear();
            flpPrices.Controls.Clear();
            flpTimes.Controls.Clear();

            //
            // Заполнение 
            //

            // Получение всех записей
            var invetories = _inventoryRepository.GetAllInventory();
            var prices = _priceRepository.GetAll();
            var times = _timeRepository.GetAll();

            // Заполнение всех flp
            foreach (var inventory in invetories)
            {
                AddInventoryCard(inventory);
            }
            foreach (var price in prices)
            {
                AddPriceCard(price);
            }
            foreach (var time in times)
            {
                AddTimeCard(time);
            }
        }

        //
        // Функция для заполнения flpInventory
        //
        private void AddInventoryCard(Models.Inventory inventory)
        {
            Panel inventoryPanel = new Panel()
            {
                Tag = inventory.InventoryId,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(1000, 60),
                Margin = new Padding(10),
                BackColor = Color.LightGray,
            };

            // Присвоение события нажатия на панель
            inventoryPanel.Click += inventoryPanel_Click;

            //
            // Ярлыки
            //

            Label lblInventoryId = new Label()
            {
                Text = "#",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true,
            };

            Label lblInventoryName = new Label()
            {
                Text = "Название:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(110, 10),
                AutoSize = true,
            };

            Label lblInventoryType = new Label()
            {
                Text = "Тип инвентаря:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(260, 10),
                AutoSize = true,
            };

            Label lblInventoryNumber = new Label()
            {
                Text = "Инвентарный номер:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(460, 10),
                AutoSize = true,
            };

            Label lblStatus = new Label()
            {
                Text = "Статус:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(660, 10),
                AutoSize = true,
            };

            Label lblFilialId = new Label()
            {
                Text = "Филиал",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(810, 10),
                AutoSize = true,
            };

            //Добавление ярлыков в панель
            inventoryPanel.Controls.Add(lblInventoryId);
            inventoryPanel.Controls.Add(lblInventoryName);
            inventoryPanel.Controls.Add(lblInventoryType);
            inventoryPanel.Controls.Add(lblInventoryNumber);
            inventoryPanel.Controls.Add(lblStatus);
            inventoryPanel.Controls.Add(lblFilialId);

            //
            // Данные
            //

            Label lblInventoryIdData = new Label()
            {
                Text = $"{inventory.InventoryId}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 35),
                AutoSize = true,
            };

            Label lblInventoryNameData = new Label()
            {
                Text = $"{inventory.InventoryName}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(110, 35),
                AutoSize = true,
            };

            Label lblInventoryTypeData = new Label()
            {
                Text = $"{inventory.InventoryTypeName}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(260, 35),
                AutoSize = true,
            };

            Label lblInventoryNumberData = new Label()
            {
                Text = $"{inventory.InventoryNumber}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(460, 35),
                AutoSize = true,
            };

            Label lblStatusData = new Label()
            {
                Text = $"{inventory.Status}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(660, 35),
                AutoSize = true,
            };

            Label lblFilialIdData = new Label()
            {
                Text = $"{inventory.FilialName}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(810, 35),
                AutoSize = true,
            };

            //Добавляем в панель
            inventoryPanel.Controls.Add(lblInventoryIdData);
            inventoryPanel.Controls.Add(lblInventoryNameData);
            inventoryPanel.Controls.Add(lblInventoryTypeData);
            inventoryPanel.Controls.Add(lblInventoryNumberData);
            inventoryPanel.Controls.Add(lblStatusData);
            inventoryPanel.Controls.Add(lblFilialIdData);

            //Добавляем панель в flpInventory
            flpInventory.Controls.Add(inventoryPanel);
        }

        //
        // Функция для заполнения flpTimes
        //
        private void AddTimeCard(Models.Time time)
        {
            Panel timePanel = new Panel()
            {
                Tag = time.Id,
                Size = new Size(470, 37),
                Margin = new Padding(10),
                BackColor = Color.LightGray,
            };

            // Присвоение события нажатия на панель
            timePanel.Click += timePanel_Click;

            // Ярлыки
            Label lblTimeId = new Label()
            {
                Text = "#:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true,
            };
            Label lblTimeLabel = new Label()
            {
                Text = "Период:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(120, 10),
                AutoSize = true,
            };

            //Добавление ярлыков в timePanel
            timePanel.Controls.Add(lblTimeId);
            timePanel.Controls.Add(lblTimeLabel);

            //Данные
            Label lblTimeIdData = new Label()
            {
                Text = $"{time.Id}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(30, 10),
                AutoSize = true,
            };
            Label lblTimeLabelData = new Label()
            {
                Text = $"{time.TimeLabel}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(200, 10),
                AutoSize = true,
            };
            timePanel.Controls.Add(lblTimeIdData);
            timePanel.Controls.Add(lblTimeLabelData);

            flpTimes.Controls.Add(timePanel);
        }

        //
        // Функция для заполнения flpPrice
        //
        private void AddPriceCard(Models.Price price)
        {
            Panel pricePanel = new Panel()
            {
                Tag = price.Id,
                Size = new Size(470, 37),
                Margin = new Padding(10),
                BackColor = Color.LightGray
            };

            // Присвоение события нажатия на панель
            pricePanel.Click += pricePanel_Click;

            // Ярлыки
            Label lblPriceId = new Label()
            {
                Text = "#",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true,
            };
            Label lblPriceAmount = new Label()
            {
                Text = "Стоимость:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(120, 10),
                AutoSize = true,
            };

            // Добавление ярлыков в pricePanel
            pricePanel.Controls.Add(lblPriceId);
            pricePanel.Controls.Add(lblPriceAmount);

            //Данные
            Label lblPriceIdData = new Label()
            {
                Text = $"{price.Id}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(30, 10),
                AutoSize = true,
            };
            Label lblPriceAmountData = new Label()
            {
                Text = $"{price.Amount} ₽",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(230, 10),
                AutoSize = true,
            };

            pricePanel.Controls.Add(lblPriceIdData);
            pricePanel.Controls.Add(lblPriceAmountData);

            flpPrices.Controls.Add(pricePanel);
        }

        //
        // События на кнопках
        //

        private void addInventory_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPrice_Click(object sender, EventArgs e)
        {
            PriceAddForm priceAddForm = new PriceAddForm(_connection);
            priceAddForm.ShowDialog();
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            TimeAddForm timeAddForm = new TimeAddForm(_connection);
            timeAddForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        //
        // События на нажатия на каждоый панели
        //

        private void inventoryPanel_Click(object sender, EventArgs e)
        {
            Panel inventoryPanel = sender as Panel;

            if (inventoryPanel != null && inventoryPanel.Tag is int iId)
            {
                if (_selectedInventoryPanel != null)
                {
                    _selectedInventoryPanel.BackColor = Color.LightGray;
                }

                inventoryPanel.BackColor = Color.DarkGreen;
                _selectedInventoryPanel = inventoryPanel;

                inventoryId = iId;
            }
        }

        private void pricePanel_Click(Object sender, EventArgs e)
        {
            Panel pricePanel = sender as Panel;

            if (pricePanel != null && pricePanel.Tag is int pId)
            {
                if (_selectedPricePanel != null)
                {
                    _selectedPricePanel.BackColor = Color.LightGray;
                }

                pricePanel.BackColor = Color.DarkGreen;
                _selectedPricePanel = pricePanel;

                priceId = pId;
            }
        }

        private void timePanel_Click(Object sender, EventArgs e)
        {
            Panel timePanel = sender as Panel;

            if (timePanel != null && timePanel.Tag is int tId)
            {
                if (_selectedTimePanel != null)
                {
                    _selectedTimePanel.BackColor = Color.LightGray;
                }

                timePanel.BackColor = Color.DarkGreen;
                _selectedTimePanel = timePanel;

                timeId = tId;
            }
        }

        private void btnAddInventoryPrice_Click(object sender, EventArgs e)
        {
            if (inventoryId == 0) { MessageBox.Show("Не выбран инвентарь!"); return; }
            if (priceId == 0) { MessageBox.Show("Не выбрана цена!"); return; }
            if (timeId == 0) { MessageBox.Show("Не выбрано время!"); return; }

            try
            {
                Models.InventoryPrice inventoryPrice = new Models.InventoryPrice() 
                {
                    PriceId = priceId,
                    TimeId = timeId,
                    InventoryId = inventoryId
                };

                _inventoryPriceRepository.Add(inventoryPrice);
                MessageBox.Show("Тариф добавлен!");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка! {ex.Message}");
            }
        }
    }
}
