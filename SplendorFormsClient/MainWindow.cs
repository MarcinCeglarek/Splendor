namespace SplendorFormsClient
{
    #region

    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using SplendorCore.Data;
    using SplendorCore.Models;

    using SplendorFormsClient.Panels;

    using Color = SplendorCore.Models.Color;

    #endregion

    public partial class MainWindow : Form
    {
        #region Fields

        private readonly Game game;

        private Chips bankChips = new Chips();

        private Chips chipsToTake = new Chips();

        #endregion

        #region Constructors and Destructors

        public MainWindow()
        {
            this.playerPanel1 = new PlayerPanel();
            this.playerPanel2 = new PlayerPanel();
            this.playerPanel3 = new PlayerPanel();
            this.playerPanel4 = new PlayerPanel();
            this.game = new Game();
            this.InitializeComponent();

            this.BlackChips.ForeColor = FormsColor.ForeColor(Color.Black);
            this.BlackChips.BackColor = FormsColor.BackColor(Color.Black);
            this.BlueChips.ForeColor = FormsColor.ForeColor(Color.Blue);
            this.BlueChips.BackColor = FormsColor.BackColor(Color.Blue);
            this.GoldChips.ForeColor = FormsColor.ForeColor(Color.Gold);
            this.GoldChips.BackColor = FormsColor.BackColor(Color.Gold);
            this.GreenChips.ForeColor = FormsColor.ForeColor(Color.Green);
            this.GreenChips.BackColor = FormsColor.BackColor(Color.Green);
            this.RedChips.ForeColor = FormsColor.ForeColor(Color.Red);
            this.RedChips.BackColor = FormsColor.BackColor(Color.Red);
            this.WhiteChips.ForeColor = FormsColor.ForeColor(Color.White);
            this.WhiteChips.BackColor = FormsColor.BackColor(Color.White);

            this.TakenBlackChips.ForeColor = FormsColor.ForeColor(Color.Black);
            this.TakenBlackChips.BackColor = FormsColor.BackColor(Color.Black);
            this.TakenBlueChips.ForeColor = FormsColor.ForeColor(Color.Blue);
            this.TakenBlueChips.BackColor = FormsColor.BackColor(Color.Blue);
            this.TakenGreenChips.ForeColor = FormsColor.ForeColor(Color.Green);
            this.TakenGreenChips.BackColor = FormsColor.BackColor(Color.Green);
            this.TakenRedChips.ForeColor = FormsColor.ForeColor(Color.Red);
            this.TakenRedChips.BackColor = FormsColor.BackColor(Color.Red);
            this.TakenWhiteChips.ForeColor = FormsColor.ForeColor(Color.White);
            this.TakenWhiteChips.BackColor = FormsColor.BackColor(Color.White);
        }

        #endregion

        #region Public Methods and Operators

        public void BuyReservedCard(Card reservedCard)
        {
            if (this.game.CanPurchaseCard(this.game.CurrentPlayer, reservedCard))
            {
                this.Log(string.Format("Player {0} purchases previously reserved card {1}", this.game.CurrentPlayer, reservedCard));
                this.game.PurchaseCard(this.game.CurrentPlayer, reservedCard);
            }
            else
            {
                this.Log(string.Format("Player {0} can't purchase previously reserved card {1}", this.game.CurrentPlayer, reservedCard));
            }

            this.RefreshAristocrates();
            this.FillDeck();
            this.RefreshBank();
            this.RefreshCurrentPlayer();
        }

        public void PurchaseOrReserveCard(Card card)
        {
            var currentPlayer = this.game.CurrentPlayer;
            if (this.game.CanPurchaseCard(currentPlayer, card))
            {
                this.Log(string.Format("Player {0} purchases card {1}", this.game.CurrentPlayer, card));
                this.game.PurchaseCard(currentPlayer, card);
            }
            else if (this.game.CanReserveCard(currentPlayer, card))
            {
                this.Log(string.Format("Player {0} reserves card {1}", this.game.CurrentPlayer, card));
                this.game.ReserveCard(currentPlayer, card);
                this.bankChips.Gold = this.game.Bank.Gold;
            }
            else
            {
                this.Log(string.Format("Player {0} can't purchase nor reserve card {1}", this.game.CurrentPlayer, card));
            }

            this.RefreshAristocrates();
            this.FillDeck();
            this.RefreshBank();
            this.RefreshCurrentPlayer();
        }

        #endregion

        #region Methods

        private void AddPlayer_Click(object sender, EventArgs e)
        {
            var player = new Player { Name = this.PlayerNameBox.Text };

            this.game.Players.Add(player);

            this.Log(string.Format("Player {0} joins game", player));

            if (this.game.Players.Count >= 2)
            {
                this.StartGame.Enabled = true;
            }

            if (this.game.Players.Count == 4)
            {
                this.AddPlayer.Enabled = false;
            }

            switch (this.game.Players.Count)
            {
                case 4:
                    this.playerPanel4.Visible = true;
                    break;
                case 3:
                    this.playerPanel3.Visible = true;
                    break;
                case 2:
                    this.playerPanel2.Visible = true;
                    break;
                case 1:
                    this.playerPanel1.Visible = true;
                    break;
            }

            this.PlayerNameBox.Text = string.Empty;
            this.AddPlayer.Enabled = false;
        }

        private void BankTakeButton_Click(object sender, EventArgs e)
        {
            if (this.game.CanTakeChips(this.game.CurrentPlayer, this.game.CurrentPlayer.Chips + this.chipsToTake))
            {
                this.Log(string.Format("Player {0} takes {1}", this.game.CurrentPlayer, this.chipsToTake));
                this.game.TakeChips(this.game.CurrentPlayer, this.game.CurrentPlayer.Chips + this.chipsToTake);
                this.bankChips = this.game.Bank;
                this.chipsToTake = new Chips();
            }
            else
            {
                this.Log(string.Format("Player {0} can't take {1}", this.game.CurrentPlayer, this.chipsToTake));
            }

            this.RefreshAristocrates();
            this.RefreshBank();
            this.RefreshCurrentPlayer();
        }

        private void RefreshAristocrates()
        {
            this.aristocrate1.Visible = this.game.Deck.AvailableAristocrates.Contains(this.aristocrate1.Aristocrate);
            this.aristocrate2.Visible = this.game.Deck.AvailableAristocrates.Contains(this.aristocrate2.Aristocrate);
            this.aristocrate3.Visible = this.game.Deck.AvailableAristocrates.Contains(this.aristocrate3.Aristocrate);
            this.aristocrate4.Visible = this.game.Deck.AvailableAristocrates.Contains(this.aristocrate4.Aristocrate);
            this.aristocrate5.Visible = this.game.Deck.AvailableAristocrates.Contains(this.aristocrate5.Aristocrate);
        }

        private void BlackChips_Click(object sender, EventArgs e)
        {
            if (this.bankChips[Color.Black] > 0)
            {
                this.bankChips[Color.Black]--;
                this.chipsToTake[Color.Black]++;
            }

            this.RefreshBank();
        }

        private void BlueChips_Click(object sender, EventArgs e)
        {
            if (this.bankChips[Color.Blue] > 0)
            {
                this.bankChips[Color.Blue]--;
                this.chipsToTake[Color.Blue]++;
            }

            this.RefreshBank();
        }

        private void FillButton(Button button, int amount)
        {
            if (amount > 0)
            {
                button.Visible = true;
                button.Text = amount.ToString();
            }
            else
            {
                button.Visible = false;
            }
        }

        private void FillDeck()
        {
            this.Card11.Card = this.game.Deck.AvailableCards[0];
            this.Card12.Card = this.game.Deck.AvailableCards[1];
            this.Card13.Card = this.game.Deck.AvailableCards[2];
            this.Card14.Card = this.game.Deck.AvailableCards[3];

            this.Card21.Card = this.game.Deck.AvailableCards[4];
            this.Card22.Card = this.game.Deck.AvailableCards[5];
            this.Card23.Card = this.game.Deck.AvailableCards[6];
            this.Card24.Card = this.game.Deck.AvailableCards[7];

            this.Card31.Card = this.game.Deck.AvailableCards[8];
            this.Card32.Card = this.game.Deck.AvailableCards[9];
            this.Card33.Card = this.game.Deck.AvailableCards[10];
            this.Card34.Card = this.game.Deck.AvailableCards[11];

            this.RefreshCurrentPlayer();
        }

        private void GreenChips_Click(object sender, EventArgs e)
        {
            if (this.bankChips[Color.Green] > 0)
            {
                this.bankChips[Color.Green]--;
                this.chipsToTake[Color.Green]++;
            }

            this.RefreshBank();
        }

        private void Log(string message)
        {
            this.textBox1.AppendText(message + Environment.NewLine);
        }

        private void RedChips_Click(object sender, EventArgs e)
        {
            if (this.bankChips[Color.Red] > 0)
            {
                this.bankChips[Color.Red]--;
                this.chipsToTake[Color.Red]++;
            }

            this.RefreshBank();
        }

        private void RefreshBank()
        {
            this.FillButton(this.WhiteChips, this.bankChips.White);
            this.FillButton(this.BlueChips, this.bankChips.Blue);
            this.FillButton(this.BlackChips, this.bankChips.Black);
            this.FillButton(this.GreenChips, this.bankChips.Green);
            this.FillButton(this.RedChips, this.bankChips.Red);
            this.FillButton(this.GoldChips, this.bankChips.Gold);

            this.FillButton(this.TakenWhiteChips, this.chipsToTake.White);
            this.FillButton(this.TakenBlackChips, this.chipsToTake.Black);
            this.FillButton(this.TakenBlueChips, this.chipsToTake.Blue);
            this.FillButton(this.TakenGreenChips, this.chipsToTake.Green);
            this.FillButton(this.TakenRedChips, this.chipsToTake.Red);

            if (this.game.HasStarted && !this.game.HasFinished)
            {
                this.WhiteChips.Enabled = true;
                this.BlueChips.Enabled = true;
                this.GreenChips.Enabled = true;
                this.RedChips.Enabled = true;
                this.BlackChips.Enabled = true;

                if (this.game.CanTakeChips(this.game.CurrentPlayer, this.game.CurrentPlayer.Chips + this.chipsToTake))
                {
                    this.BankTakeButton.Enabled = true;
                }
                else
                {
                    this.BankTakeButton.Enabled = false;
                }
            }
        }

        private void RefreshCurrentPlayer()
        {
            this.playerPanel1.RefreshValues();
            this.playerPanel2.RefreshValues();
            this.playerPanel3.RefreshValues();
            this.playerPanel4.RefreshValues();

            this.playerPanel1.BackColor = this.playerPanel1.Player == this.game.CurrentPlayer ? System.Drawing.Color.LightPink : SystemColors.Control;
            this.playerPanel2.BackColor = this.playerPanel2.Player == this.game.CurrentPlayer ? System.Drawing.Color.LightPink : SystemColors.Control;
            this.playerPanel3.BackColor = this.playerPanel3.Player == this.game.CurrentPlayer ? System.Drawing.Color.LightPink : SystemColors.Control;
            this.playerPanel4.BackColor = this.playerPanel4.Player == this.game.CurrentPlayer ? System.Drawing.Color.LightPink : SystemColors.Control;
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            this.Log("Game started");

            this.PlayerNameBox.Visible = false;
            this.AddPlayer.Visible = false;
            this.StartGame.Visible = false;

            this.Card11.Visible = true;
            this.Card12.Visible = true;
            this.Card13.Visible = true;
            this.Card14.Visible = true;
            this.Card21.Visible = true;
            this.Card22.Visible = true;
            this.Card23.Visible = true;
            this.Card24.Visible = true;
            this.Card31.Visible = true;
            this.Card32.Visible = true;
            this.Card33.Visible = true;
            this.Card34.Visible = true;

            this.game.Deck = new Deck(this.game, CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);
            this.game.Start();
            this.Log("Shuffling players, order: " + string.Join(", ", this.game.Players));

            this.bankChips = this.game.Bank;

            this.playerPanel1.Player = this.game.Players[0];
            this.playerPanel2.Player = this.game.Players[1];

            this.aristocrate1.Aristocrate = this.game.Deck.AvailableAristocrates[0];
            this.aristocrate2.Aristocrate = this.game.Deck.AvailableAristocrates[1];
            this.aristocrate3.Aristocrate = this.game.Deck.AvailableAristocrates[2];
            this.aristocrate1.Visible = true;
            this.aristocrate2.Visible = true;
            this.aristocrate3.Visible = true;

            if (this.game.Players.Count > 2)
            {
                this.playerPanel3.Player = this.game.Players[2];
                this.aristocrate4.Aristocrate = this.game.Deck.AvailableAristocrates[3];
                this.aristocrate4.Visible = true;

                if (this.game.Players.Count > 3)
                {
                    this.playerPanel4.Player = this.game.Players[3];
                    this.aristocrate5.Aristocrate = this.game.Deck.AvailableAristocrates[4];
                    this.aristocrate5.Visible = true;
                }
            }

            this.RefreshCurrentPlayer();
            this.RefreshBank();
            this.FillDeck();
        }

        private void TakenBlackChips_Click(object sender, EventArgs e)
        {
            if (this.chipsToTake[Color.Black] > 0)
            {
                this.chipsToTake[Color.Black]--;
                this.bankChips[Color.Black]++;
            }

            this.RefreshBank();
        }

        private void TakenBlueChips_Click(object sender, EventArgs e)
        {
            if (this.chipsToTake[Color.Blue] > 0)
            {
                this.chipsToTake[Color.Blue]--;
                this.bankChips[Color.Blue]++;
            }

            this.RefreshBank();
        }

        private void TakenGreenChips_Click(object sender, EventArgs e)
        {
            if (this.chipsToTake[Color.Green] > 0)
            {
                this.chipsToTake[Color.Green]--;
                this.bankChips[Color.Green]++;
            }

            this.RefreshBank();
        }

        private void TakenRedChips_Click(object sender, EventArgs e)
        {
            if (this.chipsToTake[Color.Red] > 0)
            {
                this.chipsToTake[Color.Red]--;
                this.bankChips[Color.Red]++;
            }

            this.RefreshBank();
        }

        private void TakenWhiteChips_Click(object sender, EventArgs e)
        {
            if (this.chipsToTake[Color.White] > 0)
            {
                this.chipsToTake[Color.White]--;
                this.bankChips[Color.White]++;
            }

            this.RefreshBank();
        }

        private void WhiteChips_Click(object sender, EventArgs e)
        {
            if (this.bankChips[Color.White] > 0)
            {
                this.bankChips[Color.White]--;
                this.chipsToTake[Color.White]++;
            }

            this.RefreshBank();
        }

        private void PlayerNameBox_TextChanged(object sender, EventArgs e)
        {
            this.AddPlayer.Enabled = !string.IsNullOrWhiteSpace(this.PlayerNameBox.Text);
        }

        #endregion
    }
}