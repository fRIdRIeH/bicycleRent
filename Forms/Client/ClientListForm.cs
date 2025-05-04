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
using bicycleRent.Repositories;

namespace bicycleRent.Forms.Client
{
    public partial class ClientListForm : Form
    {
        private readonly ClientRepository _clientRepository;
        public ClientListForm(ClientRepository clientRepository)
        {
            InitializeComponent();
            this.TopMost = true;
            _clientRepository = clientRepository;
        }

        private void AddClientCard(Models.Client client)
        {
            Panel clientPanel = new Panel()
            {
                Tag = client.Id,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(1220, 50),
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
                Location = new Point(110, lblYpos),
                AutoSize = true,
            };
            // Имя клиента
            Label lblClientName = new Label()
            {
                Text = "Имя:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(210, lblYpos),
                AutoSize = true,
            };
            // Отчетство клиента
            Label lblClientPatronymic = new Label()
            {
                Text = "Отчество:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(310, lblYpos),
                AutoSize = true,
            };
            // Номер телефона
            Label lblClientTelephone = new Label()
            {
                Text = "Телефон:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(410, lblYpos),
                AutoSize = true,
            };

            //Добавление элементов в clientPanel
            clientPanel.Controls.Add(lblClientId);
            clientPanel.Controls.Add(lblClientSurname);
            clientPanel.Controls.Add(lblClientName);
            clientPanel.Controls.Add(lblClientPatronymic);
            clientPanel.Controls.Add(lblClientTelephone);

            //Добавление панели в flowlayoutpanel
            //flpClients.Controls.Add(clientPanel);
        }

        public void LoadData()
        {
            var clients = _clientRepository.GetAll();

            foreach (var client in clients)
            {
                AddClientCard(client);
            }
        }
    }
}
