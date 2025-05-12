using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bicycleRent.Forms.Rent;
using bicycleRent.Repositories;
using MySql.Data.MySqlClient;

namespace bicycleRent.Forms.Client
{
    public partial class ClientListForm : Form
    {
        private readonly ClientRepository _clientRepository;
        private readonly Models.User _user;
        private readonly MySqlConnection _connection;

        public ClientListForm(ClientRepository clientRepository, Models.User user, MySqlConnection connection)
        {
            InitializeComponent();
            this.TopMost = true;
            _clientRepository = clientRepository;
            _user = user;
            _connection = connection;

            LoadData();
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

            //Добавление элементов в clientPanel
            clientPanel.Controls.Add(lblClientId);
            clientPanel.Controls.Add(lblClientSurname);
            clientPanel.Controls.Add(lblClientName);
            clientPanel.Controls.Add(lblClientPatronymic);
            clientPanel.Controls.Add(lblClientTelephone);

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
            btnEdit.Click += BtnEdit_Click;

            //добавление элементов в панель
            clientPanel.Controls.Add(lblClientIdData);
            clientPanel.Controls.Add(lblClientSurnameData);
            clientPanel.Controls.Add(lblClientNameData);
            clientPanel.Controls.Add(lblClientPatronymicData);
            clientPanel.Controls.Add(lblClientTelephoneData);

            clientPanel.Controls.Add(btnEdit);

            //Добавление панели в flowlayoutpanel
            flpClients.Controls.Add(clientPanel);
        }

        public void LoadData()
        {
            //Заполняем flpClients
            var clients = _clientRepository.GetAll();

            foreach (var client in clients)
            {
                AddClientCard(client);
            }

            //Меняем ее
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Panel clientPanel && clientPanel.Tag is int cId)
            {
                //Открываем форму редактирования данных о клиенте
                ClientAddForm clientAddForm = new ClientAddForm(_clientRepository, cId, "edit");
                clientAddForm.ShowDialog();
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            ClientAddForm clientAddForm = new ClientAddForm(_clientRepository, 0, "add");
            clientAddForm.ShowDialog();
        }
    }
}
