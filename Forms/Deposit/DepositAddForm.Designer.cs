namespace bicycleRent.Forms.Deposit
{
    partial class DepositAddForm
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
            groupBox1 = new GroupBox();
            btnAddOrEdit = new Button();
            txtDepositName = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnAddOrEdit);
            groupBox1.Controls.Add(txtDepositName);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(584, 320);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Введите название депозита:";
            // 
            // btnAddOrEdit
            // 
            btnAddOrEdit.Location = new Point(77, 274);
            btnAddOrEdit.Name = "btnAddOrEdit";
            btnAddOrEdit.Size = new Size(419, 40);
            btnAddOrEdit.TabIndex = 5;
            btnAddOrEdit.Text = "button1";
            btnAddOrEdit.UseVisualStyleBackColor = true;
            btnAddOrEdit.Click += btnAddOrEdit_Click;
            // 
            // txtDepositName
            // 
            txtDepositName.Location = new Point(266, 76);
            txtDepositName.Name = "txtDepositName";
            txtDepositName.Size = new Size(230, 33);
            txtDepositName.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 79);
            label1.Name = "label1";
            label1.Size = new Size(183, 25);
            label1.TabIndex = 3;
            label1.Text = "Название депозита:";
            // 
            // DepositAddForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 344);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            MaximizeBox = false;
            Name = "DepositAddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DepositAddForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnAddOrEdit;
        private TextBox txtDepositName;
        private Label label1;
    }
}