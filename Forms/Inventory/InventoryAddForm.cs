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
using MySql.Data.MySqlClient;

namespace bicycleRent.Forms.Inventory
{
    public partial class InventoryAddForm : Form
    {
        MySqlConnection _connection;
        InventoryRepository _inventoryRepository;
        InventoryTypeRepository _inventoryTypeRepository;
        FilialRepository _filialRepository;
        public InventoryAddForm(MySqlConnection connection)
        {
            InitializeComponent();

            this.TopMost = true;

            _connection = connection;

            _inventoryRepository = new InventoryRepository(_connection);
            _inventoryTypeRepository = new InventoryTypeRepository(_connection);
            _filialRepository = new FilialRepository(_connection);
        }
        
        public void LoadData()
        {
            // Для начала очищаем

            flpInventoryType.Controls.Clear();
            flpFilial.Controls.Clear();

            // Получаем с бд данные

            var types = _inventoryTypeRepository.GetAll();
            var filials = _filialRepository.GetAll();
        }

        //
        // Создание карточки типа инвентаря
        //
        private void AddInventoryTypeCard(Models.InventoryType inventoryType)
        {
            Panel inventoryTypePanel = new Panel() 
            {
                Tag = inventoryType.Id,
                Size = new Size(250, 55),
                Margin = new Padding(10),
                BackColor = Color.LightGray,
            };

            inventoryTypePanel.Click += InventoryTypePanel_Click;

            // Ярлыки
            Label lblinventoryTypeId = new Label() 
            {
                Text = "#:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };
            Label lblinventoryTypeName = new Label()
            {
                Text = "Тип инвентаря:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(55, 10),
                AutoSize = true
            };

            // Добавляем ярлыки в панель

            inventoryTypePanel.Controls.Add(lblinventoryTypeId);
            inventoryTypePanel.Controls.Add(lblinventoryTypeName);

            Label lblInventoryTypeIdData = new Label()
            {
                Text = $"{inventoryType.Id}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 35),
                AutoSize = true
            };
            Label lnlInventoryTypeNameData = new Label()
            {
                Text = $"{inventoryType.Name}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(55, 35),
                AutoSize = true
            };

            inventoryTypePanel.Controls.Add(lblInventoryTypeIdData);
            inventoryTypePanel.Controls.Add(lnlInventoryTypeNameData);

            // Добавляем панель в flpInventoryType

            flpInventoryType.Controls.Add(lblInventoryTypeIdData);
        }


        //
        // Создание карточки 
        //
        private void AddFilialCard(Models.Filial filial)
        {
            Panel filialPanel = new Panel()
            {
                Tag= filial.Id,
                Size = new Size(510, 55),
                Margin = new Padding(10),
                BackColor = Color.LightGray,
            };

            filialPanel.Click += FilialPanel_Click;
        }

        //
        // События нажатия на панели
        //
        private void InventoryTypePanel_Click(object sender, EventArgs e) 
        {
        
        }
        private void FilialPanel_Click(Object sender, EventArgs e)
        {

        }
    }
}
