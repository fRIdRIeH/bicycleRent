namespace bicycleRent.Forms.InventoryType
{
    partial class InventoryTypeAddForm
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
            btnAddOrEdit = new Button();
            txtInventoryTypeName = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 96);
            label1.Name = "label1";
            label1.Size = new Size(296, 25);
            label1.TabIndex = 0;
            label1.Text = "Введи название типа инвентаря:";
            // 
            // btnAddOrEdit
            // 
            btnAddOrEdit.Location = new Point(99, 304);
            btnAddOrEdit.Name = "btnAddOrEdit";
            btnAddOrEdit.Size = new Size(443, 45);
            btnAddOrEdit.TabIndex = 1;
            btnAddOrEdit.Text = "button1";
            btnAddOrEdit.UseVisualStyleBackColor = true;
            btnAddOrEdit.Click += btnAddOrEdit_Click;
            // 
            // txtInventoryTypeName
            // 
            txtInventoryTypeName.Location = new Point(314, 93);
            txtInventoryTypeName.Name = "txtInventoryTypeName";
            txtInventoryTypeName.Size = new Size(328, 33);
            txtInventoryTypeName.TabIndex = 2;
            // 
            // InventoryTypeAddForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(654, 361);
            Controls.Add(txtInventoryTypeName);
            Controls.Add(btnAddOrEdit);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 5, 5, 5);
            Name = "InventoryTypeAddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InventoryTypeAddForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAddOrEdit;
        private TextBox txtInventoryTypeName;
    }
}