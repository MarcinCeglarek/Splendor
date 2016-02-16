namespace SplendorFormsClient
{
    using SplendorFormsClient.Panels;

    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl11 = new SplendorFormsClient.Panels.UserControl1();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl12 = new SplendorFormsClient.Panels.UserControl1();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl13 = new SplendorFormsClient.Panels.UserControl1();
            this.elementHost4 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl14 = new SplendorFormsClient.Panels.UserControl1();
            this.elementHost5 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl15 = new SplendorFormsClient.Panels.UserControl1();
            this.elementHost6 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl16 = new SplendorFormsClient.Panels.UserControl1();
            this.elementHost7 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl17 = new SplendorFormsClient.Panels.UserControl1();
            this.elementHost8 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl18 = new SplendorFormsClient.Panels.UserControl1();
            this.elementHost9 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl19 = new SplendorFormsClient.Panels.UserControl1();
            this.elementHost10 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl110 = new SplendorFormsClient.Panels.UserControl1();
            this.elementHost11 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl111 = new SplendorFormsClient.Panels.UserControl1();
            this.elementHost12 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl112 = new SplendorFormsClient.Panels.UserControl1();
            this.playerPanel1 = new SplendorFormsClient.Panels.PlayerPanel(this.game.CurrentPlayer);
            this.playerPanel2 = new SplendorFormsClient.Panels.PlayerPanel(this.game.CurrentPlayer);
            this.playerPanel3 = new SplendorFormsClient.Panels.PlayerPanel(this.game.CurrentPlayer);
            this.playerPanel4 = new SplendorFormsClient.Panels.PlayerPanel(this.game.CurrentPlayer);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 53);
            this.button1.TabIndex = 21;
            this.button1.Text = "Initialize";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(117, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 53);
            this.button2.TabIndex = 22;
            this.button2.Text = "Shuffle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(12, 71);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(200, 256);
            this.elementHost1.TabIndex = 23;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.userControl11;
            // 
            // elementHost2
            // 
            this.elementHost2.Location = new System.Drawing.Point(218, 71);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(200, 256);
            this.elementHost2.TabIndex = 24;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = this.userControl12;
            // 
            // elementHost3
            // 
            this.elementHost3.Location = new System.Drawing.Point(424, 71);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(200, 256);
            this.elementHost3.TabIndex = 25;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.Child = this.userControl13;
            // 
            // elementHost4
            // 
            this.elementHost4.Location = new System.Drawing.Point(630, 71);
            this.elementHost4.Name = "elementHost4";
            this.elementHost4.Size = new System.Drawing.Size(200, 256);
            this.elementHost4.TabIndex = 26;
            this.elementHost4.Text = "elementHost4";
            this.elementHost4.Child = this.userControl14;
            // 
            // elementHost5
            // 
            this.elementHost5.Location = new System.Drawing.Point(12, 333);
            this.elementHost5.Name = "elementHost5";
            this.elementHost5.Size = new System.Drawing.Size(200, 256);
            this.elementHost5.TabIndex = 30;
            this.elementHost5.Text = "elementHost5";
            this.elementHost5.Child = this.userControl15;
            // 
            // elementHost6
            // 
            this.elementHost6.Location = new System.Drawing.Point(218, 333);
            this.elementHost6.Name = "elementHost6";
            this.elementHost6.Size = new System.Drawing.Size(200, 256);
            this.elementHost6.TabIndex = 29;
            this.elementHost6.Text = "elementHost6";
            this.elementHost6.Child = this.userControl16;
            // 
            // elementHost7
            // 
            this.elementHost7.Location = new System.Drawing.Point(424, 333);
            this.elementHost7.Name = "elementHost7";
            this.elementHost7.Size = new System.Drawing.Size(200, 256);
            this.elementHost7.TabIndex = 28;
            this.elementHost7.Text = "elementHost7";
            this.elementHost7.Child = this.userControl17;
            // 
            // elementHost8
            // 
            this.elementHost8.Location = new System.Drawing.Point(630, 333);
            this.elementHost8.Name = "elementHost8";
            this.elementHost8.Size = new System.Drawing.Size(200, 256);
            this.elementHost8.TabIndex = 27;
            this.elementHost8.Text = "elementHost8";
            this.elementHost8.Child = this.userControl18;
            // 
            // elementHost9
            // 
            this.elementHost9.Location = new System.Drawing.Point(12, 595);
            this.elementHost9.Name = "elementHost9";
            this.elementHost9.Size = new System.Drawing.Size(200, 256);
            this.elementHost9.TabIndex = 34;
            this.elementHost9.Text = "elementHost9";
            this.elementHost9.Child = this.userControl19;
            // 
            // elementHost10
            // 
            this.elementHost10.Location = new System.Drawing.Point(218, 595);
            this.elementHost10.Name = "elementHost10";
            this.elementHost10.Size = new System.Drawing.Size(200, 256);
            this.elementHost10.TabIndex = 33;
            this.elementHost10.Text = "elementHost10";
            this.elementHost10.Child = this.userControl110;
            // 
            // elementHost11
            // 
            this.elementHost11.Location = new System.Drawing.Point(424, 595);
            this.elementHost11.Name = "elementHost11";
            this.elementHost11.Size = new System.Drawing.Size(200, 256);
            this.elementHost11.TabIndex = 32;
            this.elementHost11.Text = "elementHost11";
            this.elementHost11.Child = this.userControl111;
            // 
            // elementHost12
            // 
            this.elementHost12.Location = new System.Drawing.Point(630, 595);
            this.elementHost12.Name = "elementHost12";
            this.elementHost12.Size = new System.Drawing.Size(200, 256);
            this.elementHost12.TabIndex = 31;
            this.elementHost12.Text = "elementHost12";
            this.elementHost12.Child = this.userControl112;
            // 
            // playerPanel1
            // 
            this.playerPanel1.Location = new System.Drawing.Point(12, 867);
            this.playerPanel1.Name = "playerPanel1";
            this.playerPanel1.Player = null;
            this.playerPanel1.Size = new System.Drawing.Size(287, 273);
            this.playerPanel1.TabIndex = 35;
            // 
            // playerPanel2
            // 
            this.playerPanel2.Location = new System.Drawing.Point(305, 867);
            this.playerPanel2.Name = "playerPanel2";
            this.playerPanel2.Player = null;
            this.playerPanel2.Size = new System.Drawing.Size(287, 273);
            this.playerPanel2.TabIndex = 36;
            // 
            // playerPanel3
            // 
            this.playerPanel3.Location = new System.Drawing.Point(598, 867);
            this.playerPanel3.Name = "playerPanel3";
            this.playerPanel3.Player = null;
            this.playerPanel3.Size = new System.Drawing.Size(287, 273);
            this.playerPanel3.TabIndex = 37;
            // 
            // playerPanel4
            // 
            this.playerPanel4.Location = new System.Drawing.Point(891, 867);
            this.playerPanel4.Name = "playerPanel4";
            this.playerPanel4.Player = null;
            this.playerPanel4.Size = new System.Drawing.Size(287, 273);
            this.playerPanel4.TabIndex = 38;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 1171);
            this.Controls.Add(this.playerPanel4);
            this.Controls.Add(this.playerPanel3);
            this.Controls.Add(this.playerPanel2);
            this.Controls.Add(this.playerPanel1);
            this.Controls.Add(this.elementHost9);
            this.Controls.Add(this.elementHost10);
            this.Controls.Add(this.elementHost11);
            this.Controls.Add(this.elementHost12);
            this.Controls.Add(this.elementHost5);
            this.Controls.Add(this.elementHost6);
            this.Controls.Add(this.elementHost7);
            this.Controls.Add(this.elementHost8);
            this.Controls.Add(this.elementHost4);
            this.Controls.Add(this.elementHost3);
            this.Controls.Add(this.elementHost2);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private UserControl1 userControl11;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private UserControl1 userControl12;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private UserControl1 userControl13;
        private System.Windows.Forms.Integration.ElementHost elementHost4;
        private UserControl1 userControl14;
        private System.Windows.Forms.Integration.ElementHost elementHost5;
        private UserControl1 userControl15;
        private System.Windows.Forms.Integration.ElementHost elementHost6;
        private UserControl1 userControl16;
        private System.Windows.Forms.Integration.ElementHost elementHost7;
        private UserControl1 userControl17;
        private System.Windows.Forms.Integration.ElementHost elementHost8;
        private UserControl1 userControl18;
        private System.Windows.Forms.Integration.ElementHost elementHost9;
        private UserControl1 userControl19;
        private System.Windows.Forms.Integration.ElementHost elementHost10;
        private UserControl1 userControl110;
        private System.Windows.Forms.Integration.ElementHost elementHost11;
        private UserControl1 userControl111;
        private System.Windows.Forms.Integration.ElementHost elementHost12;
        private UserControl1 userControl112;
        private PlayerPanel playerPanel1;
        private PlayerPanel playerPanel2;
        private PlayerPanel playerPanel3;
        private PlayerPanel playerPanel4;
    }
}

