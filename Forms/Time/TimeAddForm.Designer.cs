namespace bicycleRent.Forms.Time
{
    partial class TimeAddForm
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
            txtTimeLabel = new TextBox();
            btnAddOrEdit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 103);
            label1.Name = "label1";
            label1.Size = new Size(283, 25);
            label1.TabIndex = 0;
            label1.Text = "Введи наименование времени:";
            // 
            // txtTimeLabel
            // 
            txtTimeLabel.Location = new Point(301, 100);
            txtTimeLabel.Name = "txtTimeLabel";
            txtTimeLabel.Size = new Size(271, 33);
            txtTimeLabel.TabIndex = 1;
            // 
            // btnAddOrEdit
            // 
            btnAddOrEdit.Location = new Point(140, 262);
            btnAddOrEdit.Name = "btnAddOrEdit";
            btnAddOrEdit.Size = new Size(301, 37);
            btnAddOrEdit.TabIndex = 2;
            btnAddOrEdit.Text = "Добавить";
            btnAddOrEdit.UseVisualStyleBackColor = true;
            btnAddOrEdit.Click += btnAddOrEdit_Click;
            // 
            // TimeAddForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 311);
            Controls.Add(btnAddOrEdit);
            Controls.Add(txtTimeLabel);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "TimeAddForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление времени";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTimeLabel;
        private Button btnAddOrEdit;
    }
}