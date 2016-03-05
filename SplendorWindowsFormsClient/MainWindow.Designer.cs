namespace SplendorWindowsFormsClient
{
    using SplendorWindowsFormsClient.Panels;

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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.PlayerNameBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.BankPanel3 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TakenBlackChips = new System.Windows.Forms.Button();
            this.BankTakeButton = new System.Windows.Forms.Button();
            this.TakenRedChips = new System.Windows.Forms.Button();
            this.TakenWhiteChips = new System.Windows.Forms.Button();
            this.TakenGreenChips = new System.Windows.Forms.Button();
            this.TakenBlueChips = new System.Windows.Forms.Button();
            this.BankPanel = new System.Windows.Forms.GroupBox();
            this.BankGoldChips = new System.Windows.Forms.Button();
            this.BankBlackChips = new System.Windows.Forms.Button();
            this.BankRedChips = new System.Windows.Forms.Button();
            this.BankGreenChips = new System.Windows.Forms.Button();
            this.BankBlueChips = new System.Windows.Forms.Button();
            this.BankWhiteChips = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.AristocratesPanel = new System.Windows.Forms.Panel();
            this.CardsPanel = new System.Windows.Forms.Panel();
            this.PlayersPanel = new System.Windows.Forms.Panel();
            this.Tier1Cards = new System.Windows.Forms.Label();
            this.Tier2Cards = new System.Windows.Forms.Label();
            this.Tier3Cards = new System.Windows.Forms.Label();
            this.aristocrate5 = new AristocratePanel();
            this.aristocrate3 = new AristocratePanel();
            this.aristocrate2 = new AristocratePanel();
            this.aristocrate1 = new AristocratePanel();
            this.aristocrate4 = new AristocratePanel();
            this.Card11 = new CardPanel();
            this.Card34 = new CardPanel();
            this.Card33 = new CardPanel();
            this.Card32 = new CardPanel();
            this.Card31 = new CardPanel();
            this.Card24 = new CardPanel();
            this.Card23 = new CardPanel();
            this.Card22 = new CardPanel();
            this.Card21 = new CardPanel();
            this.Card14 = new CardPanel();
            this.Card13 = new CardPanel();
            this.Card12 = new CardPanel();
            this.playerPanel4 = new PlayerPanel();
            this.playerPanel3 = new PlayerPanel();
            this.playerPanel2 = new PlayerPanel();
            this.playerPanel1 = new PlayerPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.BankPanel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.BankPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.AristocratesPanel.SuspendLayout();
            this.CardsPanel.SuspendLayout();
            this.PlayersPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddPlayer
            // 
            this.AddPlayer.Enabled = false;
            this.AddPlayer.Location = new System.Drawing.Point(303, 461);
            this.AddPlayer.Name = "AddPlayer";
            this.AddPlayer.Size = new System.Drawing.Size(182, 28);
            this.AddPlayer.TabIndex = 21;
            this.AddPlayer.Text = "Add Player";
            this.AddPlayer.UseVisualStyleBackColor = true;
            this.AddPlayer.Click += new System.EventHandler(this.AddPlayerClick);
            // 
            // StartGame
            // 
            this.StartGame.Enabled = false;
            this.StartGame.Location = new System.Drawing.Point(491, 435);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(167, 54);
            this.StartGame.TabIndex = 22;
            this.StartGame.Text = "Start Game";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGameClick);
            // 
            // PlayerNameBox
            // 
            this.PlayerNameBox.Location = new System.Drawing.Point(303, 435);
            this.PlayerNameBox.Name = "PlayerNameBox";
            this.PlayerNameBox.Size = new System.Drawing.Size(182, 20);
            this.PlayerNameBox.TabIndex = 63;
            this.PlayerNameBox.TextChanged += new System.EventHandler(this.PlayerNameBoxTextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.25739F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PlayersPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.05901F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.941F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1203, 1022);
            this.tableLayoutPanel1.TabIndex = 69;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.7804F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.21959F));
            this.tableLayoutPanel2.Controls.Add(this.BankPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 756F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1203, 756);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // BankPanel3
            // 
            this.BankPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.BankPanel3.Controls.Add(this.textBox1);
            this.BankPanel3.Controls.Add(this.groupBox2);
            this.BankPanel3.Controls.Add(this.BankPanel);
            this.BankPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BankPanel3.Location = new System.Drawing.Point(779, 0);
            this.BankPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.BankPanel3.Name = "BankPanel3";
            this.BankPanel3.Size = new System.Drawing.Size(424, 756);
            this.BankPanel3.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(28, 238);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(360, 490);
            this.textBox1.TabIndex = 65;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.TakenBlackChips);
            this.groupBox2.Controls.Add(this.BankTakeButton);
            this.groupBox2.Controls.Add(this.TakenRedChips);
            this.groupBox2.Controls.Add(this.TakenWhiteChips);
            this.groupBox2.Controls.Add(this.TakenGreenChips);
            this.groupBox2.Controls.Add(this.TakenBlueChips);
            this.groupBox2.Location = new System.Drawing.Point(28, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 104);
            this.groupBox2.TabIndex = 64;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Take";
            // 
            // TakenBlackChips
            // 
            this.TakenBlackChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TakenBlackChips.Location = new System.Drawing.Point(218, 19);
            this.TakenBlackChips.Name = "TakenBlackChips";
            this.TakenBlackChips.Size = new System.Drawing.Size(47, 45);
            this.TakenBlackChips.TabIndex = 11;
            this.TakenBlackChips.Text = "0";
            this.TakenBlackChips.UseVisualStyleBackColor = false;
            this.TakenBlackChips.Visible = false;
            this.TakenBlackChips.Click += new System.EventHandler(this.TakenBlackChipsClick);
            // 
            // BankTakeButton
            // 
            this.BankTakeButton.Enabled = false;
            this.BankTakeButton.Location = new System.Drawing.Point(6, 67);
            this.BankTakeButton.Name = "BankTakeButton";
            this.BankTakeButton.Size = new System.Drawing.Size(348, 31);
            this.BankTakeButton.TabIndex = 0;
            this.BankTakeButton.Text = "Take";
            this.BankTakeButton.UseVisualStyleBackColor = true;
            this.BankTakeButton.Click += new System.EventHandler(this.BankTakeButtonClick);
            // 
            // TakenRedChips
            // 
            this.TakenRedChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TakenRedChips.Location = new System.Drawing.Point(165, 19);
            this.TakenRedChips.Name = "TakenRedChips";
            this.TakenRedChips.Size = new System.Drawing.Size(47, 45);
            this.TakenRedChips.TabIndex = 10;
            this.TakenRedChips.Text = "0";
            this.TakenRedChips.UseVisualStyleBackColor = false;
            this.TakenRedChips.Visible = false;
            this.TakenRedChips.Click += new System.EventHandler(this.TakenRedChipsClick);
            // 
            // TakenWhiteChips
            // 
            this.TakenWhiteChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TakenWhiteChips.Location = new System.Drawing.Point(6, 19);
            this.TakenWhiteChips.Name = "TakenWhiteChips";
            this.TakenWhiteChips.Size = new System.Drawing.Size(47, 45);
            this.TakenWhiteChips.TabIndex = 7;
            this.TakenWhiteChips.Text = "0";
            this.TakenWhiteChips.UseVisualStyleBackColor = false;
            this.TakenWhiteChips.Visible = false;
            this.TakenWhiteChips.Click += new System.EventHandler(this.TakenWhiteChipsClick);
            // 
            // TakenGreenChips
            // 
            this.TakenGreenChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TakenGreenChips.Location = new System.Drawing.Point(112, 19);
            this.TakenGreenChips.Name = "TakenGreenChips";
            this.TakenGreenChips.Size = new System.Drawing.Size(47, 45);
            this.TakenGreenChips.TabIndex = 9;
            this.TakenGreenChips.Text = "0";
            this.TakenGreenChips.UseVisualStyleBackColor = false;
            this.TakenGreenChips.Visible = false;
            this.TakenGreenChips.Click += new System.EventHandler(this.TakenGreenChipsClick);
            // 
            // TakenBlueChips
            // 
            this.TakenBlueChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TakenBlueChips.Location = new System.Drawing.Point(59, 19);
            this.TakenBlueChips.Name = "TakenBlueChips";
            this.TakenBlueChips.Size = new System.Drawing.Size(47, 45);
            this.TakenBlueChips.TabIndex = 8;
            this.TakenBlueChips.Text = "0";
            this.TakenBlueChips.UseVisualStyleBackColor = false;
            this.TakenBlueChips.Visible = false;
            this.TakenBlueChips.Click += new System.EventHandler(this.TakenBlueChipsClick);
            // 
            // BankPanel
            // 
            this.BankPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BankPanel.Controls.Add(this.BankGoldChips);
            this.BankPanel.Controls.Add(this.BankBlackChips);
            this.BankPanel.Controls.Add(this.BankRedChips);
            this.BankPanel.Controls.Add(this.BankGreenChips);
            this.BankPanel.Controls.Add(this.BankBlueChips);
            this.BankPanel.Controls.Add(this.BankWhiteChips);
            this.BankPanel.Location = new System.Drawing.Point(28, 27);
            this.BankPanel.Name = "BankPanel";
            this.BankPanel.Size = new System.Drawing.Size(360, 74);
            this.BankPanel.TabIndex = 63;
            this.BankPanel.TabStop = false;
            this.BankPanel.Text = "Bank";
            // 
            // BankGoldChips
            // 
            this.BankGoldChips.Enabled = false;
            this.BankGoldChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BankGoldChips.Location = new System.Drawing.Point(307, 19);
            this.BankGoldChips.Name = "BankGoldChips";
            this.BankGoldChips.Size = new System.Drawing.Size(47, 45);
            this.BankGoldChips.TabIndex = 6;
            this.BankGoldChips.Text = "0";
            this.BankGoldChips.UseVisualStyleBackColor = false;
            // 
            // BankBlackChips
            // 
            this.BankBlackChips.Enabled = false;
            this.BankBlackChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BankBlackChips.Location = new System.Drawing.Point(218, 19);
            this.BankBlackChips.Name = "BankBlackChips";
            this.BankBlackChips.Size = new System.Drawing.Size(47, 45);
            this.BankBlackChips.TabIndex = 5;
            this.BankBlackChips.Text = "0";
            this.BankBlackChips.UseVisualStyleBackColor = false;
            this.BankBlackChips.Click += new System.EventHandler(this.BankBlackChipsClick);
            // 
            // BankRedChips
            // 
            this.BankRedChips.Enabled = false;
            this.BankRedChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BankRedChips.Location = new System.Drawing.Point(165, 19);
            this.BankRedChips.Name = "BankRedChips";
            this.BankRedChips.Size = new System.Drawing.Size(47, 45);
            this.BankRedChips.TabIndex = 4;
            this.BankRedChips.Text = "0";
            this.BankRedChips.UseVisualStyleBackColor = false;
            this.BankRedChips.Click += new System.EventHandler(this.BankRedChipsClick);
            // 
            // BankGreenChips
            // 
            this.BankGreenChips.Enabled = false;
            this.BankGreenChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BankGreenChips.Location = new System.Drawing.Point(112, 19);
            this.BankGreenChips.Name = "BankGreenChips";
            this.BankGreenChips.Size = new System.Drawing.Size(47, 45);
            this.BankGreenChips.TabIndex = 3;
            this.BankGreenChips.Text = "0";
            this.BankGreenChips.UseVisualStyleBackColor = false;
            this.BankGreenChips.Click += new System.EventHandler(this.BankGreenChipsClick);
            // 
            // BankBlueChips
            // 
            this.BankBlueChips.Enabled = false;
            this.BankBlueChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BankBlueChips.Location = new System.Drawing.Point(59, 19);
            this.BankBlueChips.Name = "BankBlueChips";
            this.BankBlueChips.Size = new System.Drawing.Size(47, 45);
            this.BankBlueChips.TabIndex = 2;
            this.BankBlueChips.Text = "0";
            this.BankBlueChips.UseVisualStyleBackColor = false;
            this.BankBlueChips.Click += new System.EventHandler(this.BankBlueChipsClick);
            // 
            // BankWhiteChips
            // 
            this.BankWhiteChips.Enabled = false;
            this.BankWhiteChips.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BankWhiteChips.Location = new System.Drawing.Point(6, 19);
            this.BankWhiteChips.Name = "BankWhiteChips";
            this.BankWhiteChips.Size = new System.Drawing.Size(47, 45);
            this.BankWhiteChips.TabIndex = 1;
            this.BankWhiteChips.Text = "0";
            this.BankWhiteChips.UseVisualStyleBackColor = false;
            this.BankWhiteChips.Click += new System.EventHandler(this.BankWhiteChipsClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.AristocratesPanel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.CardsPanel, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.57542F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.42458F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(779, 756);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // AristocratesPanel
            // 
            this.AristocratesPanel.BackColor = System.Drawing.SystemColors.Control;
            this.AristocratesPanel.Controls.Add(this.aristocrate5);
            this.AristocratesPanel.Controls.Add(this.aristocrate3);
            this.AristocratesPanel.Controls.Add(this.aristocrate2);
            this.AristocratesPanel.Controls.Add(this.aristocrate1);
            this.AristocratesPanel.Controls.Add(this.aristocrate4);
            this.AristocratesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AristocratesPanel.Location = new System.Drawing.Point(0, 0);
            this.AristocratesPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AristocratesPanel.Name = "AristocratesPanel";
            this.AristocratesPanel.Size = new System.Drawing.Size(779, 140);
            this.AristocratesPanel.TabIndex = 0;
            // 
            // CardsPanel
            // 
            this.CardsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.CardsPanel.Controls.Add(this.Tier3Cards);
            this.CardsPanel.Controls.Add(this.Tier2Cards);
            this.CardsPanel.Controls.Add(this.Tier1Cards);
            this.CardsPanel.Controls.Add(this.Card11);
            this.CardsPanel.Controls.Add(this.Card34);
            this.CardsPanel.Controls.Add(this.Card33);
            this.CardsPanel.Controls.Add(this.Card32);
            this.CardsPanel.Controls.Add(this.Card31);
            this.CardsPanel.Controls.Add(this.Card24);
            this.CardsPanel.Controls.Add(this.Card23);
            this.CardsPanel.Controls.Add(this.Card22);
            this.CardsPanel.Controls.Add(this.Card21);
            this.CardsPanel.Controls.Add(this.Card14);
            this.CardsPanel.Controls.Add(this.Card13);
            this.CardsPanel.Controls.Add(this.Card12);
            this.CardsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardsPanel.Location = new System.Drawing.Point(0, 140);
            this.CardsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.CardsPanel.Name = "CardsPanel";
            this.CardsPanel.Size = new System.Drawing.Size(779, 616);
            this.CardsPanel.TabIndex = 1;
            // 
            // PlayersPanel
            // 
            this.PlayersPanel.BackColor = System.Drawing.SystemColors.Control;
            this.PlayersPanel.Controls.Add(this.playerPanel4);
            this.PlayersPanel.Controls.Add(this.playerPanel3);
            this.PlayersPanel.Controls.Add(this.playerPanel2);
            this.PlayersPanel.Controls.Add(this.playerPanel1);
            this.PlayersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayersPanel.Location = new System.Drawing.Point(0, 756);
            this.PlayersPanel.Margin = new System.Windows.Forms.Padding(0);
            this.PlayersPanel.Name = "PlayersPanel";
            this.PlayersPanel.Size = new System.Drawing.Size(1203, 266);
            this.PlayersPanel.TabIndex = 1;
            // 
            // Tier1Cards
            // 
            this.Tier1Cards.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Tier1Cards.BackColor = System.Drawing.Color.Lime;
            this.Tier1Cards.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Tier1Cards.Location = new System.Drawing.Point(3, 62);
            this.Tier1Cards.Name = "Tier1Cards";
            this.Tier1Cards.Size = new System.Drawing.Size(50, 86);
            this.Tier1Cards.TabIndex = 70;
            this.Tier1Cards.Text = "99";
            this.Tier1Cards.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Tier1Cards.Visible = false;
            // 
            // Tier2Cards
            // 
            this.Tier2Cards.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Tier2Cards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Tier2Cards.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Tier2Cards.Location = new System.Drawing.Point(3, 256);
            this.Tier2Cards.Name = "Tier2Cards";
            this.Tier2Cards.Size = new System.Drawing.Size(50, 86);
            this.Tier2Cards.TabIndex = 71;
            this.Tier2Cards.Text = "99";
            this.Tier2Cards.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Tier2Cards.Visible = false;
            // 
            // Tier3Cards
            // 
            this.Tier3Cards.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Tier3Cards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Tier3Cards.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Tier3Cards.Location = new System.Drawing.Point(3, 461);
            this.Tier3Cards.Name = "Tier3Cards";
            this.Tier3Cards.Size = new System.Drawing.Size(50, 86);
            this.Tier3Cards.TabIndex = 72;
            this.Tier3Cards.Text = "99";
            this.Tier3Cards.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Tier3Cards.Visible = false;
            // 
            // aristocrate5
            // 
            this.aristocrate5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.aristocrate5.Aristocrate = null;
            this.aristocrate5.Location = new System.Drawing.Point(578, 6);
            this.aristocrate5.Name = "aristocrate5";
            this.aristocrate5.Size = new System.Drawing.Size(119, 127);
            this.aristocrate5.TabIndex = 73;
            this.aristocrate5.Visible = false;
            // 
            // aristocrate3
            // 
            this.aristocrate3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.aristocrate3.Aristocrate = null;
            this.aristocrate3.Location = new System.Drawing.Point(453, 6);
            this.aristocrate3.Name = "aristocrate3";
            this.aristocrate3.Size = new System.Drawing.Size(119, 127);
            this.aristocrate3.TabIndex = 72;
            this.aristocrate3.Visible = false;
            // 
            // aristocrate2
            // 
            this.aristocrate2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.aristocrate2.Aristocrate = null;
            this.aristocrate2.Location = new System.Drawing.Point(328, 6);
            this.aristocrate2.Name = "aristocrate2";
            this.aristocrate2.Size = new System.Drawing.Size(119, 127);
            this.aristocrate2.TabIndex = 71;
            this.aristocrate2.Visible = false;
            // 
            // aristocrate1
            // 
            this.aristocrate1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.aristocrate1.Aristocrate = null;
            this.aristocrate1.Location = new System.Drawing.Point(203, 6);
            this.aristocrate1.Name = "aristocrate1";
            this.aristocrate1.Size = new System.Drawing.Size(119, 127);
            this.aristocrate1.TabIndex = 70;
            this.aristocrate1.Visible = false;
            // 
            // aristocrate4
            // 
            this.aristocrate4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.aristocrate4.Aristocrate = null;
            this.aristocrate4.Location = new System.Drawing.Point(78, 6);
            this.aristocrate4.Name = "aristocrate4";
            this.aristocrate4.Size = new System.Drawing.Size(119, 127);
            this.aristocrate4.TabIndex = 69;
            this.aristocrate4.Visible = false;
            // 
            // Card11
            // 
            this.Card11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Card11.Card = null;
            this.Card11.Location = new System.Drawing.Point(61, 11);
            this.Card11.Name = "Card11";
            this.Card11.Size = new System.Drawing.Size(157, 194);
            this.Card11.TabIndex = 58;
            // 
            // Card34
            // 
            this.Card34.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Card34.Card = null;
            this.Card34.Location = new System.Drawing.Point(550, 411);
            this.Card34.Name = "Card34";
            this.Card34.Size = new System.Drawing.Size(157, 194);
            this.Card34.TabIndex = 69;
            // 
            // Card33
            // 
            this.Card33.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Card33.Card = null;
            this.Card33.Location = new System.Drawing.Point(387, 411);
            this.Card33.Name = "Card33";
            this.Card33.Size = new System.Drawing.Size(157, 194);
            this.Card33.TabIndex = 68;
            // 
            // Card32
            // 
            this.Card32.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Card32.Card = null;
            this.Card32.Location = new System.Drawing.Point(224, 411);
            this.Card32.Name = "Card32";
            this.Card32.Size = new System.Drawing.Size(157, 194);
            this.Card32.TabIndex = 67;
            // 
            // Card31
            // 
            this.Card31.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Card31.Card = null;
            this.Card31.Location = new System.Drawing.Point(61, 411);
            this.Card31.Name = "Card31";
            this.Card31.Size = new System.Drawing.Size(157, 194);
            this.Card31.TabIndex = 66;
            // 
            // Card24
            // 
            this.Card24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Card24.Card = null;
            this.Card24.Location = new System.Drawing.Point(550, 211);
            this.Card24.Name = "Card24";
            this.Card24.Size = new System.Drawing.Size(157, 194);
            this.Card24.TabIndex = 65;
            // 
            // Card23
            // 
            this.Card23.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Card23.Card = null;
            this.Card23.Location = new System.Drawing.Point(387, 211);
            this.Card23.Name = "Card23";
            this.Card23.Size = new System.Drawing.Size(157, 194);
            this.Card23.TabIndex = 64;
            // 
            // Card22
            // 
            this.Card22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Card22.Card = null;
            this.Card22.Location = new System.Drawing.Point(224, 211);
            this.Card22.Name = "Card22";
            this.Card22.Size = new System.Drawing.Size(157, 194);
            this.Card22.TabIndex = 63;
            // 
            // Card21
            // 
            this.Card21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Card21.Card = null;
            this.Card21.Location = new System.Drawing.Point(61, 211);
            this.Card21.Name = "Card21";
            this.Card21.Size = new System.Drawing.Size(157, 194);
            this.Card21.TabIndex = 62;
            // 
            // Card14
            // 
            this.Card14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Card14.Card = null;
            this.Card14.Location = new System.Drawing.Point(550, 11);
            this.Card14.Name = "Card14";
            this.Card14.Size = new System.Drawing.Size(157, 194);
            this.Card14.TabIndex = 61;
            // 
            // Card13
            // 
            this.Card13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Card13.Card = null;
            this.Card13.Location = new System.Drawing.Point(387, 11);
            this.Card13.Name = "Card13";
            this.Card13.Size = new System.Drawing.Size(157, 194);
            this.Card13.TabIndex = 60;
            // 
            // Card12
            // 
            this.Card12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Card12.Card = null;
            this.Card12.Location = new System.Drawing.Point(224, 11);
            this.Card12.Name = "Card12";
            this.Card12.Size = new System.Drawing.Size(157, 194);
            this.Card12.TabIndex = 59;
            // 
            // playerPanel4
            // 
            this.playerPanel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playerPanel4.Location = new System.Drawing.Point(901, 1);
            this.playerPanel4.MaximumSize = new System.Drawing.Size(293, 260);
            this.playerPanel4.MinimumSize = new System.Drawing.Size(293, 260);
            this.playerPanel4.Name = "playerPanel4";
            this.playerPanel4.Player = null;
            this.playerPanel4.Size = new System.Drawing.Size(293, 260);
            this.playerPanel4.TabIndex = 65;
            this.playerPanel4.Visible = false;
            // 
            // playerPanel3
            // 
            this.playerPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playerPanel3.Location = new System.Drawing.Point(602, 1);
            this.playerPanel3.MaximumSize = new System.Drawing.Size(293, 260);
            this.playerPanel3.MinimumSize = new System.Drawing.Size(293, 260);
            this.playerPanel3.Name = "playerPanel3";
            this.playerPanel3.Player = null;
            this.playerPanel3.Size = new System.Drawing.Size(293, 260);
            this.playerPanel3.TabIndex = 64;
            this.playerPanel3.Visible = false;
            // 
            // playerPanel2
            // 
            this.playerPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playerPanel2.Location = new System.Drawing.Point(303, 1);
            this.playerPanel2.MaximumSize = new System.Drawing.Size(293, 260);
            this.playerPanel2.MinimumSize = new System.Drawing.Size(293, 260);
            this.playerPanel2.Name = "playerPanel2";
            this.playerPanel2.Player = null;
            this.playerPanel2.Size = new System.Drawing.Size(293, 260);
            this.playerPanel2.TabIndex = 63;
            this.playerPanel2.Visible = false;
            // 
            // playerPanel1
            // 
            this.playerPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.playerPanel1.Location = new System.Drawing.Point(4, 1);
            this.playerPanel1.MaximumSize = new System.Drawing.Size(293, 260);
            this.playerPanel1.MinimumSize = new System.Drawing.Size(293, 260);
            this.playerPanel1.Name = "playerPanel1";
            this.playerPanel1.Player = null;
            this.playerPanel1.Size = new System.Drawing.Size(293, 260);
            this.playerPanel1.TabIndex = 62;
            this.playerPanel1.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 1022);
            this.Controls.Add(this.PlayerNameBox);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.AddPlayer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainWindow";
            this.Text = "Splendor v0.1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.BankPanel3.ResumeLayout(false);
            this.BankPanel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.BankPanel.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.AristocratesPanel.ResumeLayout(false);
            this.CardsPanel.ResumeLayout(false);
            this.PlayersPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddPlayer;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.TextBox PlayerNameBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel BankPanel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button TakenBlackChips;
        private System.Windows.Forms.Button BankTakeButton;
        private System.Windows.Forms.Button TakenRedChips;
        private System.Windows.Forms.Button TakenWhiteChips;
        private System.Windows.Forms.Button TakenGreenChips;
        private System.Windows.Forms.Button TakenBlueChips;
        private System.Windows.Forms.GroupBox BankPanel;
        private System.Windows.Forms.Button BankGoldChips;
        private System.Windows.Forms.Button BankBlackChips;
        private System.Windows.Forms.Button BankRedChips;
        private System.Windows.Forms.Button BankGreenChips;
        private System.Windows.Forms.Button BankBlueChips;
        private System.Windows.Forms.Button BankWhiteChips;
        private System.Windows.Forms.Panel AristocratesPanel;
        private AristocratePanel aristocrate5;
        private AristocratePanel aristocrate3;
        private AristocratePanel aristocrate2;
        private AristocratePanel aristocrate1;
        private AristocratePanel aristocrate4;
        private System.Windows.Forms.Panel CardsPanel;
        private CardPanel Card34;
        private CardPanel Card33;
        private CardPanel Card32;
        private CardPanel Card31;
        private CardPanel Card24;
        private CardPanel Card23;
        private CardPanel Card22;
        private CardPanel Card21;
        private CardPanel Card14;
        private CardPanel Card13;
        private CardPanel Card12;
        private CardPanel Card11;
        private System.Windows.Forms.Panel PlayersPanel;
        private PlayerPanel playerPanel4;
        private PlayerPanel playerPanel3;
        private PlayerPanel playerPanel2;
        private PlayerPanel playerPanel1;
        private System.Windows.Forms.Label Tier3Cards;
        private System.Windows.Forms.Label Tier2Cards;
        private System.Windows.Forms.Label Tier1Cards;
        #region Fields


        #endregion
    }
}

