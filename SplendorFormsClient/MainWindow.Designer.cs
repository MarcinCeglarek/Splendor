namespace SplendorFormsClient
{
    using System.Windows.Media;

    using SplendorCore.Models;

    using SplendorFormsClient.Panels;

    partial class MainWindow
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
            this.AddPlayer = new System.Windows.Forms.Button();
            this.StartGame = new System.Windows.Forms.Button();
            this.BankPanel = new System.Windows.Forms.GroupBox();
            this.GoldChips = new System.Windows.Forms.Button();
            this.BlackChips = new System.Windows.Forms.Button();
            this.RedChips = new System.Windows.Forms.Button();
            this.GreenChips = new System.Windows.Forms.Button();
            this.BlueChips = new System.Windows.Forms.Button();
            this.WhiteChips = new System.Windows.Forms.Button();
            this.BankTakeButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TakenBlackChips = new System.Windows.Forms.Button();
            this.TakenRedChips = new System.Windows.Forms.Button();
            this.TakenWhiteChips = new System.Windows.Forms.Button();
            this.TakenGreenChips = new System.Windows.Forms.Button();
            this.TakenBlueChips = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.playerPanel4 = new SplendorFormsClient.Panels.PlayerPanel();
            this.playerPanel3 = new SplendorFormsClient.Panels.PlayerPanel();
            this.playerPanel2 = new SplendorFormsClient.Panels.PlayerPanel();
            this.playerPanel1 = new SplendorFormsClient.Panels.PlayerPanel();
            this.Card34 = new SplendorFormsClient.Panels.CardPanel();
            this.Card33 = new SplendorFormsClient.Panels.CardPanel();
            this.Card32 = new SplendorFormsClient.Panels.CardPanel();
            this.Card31 = new SplendorFormsClient.Panels.CardPanel();
            this.Card24 = new SplendorFormsClient.Panels.CardPanel();
            this.Card23 = new SplendorFormsClient.Panels.CardPanel();
            this.Card22 = new SplendorFormsClient.Panels.CardPanel();
            this.Card21 = new SplendorFormsClient.Panels.CardPanel();
            this.Card14 = new SplendorFormsClient.Panels.CardPanel();
            this.Card13 = new SplendorFormsClient.Panels.CardPanel();
            this.Card12 = new SplendorFormsClient.Panels.CardPanel();
            this.Card11 = new SplendorFormsClient.Panels.CardPanel();
            this.PlayerNameBox = new System.Windows.Forms.TextBox();
            this.BankPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddPlayer
            // 
            this.AddPlayer.Enabled = false;
            this.AddPlayer.Location = new System.Drawing.Point(200, 35);
            this.AddPlayer.Name = "AddPlayer";
            this.AddPlayer.Size = new System.Drawing.Size(99, 20);
            this.AddPlayer.TabIndex = 21;
            this.AddPlayer.Text = "Add Player";
            this.AddPlayer.UseVisualStyleBackColor = true;
            this.AddPlayer.Click += new System.EventHandler(this.AddPlayer_Click);
            // 
            // StartGame
            // 
            this.StartGame.Enabled = false;
            this.StartGame.Location = new System.Drawing.Point(305, 35);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(99, 20);
            this.StartGame.TabIndex = 22;
            this.StartGame.Text = "Start Game";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // BankPanel
            // 
            this.BankPanel.Controls.Add(this.GoldChips);
            this.BankPanel.Controls.Add(this.BlackChips);
            this.BankPanel.Controls.Add(this.RedChips);
            this.BankPanel.Controls.Add(this.GreenChips);
            this.BankPanel.Controls.Add(this.BlueChips);
            this.BankPanel.Controls.Add(this.WhiteChips);
            this.BankPanel.Location = new System.Drawing.Point(836, 71);
            this.BankPanel.Name = "BankPanel";
            this.BankPanel.Size = new System.Drawing.Size(360, 74);
            this.BankPanel.TabIndex = 40;
            this.BankPanel.TabStop = false;
            this.BankPanel.Text = "Bank";
            // 
            // GoldChips
            // 
            this.GoldChips.BackColor = System.Drawing.Color.Yellow;
            this.GoldChips.Enabled = false;
            this.GoldChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GoldChips.Location = new System.Drawing.Point(307, 19);
            this.GoldChips.Name = "GoldChips";
            this.GoldChips.Size = new System.Drawing.Size(47, 45);
            this.GoldChips.TabIndex = 6;
            this.GoldChips.Text = "0";
            this.GoldChips.UseVisualStyleBackColor = false;
            // 
            // BlackChips
            // 
            this.BlackChips.BackColor = System.Drawing.Color.Black;
            this.BlackChips.Enabled = false;
            this.BlackChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BlackChips.ForeColor = System.Drawing.Color.White;
            this.BlackChips.Location = new System.Drawing.Point(218, 19);
            this.BlackChips.Name = "BlackChips";
            this.BlackChips.Size = new System.Drawing.Size(47, 45);
            this.BlackChips.TabIndex = 5;
            this.BlackChips.Text = "0";
            this.BlackChips.UseVisualStyleBackColor = false;
            this.BlackChips.Click += new System.EventHandler(this.BlackChips_Click);
            // 
            // RedChips
            // 
            this.RedChips.BackColor = System.Drawing.Color.Red;
            this.RedChips.Enabled = false;
            this.RedChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RedChips.ForeColor = System.Drawing.Color.White;
            this.RedChips.Location = new System.Drawing.Point(165, 19);
            this.RedChips.Name = "RedChips";
            this.RedChips.Size = new System.Drawing.Size(47, 45);
            this.RedChips.TabIndex = 4;
            this.RedChips.Text = "0";
            this.RedChips.UseVisualStyleBackColor = false;
            this.RedChips.Click += new System.EventHandler(this.RedChips_Click);
            // 
            // GreenChips
            // 
            this.GreenChips.BackColor = System.Drawing.Color.Green;
            this.GreenChips.Enabled = false;
            this.GreenChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GreenChips.ForeColor = System.Drawing.Color.White;
            this.GreenChips.Location = new System.Drawing.Point(112, 19);
            this.GreenChips.Name = "GreenChips";
            this.GreenChips.Size = new System.Drawing.Size(47, 45);
            this.GreenChips.TabIndex = 3;
            this.GreenChips.Text = "0";
            this.GreenChips.UseVisualStyleBackColor = false;
            this.GreenChips.Click += new System.EventHandler(this.GreenChips_Click);
            // 
            // BlueChips
            // 
            this.BlueChips.BackColor = System.Drawing.Color.Blue;
            this.BlueChips.Enabled = false;
            this.BlueChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BlueChips.ForeColor = System.Drawing.Color.White;
            this.BlueChips.Location = new System.Drawing.Point(59, 19);
            this.BlueChips.Name = "BlueChips";
            this.BlueChips.Size = new System.Drawing.Size(47, 45);
            this.BlueChips.TabIndex = 2;
            this.BlueChips.Text = "0";
            this.BlueChips.UseVisualStyleBackColor = false;
            this.BlueChips.Click += new System.EventHandler(this.BlueChips_Click);
            // 
            // WhiteChips
            // 
            this.WhiteChips.BackColor = System.Drawing.Color.White;
            this.WhiteChips.Enabled = false;
            this.WhiteChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WhiteChips.Location = new System.Drawing.Point(6, 19);
            this.WhiteChips.Name = "WhiteChips";
            this.WhiteChips.Size = new System.Drawing.Size(47, 45);
            this.WhiteChips.TabIndex = 1;
            this.WhiteChips.Text = "0";
            this.WhiteChips.UseVisualStyleBackColor = false;
            this.WhiteChips.Click += new System.EventHandler(this.WhiteChips_Click);
            // 
            // BankTakeButton
            // 
            this.BankTakeButton.Location = new System.Drawing.Point(6, 67);
            this.BankTakeButton.Name = "BankTakeButton";
            this.BankTakeButton.Size = new System.Drawing.Size(348, 31);
            this.BankTakeButton.TabIndex = 0;
            this.BankTakeButton.Text = "Take";
            this.BankTakeButton.UseVisualStyleBackColor = true;
            this.BankTakeButton.Click += new System.EventHandler(this.BankTakeButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TakenBlackChips);
            this.groupBox2.Controls.Add(this.BankTakeButton);
            this.groupBox2.Controls.Add(this.TakenRedChips);
            this.groupBox2.Controls.Add(this.TakenWhiteChips);
            this.groupBox2.Controls.Add(this.TakenGreenChips);
            this.groupBox2.Controls.Add(this.TakenBlueChips);
            this.groupBox2.Location = new System.Drawing.Point(836, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 104);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Take";
            // 
            // TakenBlackChips
            // 
            this.TakenBlackChips.BackColor = System.Drawing.Color.Black;
            this.TakenBlackChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TakenBlackChips.ForeColor = System.Drawing.Color.White;
            this.TakenBlackChips.Location = new System.Drawing.Point(218, 19);
            this.TakenBlackChips.Name = "TakenBlackChips";
            this.TakenBlackChips.Size = new System.Drawing.Size(47, 45);
            this.TakenBlackChips.TabIndex = 11;
            this.TakenBlackChips.Text = "0";
            this.TakenBlackChips.UseVisualStyleBackColor = false;
            this.TakenBlackChips.Visible = false;
            this.TakenBlackChips.Click += new System.EventHandler(this.TakenBlackChips_Click);
            // 
            // TakenRedChips
            // 
            this.TakenRedChips.BackColor = System.Drawing.Color.Red;
            this.TakenRedChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TakenRedChips.ForeColor = System.Drawing.Color.White;
            this.TakenRedChips.Location = new System.Drawing.Point(165, 19);
            this.TakenRedChips.Name = "TakenRedChips";
            this.TakenRedChips.Size = new System.Drawing.Size(47, 45);
            this.TakenRedChips.TabIndex = 10;
            this.TakenRedChips.Text = "0";
            this.TakenRedChips.UseVisualStyleBackColor = false;
            this.TakenRedChips.Visible = false;
            this.TakenRedChips.Click += new System.EventHandler(this.TakenRedChips_Click);
            // 
            // TakenWhiteChips
            // 
            this.TakenWhiteChips.BackColor = System.Drawing.Color.White;
            this.TakenWhiteChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TakenWhiteChips.Location = new System.Drawing.Point(6, 19);
            this.TakenWhiteChips.Name = "TakenWhiteChips";
            this.TakenWhiteChips.Size = new System.Drawing.Size(47, 45);
            this.TakenWhiteChips.TabIndex = 7;
            this.TakenWhiteChips.Text = "0";
            this.TakenWhiteChips.UseVisualStyleBackColor = false;
            this.TakenWhiteChips.Visible = false;
            this.TakenWhiteChips.Click += new System.EventHandler(this.TakenWhiteChips_Click);
            // 
            // TakenGreenChips
            // 
            this.TakenGreenChips.BackColor = System.Drawing.Color.Green;
            this.TakenGreenChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TakenGreenChips.ForeColor = System.Drawing.Color.White;
            this.TakenGreenChips.Location = new System.Drawing.Point(112, 19);
            this.TakenGreenChips.Name = "TakenGreenChips";
            this.TakenGreenChips.Size = new System.Drawing.Size(47, 45);
            this.TakenGreenChips.TabIndex = 9;
            this.TakenGreenChips.Text = "0";
            this.TakenGreenChips.UseVisualStyleBackColor = false;
            this.TakenGreenChips.Visible = false;
            this.TakenGreenChips.Click += new System.EventHandler(this.TakenGreenChips_Click);
            // 
            // TakenBlueChips
            // 
            this.TakenBlueChips.BackColor = System.Drawing.Color.Blue;
            this.TakenBlueChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TakenBlueChips.ForeColor = System.Drawing.Color.White;
            this.TakenBlueChips.Location = new System.Drawing.Point(59, 19);
            this.TakenBlueChips.Name = "TakenBlueChips";
            this.TakenBlueChips.Size = new System.Drawing.Size(47, 45);
            this.TakenBlueChips.TabIndex = 8;
            this.TakenBlueChips.Text = "0";
            this.TakenBlueChips.UseVisualStyleBackColor = false;
            this.TakenBlueChips.Visible = false;
            this.TakenBlueChips.Click += new System.EventHandler(this.TakenBlueChips_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(836, 261);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(360, 516);
            this.textBox1.TabIndex = 62;
            // 
            // playerPanel4
            // 
            this.playerPanel4.Location = new System.Drawing.Point(891, 783);
            this.playerPanel4.Name = "playerPanel4";
            this.playerPanel4.Player = null;
            this.playerPanel4.Size = new System.Drawing.Size(287, 256);
            this.playerPanel4.TabIndex = 61;
            this.playerPanel4.Visible = false;
            // 
            // playerPanel3
            // 
            this.playerPanel3.Location = new System.Drawing.Point(598, 783);
            this.playerPanel3.Name = "playerPanel3";
            this.playerPanel3.Player = null;
            this.playerPanel3.Size = new System.Drawing.Size(287, 256);
            this.playerPanel3.TabIndex = 60;
            this.playerPanel3.Visible = false;
            // 
            // playerPanel2
            // 
            this.playerPanel2.Location = new System.Drawing.Point(305, 783);
            this.playerPanel2.Name = "playerPanel2";
            this.playerPanel2.Player = null;
            this.playerPanel2.Size = new System.Drawing.Size(287, 256);
            this.playerPanel2.TabIndex = 59;
            this.playerPanel2.Visible = false;
            // 
            // playerPanel1
            // 
            this.playerPanel1.Location = new System.Drawing.Point(12, 783);
            this.playerPanel1.Name = "playerPanel1";
            this.playerPanel1.Player = null;
            this.playerPanel1.Size = new System.Drawing.Size(287, 256);
            this.playerPanel1.TabIndex = 58;
            this.playerPanel1.Visible = false;
            // 
            // Card34
            // 
            this.Card34.Card = null;
            this.Card34.Location = new System.Drawing.Point(621, 554);
            this.Card34.Name = "Card34";
            this.Card34.Size = new System.Drawing.Size(197, 223);
            this.Card34.TabIndex = 57;
            // 
            // Card33
            // 
            this.Card33.Card = null;
            this.Card33.Location = new System.Drawing.Point(418, 554);
            this.Card33.Name = "Card33";
            this.Card33.Size = new System.Drawing.Size(197, 223);
            this.Card33.TabIndex = 56;
            // 
            // Card32
            // 
            this.Card32.Card = null;
            this.Card32.Location = new System.Drawing.Point(215, 554);
            this.Card32.Name = "Card32";
            this.Card32.Size = new System.Drawing.Size(197, 223);
            this.Card32.TabIndex = 55;
            // 
            // Card31
            // 
            this.Card31.Card = null;
            this.Card31.Location = new System.Drawing.Point(12, 554);
            this.Card31.Name = "Card31";
            this.Card31.Size = new System.Drawing.Size(197, 223);
            this.Card31.TabIndex = 54;
            // 
            // Card24
            // 
            this.Card24.Card = null;
            this.Card24.Location = new System.Drawing.Point(621, 324);
            this.Card24.Name = "Card24";
            this.Card24.Size = new System.Drawing.Size(197, 224);
            this.Card24.TabIndex = 53;
            // 
            // Card23
            // 
            this.Card23.Card = null;
            this.Card23.Location = new System.Drawing.Point(418, 324);
            this.Card23.Name = "Card23";
            this.Card23.Size = new System.Drawing.Size(197, 224);
            this.Card23.TabIndex = 52;
            // 
            // Card22
            // 
            this.Card22.Card = null;
            this.Card22.Location = new System.Drawing.Point(215, 324);
            this.Card22.Name = "Card22";
            this.Card22.Size = new System.Drawing.Size(197, 224);
            this.Card22.TabIndex = 51;
            // 
            // Card21
            // 
            this.Card21.Card = null;
            this.Card21.Location = new System.Drawing.Point(12, 324);
            this.Card21.Name = "Card21";
            this.Card21.Size = new System.Drawing.Size(197, 224);
            this.Card21.TabIndex = 50;
            // 
            // Card14
            // 
            this.Card14.Card = null;
            this.Card14.Location = new System.Drawing.Point(621, 90);
            this.Card14.Name = "Card14";
            this.Card14.Size = new System.Drawing.Size(197, 226);
            this.Card14.TabIndex = 49;
            // 
            // Card13
            // 
            this.Card13.Card = null;
            this.Card13.Location = new System.Drawing.Point(418, 90);
            this.Card13.Name = "Card13";
            this.Card13.Size = new System.Drawing.Size(197, 226);
            this.Card13.TabIndex = 48;
            // 
            // Card12
            // 
            this.Card12.Card = null;
            this.Card12.Location = new System.Drawing.Point(215, 90);
            this.Card12.Name = "Card12";
            this.Card12.Size = new System.Drawing.Size(197, 226);
            this.Card12.TabIndex = 47;
            // 
            // Card11
            // 
            this.Card11.Card = null;
            this.Card11.Location = new System.Drawing.Point(12, 90);
            this.Card11.Name = "Card11";
            this.Card11.Size = new System.Drawing.Size(197, 226);
            this.Card11.TabIndex = 46;
            // 
            // PlayerNameBox
            // 
            this.PlayerNameBox.Location = new System.Drawing.Point(12, 35);
            this.PlayerNameBox.Name = "PlayerNameBox";
            this.PlayerNameBox.Size = new System.Drawing.Size(182, 20);
            this.PlayerNameBox.TabIndex = 63;
            this.PlayerNameBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 1092);
            this.Controls.Add(this.PlayerNameBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.playerPanel4);
            this.Controls.Add(this.playerPanel3);
            this.Controls.Add(this.playerPanel2);
            this.Controls.Add(this.playerPanel1);
            this.Controls.Add(this.Card34);
            this.Controls.Add(this.Card33);
            this.Controls.Add(this.Card32);
            this.Controls.Add(this.Card31);
            this.Controls.Add(this.Card24);
            this.Controls.Add(this.Card23);
            this.Controls.Add(this.Card22);
            this.Controls.Add(this.Card21);
            this.Controls.Add(this.Card14);
            this.Controls.Add(this.Card13);
            this.Controls.Add(this.Card12);
            this.Controls.Add(this.Card11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BankPanel);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.AddPlayer);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.BankPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddPlayer;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.GroupBox BankPanel;
        private System.Windows.Forms.Button BlackChips;
        private System.Windows.Forms.Button RedChips;
        private System.Windows.Forms.Button GreenChips;
        private System.Windows.Forms.Button BlueChips;
        private System.Windows.Forms.Button WhiteChips;
        private System.Windows.Forms.Button BankTakeButton;
        private System.Windows.Forms.Button GoldChips;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button TakenBlackChips;
        private System.Windows.Forms.Button TakenRedChips;
        private System.Windows.Forms.Button TakenWhiteChips;
        private System.Windows.Forms.Button TakenGreenChips;
        private System.Windows.Forms.Button TakenBlueChips;
        private CardPanel Card11 = new CardPanel();
        private CardPanel Card12 = new CardPanel();
        private CardPanel Card13 = new CardPanel();
        private CardPanel Card14 = new CardPanel();
        private CardPanel Card24 = new CardPanel();
        private CardPanel Card23 = new CardPanel();
        private CardPanel Card22 = new CardPanel();
        private CardPanel Card21 = new CardPanel();
        private CardPanel Card34 = new CardPanel();
        private CardPanel Card33= new CardPanel();
        private CardPanel Card32= new CardPanel();
        private CardPanel Card31= new CardPanel();
        private PlayerPanel playerPanel1;
        private PlayerPanel playerPanel2;
        private PlayerPanel playerPanel3;
        private PlayerPanel playerPanel4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox PlayerNameBox;
        #region Fields


        #endregion
    }
}

