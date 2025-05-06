using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bicycleRent.Forms.Inventory
{
    public partial class InventoryAddForm : Form
    {
        public InventoryAddForm()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //СУММАРНАЯ ДЛИНА NAME + TYPE НЕ ДОЛЖНА БЫТЬ больше 35!

        }
    }
}
