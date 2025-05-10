namespace bicycleRent.Forms.Rent
{
    partial class RentListForm
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
            flpRents = new FlowLayoutPanel();
            GoToAddRentBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 9);
            label1.Margin = new Padding(7, 0, 7, 0);
            label1.Name = "label1";
            label1.Size = new Size(284, 40);
            label1.TabIndex = 1;
            label1.Text = "Список всех аренд";
            // 
            // flpRents
            // 
            flpRents.AutoScroll = true;
            flpRents.FlowDirection = FlowDirection.TopDown;
            flpRents.Location = new Point(16, 52);
            flpRents.Name = "flpRents";
            flpRents.Size = new Size(1556, 797);
            flpRents.TabIndex = 2;
            // 
            // GoToAddRentBtn
            // 
            GoToAddRentBtn.BackColor = Color.LimeGreen;
            GoToAddRentBtn.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            GoToAddRentBtn.Location = new Point(1303, 9);
            GoToAddRentBtn.Margin = new Padding(4);
            GoToAddRentBtn.Name = "GoToAddRentBtn";
            GoToAddRentBtn.Size = new Size(269, 40);
            GoToAddRentBtn.TabIndex = 5;
            GoToAddRentBtn.Text = "Создать аренду";
            GoToAddRentBtn.UseVisualStyleBackColor = false;
            GoToAddRentBtn.Click += GoToAddRentBtn_Click;
            // 
            // RentListForm
            // 
            AutoScaleDimensions = new SizeF(17F, 40F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(GoToAddRentBtn);
            Controls.Add(flpRents);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Margin = new Padding(7, 8, 7, 8);
            MaximizeBox = false;
            Name = "RentListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Аренды";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private FlowLayoutPanel flpRents;
        private Button GoToAddRentBtn;
    }
}