namespace Progress_Tracker {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dayTitle = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addExercise = new System.Windows.Forms.Button();
            this.sets_volume = new System.Windows.Forms.Label();
            this.UserPage = new System.Windows.Forms.Panel();
            this.loginPagePanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.passwordVisible = new System.Windows.Forms.CheckBox();
            this.loginPassword = new System.Windows.Forms.TextBox();
            this.loginUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SignupPagePanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.signupBtn = new System.Windows.Forms.Button();
            this.signupPassword = new System.Windows.Forms.TextBox();
            this.signupUsername = new System.Windows.Forms.TextBox();
            this.signupPasswordVerification = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.UserPage.SuspendLayout();
            this.loginPagePanel.SuspendLayout();
            this.SignupPagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dayTitle
            // 
            this.dayTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dayTitle.BackColor = System.Drawing.Color.Red;
            this.dayTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.dayTitle.Location = new System.Drawing.Point(265, 87);
            this.dayTitle.Multiline = true;
            this.dayTitle.Name = "dayTitle";
            this.dayTitle.Size = new System.Drawing.Size(207, 66);
            this.dayTitle.TabIndex = 7;
            this.dayTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dayTitle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.changeDayName);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(126, 31);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(130, 29);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.Value = new System.DateTime(2024, 1, 9, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.addExercise);
            this.panel1.Location = new System.Drawing.Point(95, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 460);
            this.panel1.TabIndex = 15;
            // 
            // addExercise
            // 
            this.addExercise.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addExercise.BackColor = System.Drawing.Color.Red;
            this.addExercise.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addExercise.ForeColor = System.Drawing.SystemColors.Control;
            this.addExercise.Location = new System.Drawing.Point(324, 59);
            this.addExercise.MinimumSize = new System.Drawing.Size(160, 36);
            this.addExercise.Name = "addExercise";
            this.addExercise.Size = new System.Drawing.Size(160, 36);
            this.addExercise.TabIndex = 11;
            this.addExercise.Text = "Add Exercise";
            this.addExercise.UseVisualStyleBackColor = false;
            this.addExercise.Click += new System.EventHandler(this.addExercise_Click);
            // 
            // sets_volume
            // 
            this.sets_volume.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.sets_volume.BackColor = System.Drawing.Color.Red;
            this.sets_volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.sets_volume.ForeColor = System.Drawing.SystemColors.Control;
            this.sets_volume.Location = new System.Drawing.Point(518, 87);
            this.sets_volume.Name = "sets_volume";
            this.sets_volume.Size = new System.Drawing.Size(237, 66);
            this.sets_volume.TabIndex = 16;
            this.sets_volume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserPage
            // 
            this.UserPage.BackColor = System.Drawing.Color.Transparent;
            this.UserPage.Controls.Add(this.loginPagePanel);
            this.UserPage.Controls.Add(this.SignupPagePanel);
            this.UserPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserPage.Location = new System.Drawing.Point(0, 0);
            this.UserPage.Name = "UserPage";
            this.UserPage.Size = new System.Drawing.Size(1009, 654);
            this.UserPage.TabIndex = 17;
            // 
            // loginPagePanel
            // 
            this.loginPagePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginPagePanel.BackColor = System.Drawing.Color.Gray;
            this.loginPagePanel.Controls.Add(this.label5);
            this.loginPagePanel.Controls.Add(this.label4);
            this.loginPagePanel.Controls.Add(this.loginBtn);
            this.loginPagePanel.Controls.Add(this.passwordVisible);
            this.loginPagePanel.Controls.Add(this.loginPassword);
            this.loginPagePanel.Controls.Add(this.loginUsername);
            this.loginPagePanel.Controls.Add(this.label3);
            this.loginPagePanel.Controls.Add(this.label2);
            this.loginPagePanel.Controls.Add(this.label1);
            this.loginPagePanel.Location = new System.Drawing.Point(317, 128);
            this.loginPagePanel.Name = "loginPagePanel";
            this.loginPagePanel.Size = new System.Drawing.Size(394, 416);
            this.loginPagePanel.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(218, 366);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Sign Up.";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.Location = new System.Drawing.Point(72, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Not a member?";
            // 
            // loginBtn
            // 
            this.loginBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loginBtn.BackColor = System.Drawing.Color.Red;
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.loginBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.loginBtn.Location = new System.Drawing.Point(120, 310);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(150, 50);
            this.loginBtn.TabIndex = 6;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // passwordVisible
            // 
            this.passwordVisible.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.passwordVisible.AutoSize = true;
            this.passwordVisible.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.passwordVisible.Location = new System.Drawing.Point(222, 201);
            this.passwordVisible.Name = "passwordVisible";
            this.passwordVisible.Size = new System.Drawing.Size(96, 30);
            this.passwordVisible.TabIndex = 5;
            this.passwordVisible.Text = "Visible";
            this.passwordVisible.UseVisualStyleBackColor = true;
            this.passwordVisible.CheckedChanged += new System.EventHandler(this.passwordVisible_CheckedChanged);
            // 
            // loginPassword
            // 
            this.loginPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.loginPassword.Location = new System.Drawing.Point(60, 242);
            this.loginPassword.Name = "loginPassword";
            this.loginPassword.PasswordChar = '*';
            this.loginPassword.Size = new System.Drawing.Size(276, 38);
            this.loginPassword.TabIndex = 4;
            // 
            // loginUsername
            // 
            this.loginUsername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.loginUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.loginUsername.Location = new System.Drawing.Point(60, 149);
            this.loginUsername.Name = "loginUsername";
            this.loginUsername.Size = new System.Drawing.Size(276, 38);
            this.loginUsername.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.Location = new System.Drawing.Point(82, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(130, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login Page";
            // 
            // SignupPagePanel
            // 
            this.SignupPagePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SignupPagePanel.BackColor = System.Drawing.Color.Gray;
            this.SignupPagePanel.Controls.Add(this.label11);
            this.SignupPagePanel.Controls.Add(this.label6);
            this.SignupPagePanel.Controls.Add(this.label7);
            this.SignupPagePanel.Controls.Add(this.signupBtn);
            this.SignupPagePanel.Controls.Add(this.signupPassword);
            this.SignupPagePanel.Controls.Add(this.signupUsername);
            this.SignupPagePanel.Controls.Add(this.signupPasswordVerification);
            this.SignupPagePanel.Controls.Add(this.label8);
            this.SignupPagePanel.Controls.Add(this.label9);
            this.SignupPagePanel.Controls.Add(this.label10);
            this.SignupPagePanel.Location = new System.Drawing.Point(317, 128);
            this.SignupPagePanel.Name = "SignupPagePanel";
            this.SignupPagePanel.Size = new System.Drawing.Size(394, 416);
            this.SignupPagePanel.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label11.Location = new System.Drawing.Point(97, 228);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(211, 31);
            this.label11.TabIndex = 10;
            this.label11.Text = "Verify Password";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(238, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "Login.";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label7.Location = new System.Drawing.Point(66, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "Already a member?";
            // 
            // signupBtn
            // 
            this.signupBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.signupBtn.BackColor = System.Drawing.Color.Red;
            this.signupBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.signupBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.signupBtn.Location = new System.Drawing.Point(120, 310);
            this.signupBtn.Name = "signupBtn";
            this.signupBtn.Size = new System.Drawing.Size(150, 50);
            this.signupBtn.TabIndex = 6;
            this.signupBtn.Text = "Sign Up";
            this.signupBtn.UseVisualStyleBackColor = false;
            this.signupBtn.Click += new System.EventHandler(this.signupBtn_Click);
            // 
            // signupPassword
            // 
            this.signupPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.signupPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.signupPassword.Location = new System.Drawing.Point(60, 190);
            this.signupPassword.Name = "signupPassword";
            this.signupPassword.PasswordChar = '*';
            this.signupPassword.Size = new System.Drawing.Size(276, 38);
            this.signupPassword.TabIndex = 4;
            // 
            // signupUsername
            // 
            this.signupUsername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.signupUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.signupUsername.Location = new System.Drawing.Point(60, 105);
            this.signupUsername.Name = "signupUsername";
            this.signupUsername.Size = new System.Drawing.Size(276, 38);
            this.signupUsername.TabIndex = 3;
            // 
            // signupPasswordVerification
            // 
            this.signupPasswordVerification.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.signupPasswordVerification.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.signupPasswordVerification.Location = new System.Drawing.Point(60, 262);
            this.signupPasswordVerification.Name = "signupPasswordVerification";
            this.signupPasswordVerification.PasswordChar = '*';
            this.signupPasswordVerification.Size = new System.Drawing.Size(276, 38);
            this.signupPasswordVerification.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label8.Location = new System.Drawing.Point(136, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 31);
            this.label8.TabIndex = 2;
            this.label8.Text = "Password";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label9.Location = new System.Drawing.Point(131, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 31);
            this.label9.TabIndex = 1;
            this.label9.Text = "Username";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(266, 46);
            this.label10.TabIndex = 0;
            this.label10.Text = "Sign Up Page";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(854, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 33);
            this.button1.TabIndex = 10;
            this.button1.Text = "Log Out";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Progress_Tracker.Properties.Resources.crossedSheetDarker;
            this.ClientSize = new System.Drawing.Size(1009, 654);
            this.Controls.Add(this.UserPage);
            this.Controls.Add(this.sets_volume);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dayTitle);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "ExerTrace";
            this.panel1.ResumeLayout(false);
            this.UserPage.ResumeLayout(false);
            this.loginPagePanel.ResumeLayout(false);
            this.loginPagePanel.PerformLayout();
            this.SignupPagePanel.ResumeLayout(false);
            this.SignupPagePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox dayTitle;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button addExercise;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label sets_volume;
        private System.Windows.Forms.Panel UserPage;
        private System.Windows.Forms.Panel loginPagePanel;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.CheckBox passwordVisible;
        private System.Windows.Forms.TextBox loginPassword;
        private System.Windows.Forms.TextBox loginUsername;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel SignupPagePanel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button signupBtn;
        private System.Windows.Forms.TextBox signupPassword;
        private System.Windows.Forms.TextBox signupUsername;
        private System.Windows.Forms.TextBox signupPasswordVerification;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
    }
}

