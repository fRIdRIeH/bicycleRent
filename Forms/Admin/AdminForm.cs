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
            flp.Controls.Clear();

            ClientRepository clientRepository = new ClientRepository(_connection);

            var clients = clientRepository.GetAll();

            foreach(var client in clients)
            {
                AddClientCard(client);
            }
        }

        private void ShowMeRentForTodayBtn_Click(object sender, EventArgs e)
        {

        }

        private void ShowMeFilialsBtn_Click(object sender, EventArgs e)
        {

        }

        private void ShowMeWorkersBtn_Click(object sender, EventArgs e)
        {
            flp.Controls.Clear();

            UserRepository userRepository = new UserRepository(_connection);

            var workers = userRepository.GetAll();

            foreach (var worker in workers) 
            {
                AddUserCard(worker);
            }
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
            Panel clientPanel = new Panel()
            {
                Tag = client.Id,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(1220, 60),
                Margin = new Padding(10),
                BackColor = Color.LightGray,
            };

            //
            // Ярлыки
            //

            int lblYpos = 5;

            // id клиента
            Label lblClientId = new Label()
            {
                Text = "#:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, lblYpos),
                AutoSize = true,
            };
            // Фамилия клиента 
            Label lblClientSurname = new Label()
            {
                Text = "Фамилия:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(100, lblYpos),
                AutoSize = true,
            };
            // Имя клиента
            Label lblClientName = new Label()
            {
                Text = "Имя:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(260, lblYpos),
                AutoSize = true,
            };
            // Отчетство клиента
            Label lblClientPatronymic = new Label()
            {
                Text = "Отчество:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(410, lblYpos),
                AutoSize = true,
            };
            // Номер телефона
            Label lblClientTelephone = new Label()
            {
                Text = "Телефон:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(610, lblYpos),
                AutoSize = true,
            };
            Label lblVisitCount = new Label()
            {
                Text = "Количество посещений::",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(750, lblYpos),
                AutoSize = true,
            };
        

            //Добавление элементов в clientPanel
            clientPanel.Controls.Add(lblClientId);
            clientPanel.Controls.Add(lblClientSurname);
            clientPanel.Controls.Add(lblClientName);
            clientPanel.Controls.Add(lblClientPatronymic);
            clientPanel.Controls.Add(lblClientTelephone);
            clientPanel.Controls.Add(lblVisitCount);

            //
            // Данные
            //

            // id клиента
            Label lblClientIdData = new Label()
            {
                Text = $"{client.Id}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, lblYpos + 25),
                AutoSize = true,
            };
            // Фамилия клиента 
            Label lblClientSurnameData = new Label()
            {
                Text = $"{client.Surname}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(100, lblYpos + 25),
                AutoSize = true,
            };
            // Имя клиента
            Label lblClientNameData = new Label()
            {
                Text = $"{client.Name}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(260, lblYpos + 25),
                AutoSize = true,
            };
            // Отчетство клиента
            Label lblClientPatronymicData = new Label()
            {
                Text = $"{client.Patronymic}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(410, lblYpos + 25),
                AutoSize = true,
            };
            // Номер телефона
            Label lblClientTelephoneData = new Label()
            {
                Text = $"{client.Telephone}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(610, lblYpos + 25),
                AutoSize = true,
            };
            Label lblVisitCountData = new Label()
            {
                Text = $"{client.VisitCount}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(750, lblYpos + 25),
                AutoSize = true,
            };


            //Кнопки
            Button btnEdit = new Button()
            {
                Text = "✎",
                Font = new Font("Segue UI", 20, FontStyle.Bold),
                Location = new Point(1150, 5),
                Cursor = Cursors.Hand,
                Size = new Size(50, 50),
                Tag = clientPanel
            };
            Button btnDelete = new Button()
            {
                Text = "❌",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Cursor = Cursors.Hand,
                Size = new Size(50, 50),
                Location = new Point(1100, 5),
                BackColor = Color.LightGray,
                Tag = clientPanel
            };

            //привязка событий нажатия на кнопку
            btnEdit.Click += btnEditClient_Click;

            //добавление элементов в панель
            clientPanel.Controls.Add(lblClientIdData);
            clientPanel.Controls.Add(lblClientSurnameData);
            clientPanel.Controls.Add(lblClientNameData);
            clientPanel.Controls.Add(lblClientPatronymicData);
            clientPanel.Controls.Add(lblClientTelephoneData);
            clientPanel.Controls.Add(lblVisitCountData);

            clientPanel.Controls.Add(btnEdit);

            //Добавление панели в flowlayoutpanel
            flp.Controls.Add(clientPanel);
        }

        private void AddUserCard(Models.User user)
        {
            Panel userPanel = new Panel()
            {
                Tag = user.Id,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(1260, 60),
                Margin = new Padding(10),
                BackColor = Color.LightGray,
            };

            //Ярлыки
            int lblYpos = 5;

            Label lblUserId = new Label()
            {
                Text = "#:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, lblYpos),
                AutoSize = true,
            };
            // Фамилия клиента 
            Label lblUserSurname = new Label()
            {
                Text = "Фамилия:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(100, lblYpos),
                AutoSize = true,
            };
            // Имя клиента
            Label lblUserName = new Label()
            {
                Text = "Имя:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(260, lblYpos),
                AutoSize = true,
            };
            // Отчетство клиента
            Label lblUserPatronymic = new Label()
            {
                Text = "Отчество:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(410, lblYpos),
                AutoSize = true,
            };
            // Номер телефона
            Label lblUserTelephone = new Label()
            {
                Text = "Телефон:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(610, lblYpos),
                AutoSize = true,
            };
            Label lblUserLogin = new Label()
            {
                Text = "Логин:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(750, lblYpos),
                AutoSize = true,
            };
            // Номер телефона
            Label lblUserPassword = new Label()
            {
                Text = "Пароль:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(900, lblYpos),
                AutoSize = true,
            };

            userPanel.Controls.Add(lblUserId);
            userPanel.Controls.Add(lblUserSurname);
            userPanel.Controls.Add(lblUserName);
            userPanel.Controls.Add(lblUserPatronymic);
            userPanel.Controls.Add(lblUserTelephone);
            userPanel.Controls.Add(lblUserLogin);
            userPanel.Controls.Add(lblUserPassword);

            //Данные

            lblYpos += 25;

            Label lblUserIdData = new Label()
            {
                Text = $"{user.Id}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, lblYpos),
                AutoSize = true,
            };
            // Фамилия клиента 
            Label lblUserSurnameData = new Label()
            {
                Text = $"{user.Surname}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(100, lblYpos),
                AutoSize = true,
            };
            // Имя клиента
            Label lblUserNameData = new Label()
            {
                Text = $"{user.Name}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(260, lblYpos),
                AutoSize = true,
            };
            // Отчетство клиента
            Label lblUserPatronymicData = new Label()
            {
                Text = $"{user.Patronymic}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(410, lblYpos),
                AutoSize = true,
            };
            // Номер телефона
            Label lblUserTelephoneData = new Label()
            {
                Text = $"{user.Telephone}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(610, lblYpos),
                AutoSize = true,
            };
            Label lblUserLoginData = new Label()
            {
                Text = $"{user.Login}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(750, lblYpos),
                AutoSize = true,
            };
            // Номер телефона
            Label lblUserPasswordData = new Label()
            {
                Text = $"{user.Password}",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(900, lblYpos),
                AutoSize = true,
            };

            userPanel.Controls.Add(lblUserIdData);
            userPanel.Controls.Add(lblUserSurnameData);
            userPanel.Controls.Add(lblUserNameData);
            userPanel.Controls.Add(lblUserPatronymicData);
            userPanel.Controls.Add(lblUserTelephoneData);
            userPanel.Controls.Add(lblUserLoginData);
            userPanel.Controls.Add(lblUserPasswordData);

            //Кнопка редактирования
            //Кнопки
            Button btnEditUser = new Button()
            {
                Text = "✎",
                Font = new Font("Segue UI", 20, FontStyle.Bold),
                Location = new Point(1140, 5),
                Cursor = Cursors.Hand,
                Size = new Size(50, 50),
                Tag = userPanel
            };
            Button btnDeleteUser = new Button()
            {
                Text = "❌",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Cursor = Cursors.Hand,
                Size = new Size(50, 50),
                Location = new Point(1200, 5),
                BackColor = Color.LightGray,
                Tag = userPanel
            };

            //привязка событий нажатия на кнопку
            btnEditUser.Click += btnUserEdit_Click;
            btnDeleteUser.Click += btnUserDelete_Click;

            userPanel.Controls.Add(btnEditUser);
            userPanel.Controls.Add(btnDeleteUser);

            flp.Controls.Add(userPanel);
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
        private void btnEditClient_Click(object sender, EventArgs e) 
        {
            if(sender is Button btn && btn.Tag is Panel clientPanel && clientPanel.Tag is int cId)
            {
                ClientRepository clientRepository = new ClientRepository(_connection);
                ClientAddForm clientAddForm = new ClientAddForm(clientRepository, cId, "edit");
                clientAddForm.ShowDialog();
            }
        }
        private void btnUserEdit_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Panel userPanel && userPanel.Tag is int uId)
            {
                UserRepository userRepository = new UserRepository(_connection);
                UserAddForm userAddForm = new UserAddForm(_connection, uId, "edit");
                userAddForm.ShowDialog();
            }
        }
        private void btnUserDelete_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Panel userPanel && userPanel.Tag is int uId)
            {
                UserRepository userRepository = new UserRepository(_connection);
                userRepository.Delete(uId);
                MessageBox.Show("Пользователь удален!");

                flp.Controls.Clear();

                var workers = userRepository.GetAll();

                foreach (var worker in workers)
                {
                    AddUserCard(worker);
                }
            }
        }
    }
}
