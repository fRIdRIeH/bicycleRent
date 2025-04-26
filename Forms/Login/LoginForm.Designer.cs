namespace bicycleRent.Forms.Login
{
    partial class LoginForm
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
            button1 = new Button();
            loginInput = new TextBox();
            label2 = new Label();
            label3 = new Label();
            passwordInput = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(152, 32);
            label1.Name = "label1";
            label1.Size = new Size(247, 47);
            label1.TabIndex = 0;
            label1.Text = "Авторизация";
            // 
            // button1
            // 
            button1.Location = new Point(51, 308);
            button1.Name = "button1";
            button1.Size = new Size(468, 41);
            button1.TabIndex = 1;
            button1.Text = "Войти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // loginInput
            // 
            loginInput.Location = new Point(152, 115);
            loginInput.Name = "loginInput";
            loginInput.Size = new Size(367, 33);
            loginInput.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 115);
            label2.Name = "label2";
            label2.Size = new Size(70, 25);
            label2.TabIndex = 3;
            label2.Text = "Логин";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 171);
            label3.Name = "label3";
            label3.Size = new Size(83, 25);
            label3.TabIndex = 4;
            label3.Text = "Пароль";
            // 
            // passwordInput
            // 
            passwordInput.Location = new Point(152, 171);
            passwordInput.Name = "passwordInput";
            passwordInput.Size = new Size(367, 33);
            passwordInput.TabIndex = 5;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(passwordInput);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(loginInput);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 5, 5, 5);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private TextBox loginInput;
        private Label label2;
        private Label label3;
        private TextBox passwordInput;
    }
}