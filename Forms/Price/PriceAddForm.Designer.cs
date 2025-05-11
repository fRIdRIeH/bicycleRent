namespace bicycleRent.Forms.Price
{
    partial class PriceAddForm
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
            btnAddOrEdit = new Button();
            label1 = new Label();
            numPrice = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            SuspendLayout();
            // 
            // btnAddOrEdit
            // 
            btnAddOrEdit.Location = new Point(140, 262);
            btnAddOrEdit.Name = "btnAddOrEdit";
            btnAddOrEdit.Size = new Size(301, 37);
            btnAddOrEdit.TabIndex = 5;
            btnAddOrEdit.Text = "Добавить";
            btnAddOrEdit.UseVisualStyleBackColor = true;
            btnAddOrEdit.Click += btnAddOrEdit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 103);
            label1.Name = "label1";
            label1.Size = new Size(163, 25);
            label1.TabIndex = 3;
            label1.Text = "Введи стоимость:";
            // 
            // numPrice
            // 
            numPrice.Location = new Point(181, 101);
            numPrice.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(391, 33);
            numPrice.TabIndex = 6;
            // 
            // PriceAddForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 311);
            Controls.Add(numPrice);
            Controls.Add(btnAddOrEdit);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "PriceAddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление стоимости";
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddOrEdit;
        private Label label1;
        private NumericUpDown numPrice;
    }
}