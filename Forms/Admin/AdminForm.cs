using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bicycleRent.Forms.Deposit;
using bicycleRent.Forms.Filial;
using bicycleRent.Forms.Inventory;
using bicycleRent.Forms.InventoryPrice;
using bicycleRent.Forms.InventoryType;
using bicycleRent.Forms.User;
using bicycleRent.Models;
using bicycleRent.Repositories;
using MySql.Data.MySqlClient;

namespace bicycleRent.Forms.Admin
{
    public partial class AdminForm : Form
    {
        private readonly MySqlConnection _connection;
        public AdminForm(MySqlConnection connection)
        {
            InitializeComponent();
            this.TopMost = true;

            _connection = connection;

            //this.WindowState = FormWindowState.Maximized;
        }

        private void GoToInventoryAddFormBtn_Click(object sender, EventArgs e)
        {
            InventoryAddForm inventoryAddForm = new InventoryAddForm(_connection, 0, "add");
            inventoryAddForm.ShowDialog();
        }

        private void GoToUserAddFormBtn_Click(object sender, EventArgs e)
        {
            UserAddForm userAddForm = new UserAddForm(_connection, 0, "add");
            userAddForm.ShowDialog();
        }

        private void GoToDepositAddFormAdd_Click(object sender, EventArgs e)
        {
            DepositAddForm depositAddForm = new DepositAddForm(_connection, 0, "add");
            depositAddForm.ShowDialog();
        }

        private void GoToInventoryTypeAddFormBtn_Click(object sender, EventArgs e)
        {
            InventoryTypeAddForm inventoryTypeAddForm = new InventoryTypeAddForm(_connection, 0, "add");
            inventoryTypeAddForm.ShowDialog();
        }

        private void GoToFilialAddFormBtn_Click(object sender, EventArgs e)
        {
            FilialAddForm filialAddForm = new FilialAddForm(_connection, 0 , "add");
            filialAddForm.ShowDialog();
        }

        private void btnAddPrice_Click(object sender, EventArgs e)
        {
            AddInventoryPrice addInventoryPrice = new AddInventoryPrice(_connection);
            addInventoryPrice.ShowDialog();
        }

        private void ShowMeInventoryBtn_Click(object sender, EventArgs e)
        {
            flp.Controls.Clear();

            InventoryRepository inventoryRepository = new InventoryRepository(_connection);

            var inventories = inventoryRepository.GetAllInventoryForAdmin();

            foreach(var inventory in inventories)
            {
                AddInventoryCard(inventory);
            }
        }

        private void ShowMeClientsBtn_Click(object sender, EventArgs e)
        {

        }

        private void ShowMeRentForTodayBtn_Click(object sender, EventArgs e)
        {

        }

        private void ShowMeFilialsBtn_Click(object sender, EventArgs e)
        {

        }

        private void ShowMeWorkersBtn_Click(object sender, EventArgs e)
        {

        }

        //
        // Панель инвентаря
        //
        private void AddInventoryCard(Models.Inventory inventory)
        {
            Panel inventoryPanel = new Panel()
            {
                Tag = inventory.InventoryId,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(1260, 60),
                Margin = new Padding(10),
                BackColor = Color.LightGray,
            };

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

            Label lblRentsCount = new Label()
            {
                Text = "Кол-во аренд:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(950, 10),
                AutoSize = true,
            };

            Label lblTotal = new Label()
            {
                Text = "Прибыль:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(1100, 10),
                AutoSize = true,
            };

            //Добавление ярлыков в панель
            inventoryPanel.Controls.Add(lblInventoryId);
            inventoryPanel.Controls.Add(lblInventoryName);
            inventoryPanel.Controls.Add(lblInventoryType);
            inventoryPanel.Controls.Add(lblInventoryNumber);
            inventoryPanel.Controls.Add(lblStatus);
            inventoryPanel.Controls.Add(lblFilialId);
            inventoryPanel.Controls.Add(lblRentsCount);
            inventoryPanel.Controls.Add(lblTotal);

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

            Label lblRentsCountData = new Label()
            {
                Text = $"{inventory.InventoryRentsCount}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(950, 35),
                AutoSize = true,
            };

            Label lblTotalData = new Label()
            {
                Text = $"{inventory.InventoryTotal}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(1100, 35),
                AutoSize = true,
            };

            //Добавляем в панель
            inventoryPanel.Controls.Add(lblInventoryIdData);
            inventoryPanel.Controls.Add(lblInventoryNameData);
            inventoryPanel.Controls.Add(lblInventoryTypeData);
            inventoryPanel.Controls.Add(lblInventoryNumberData);
            inventoryPanel.Controls.Add(lblStatusData);
            inventoryPanel.Controls.Add(lblFilialIdData);
            inventoryPanel.Controls.Add(lblRentsCountData);
            inventoryPanel.Controls.Add(lblTotalData);

            // Кнопка на редактирование

            Button btnEditInventory = new Button()
            {
                Text = "✎",
                Font = new Font("Segue UI", 20, FontStyle.Bold),
                Location = new Point(1200, 5),
                Cursor = Cursors.Hand,
                Size = new Size(50, 50),
                Tag = inventoryPanel
            };

            btnEditInventory.Click += btnEditInventory_Click;

            inventoryPanel.Controls.Add(btnEditInventory);

            //Добавляем панель в flpInventory
            flp.Controls.Add(inventoryPanel);
        }

        private void AddClientCard(Models.Client client)
        {

        }

        private void AddUserCard(Models.User user)
        {

        }

        private void AddRentCard(Models.Rent rent)
        {

        }

        private void AddFilialCard(Models.Filial filial) 
        {
        
        }

        // События на кнопках

        private void btnEditInventory_Click(object sender, EventArgs e) 
        {
            if (sender is Button btn && btn.Tag is Panel inventoryPanel && inventoryPanel.Tag is int iId) 
            {
                //MessageBox.Show($"{iId}");

                InventoryAddForm inventoryAddForm = new InventoryAddForm(_connection, iId, "edit");
                inventoryAddForm.ShowDialog();
            }
        }
    }
}
