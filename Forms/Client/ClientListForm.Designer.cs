namespace bicycleRent.Forms.Client
{
    partial class ClientListForm
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
            flpClients = new FlowLayoutPanel();
            btnAddClient = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(245, 37);
            label1.TabIndex = 2;
            label1.Text = "Список клиентов";
            // 
            // flpClients
            // 
            flpClients.AutoScroll = true;
            flpClients.FlowDirection = FlowDirection.TopDown;
            flpClients.Location = new Point(12, 49);
            flpClients.Name = "flpClients";
            flpClients.Size = new Size(1560, 800);
            flpClients.TabIndex = 3;
            flpClients.WrapContents = false;
            // 
            // btnAddClient
            // 
            btnAddClient.BackColor = Color.LimeGreen;
            btnAddClient.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAddClient.Location = new Point(1303, 6);
            btnAddClient.Margin = new Padding(4);
            btnAddClient.Name = "btnAddClient";
            btnAddClient.Size = new Size(269, 40);
            btnAddClient.TabIndex = 6;
            btnAddClient.Text = "Добавить клиента";
            btnAddClient.UseVisualStyleBackColor = false;
            btnAddClient.Click += btnAddClient_Click;
            // 
            // ClientListForm
            // 
            AutoScaleDimensions = new SizeF(16F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(btnAddClient);
            Controls.Add(flpClients);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Margin = new Padding(7);
            MaximizeBox = false;
            Name = "ClientListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список клиентов";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private FlowLayoutPanel flpClients;
        private Button btnAddClient;
    }
}