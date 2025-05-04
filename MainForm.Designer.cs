namespace bicycleRent
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GoToRentsListBtn = new Button();
            GoToClientsListBtn = new Button();
            GoToAddRentBtn = new Button();
            GoToInventoryListBtn = new Button();
            GoToAdminPanelBtn = new Button();
            label1 = new Label();
            labelForUserSNP = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // GoToRentsListBtn
            // 
            GoToRentsListBtn.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GoToRentsListBtn.Location = new Point(17, 116);
            GoToRentsListBtn.Margin = new Padding(4);
            GoToRentsListBtn.Name = "GoToRentsListBtn";
            GoToRentsListBtn.Size = new Size(250, 40);
            GoToRentsListBtn.TabIndex = 0;
            GoToRentsListBtn.Text = "Список всех аренд";
            GoToRentsListBtn.UseVisualStyleBackColor = true;
            GoToRentsListBtn.Click += GoToRentsListBtn_Click;
            // 
            // GoToClientsListBtn
            // 
            GoToClientsListBtn.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GoToClientsListBtn.Location = new Point(17, 164);
            GoToClientsListBtn.Margin = new Padding(4);
            GoToClientsListBtn.Name = "GoToClientsListBtn";
            GoToClientsListBtn.Size = new Size(250, 40);
            GoToClientsListBtn.TabIndex = 3;
            GoToClientsListBtn.Text = "Список всех клиентов";
            GoToClientsListBtn.UseVisualStyleBackColor = true;
            GoToClientsListBtn.Click += GoToClientsListBtn_Click;
            // 
            // GoToAddRentBtn
            // 
            GoToAddRentBtn.BackColor = Color.LimeGreen;
            GoToAddRentBtn.Location = new Point(17, 18);
            GoToAddRentBtn.Margin = new Padding(4);
            GoToAddRentBtn.Name = "GoToAddRentBtn";
            GoToAddRentBtn.Size = new Size(250, 90);
            GoToAddRentBtn.TabIndex = 4;
            GoToAddRentBtn.Text = "Создать аренду";
            GoToAddRentBtn.UseVisualStyleBackColor = false;
            GoToAddRentBtn.Click += GoToAddRentBtn_Click;
            // 
            // GoToInventoryListBtn
            // 
            GoToInventoryListBtn.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GoToInventoryListBtn.Location = new Point(17, 212);
            GoToInventoryListBtn.Margin = new Padding(4);
            GoToInventoryListBtn.Name = "GoToInventoryListBtn";
            GoToInventoryListBtn.Size = new Size(250, 40);
            GoToInventoryListBtn.TabIndex = 5;
            GoToInventoryListBtn.Text = "Список всего инвентаря";
            GoToInventoryListBtn.UseVisualStyleBackColor = true;
            GoToInventoryListBtn.Click += GoToInventoryListBtn_Click;
            // 
            // GoToAdminPanelBtn
            // 
            GoToAdminPanelBtn.Location = new Point(1642, 18);
            GoToAdminPanelBtn.Name = "GoToAdminPanelBtn";
            GoToAdminPanelBtn.Size = new Size(250, 90);
            GoToAdminPanelBtn.TabIndex = 6;
            GoToAdminPanelBtn.Text = "Админ панель";
            GoToAdminPanelBtn.UseVisualStyleBackColor = true;
            GoToAdminPanelBtn.Click += GoToAdminPanelBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(296, 71);
            label1.Name = "label1";
            label1.Size = new Size(416, 37);
            label1.TabIndex = 8;
            label1.Text = "Текущие и недавние аренды :";
            // 
            // labelForUserSNP
            // 
            labelForUserSNP.AutoSize = true;
            labelForUserSNP.Location = new Point(296, 18);
            labelForUserSNP.Name = "labelForUserSNP";
            labelForUserSNP.Size = new Size(96, 37);
            labelForUserSNP.TabIndex = 9;
            labelForUserSNP.Text = "label2";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(296, 116);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1373, 913);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(1475, 71);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(161, 39);
            btnRefresh.TabIndex = 11;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(16F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(btnRefresh);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(labelForUserSNP);
            Controls.Add(label1);
            Controls.Add(GoToAdminPanelBtn);
            Controls.Add(GoToInventoryListBtn);
            Controls.Add(GoToAddRentBtn);
            Controls.Add(GoToClientsListBtn);
            Controls.Add(GoToRentsListBtn);
            Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Margin = new Padding(7);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Учет аренд предприятия";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GoToRentsListBtn;
        private Button GoToClientsListBtn;
        private Button GoToAddRentBtn;
        private Button GoToInventoryListBtn;
        private Button GoToAdminPanelBtn;
        private Label label1;
        private Label labelForUserSNP;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnRefresh;
    }
}
