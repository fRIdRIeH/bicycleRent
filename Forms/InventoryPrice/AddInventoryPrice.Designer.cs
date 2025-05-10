namespace bicycleRent.Forms.InventoryPrice
{
    partial class AddInventoryPrice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flpTimes = new FlowLayoutPanel();
            flpPrices = new FlowLayoutPanel();
            flpInventory = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            btnRefresh = new Button();
            btnAddTime = new Button();
            btnAddPrice = new Button();
            addInventory = new Button();
            btnAddInventoryPrice = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // flpTimes
            // 
            flpTimes.Location = new Point(6, 32);
            flpTimes.Name = "flpTimes";
            flpTimes.Size = new Size(648, 250);
            flpTimes.TabIndex = 0;
            // 
            // flpPrices
            // 
            flpPrices.Location = new Point(6, 32);
            flpPrices.Name = "flpPrices";
            flpPrices.Size = new Size(648, 250);
            flpPrices.TabIndex = 1;
            // 
            // flpInventory
            // 
            flpInventory.Location = new Point(6, 32);
            flpInventory.Name = "flpInventory";
            flpInventory.Size = new Size(1328, 262);
            flpInventory.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(flpInventory);
            groupBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1340, 300);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Выбери инвентарь";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flpTimes);
            groupBox2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox2.Location = new Point(678, 318);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(660, 300);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Выбери время";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(flpPrices);
            groupBox3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox3.Location = new Point(12, 318);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(660, 300);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Выбери цену";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnRefresh);
            groupBox4.Controls.Add(btnAddTime);
            groupBox4.Controls.Add(btnAddPrice);
            groupBox4.Controls.Add(addInventory);
            groupBox4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            groupBox4.Location = new Point(1358, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(294, 294);
            groupBox4.TabIndex = 6;
            groupBox4.TabStop = false;
            groupBox4.Text = "Добавление";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(6, 254);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(282, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnAddTime
            // 
            btnAddTime.Location = new Point(6, 112);
            btnAddTime.Name = "btnAddTime";
            btnAddTime.Size = new Size(282, 34);
            btnAddTime.TabIndex = 2;
            btnAddTime.Text = "Добавить время";
            btnAddTime.UseVisualStyleBackColor = true;
            btnAddTime.Click += btnAddTime_Click;
            // 
            // btnAddPrice
            // 
            btnAddPrice.Location = new Point(6, 72);
            btnAddPrice.Name = "btnAddPrice";
            btnAddPrice.Size = new Size(282, 34);
            btnAddPrice.TabIndex = 1;
            btnAddPrice.Text = "Добавить цену";
            btnAddPrice.UseVisualStyleBackColor = true;
            btnAddPrice.Click += btnAddPrice_Click;
            // 
            // addInventory
            // 
            addInventory.Location = new Point(6, 32);
            addInventory.Name = "addInventory";
            addInventory.Size = new Size(282, 34);
            addInventory.TabIndex = 0;
            addInventory.Text = "Добавить инвентарь";
            addInventory.UseVisualStyleBackColor = true;
            addInventory.Click += addInventory_Click;
            // 
            // btnAddInventoryPrice
            // 
            btnAddInventoryPrice.BackColor = Color.DarkSeaGreen;
            btnAddInventoryPrice.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnAddInventoryPrice.Location = new Point(1278, 936);
            btnAddInventoryPrice.Name = "btnAddInventoryPrice";
            btnAddInventoryPrice.Size = new Size(374, 63);
            btnAddInventoryPrice.TabIndex = 4;
            btnAddInventoryPrice.Text = "Добавить тариф к инвентарю";
            btnAddInventoryPrice.UseVisualStyleBackColor = false;
            btnAddInventoryPrice.Click += btnAddInventoryPrice_Click;
            // 
            // AddInventoryPrice
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1664, 1011);
            Controls.Add(btnAddInventoryPrice);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "AddInventoryPrice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление тарифов";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpTimes;
        private FlowLayoutPanel flpPrices;
        private FlowLayoutPanel flpInventory;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Button btnAddTime;
        private Button btnAddPrice;
        private Button addInventory;
        private Button btnRefresh;
        private Button btnAddInventoryPrice;
        private GroupBox groupBox5;
    }
}