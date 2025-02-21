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
            dgvMainForm = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMainForm).BeginInit();
            SuspendLayout();
            // 
            // GoToRentsListBtn
            // 
            GoToRentsListBtn.Location = new Point(17, 116);
            GoToRentsListBtn.Margin = new Padding(4);
            GoToRentsListBtn.Name = "GoToRentsListBtn";
            GoToRentsListBtn.Size = new Size(250, 90);
            GoToRentsListBtn.TabIndex = 0;
            GoToRentsListBtn.Text = "Список всех аренд";
            GoToRentsListBtn.UseVisualStyleBackColor = true;
            GoToRentsListBtn.Click += GoToRentsListBtn_Click;
            // 
            // GoToClientsListBtn
            // 
            GoToClientsListBtn.Location = new Point(17, 214);
            GoToClientsListBtn.Margin = new Padding(4);
            GoToClientsListBtn.Name = "GoToClientsListBtn";
            GoToClientsListBtn.Size = new Size(250, 90);
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
            GoToInventoryListBtn.Location = new Point(17, 312);
            GoToInventoryListBtn.Margin = new Padding(4);
            GoToInventoryListBtn.Name = "GoToInventoryListBtn";
            GoToInventoryListBtn.Size = new Size(250, 90);
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
            // dgvMainForm
            // 
            dgvMainForm.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMainForm.Location = new Point(296, 116);
            dgvMainForm.Name = "dgvMainForm";
            dgvMainForm.Size = new Size(1315, 901);
            dgvMainForm.TabIndex = 7;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(16F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(label1);
            Controls.Add(dgvMainForm);
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
            ((System.ComponentModel.ISupportInitialize)dgvMainForm).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button GoToRentsListBtn;
        private Button GoToClientsListBtn;
        private Button GoToAddRentBtn;
        private Button GoToInventoryListBtn;
        private Button GoToAdminPanelBtn;
        private DataGridView dgvMainForm;
        private Label label1;
    }
}
