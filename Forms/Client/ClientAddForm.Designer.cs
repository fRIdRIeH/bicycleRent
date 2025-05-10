namespace bicycleRent.Forms.Client
{
    partial class ClientAddForm
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
            txtSurname = new TextBox();
            label1 = new Label();
            btnAddOrEdit = new Button();
            groupBox1 = new GroupBox();
            label6 = new Label();
            txtFeatures = new TextBox();
            label5 = new Label();
            txtAddress = new TextBox();
            label4 = new Label();
            txtTelephone = new TextBox();
            label3 = new Label();
            txtPatronymic = new TextBox();
            label2 = new Label();
            txtName = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // txtSurname
            // 
            txtSurname.Location = new Point(15, 67);
            txtSurname.Name = "txtSurname";
            txtSurname.Size = new Size(392, 33);
            txtSurname.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 39);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 1;
            label1.Text = "Фамилия";
            // 
            // btnAddOrEdit
            // 
            btnAddOrEdit.Location = new Point(12, 506);
            btnAddOrEdit.Name = "btnAddOrEdit";
            btnAddOrEdit.Size = new Size(413, 40);
            btnAddOrEdit.TabIndex = 2;
            btnAddOrEdit.Text = "button1";
            btnAddOrEdit.UseVisualStyleBackColor = true;
            btnAddOrEdit.Click += btnAddOrEdit_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtFeatures);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtTelephone);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtPatronymic);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtSurname);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(413, 488);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Введите информацию о клиенте";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 359);
            label6.Name = "label6";
            label6.Size = new Size(138, 25);
            label6.TabIndex = 11;
            label6.Text = "Особые черты";
            // 
            // txtFeatures
            // 
            txtFeatures.Location = new Point(15, 387);
            txtFeatures.Name = "txtFeatures";
            txtFeatures.Size = new Size(392, 33);
            txtFeatures.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 295);
            label5.Name = "label5";
            label5.Size = new Size(64, 25);
            label5.TabIndex = 9;
            label5.Text = "Адрес";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(15, 323);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(392, 33);
            txtAddress.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 231);
            label4.Name = "label4";
            label4.Size = new Size(87, 25);
            label4.TabIndex = 7;
            label4.Text = "Телефон";
            // 
            // txtTelephone
            // 
            txtTelephone.Location = new Point(15, 259);
            txtTelephone.Name = "txtTelephone";
            txtTelephone.Size = new Size(392, 33);
            txtTelephone.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 167);
            label3.Name = "label3";
            label3.Size = new Size(93, 25);
            label3.TabIndex = 5;
            label3.Text = "Отчество";
            // 
            // txtPatronymic
            // 
            txtPatronymic.Location = new Point(15, 195);
            txtPatronymic.Name = "txtPatronymic";
            txtPatronymic.Size = new Size(392, 33);
            txtPatronymic.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 103);
            label2.Name = "label2";
            label2.Size = new Size(49, 25);
            label2.TabIndex = 3;
            label2.Text = "Имя";
            // 
            // txtName
            // 
            txtName.Location = new Point(15, 131);
            txtName.Name = "txtName";
            txtName.Size = new Size(392, 33);
            txtName.TabIndex = 2;
            // 
            // ClientAddForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 558);
            Controls.Add(groupBox1);
            Controls.Add(btnAddOrEdit);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            MaximizeBox = false;
            Name = "ClientAddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление клиента";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtSurname;
        private Label label1;
        private Button btnAddOrEdit;
        private GroupBox groupBox1;
        private Label label6;
        private TextBox txtFeatures;
        private Label label5;
        private TextBox txtAddress;
        private Label label4;
        private TextBox txtTelephone;
        private Label label3;
        private TextBox txtPatronymic;
        private Label label2;
        private TextBox txtName;
    }
}