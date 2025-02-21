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
    }
}
