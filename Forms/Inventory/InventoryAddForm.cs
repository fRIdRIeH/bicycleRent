using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bicycleRent.Forms.Client;
using bicycleRent.Forms.Filial;
using bicycleRent.Forms.InventoryType;
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

        int filialId = 0, inventoryTypeId = 0;

        private Panel _selectedInventoryTypePanel = null;
        private Panel _selectedfilialPanel = null;

        public InventoryAddForm(MySqlConnection connection)
        {
            InitializeComponent();

            this.TopMost = true;

            _connection = connection;

            _inventoryRepository = new InventoryRepository(_connection);
            _inventoryTypeRepository = new InventoryTypeRepository(_connection);
            _filialRepository = new FilialRepository(_connection);

            LoadData();
        }

        public void LoadData()
        {
            // Для начала очищаем

            flpInventoryType.Controls.Clear();
            flpFilial.Controls.Clear();

            // Получаем с бд данные

            var types = _inventoryTypeRepository.GetAll();
            var filials = _filialRepository.GetAll();

            // Записываем в flp

            foreach (var type in types)
            {
                AddInventoryTypeCard(type);
            }

            foreach (var filial in filials)
            {
                AddFilialCard(filial);
            }
        }

        //
        // Создание карточки типа инвентаря
        //
        private void AddInventoryTypeCard(Models.InventoryType inventoryType)
        {
            Panel inventoryTypePanel = new Panel()
            {
                Tag = inventoryType.Id,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(480, 55),
                Margin = new Padding(10),
                BackColor = Color.LightGray,
            };

            inventoryTypePanel.Click += InventoryTypePanel_Click;

            // Ярлыки
            Label lblinventoryTypeId = new Label()
            {
                Text = "#:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 5),
                AutoSize = true
            };
            Label lblinventoryTypeName = new Label()
            {
                Text = "Тип инвентаря:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(55, 5),
                AutoSize = true
            };

            // Добавляем ярлыки в панель

            inventoryTypePanel.Controls.Add(lblinventoryTypeId);
            inventoryTypePanel.Controls.Add(lblinventoryTypeName);

            Label lblInventoryTypeIdData = new Label()
            {
                Text = $"{inventoryType.Id}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 30),
                AutoSize = true
            };
            Label lnlInventoryTypeNameData = new Label()
            {
                Text = $"{inventoryType.Name}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(55, 30),
                AutoSize = true
            };

            inventoryTypePanel.Controls.Add(lblInventoryTypeIdData);
            inventoryTypePanel.Controls.Add(lnlInventoryTypeNameData);

            //Кнопка редактирования
            Button btnEditType = new Button()
            {
                Text = "✎",
                Font = new Font("Segue UI", 20, FontStyle.Bold),
                Location = new Point(425, 2),
                Cursor = Cursors.Hand,
                Size = new Size(50, 50),
                Tag = inventoryTypePanel
            };

            btnEditType.Click += BtnEditType_Click;

            inventoryTypePanel.Controls.Add(btnEditType);

            // Добавляем панель в flpInventoryType

            flpInventoryType.Controls.Add(inventoryTypePanel);
        }


        //
        // Создание карточки 
        //
        private void AddFilialCard(Models.Filial filial)
        {
            Panel filialPanel = new Panel()
            {
                Tag = filial.Id,
                Size = new Size(670, 55),
                Margin = new Padding(10),
                BackColor = Color.LightGray,
            };

            filialPanel.Click += FilialPanel_Click;

            //Ярлыки
            Label lblFilialId = new Label()
            {
                Text = "#:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 5),
                AutoSize = true
            };
            Label lblFilialName = new Label()
            {
                Text = "Название:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(55, 5),
                AutoSize = true
            };
            Label lblFilialAddress = new Label()
            {
                Text = "Адрес:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(220, 5),
                AutoSize = true
            };

            filialPanel.Controls.Add(lblFilialId);
            filialPanel.Controls.Add(lblFilialName);
            filialPanel.Controls.Add(lblFilialAddress);

            //Данные
            Label lblFilialIdData = new Label()
            {
                Text = $"{filial.Id}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 30),
                AutoSize = true
            };
            Label lblFilialNameData = new Label()
            {
                Text = $"{filial.Name}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(55, 30),
                AutoSize = true
            };
            Label lblFilialAddressData = new Label()
            {
                Text = $"{filial.Address}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(220, 30),
                AutoSize = true
            };

            filialPanel.Controls.Add(lblFilialIdData);
            filialPanel.Controls.Add(lblFilialNameData);
            filialPanel.Controls.Add(lblFilialAddressData);

            //Кнопки редактирования
            Button btnEditFilial = new Button()
            {
                Text = "✎",
                Font = new Font("Segue UI", 20, FontStyle.Bold),
                Location = new Point(615, 2),
                Cursor = Cursors.Hand,
                Size = new Size(50, 50),
                Tag = filialPanel
            };

            btnEditFilial.Click += BtnEditFilial_Click;

            filialPanel.Controls.Add(btnEditFilial);

            flpFilial.Controls.Add(filialPanel);
        }

        //
        // События нажатия на панели
        //
        private void InventoryTypePanel_Click(object sender, EventArgs e)
        {
            Panel inventoryTypePanel = sender as Panel;

            if (inventoryTypePanel != null && inventoryTypePanel.Tag is int itId)
            {
                if (_selectedInventoryTypePanel != null)
                {
                    _selectedInventoryTypePanel.BackColor = Color.LightGray;
                }

                inventoryTypePanel.BackColor = Color.DarkGreen;
                _selectedInventoryTypePanel = inventoryTypePanel;

                inventoryTypeId = itId;
            }
        }
        private void FilialPanel_Click(Object sender, EventArgs e)
        {
            Panel filialPanel = sender as Panel;

            if (filialPanel != null && filialPanel.Tag is int fId)
            {
                if (_selectedfilialPanel != null)
                {
                    _selectedfilialPanel.BackColor = Color.LightGray;
                }

                filialPanel.BackColor = Color.DarkGreen;
                _selectedfilialPanel = filialPanel;

                filialId = fId;
            }
        }
        //
        // События нажатия на кнопки редактирования
        //
        private void BtnEditType_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Panel inventoryTypePanel && inventoryTypePanel.Tag is int itId)
            {
                //Открываем форму редактирования данных о типе инвентаря
                InventoryTypeAddForm inventoryTypeAddForm = new InventoryTypeAddForm(_connection, itId, "edit");
                inventoryTypeAddForm.ShowDialog();
            }
        }
        private void BtnEditFilial_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Panel filialPanel && filialPanel.Tag is int fId)
            {
                //Открываем форму редактирования данных о филиале
                FilialAddForm filialAddForm = new FilialAddForm(_connection, fId, "edit");
                filialAddForm.ShowDialog();
            }
        }

        private void btnAddInventoryType_Click(object sender, EventArgs e)
        {
            InventoryTypeAddForm inventoryTypeAddForm = new InventoryTypeAddForm(_connection, 0, "add");
            inventoryTypeAddForm.ShowDialog();
        }

        private void btnAddFilial_Click(object sender, EventArgs e)
        {
            FilialAddForm filialAddForm = new FilialAddForm(_connection, 0, "add");
            filialAddForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            if (txtInventoryName.Text == "") { MessageBox.Show("Поле 'Название инвентаря' должно быть заполнено."); return; }
            if (numInventoryNumber.Value == 0) { MessageBox.Show("Поле 'Инвнтарный номер' должно быть заполнено."); return; }

            if (txtInventoryName.Text.Length > 20) { MessageBox.Show("Поле 'Название инвентаря' не должно быть длиннее 20 символов"); return; }

            if (filialId == 0) { MessageBox.Show("Не выбран филиал."); return; }
            if (inventoryTypeId == 0) { MessageBox.Show("Не выбран тип инвентаря."); return; }

            try
            {
                Models.Inventory inventory = new Models.Inventory() 
                {
                    InventoryName = txtInventoryName.Text,
                    InventoryTypeId = inventoryTypeId,
                    InventoryNumber = (int)numInventoryNumber.Value,
                    FilialId = filialId,
                };

                _inventoryRepository.Add(inventory);
                MessageBox.Show("Инвентарь успешно добавлен!");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Возникла ошибка! {ex.Message}");
            }
        }
    }
}
