namespace bicycleRent.Forms.Inventory
{
    partial class InventoryListForm
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
            flpInventory = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(261, 37);
            label1.TabIndex = 0;
            label1.Text = "Список инвентаря";
            // 
            // flpInventory
            // 
            flpInventory.AutoScroll = true;
            flpInventory.FlowDirection = FlowDirection.TopDown;
            flpInventory.Location = new Point(12, 49);
            flpInventory.Name = "flpInventory";
            flpInventory.Size = new Size(1560, 800);
            flpInventory.TabIndex = 1;
            flpInventory.WrapContents = false;
            // 
            // InventoryListForm
            // 
            AutoScaleDimensions = new SizeF(16F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(flpInventory);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Margin = new Padding(7);
            MaximizeBox = false;
            Name = "InventoryListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Инвентарь";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FlowLayoutPanel flpInventory;
    }
}