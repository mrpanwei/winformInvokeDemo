namespace gmWeight
{
    partial class login
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
            this.userName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.Key_R = new System.Windows.Forms.Button();
            this.Key_F = new System.Windows.Forms.Button();
            this.Key_W = new System.Windows.Forms.Button();
            this.Key_1 = new System.Windows.Forms.Button();
            this.Key_2 = new System.Windows.Forms.Button();
            this.Key_3 = new System.Windows.Forms.Button();
            this.Key_4 = new System.Windows.Forms.Button();
            this.Key_5 = new System.Windows.Forms.Button();
            this.Key_6 = new System.Windows.Forms.Button();
            this.Key_9 = new System.Windows.Forms.Button();
            this.Key_8 = new System.Windows.Forms.Button();
            this.Key_7 = new System.Windows.Forms.Button();
            this.Key_0 = new System.Windows.Forms.Button();
            this.Key_Del = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userName.Location = new System.Drawing.Point(135, 26);
            this.userName.MaxLength = 6;
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(100, 33);
            this.userName.TabIndex = 0;
            this.userName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.userName_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 39);
            this.label1.TabIndex = 1;
            this.label1.Tag = "";
            this.label1.Text = "账户：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(25, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 39);
            this.label2.TabIndex = 3;
            this.label2.Tag = "";
            this.label2.Text = "密码：";
            // 
            // userPassword
            // 
            this.userPassword.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userPassword.Location = new System.Drawing.Point(135, 82);
            this.userPassword.MaxLength = 6;
            this.userPassword.Name = "userPassword";
            this.userPassword.PasswordChar = '*';
            this.userPassword.Size = new System.Drawing.Size(100, 33);
            this.userPassword.TabIndex = 2;
            this.userPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.userPassword_MouseClick);
            // 
            // Key_R
            // 
            this.Key_R.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_R.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_R.Location = new System.Drawing.Point(32, 138);
            this.Key_R.Name = "Key_R";
            this.Key_R.Size = new System.Drawing.Size(40, 40);
            this.Key_R.TabIndex = 4;
            this.Key_R.Text = "R";
            this.Key_R.UseVisualStyleBackColor = true;
            this.Key_R.Click += new System.EventHandler(this.Key_R_Click);
            // 
            // Key_F
            // 
            this.Key_F.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_F.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_F.Location = new System.Drawing.Point(78, 138);
            this.Key_F.Name = "Key_F";
            this.Key_F.Size = new System.Drawing.Size(40, 40);
            this.Key_F.TabIndex = 5;
            this.Key_F.Text = "F";
            this.Key_F.UseVisualStyleBackColor = true;
            this.Key_F.Click += new System.EventHandler(this.Key_F_Click);
            // 
            // Key_W
            // 
            this.Key_W.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_W.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_W.Location = new System.Drawing.Point(124, 138);
            this.Key_W.Name = "Key_W";
            this.Key_W.Size = new System.Drawing.Size(40, 40);
            this.Key_W.TabIndex = 6;
            this.Key_W.Text = "W";
            this.Key_W.UseVisualStyleBackColor = true;
            this.Key_W.Click += new System.EventHandler(this.Key_W_Click);
            // 
            // Key_1
            // 
            this.Key_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_1.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_1.Location = new System.Drawing.Point(170, 138);
            this.Key_1.Name = "Key_1";
            this.Key_1.Size = new System.Drawing.Size(40, 40);
            this.Key_1.TabIndex = 7;
            this.Key_1.Text = "1";
            this.Key_1.UseVisualStyleBackColor = true;
            this.Key_1.Click += new System.EventHandler(this.Key_1_Click);
            // 
            // Key_2
            // 
            this.Key_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_2.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_2.Location = new System.Drawing.Point(216, 138);
            this.Key_2.Name = "Key_2";
            this.Key_2.Size = new System.Drawing.Size(40, 40);
            this.Key_2.TabIndex = 8;
            this.Key_2.Text = "2";
            this.Key_2.UseVisualStyleBackColor = true;
            this.Key_2.Click += new System.EventHandler(this.Key_2_Click);
            // 
            // Key_3
            // 
            this.Key_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_3.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_3.Location = new System.Drawing.Point(262, 138);
            this.Key_3.Name = "Key_3";
            this.Key_3.Size = new System.Drawing.Size(40, 40);
            this.Key_3.TabIndex = 9;
            this.Key_3.Text = "3";
            this.Key_3.UseVisualStyleBackColor = true;
            this.Key_3.Click += new System.EventHandler(this.Key_3_Click);
            // 
            // Key_4
            // 
            this.Key_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_4.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_4.Location = new System.Drawing.Point(308, 138);
            this.Key_4.Name = "Key_4";
            this.Key_4.Size = new System.Drawing.Size(40, 40);
            this.Key_4.TabIndex = 10;
            this.Key_4.Text = "4";
            this.Key_4.UseVisualStyleBackColor = true;
            this.Key_4.Click += new System.EventHandler(this.Key_4_Click);
            // 
            // Key_5
            // 
            this.Key_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_5.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_5.Location = new System.Drawing.Point(32, 184);
            this.Key_5.Name = "Key_5";
            this.Key_5.Size = new System.Drawing.Size(40, 40);
            this.Key_5.TabIndex = 11;
            this.Key_5.Text = "5";
            this.Key_5.UseVisualStyleBackColor = true;
            this.Key_5.Click += new System.EventHandler(this.Key_5_Click);
            // 
            // Key_6
            // 
            this.Key_6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_6.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_6.Location = new System.Drawing.Point(78, 184);
            this.Key_6.Name = "Key_6";
            this.Key_6.Size = new System.Drawing.Size(40, 40);
            this.Key_6.TabIndex = 12;
            this.Key_6.Text = "6";
            this.Key_6.UseVisualStyleBackColor = true;
            this.Key_6.Click += new System.EventHandler(this.Key_6_Click);
            // 
            // Key_9
            // 
            this.Key_9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_9.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_9.Location = new System.Drawing.Point(216, 184);
            this.Key_9.Name = "Key_9";
            this.Key_9.Size = new System.Drawing.Size(40, 40);
            this.Key_9.TabIndex = 15;
            this.Key_9.Text = "9";
            this.Key_9.UseVisualStyleBackColor = true;
            this.Key_9.Click += new System.EventHandler(this.Key_9_Click);
            // 
            // Key_8
            // 
            this.Key_8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_8.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_8.Location = new System.Drawing.Point(170, 184);
            this.Key_8.Name = "Key_8";
            this.Key_8.Size = new System.Drawing.Size(40, 40);
            this.Key_8.TabIndex = 14;
            this.Key_8.Text = "8";
            this.Key_8.UseVisualStyleBackColor = true;
            this.Key_8.Click += new System.EventHandler(this.Key_8_Click);
            // 
            // Key_7
            // 
            this.Key_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_7.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_7.Location = new System.Drawing.Point(124, 184);
            this.Key_7.Name = "Key_7";
            this.Key_7.Size = new System.Drawing.Size(40, 40);
            this.Key_7.TabIndex = 13;
            this.Key_7.Text = "7";
            this.Key_7.UseVisualStyleBackColor = true;
            this.Key_7.Click += new System.EventHandler(this.Key_7_Click);
            // 
            // Key_0
            // 
            this.Key_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_0.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_0.Location = new System.Drawing.Point(262, 184);
            this.Key_0.Name = "Key_0";
            this.Key_0.Size = new System.Drawing.Size(40, 40);
            this.Key_0.TabIndex = 16;
            this.Key_0.Text = "0";
            this.Key_0.UseVisualStyleBackColor = true;
            this.Key_0.Click += new System.EventHandler(this.Key_0_Click);
            // 
            // Key_Del
            // 
            this.Key_Del.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Key_Del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Key_Del.Font = new System.Drawing.Font("幼圆", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Key_Del.Location = new System.Drawing.Point(308, 184);
            this.Key_Del.Name = "Key_Del";
            this.Key_Del.Size = new System.Drawing.Size(40, 40);
            this.Key_Del.TabIndex = 17;
            this.Key_Del.Text = "←";
            this.Key_Del.UseVisualStyleBackColor = false;
            this.Key_Del.Click += new System.EventHandler(this.Key_Del_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginBtn.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.loginBtn.ForeColor = System.Drawing.Color.White;
            this.loginBtn.Location = new System.Drawing.Point(273, 82);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 33);
            this.loginBtn.TabIndex = 18;
            this.loginBtn.Text = "登  录";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 249);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.Key_Del);
            this.Controls.Add(this.Key_0);
            this.Controls.Add(this.Key_9);
            this.Controls.Add(this.Key_8);
            this.Controls.Add(this.Key_7);
            this.Controls.Add(this.Key_6);
            this.Controls.Add(this.Key_5);
            this.Controls.Add(this.Key_4);
            this.Controls.Add(this.Key_3);
            this.Controls.Add(this.Key_2);
            this.Controls.Add(this.Key_1);
            this.Controls.Add(this.Key_W);
            this.Controls.Add(this.Key_F);
            this.Controls.Add(this.Key_R);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "国贸在线称重平台";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.Button Key_R;
        private System.Windows.Forms.Button Key_F;
        private System.Windows.Forms.Button Key_W;
        private System.Windows.Forms.Button Key_1;
        private System.Windows.Forms.Button Key_2;
        private System.Windows.Forms.Button Key_3;
        private System.Windows.Forms.Button Key_4;
        private System.Windows.Forms.Button Key_5;
        private System.Windows.Forms.Button Key_6;
        private System.Windows.Forms.Button Key_9;
        private System.Windows.Forms.Button Key_8;
        private System.Windows.Forms.Button Key_7;
        private System.Windows.Forms.Button Key_0;
        private System.Windows.Forms.Button Key_Del;
        private System.Windows.Forms.Button loginBtn;
    }
}