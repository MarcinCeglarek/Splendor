namespace SplendorFormsClient
{
    #region

    using System;
    using System.Collections.Generic;
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

        private Chips bankChips = new Chips();

        private Chips chipsToTake = new Chips();

        #endregion

        #region Constructors and Destructors

        public MainWindow()
        {
            this.playerPanel1 = new PlayerPanel(null);
            this.playerPanel2 = new PlayerPanel(null);
            this.playerPanel3 = new PlayerPanel(null);
            this.playerPanel4 = new PlayerPanel(null);
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        private void BankTakeButton_Click(object sender, EventArgs e)
        {
            this.game.TakeChips(this.game.CurrentPlayer, this.game.CurrentPlayer.Chips + this.chipsToTake);
            this.bankChips = this.game.Bank;
            this.chipsToTake = new Chips();
            this.RefreshBank();
            this.RefreshCurrentPlayer();
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
            this.WhiteChips.Text = this.bankChips[Color.White].ToString();
            this.TakenWhiteChips.Text = this.chipsToTake[Color.White].ToString();

            this.BlueChips.Text = this.bankChips[Color.Blue].ToString();
            this.TakenBlueChips.Text = this.chipsToTake[Color.Blue].ToString();

            this.GreenChips.Text = this.bankChips[Color.Green].ToString();
            this.TakenGreenChips.Text = this.chipsToTake[Color.Green].ToString();

            this.RedChips.Text = this.bankChips[Color.Red].ToString();
            this.TakenRedChips.Text = this.chipsToTake[Color.Red].ToString();

            this.BlackChips.Text = this.bankChips[Color.Black].ToString();
            this.TakenBlackChips.Text = this.chipsToTake[Color.Black].ToString();

            this.GoldChips.Text = this.bankChips[Color.Gold].ToString();

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.game = new Game();

            var list = new List<Player>() { new Player(), new Player(), new Player(), new Player() };
            
            this.playerPanel1.Player = list[0];
            this.playerPanel2.Player = list[1];
            this.playerPanel3.Player = list[2];
            this.playerPanel4.Player = list[3];

            System.Threading.Thread.Sleep(100);
            this.game.Players = list;

            this.game.Deck = new Deck(this.game, CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);
            this.game.Start();

            this.bankChips = this.game.Bank;
            this.WhiteChips.Text = this.bankChips[Color.White].ToString();
            this.BlueChips.Text = this.bankChips[Color.Blue].ToString();
            this.GreenChips.Text = this.bankChips[Color.Green].ToString();
            this.RedChips.Text = this.bankChips[Color.Red].ToString();
            this.BlackChips.Text = this.bankChips[Color.Black].ToString();
            this.RefreshCurrentPlayer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FillDeck();
        }

        #endregion

        private void Card11_Click(object sender, EventArgs e)
        {
            this.CardClick(this.game.CurrentPlayer, this.Card11.Card);
        }

        private void Card12_Click(object sender, EventArgs e)
        {
            this.CardClick(this.game.CurrentPlayer, this.Card12.Card);
        }

        private void Card13_Click(object sender, EventArgs e)
        {
            this.CardClick(this.game.CurrentPlayer, this.Card13.Card);
        }

        private void Card14_Click(object sender, EventArgs e)
        {
            this.CardClick(this.game.CurrentPlayer, this.Card14.Card);
        }

        private void CardClick(Player currentPlayer, Card card)
        {
            if (this.game.CanPurchaseCard(currentPlayer, card))
            {
                this.game.PurchaseCard(currentPlayer, card);
            }
            else if (this.game.CanReserveCard(currentPlayer, card))
            {
                this.game.ReserveCard(currentPlayer, card);
            }

            this.FillDeck();
            this.RefreshCurrentPlayer();
        }

    }
}