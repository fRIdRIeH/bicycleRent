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
            dgvRents = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRents).BeginInit();
            SuspendLayout();
            // 
            // dgvRents
            // 
            dgvRents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRents.Location = new Point(16, 57);
            dgvRents.Margin = new Padding(7, 8, 7, 8);
            dgvRents.Name = "dgvRents";
            dgvRents.Size = new Size(1552, 787);
            dgvRents.TabIndex = 0;
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
            // RentListForm
            // 
            AutoScaleDimensions = new SizeF(17F, 40F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(label1);
            Controls.Add(dgvRents);
            Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Margin = new Padding(7, 8, 7, 8);
            MaximizeBox = false;
            Name = "RentListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Аренды";
            ((System.ComponentModel.ISupportInitialize)dgvRents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRents;
        private Label label1;
    }
}