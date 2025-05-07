namespace bicycleRent.Forms.Rent
{
    partial class RentEditForm
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
            btnCreateRent = new Button();
            btnCount = new Button();
            cbClients = new ComboBox();
            btnChooseInventory = new Button();
            flpSelectedInventory = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            lblForPrice = new Label();
            lblForTimePeriod = new Label();
            label7 = new Label();
            lblForClient = new Label();
            label9 = new Label();
            label6 = new Label();
            cbDeposit = new ComboBox();
            dtpStart = new DateTimePicker();
            label5 = new Label();
            dtpEnd = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnCreateRent
            // 
            btnCreateRent.Location = new Point(1348, 792);
            btnCreateRent.Name = "btnCreateRent";
            btnCreateRent.Size = new Size(218, 56);
            btnCreateRent.TabIndex = 32;
            btnCreateRent.Text = "Создать аренду";
            btnCreateRent.UseVisualStyleBackColor = true;
            // 
            // btnCount
            // 
            btnCount.Location = new Point(1348, 730);
            btnCount.Name = "btnCount";
            btnCount.Size = new Size(218, 56);
            btnCount.TabIndex = 31;
            btnCount.Text = "Подсчет";
            btnCount.UseVisualStyleBackColor = true;
            btnCount.Click += btnCount_Click;
            // 
            // cbClients
            // 
            cbClients.FormattingEnabled = true;
            cbClients.Location = new Point(89, 12);
            cbClients.Name = "cbClients";
            cbClients.Size = new Size(1177, 33);
            cbClients.TabIndex = 30;
            cbClients.SelectedIndexChanged += cbClients_SelectedIndexChanged;
            // 
            // btnChooseInventory
            // 
            btnChooseInventory.Location = new Point(1164, 71);
            btnChooseInventory.Name = "btnChooseInventory";
            btnChooseInventory.Size = new Size(102, 30);
            btnChooseInventory.TabIndex = 29;
            btnChooseInventory.Text = "Выбрать";
            btnChooseInventory.UseVisualStyleBackColor = true;
            btnChooseInventory.Click += btnChooseInventory_Click;
            // 
            // flpSelectedInventory
            // 
            flpSelectedInventory.AutoScroll = true;
            flpSelectedInventory.Location = new Point(6, 107);
            flpSelectedInventory.Name = "flpSelectedInventory";
            flpSelectedInventory.Size = new Size(1260, 333);
            flpSelectedInventory.TabIndex = 28;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblForPrice);
            groupBox1.Controls.Add(lblForTimePeriod);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(lblForClient);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(1272, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(307, 484);
            groupBox1.TabIndex = 27;
            groupBox1.TabStop = false;
            groupBox1.Text = "Информация о аренде:";
            // 
            // lblForPrice
            // 
            lblForPrice.AutoSize = true;
            lblForPrice.Location = new Point(108, 86);
            lblForPrice.Name = "lblForPrice";
            lblForPrice.Size = new Size(37, 25);
            lblForPrice.TabIndex = 7;
            lblForPrice.Text = "0 ₽";
            // 
            // lblForTimePeriod
            // 
            lblForTimePeriod.AutoSize = true;
            lblForTimePeriod.Location = new Point(108, 61);
            lblForTimePeriod.Name = "lblForTimePeriod";
            lblForTimePeriod.Size = new Size(79, 25);
            lblForTimePeriod.TabIndex = 6;
            lblForTimePeriod.Text = "0 минут";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 61);
            label7.Name = "label7";
            label7.Size = new Size(71, 25);
            label7.TabIndex = 5;
            label7.Text = "Время:";
            // 
            // lblForClient
            // 
            lblForClient.AutoSize = true;
            lblForClient.Location = new Point(108, 36);
            lblForClient.Name = "lblForClient";
            lblForClient.Size = new Size(76, 25);
            lblForClient.TabIndex = 4;
            lblForClient.Text = "anonim";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 86);
            label9.Name = "label9";
            label9.Size = new Size(92, 25);
            label9.TabIndex = 3;
            label9.Text = "К оплате:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 36);
            label6.Name = "label6";
            label6.Size = new Size(77, 25);
            label6.TabIndex = 0;
            label6.Text = "Клиент:";
            // 
            // cbDeposit
            // 
            cbDeposit.FormattingEnabled = true;
            cbDeposit.Location = new Point(845, 474);
            cbDeposit.Name = "cbDeposit";
            cbDeposit.Size = new Size(421, 33);
            cbDeposit.TabIndex = 26;
            // 
            // dtpStart
            // 
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(6, 471);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(485, 33);
            dtpStart.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1202, 443);
            label5.Name = "label5";
            label5.Size = new Size(64, 25);
            label5.TabIndex = 23;
            label5.Text = "Залог:";
            // 
            // dtpEnd
            // 
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(6, 535);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(485, 33);
            dtpEnd.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 507);
            label4.Name = "label4";
            label4.Size = new Size(128, 25);
            label4.TabIndex = 22;
            label4.Text = "Время конца:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 443);
            label3.Name = "label3";
            label3.Size = new Size(138, 25);
            label3.TabIndex = 21;
            label3.Text = "Время начала:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 71);
            label2.Name = "label2";
            label2.Size = new Size(111, 25);
            label2.TabIndex = 20;
            label2.Text = "Инвентарь:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 15);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 19;
            label1.Text = "Клиент:";
            // 
            // RentEditForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(btnCreateRent);
            Controls.Add(btnCount);
            Controls.Add(cbClients);
            Controls.Add(btnChooseInventory);
            Controls.Add(flpSelectedInventory);
            Controls.Add(groupBox1);
            Controls.Add(cbDeposit);
            Controls.Add(dtpStart);
            Controls.Add(label5);
            Controls.Add(dtpEnd);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "RentEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RentEditForm";
            Load += RentAddForm_Load;
            Shown += RentEditForm_Shown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreateRent;
        private Button btnCount;
        private ComboBox cbClients;
        private Button btnChooseInventory;
        private FlowLayoutPanel flpSelectedInventory;
        private GroupBox groupBox1;
        private Label lblForPrice;
        private Label lblForTimePeriod;
        private Label label7;
        private Label lblForClient;
        private Label label9;
        private Label label6;
        private ComboBox cbDeposit;
        private DateTimePicker dtpStart;
        private Label label5;
        private DateTimePicker dtpEnd;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}