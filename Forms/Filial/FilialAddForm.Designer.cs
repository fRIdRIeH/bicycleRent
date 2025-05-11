namespace bicycleRent.Forms.Filial
{
    partial class FilialAddForm
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
            txtFilialName = new TextBox();
            btnAddOrEdit = new Button();
            txtFilialAddress = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 105);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(234, 25);
            label1.TabIndex = 0;
            label1.Text = "Введи название филиала:";
            // 
            // txtFilialName
            // 
            txtFilialName.Location = new Point(258, 102);
            txtFilialName.Margin = new Padding(5, 5, 5, 5);
            txtFilialName.Name = "txtFilialName";
            txtFilialName.Size = new Size(382, 33);
            txtFilialName.TabIndex = 1;
            // 
            // btnAddOrEdit
            // 
            btnAddOrEdit.Location = new Point(126, 302);
            btnAddOrEdit.Margin = new Padding(5, 5, 5, 5);
            btnAddOrEdit.Name = "btnAddOrEdit";
            btnAddOrEdit.Size = new Size(401, 45);
            btnAddOrEdit.TabIndex = 2;
            btnAddOrEdit.Text = "button1";
            btnAddOrEdit.UseVisualStyleBackColor = true;
            btnAddOrEdit.Click += btnAddOrEdit_Click;
            // 
            // txtFilialAddress
            // 
            txtFilialAddress.Location = new Point(258, 161);
            txtFilialAddress.Margin = new Padding(5);
            txtFilialAddress.Name = "txtFilialAddress";
            txtFilialAddress.Size = new Size(382, 33);
            txtFilialAddress.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 164);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(203, 25);
            label2.TabIndex = 3;
            label2.Text = "Введи адрес филиала:";
            // 
            // FilialAddForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 361);
            Controls.Add(txtFilialAddress);
            Controls.Add(label2);
            Controls.Add(btnAddOrEdit);
            Controls.Add(txtFilialName);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 5, 5, 5);
            MaximizeBox = false;
            Name = "FilialAddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FilialAddForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFilialName;
        private Button btnAddOrEdit;
        private TextBox txtFilialAddress;
        private Label label2;
    }
}