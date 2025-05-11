namespace bicycleRent.Forms.Inventory
{
    partial class InventoryAddForm
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
            flpInventoryType = new FlowLayoutPanel();
            flpFilial = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            txtInventoryName = new TextBox();
            numInventoryNumber = new NumericUpDown();
            label2 = new Label();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numInventoryNumber).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 46);
            label1.Name = "label1";
            label1.Size = new Size(285, 25);
            label1.TabIndex = 0;
            label1.Text = "Введи только название, кратко:";
            // 
            // flpInventoryType
            // 
            flpInventoryType.Location = new Point(6, 44);
            flpInventoryType.Name = "flpInventoryType";
            flpInventoryType.Size = new Size(283, 294);
            flpInventoryType.TabIndex = 1;
            // 
            // flpFilial
            // 
            flpFilial.Location = new Point(6, 44);
            flpFilial.Name = "flpFilial";
            flpFilial.Size = new Size(556, 294);
            flpFilial.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numInventoryNumber);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtInventoryName);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(352, 382);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Введите данные о инвентаре";
            // 
            // txtInventoryName
            // 
            txtInventoryName.Location = new Point(6, 76);
            txtInventoryName.Name = "txtInventoryName";
            txtInventoryName.Size = new Size(338, 33);
            txtInventoryName.TabIndex = 4;
            // 
            // numInventoryNumber
            // 
            numInventoryNumber.Location = new Point(6, 143);
            numInventoryNumber.Margin = new Padding(5, 5, 5, 5);
            numInventoryNumber.Name = "numInventoryNumber";
            numInventoryNumber.Size = new Size(338, 33);
            numInventoryNumber.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 112);
            label2.Name = "label2";
            label2.Size = new Size(247, 25);
            label2.TabIndex = 6;
            label2.Text = "Введи инвентарный номер";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Location = new Point(370, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(875, 382);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Выбери тип инвентаря и филиал, в котором он будет находиться";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(flpInventoryType);
            groupBox3.Location = new Point(6, 32);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(295, 344);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Выбери тип инвентаря";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(flpFilial);
            groupBox4.Location = new Point(307, 32);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(562, 344);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Выбери филиал";
            // 
            // InventoryAddForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1257, 750);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 5, 5, 5);
            Name = "InventoryAddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление инвентаря";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numInventoryNumber).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flpInventoryType;
        private FlowLayoutPanel flpFilial;
        private GroupBox groupBox1;
        private TextBox txtInventoryName;
        private NumericUpDown numInventoryNumber;
        private Label label2;
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
    }
}