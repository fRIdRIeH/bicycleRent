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
        }
    }
}
