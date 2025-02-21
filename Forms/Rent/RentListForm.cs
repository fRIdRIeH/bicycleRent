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

namespace bicycleRent.Forms.Rent
{
    public partial class RentListForm : Form
    {
        private readonly RentRepository _rentRepository;
        public RentListForm(RentRepository rentRepository)
        {
            InitializeComponent();
            this.TopMost = true;
            _rentRepository = rentRepository;
        }
    }
}
