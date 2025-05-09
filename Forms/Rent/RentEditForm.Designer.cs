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
            btnEditRent = new Button();
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
            groupBox2 = new GroupBox();
            flpPayments = new FlowLayoutPanel();
            btnCloseRent = new Button();
            groupBox3 = new GroupBox();
            numPaymentAmount = new NumericUpDown();
            btnAddPayment = new Button();
            label10 = new Label();
            cbPaymentType = new ComboBox();
            label8 = new Label();
            btnResumeRent = new Button();
            lblResume = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPaymentAmount).BeginInit();
            SuspendLayout();
            // 
            // btnEditRent
            // 
            btnEditRent.Location = new Point(1472, 793);
            btnEditRent.Name = "btnEditRent";
            btnEditRent.Size = new Size(200, 56);
            btnEditRent.TabIndex = 32;
            btnEditRent.Text = "Обновить";
            btnEditRent.UseVisualStyleBackColor = true;
            btnEditRent.Click += btnCreateRent_Click_1;
            // 
            // btnCount
            // 
            btnCount.Location = new Point(1472, 731);
            btnCount.Name = "btnCount";
            btnCount.Size = new Size(200, 56);
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
            flpSelectedInventory.FlowDirection = FlowDirection.TopDown;
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
            groupBox1.Size = new Size(400, 121);
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
            cbDeposit.Location = new Point(845, 477);
            cbDeposit.Name = "cbDeposit";
            cbDeposit.Size = new Size(421, 33);
            cbDeposit.TabIndex = 26;
            // 
            // dtpStart
            // 
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.Location = new Point(6, 474);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(485, 33);
            dtpStart.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1202, 446);
            label5.Name = "label5";
            label5.Size = new Size(64, 25);
            label5.TabIndex = 23;
            label5.Text = "Залог:";
            // 
            // dtpEnd
            // 
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(6, 538);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(485, 33);
            dtpEnd.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 510);
            label4.Name = "label4";
            label4.Size = new Size(128, 25);
            label4.TabIndex = 22;
            label4.Text = "Время конца:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 446);
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
            // groupBox2
            // 
            groupBox2.Controls.Add(flpPayments);
            groupBox2.Location = new Point(1272, 142);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(400, 298);
            groupBox2.TabIndex = 33;
            groupBox2.TabStop = false;
            groupBox2.Text = "Оплата:";
            // 
            // flpPayments
            // 
            flpPayments.AutoScroll = true;
            flpPayments.Location = new Point(6, 32);
            flpPayments.Name = "flpPayments";
            flpPayments.Size = new Size(388, 260);
            flpPayments.TabIndex = 0;
            // 
            // btnCloseRent
            // 
            btnCloseRent.Location = new Point(1266, 793);
            btnCloseRent.Name = "btnCloseRent";
            btnCloseRent.Size = new Size(200, 56);
            btnCloseRent.TabIndex = 34;
            btnCloseRent.Text = "Закрыть аренду";
            btnCloseRent.UseVisualStyleBackColor = true;
            btnCloseRent.Click += btnCloseRent_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(numPaymentAmount);
            groupBox3.Controls.Add(btnAddPayment);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(cbPaymentType);
            groupBox3.Controls.Add(label8);
            groupBox3.Location = new Point(1272, 446);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(400, 109);
            groupBox3.TabIndex = 35;
            groupBox3.TabStop = false;
            groupBox3.Text = "Внести оплату:";
            // 
            // numPaymentAmount
            // 
            numPaymentAmount.Location = new Point(76, 27);
            numPaymentAmount.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numPaymentAmount.Name = "numPaymentAmount";
            numPaymentAmount.Size = new Size(111, 33);
            numPaymentAmount.TabIndex = 40;
            // 
            // btnAddPayment
            // 
            btnAddPayment.Location = new Point(8, 65);
            btnAddPayment.Name = "btnAddPayment";
            btnAddPayment.Size = new Size(382, 38);
            btnAddPayment.TabIndex = 39;
            btnAddPayment.Text = "Добавить оплату";
            btnAddPayment.UseVisualStyleBackColor = true;
            btnAddPayment.Click += btnAddPayment_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(190, 29);
            label10.Name = "label10";
            label10.Size = new Size(48, 25);
            label10.TabIndex = 38;
            label10.Text = "Тип:";
            // 
            // cbPaymentType
            // 
            cbPaymentType.FormattingEnabled = true;
            cbPaymentType.Location = new Point(244, 25);
            cbPaymentType.Name = "cbPaymentType";
            cbPaymentType.Size = new Size(146, 33);
            cbPaymentType.TabIndex = 36;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 29);
            label8.Name = "label8";
            label8.Size = new Size(73, 25);
            label8.TabIndex = 36;
            label8.Text = "Сумма:";
            // 
            // btnResumeRent
            // 
            btnResumeRent.BackColor = Color.Aquamarine;
            btnResumeRent.Location = new Point(12, 793);
            btnResumeRent.Name = "btnResumeRent";
            btnResumeRent.Size = new Size(200, 56);
            btnResumeRent.TabIndex = 36;
            btnResumeRent.Text = "Возобновить";
            btnResumeRent.UseVisualStyleBackColor = false;
            btnResumeRent.Click += btnResumeRent_Click;
            // 
            // lblResume
            // 
            lblResume.AutoSize = true;
            lblResume.Location = new Point(12, 762);
            lblResume.Name = "lblResume";
            lblResume.Size = new Size(249, 25);
            lblResume.TabIndex = 37;
            lblResume.Text = "Случайно закрыли аренду?";
            // 
            // RentEditForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1684, 861);
            Controls.Add(lblResume);
            Controls.Add(btnResumeRent);
            Controls.Add(groupBox3);
            Controls.Add(btnCloseRent);
            Controls.Add(groupBox2);
            Controls.Add(btnEditRent);
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
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPaymentAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEditRent;
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
        private GroupBox groupBox2;
        private FlowLayoutPanel flpPayments;
        private Button btnCloseRent;
        private GroupBox groupBox3;
        private Button btnAddPayment;
        private Label label10;
        private ComboBox cbPaymentType;
        private Label label8;
        private NumericUpDown numPaymentAmount;
        private Button btnResumeRent;
        private Label lblResume;
    }
}