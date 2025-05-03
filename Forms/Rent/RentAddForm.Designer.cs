namespace bicycleRent.Forms.Rent
{
    partial class RentAddForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dgvClients = new DataGridView();
            dgvInventory = new DataGridView();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            cbDeposit = new ComboBox();
            txtSearchClient = new TextBox();
            txtSearchInventory = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 0;
            label1.Text = "Клиент:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 228);
            label2.Name = "label2";
            label2.Size = new Size(111, 25);
            label2.TabIndex = 1;
            label2.Text = "Инвентарь:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 436);
            label3.Name = "label3";
            label3.Size = new Size(138, 25);
            label3.TabIndex = 2;
            label3.Text = "Время начала:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 500);
            label4.Name = "label4";
            label4.Size = new Size(138, 25);
            label4.TabIndex = 3;
            label4.Text = "Время начала:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1208, 436);
            label5.Name = "label5";
            label5.Size = new Size(64, 25);
            label5.TabIndex = 4;
            label5.Text = "Залог:";
            // 
            // dgvClients
            // 
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(12, 49);
            dgvClients.Name = "dgvClients";
            dgvClients.Size = new Size(1260, 170);
            dgvClients.TabIndex = 5;
            // 
            // dgvInventory
            // 
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(12, 263);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.Size = new Size(1260, 170);
            dgvInventory.TabIndex = 6;
            // 
            // dtpStart
            // 
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(12, 464);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(485, 33);
            dtpStart.TabIndex = 7;
            // 
            // dtpEnd
            // 
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(12, 528);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(485, 33);
            dtpEnd.TabIndex = 8;
            // 
            // cbDeposit
            // 
            cbDeposit.FormattingEnabled = true;
            cbDeposit.Location = new Point(851, 467);
            cbDeposit.Name = "cbDeposit";
            cbDeposit.Size = new Size(421, 33);
            cbDeposit.TabIndex = 9;
            // 
            // txtSearchClient
            // 
            txtSearchClient.Location = new Point(129, 13);
            txtSearchClient.Name = "txtSearchClient";
            txtSearchClient.Size = new Size(1143, 33);
            txtSearchClient.TabIndex = 10;
            // 
            // txtSearchInventory
            // 
            txtSearchInventory.Location = new Point(129, 225);
            txtSearchInventory.Name = "txtSearchInventory";
            txtSearchInventory.Size = new Size(1143, 33);
            txtSearchInventory.TabIndex = 11;
            // 
            // RentAddForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 761);
            Controls.Add(txtSearchInventory);
            Controls.Add(txtSearchClient);
            Controls.Add(cbDeposit);
            Controls.Add(dtpEnd);
            Controls.Add(dtpStart);
            Controls.Add(dgvInventory);
            Controls.Add(dgvClients);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "RentAddForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Добавление аренды";
            Load += RentAddForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView dgvClients;
        private DataGridView dgvInventory;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private ComboBox cbDeposit;
        private TextBox txtSearchClient;
        private TextBox txtSearchInventory;
    }
}