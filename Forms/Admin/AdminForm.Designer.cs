namespace bicycleRent.Forms.Admin
{
    partial class AdminForm
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
            GoToInventoryAddFormBtn = new Button();
            GoToUserAddFormBtn = new Button();
            GoToDepositAddFormAdd = new Button();
            GoToInventoryTypeAddFormBtn = new Button();
            GoToFilialAddFormBtn = new Button();
            ShowMeInventoryBtn = new Button();
            ShowMeClientsBtn = new Button();
            ShowMeRentForTodayBtn = new Button();
            dgvAdminForm = new DataGridView();
            ShowMeFilialsBtn = new Button();
            ShowMeWorkersBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAdminForm).BeginInit();
            SuspendLayout();
            // 
            // GoToInventoryAddFormBtn
            // 
            GoToInventoryAddFormBtn.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GoToInventoryAddFormBtn.Location = new Point(12, 12);
            GoToInventoryAddFormBtn.Name = "GoToInventoryAddFormBtn";
            GoToInventoryAddFormBtn.Size = new Size(220, 90);
            GoToInventoryAddFormBtn.TabIndex = 0;
            GoToInventoryAddFormBtn.Text = "Добавить инвентарь";
            GoToInventoryAddFormBtn.UseVisualStyleBackColor = true;
            GoToInventoryAddFormBtn.Click += GoToInventoryAddFormBtn_Click;
            // 
            // GoToUserAddFormBtn
            // 
            GoToUserAddFormBtn.Location = new Point(12, 108);
            GoToUserAddFormBtn.Name = "GoToUserAddFormBtn";
            GoToUserAddFormBtn.Size = new Size(220, 90);
            GoToUserAddFormBtn.TabIndex = 1;
            GoToUserAddFormBtn.Text = "Добавить работника";
            GoToUserAddFormBtn.UseVisualStyleBackColor = true;
            GoToUserAddFormBtn.Click += GoToUserAddFormBtn_Click;
            // 
            // GoToDepositAddFormAdd
            // 
            GoToDepositAddFormAdd.Location = new Point(12, 204);
            GoToDepositAddFormAdd.Name = "GoToDepositAddFormAdd";
            GoToDepositAddFormAdd.Size = new Size(220, 90);
            GoToDepositAddFormAdd.TabIndex = 2;
            GoToDepositAddFormAdd.Text = "Добавить депозит";
            GoToDepositAddFormAdd.UseVisualStyleBackColor = true;
            GoToDepositAddFormAdd.Click += GoToDepositAddFormAdd_Click;
            // 
            // GoToInventoryTypeAddFormBtn
            // 
            GoToInventoryTypeAddFormBtn.Location = new Point(12, 300);
            GoToInventoryTypeAddFormBtn.Name = "GoToInventoryTypeAddFormBtn";
            GoToInventoryTypeAddFormBtn.Size = new Size(220, 90);
            GoToInventoryTypeAddFormBtn.TabIndex = 3;
            GoToInventoryTypeAddFormBtn.Text = "Добавить тип инвентаря";
            GoToInventoryTypeAddFormBtn.UseVisualStyleBackColor = true;
            GoToInventoryTypeAddFormBtn.Click += GoToInventoryTypeAddFormBtn_Click;
            // 
            // GoToFilialAddFormBtn
            // 
            GoToFilialAddFormBtn.Location = new Point(12, 396);
            GoToFilialAddFormBtn.Name = "GoToFilialAddFormBtn";
            GoToFilialAddFormBtn.Size = new Size(220, 90);
            GoToFilialAddFormBtn.TabIndex = 4;
            GoToFilialAddFormBtn.Text = "Добавить филиал";
            GoToFilialAddFormBtn.UseVisualStyleBackColor = true;
            GoToFilialAddFormBtn.Click += GoToFilialAddFormBtn_Click;
            // 
            // ShowMeInventoryBtn
            // 
            ShowMeInventoryBtn.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ShowMeInventoryBtn.Location = new Point(1362, 12);
            ShowMeInventoryBtn.Name = "ShowMeInventoryBtn";
            ShowMeInventoryBtn.Size = new Size(310, 90);
            ShowMeInventoryBtn.TabIndex = 5;
            ShowMeInventoryBtn.Text = "Отобразить список инвентаря";
            ShowMeInventoryBtn.UseVisualStyleBackColor = true;
            ShowMeInventoryBtn.Click += ShowMeInventoryBtn_Click;
            // 
            // ShowMeClientsBtn
            // 
            ShowMeClientsBtn.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ShowMeClientsBtn.Location = new Point(1362, 108);
            ShowMeClientsBtn.Name = "ShowMeClientsBtn";
            ShowMeClientsBtn.Size = new Size(310, 90);
            ShowMeClientsBtn.TabIndex = 6;
            ShowMeClientsBtn.Text = "Отобразить список клиентов";
            ShowMeClientsBtn.UseVisualStyleBackColor = true;
            ShowMeClientsBtn.Click += ShowMeClientsBtn_Click;
            // 
            // ShowMeRentForTodayBtn
            // 
            ShowMeRentForTodayBtn.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ShowMeRentForTodayBtn.Location = new Point(1362, 204);
            ShowMeRentForTodayBtn.Name = "ShowMeRentForTodayBtn";
            ShowMeRentForTodayBtn.Size = new Size(310, 90);
            ShowMeRentForTodayBtn.TabIndex = 7;
            ShowMeRentForTodayBtn.Text = "Отобразить аренды за сегодня";
            ShowMeRentForTodayBtn.UseVisualStyleBackColor = true;
            ShowMeRentForTodayBtn.Click += ShowMeRentForTodayBtn_Click;
            // 
            // dgvAdminForm
            // 
            dgvAdminForm.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdminForm.Location = new Point(256, 12);
            dgvAdminForm.Name = "dgvAdminForm";
            dgvAdminForm.Size = new Size(1081, 637);
            dgvAdminForm.TabIndex = 8;
            // 
            // ShowMeFilialsBtn
            // 
            ShowMeFilialsBtn.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ShowMeFilialsBtn.Location = new Point(1362, 300);
            ShowMeFilialsBtn.Name = "ShowMeFilialsBtn";
            ShowMeFilialsBtn.Size = new Size(310, 90);
            ShowMeFilialsBtn.TabIndex = 9;
            ShowMeFilialsBtn.Text = "Отобразить все точки";
            ShowMeFilialsBtn.UseVisualStyleBackColor = true;
            ShowMeFilialsBtn.Click += ShowMeFilialsBtn_Click;
            // 
            // ShowMeWorkersBtn
            // 
            ShowMeWorkersBtn.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ShowMeWorkersBtn.Location = new Point(1362, 396);
            ShowMeWorkersBtn.Name = "ShowMeWorkersBtn";
            ShowMeWorkersBtn.Size = new Size(310, 90);
            ShowMeWorkersBtn.TabIndex = 10;
            ShowMeWorkersBtn.Text = "Отобразить список работников";
            ShowMeWorkersBtn.UseVisualStyleBackColor = true;
            ShowMeWorkersBtn.Click += ShowMeWorkersBtn_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(16F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1684, 661);
            Controls.Add(ShowMeWorkersBtn);
            Controls.Add(ShowMeFilialsBtn);
            Controls.Add(dgvAdminForm);
            Controls.Add(ShowMeRentForTodayBtn);
            Controls.Add(ShowMeClientsBtn);
            Controls.Add(ShowMeInventoryBtn);
            Controls.Add(GoToFilialAddFormBtn);
            Controls.Add(GoToInventoryTypeAddFormBtn);
            Controls.Add(GoToDepositAddFormAdd);
            Controls.Add(GoToUserAddFormBtn);
            Controls.Add(GoToInventoryAddFormBtn);
            Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Margin = new Padding(6, 7, 6, 7);
            MinimizeBox = false;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Администрирование";
            ((System.ComponentModel.ISupportInitialize)dgvAdminForm).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button GoToInventoryAddFormBtn;
        private Button GoToUserAddFormBtn;
        private Button GoToDepositAddFormAdd;
        private Button GoToInventoryTypeAddFormBtn;
        private Button GoToFilialAddFormBtn;
        private Button ShowMeInventoryBtn;
        private Button ShowMeClientsBtn;
        private Button ShowMeRentForTodayBtn;
        private DataGridView dgvAdminForm;
        private Button ShowMeFilialsBtn;
        private Button ShowMeWorkersBtn;
    }
}