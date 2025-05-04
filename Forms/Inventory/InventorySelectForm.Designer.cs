namespace bicycleRent.Forms.Inventory
{
    partial class InventorySelectForm
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
            flpInventoryForSelect = new FlowLayoutPanel();
            label1 = new Label();
            btnSendAndClose = new Button();
            SuspendLayout();
            // 
            // flpInventoryForSelect
            // 
            flpInventoryForSelect.AutoScroll = true;
            flpInventoryForSelect.Location = new Point(12, 37);
            flpInventoryForSelect.Name = "flpInventoryForSelect";
            flpInventoryForSelect.Size = new Size(1260, 566);
            flpInventoryForSelect.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(198, 25);
            label1.TabIndex = 1;
            label1.Text = "Выберите инвентарь:";
            // 
            // btnSendAndClose
            // 
            btnSendAndClose.Location = new Point(1100, 609);
            btnSendAndClose.Name = "btnSendAndClose";
            btnSendAndClose.Size = new Size(172, 40);
            btnSendAndClose.TabIndex = 2;
            btnSendAndClose.Text = "Выбрать";
            btnSendAndClose.UseVisualStyleBackColor = true;
            btnSendAndClose.Click += btnSendAndClose_Click;
            // 
            // InventorySelectForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1284, 661);
            Controls.Add(btnSendAndClose);
            Controls.Add(label1);
            Controls.Add(flpInventoryForSelect);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            MaximizeBox = false;
            Name = "InventorySelectForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Выбор инвентаря";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpInventoryForSelect;
        private Label label1;
        private Button btnSendAndClose;
    }
}