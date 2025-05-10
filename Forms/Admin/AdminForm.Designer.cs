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
            ShowMeFilialsBtn = new Button();
            ShowMeWorkersBtn = new Button();
            btnAddPrice = new Button();
            groupBox1 = new GroupBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // GoToInventoryAddFormBtn
            // 
            GoToInventoryAddFormBtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GoToInventoryAddFormBtn.Location = new Point(6, 50);
            GoToInventoryAddFormBtn.Name = "GoToInventoryAddFormBtn";
            GoToInventoryAddFormBtn.Size = new Size(270, 40);
            GoToInventoryAddFormBtn.TabIndex = 0;
            GoToInventoryAddFormBtn.Text = "Добавить инвентарь";
            GoToInventoryAddFormBtn.UseVisualStyleBackColor = true;
            GoToInventoryAddFormBtn.Click += GoToInventoryAddFormBtn_Click;
            // 
            // GoToUserAddFormBtn
            // 
            GoToUserAddFormBtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GoToUserAddFormBtn.Location = new Point(6, 96);
            GoToUserAddFormBtn.Name = "GoToUserAddFormBtn";
            GoToUserAddFormBtn.Size = new Size(270, 40);
            GoToUserAddFormBtn.TabIndex = 1;
            GoToUserAddFormBtn.Text = "Добавить работника";
            GoToUserAddFormBtn.UseVisualStyleBackColor = true;
            GoToUserAddFormBtn.Click += GoToUserAddFormBtn_Click;
            // 
            // GoToDepositAddFormAdd
            // 
            GoToDepositAddFormAdd.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GoToDepositAddFormAdd.Location = new Point(6, 146);
            GoToDepositAddFormAdd.Name = "GoToDepositAddFormAdd";
            GoToDepositAddFormAdd.Size = new Size(270, 40);
            GoToDepositAddFormAdd.TabIndex = 2;
            GoToDepositAddFormAdd.Text = "Добавить депозит";
            GoToDepositAddFormAdd.UseVisualStyleBackColor = true;
            GoToDepositAddFormAdd.Click += GoToDepositAddFormAdd_Click;
            // 
            // GoToInventoryTypeAddFormBtn
            // 
            GoToInventoryTypeAddFormBtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GoToInventoryTypeAddFormBtn.Location = new Point(6, 192);
            GoToInventoryTypeAddFormBtn.Name = "GoToInventoryTypeAddFormBtn";
            GoToInventoryTypeAddFormBtn.Size = new Size(270, 40);
            GoToInventoryTypeAddFormBtn.TabIndex = 3;
            GoToInventoryTypeAddFormBtn.Text = "Добавить тип инвентаря";
            GoToInventoryTypeAddFormBtn.UseVisualStyleBackColor = true;
            GoToInventoryTypeAddFormBtn.Click += GoToInventoryTypeAddFormBtn_Click;
            // 
            // GoToFilialAddFormBtn
            // 
            GoToFilialAddFormBtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GoToFilialAddFormBtn.Location = new Point(6, 238);
            GoToFilialAddFormBtn.Name = "GoToFilialAddFormBtn";
            GoToFilialAddFormBtn.Size = new Size(270, 40);
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
            // btnAddPrice
            // 
            btnAddPrice.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAddPrice.Location = new Point(6, 284);
            btnAddPrice.Name = "btnAddPrice";
            btnAddPrice.Size = new Size(270, 40);
            btnAddPrice.TabIndex = 11;
            btnAddPrice.Text = "Добавить тариф";
            btnAddPrice.UseVisualStyleBackColor = true;
            btnAddPrice.Click += btnAddPrice_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(GoToInventoryAddFormBtn);
            groupBox1.Controls.Add(btnAddPrice);
            groupBox1.Controls.Add(GoToUserAddFormBtn);
            groupBox1.Controls.Add(GoToDepositAddFormAdd);
            groupBox1.Controls.Add(GoToInventoryTypeAddFormBtn);
            groupBox1.Controls.Add(GoToFilialAddFormBtn);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(289, 342);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Добавление";
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(16F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1674, 1011);
            Controls.Add(groupBox1);
            Controls.Add(ShowMeWorkersBtn);
            Controls.Add(ShowMeFilialsBtn);
            Controls.Add(ShowMeRentForTodayBtn);
            Controls.Add(ShowMeClientsBtn);
            Controls.Add(ShowMeInventoryBtn);
            Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Margin = new Padding(6, 7, 6, 7);
            MinimizeBox = false;
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Администрирование";
            groupBox1.ResumeLayout(false);
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
        private Button ShowMeFilialsBtn;
        private Button ShowMeWorkersBtn;
        private Button btnAddPrice;
        private GroupBox groupBox1;
    }
}