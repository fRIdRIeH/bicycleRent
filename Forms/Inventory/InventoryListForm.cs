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

namespace bicycleRent.Forms.Inventory
{
    public partial class InventoryListForm : Form
    {
        private readonly InventoryRepository _inventoryRepository;
        public InventoryListForm(InventoryRepository inventoryRepository)
        {
            InitializeComponent();
            _inventoryRepository = inventoryRepository;

            LoadData();

            flpInventory.AutoScroll = true;
            flpInventory.WrapContents = false;
            flpInventory.FlowDirection = FlowDirection.TopDown;
        }

        private void AddInventoryCard(Models.Inventory inventory)
        {
            Panel inventoryPanel = new Panel()
            {
                Tag = inventory.InventoryId,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(1220, 60),
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

        public void LoadData()
        {
            flpInventory.Controls.Clear();

            var inventories = _inventoryRepository.GetAllInventory();

            foreach (var inventory in inventories)
            {
                AddInventoryCard(inventory);
            }
        }
    }
}
