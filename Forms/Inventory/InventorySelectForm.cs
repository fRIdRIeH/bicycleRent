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

namespace bicycleRent.Forms.Inventory
{
    public partial class InventorySelectForm : Form
    {
        //Список для выбранных id инвентарей
        public List<int> selectedInventoryIds = new List<int>();

        //Событие для передачи
        public event Action<List<int>> OnInventoriesChosen;

        InventoryRepository _inventoryRepository;
        public InventorySelectForm(InventoryRepository inventoryRepository)
        {
            InitializeComponent();
            _inventoryRepository = inventoryRepository;

            flpInventoryForSelect.Controls.Clear();
            LoadData();

            this.TopMost = true;
        }

        void inventoryPanel_Click(Object sender, EventArgs e)
        {
            Panel inventoryPanel = sender as Panel;

            var lastColor = Color.LightGray;

            if (inventoryPanel != null && inventoryPanel.Tag is int id)
            {
                //MessageBox.Show($"Нажата панель аренды с id = {id}");

                if(inventoryPanel.BackColor != Color.IndianRed)
                {
                    inventoryPanel.BackColor = Color.Aquamarine;

                    if (selectedInventoryIds.Contains(id))
                    {
                        selectedInventoryIds.Remove(id);
                        MessageBox.Show($"Удалена аренда с = {id}");
                        inventoryPanel.BackColor = Color.LightGray;
                    }
                    else
                    {
                        selectedInventoryIds.Add(id);
                    }
                }
            }
            else
            {
                if (inventoryPanel != null && inventoryPanel.BackColor == Color.Aquamarine)
                {
                    inventoryPanel.BackColor = lastColor;
                }
            }
        }

        private void AddInventoryCard(Models.Inventory inventory)
        {
            Panel inventoryPanel = new Panel()
            {
                Tag = inventory.InventoryId,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGray,
                Size = new Size(1220, 100),
            };

            inventoryPanel.Click += new EventHandler(inventoryPanel_Click);

            //От статуса зависит задний фон панели

            switch (inventory.Status)
            {
                case "В аренде":
                    inventoryPanel.BackColor = Color.IndianRed;
                    break;
                case "Забронирован":
                    inventoryPanel.BackColor = Color.CadetBlue;
                    break;
            }


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

            inventoryPanel.Controls.Add(lblInventoryName);
            inventoryPanel.Controls.Add(lblFilial);
            inventoryPanel.Controls.Add(lblStatus);

            inventoryPanel.Controls.Add(lblFilialName);
            inventoryPanel.Controls.Add(lblStatusName);

            flpInventoryForSelect.Controls.Add(inventoryPanel);
        }

        public void LoadData()
        {
            var inventoryList = _inventoryRepository.GetAllInventory();

            foreach (var inventory in inventoryList)
            {
                AddInventoryCard(inventory);
            }
        }

        private void btnSendAndClose_Click(object sender, EventArgs e)
        {
            OnInventoriesChosen?.Invoke(selectedInventoryIds);
            this.Close(); // Закрываем форму после выбора
        }
    }
}
