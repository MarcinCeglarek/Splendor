namespace SplendorFormsClient
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    using SplendorCore.Data;
    using SplendorCore.Models;

    using SplendorFormsClient.Panels;

    using Color = SplendorCore.Models.Color;

    #endregion

    public partial class MainWindow : Form
    {
        #region Fields

        private readonly List<CardPanel> cardPanels = new List<CardPanel>();

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

            this.BankBlackChips.ForeColor = FormsColor.ForeColor(Color.Black);
            this.BankBlackChips.BackColor = FormsColor.BackColor(Color.Black);
            this.BankBlueChips.ForeColor = FormsColor.ForeColor(Color.Blue);
            this.BankBlueChips.BackColor = FormsColor.BackColor(Color.Blue);
            this.BankGoldChips.ForeColor = FormsColor.ForeColor(Color.Gold);
            this.BankGoldChips.BackColor = FormsColor.BackColor(Color.Gold);
            this.BankGreenChips.ForeColor = FormsColor.ForeColor(Color.Green);
            this.BankGreenChips.BackColor = FormsColor.BackColor(Color.Green);
            this.BankRedChips.ForeColor = FormsColor.ForeColor(Color.Red);
            this.BankRedChips.BackColor = FormsColor.BackColor(Color.Red);
            this.BankWhiteChips.ForeColor = FormsColor.ForeColor(Color.White);
            this.BankWhiteChips.BackColor = FormsColor.BackColor(Color.White);

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

            this.cardPanels.Add(this.Card11);
            this.cardPanels.Add(this.Card12);
            this.cardPanels.Add(this.Card13);
            this.cardPanels.Add(this.Card14);
            this.cardPanels.Add(this.Card21);
            this.cardPanels.Add(this.Card22);
            this.cardPanels.Add(this.Card23);
            this.cardPanels.Add(this.Card24);
            this.cardPanels.Add(this.Card31);
            this.cardPanels.Add(this.Card32);
            this.cardPanels.Add(this.Card33);
            this.cardPanels.Add(this.Card34);
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

            this.UpdateGameState();
        }

        public void PurchaseOrReserveCard(Card card)
        {
            var currentPlayer = this.game.CurrentPlayer;
            if (this.game.CanPurchaseCard(currentPlayer, card))
            {
                this.Log(string.Format("Player {0} purchases card {1}", this.game.CurrentPlayer, card));
                this.RemoveCardFromDeck(card);
                this.game.PurchaseCard(currentPlayer, card);
            }
            else if (this.game.CanReserveCard(currentPlayer, card))
            {
                this.Log(string.Format("Player {0} reserves card {1}", this.game.CurrentPlayer, card));
                this.RemoveCardFromDeck(card);
                this.game.ReserveCard(currentPlayer, card);
            }
            else
            {
                this.Log(string.Format("Player {0} can't purchase nor reserve card {1}", this.game.CurrentPlayer, card));
            }

            this.UpdateGameState();
        }

        #endregion

        #region Methods

        private void AddPlayerClick(object sender, EventArgs e)
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

        private void BankBlackChipsClick(object sender, EventArgs e)
        {
            this.HandleTakeChips(Color.Black);
        }

        private void BankBlueChipsClick(object sender, EventArgs e)
        {
            this.HandleTakeChips(Color.Blue);
        }

        private void BankGreenChipsClick(object sender, EventArgs e)
        {
            this.HandleTakeChips(Color.Green);
        }

        private void BankRedChipsClick(object sender, EventArgs e)
        {
            this.HandleTakeChips(Color.Red);
        }

        private void BankTakeButtonClick(object sender, EventArgs e)
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

            this.UpdateGameState();
        }

        private void BankWhiteChipsClick(object sender, EventArgs e)
        {
            this.HandleTakeChips(Color.White);
        }

        private void CheckTakeAdditionalChips(Button chipsButton, Chips chips)
        {
            var result = this.game.CanTakeChips(this.game.CurrentPlayer, this.game.CurrentPlayer.Chips + this.chipsToTake + chips);
            chipsButton.Enabled = result;
        }

        private void CheckTakenPossibilities()
        {
            this.CheckTakeAdditionalChips(this.BankWhiteChips, new Chips(1, 0, 0, 0, 0, 0));
            this.CheckTakeAdditionalChips(this.BankBlueChips, new Chips(0, 1, 0, 0, 0, 0));
            this.CheckTakeAdditionalChips(this.BankGreenChips, new Chips(0, 0, 1, 0, 0, 0));
            this.CheckTakeAdditionalChips(this.BankRedChips, new Chips(0, 0, 0, 1, 0, 0));
            this.CheckTakeAdditionalChips(this.BankBlackChips, new Chips(0, 0, 0, 0, 1, 0));
        }

        private void CheckVictoryCondition()
        {
            if (this.game.HasFinished)
            {
                this.Log("Game Ended");
                var maxPoints = this.game.Players.Max(o => o.VictoryPoints);
                var winners = this.game.Players.Where(o => o.VictoryPoints == maxPoints).ToList();
                if (winners.Count > 1)
                {
                    this.Log("The winners are " + string.Join(", ", winners));
                }
                else
                {
                    this.Log("The winner is " + winners.Single());
                }
            }
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

        private void HandleTakeChips(Color color)
        {
            if (this.game.IsActive && this.bankChips[color] > 0)
            {
                this.chipsToTake[color]++;
                this.bankChips[color]--;
            }

            this.RefreshBankPanelButtons();
        }

        private void HandleTakenChips(Color color)
        {
            if (this.game.IsActive && this.chipsToTake[color] > 0)
            {
                this.chipsToTake[color]--;
                this.bankChips[color]++;
            }

            this.RefreshBankPanelButtons();
        }

        private void Log(string message)
        {
            this.textBox1.AppendText(message + Environment.NewLine);
        }

        private void PlayerNameBoxTextChanged(object sender, EventArgs e)
        {
            this.AddPlayer.Enabled = !string.IsNullOrWhiteSpace(this.PlayerNameBox.Text);
        }

        private void RefreshBankPanelButtons()
        {
            this.FillButton(this.BankWhiteChips, this.bankChips.White);
            this.FillButton(this.BankBlueChips, this.bankChips.Blue);
            this.FillButton(this.BankBlackChips, this.bankChips.Black);
            this.FillButton(this.BankGreenChips, this.bankChips.Green);
            this.FillButton(this.BankRedChips, this.bankChips.Red);
            this.FillButton(this.BankGoldChips, this.bankChips.Gold);

            this.FillButton(this.TakenWhiteChips, this.chipsToTake.White);
            this.FillButton(this.TakenBlackChips, this.chipsToTake.Black);
            this.FillButton(this.TakenBlueChips, this.chipsToTake.Blue);
            this.FillButton(this.TakenGreenChips, this.chipsToTake.Green);
            this.FillButton(this.TakenRedChips, this.chipsToTake.Red);

            if (this.game.HasStarted && !this.game.HasFinished)
            {
                this.CheckTakenPossibilities();

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

        private void RemoveCardFromDeck(Card card)
        {
            var cardPanelToClear = this.cardPanels.SingleOrDefault(cp => cp.Card == card);
            if (cardPanelToClear != null)
            {
                cardPanelToClear.Card = null;
            }
        }

        private void StartGameClick(object sender, EventArgs e)
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

            this.BankTakeButton.Enabled = true;

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

            this.UpdatePlayersPanels();
            this.UpdateBankPanel();
            this.UpdateDeck();
        }

        private void TakenBlackChipsClick(object sender, EventArgs e)
        {
            this.HandleTakenChips(Color.Black);
        }

        private void TakenBlueChipsClick(object sender, EventArgs e)
        {
            this.HandleTakenChips(Color.Blue);
        }

        private void TakenGreenChipsClick(object sender, EventArgs e)
        {
            this.HandleTakenChips(Color.Green);
        }

        private void TakenRedChipsClick(object sender, EventArgs e)
        {
            this.HandleTakenChips(Color.Red);
        }

        private void TakenWhiteChipsClick(object sender, EventArgs e)
        {
            this.HandleTakenChips(Color.White);
        }

        private void UpdateAristocratesPanel()
        {
            this.aristocrate1.Visible = this.game.Deck.AvailableAristocrates.Contains(this.aristocrate1.Aristocrate);
            this.aristocrate2.Visible = this.game.Deck.AvailableAristocrates.Contains(this.aristocrate2.Aristocrate);
            this.aristocrate3.Visible = this.game.Deck.AvailableAristocrates.Contains(this.aristocrate3.Aristocrate);
            this.aristocrate4.Visible = this.game.Deck.AvailableAristocrates.Contains(this.aristocrate4.Aristocrate);
            this.aristocrate5.Visible = this.game.Deck.AvailableAristocrates.Contains(this.aristocrate5.Aristocrate);
        }

        private void UpdateBankPanel()
        {
            this.bankChips = this.game.Bank;
            this.chipsToTake = new Chips();
            this.RefreshBankPanelButtons();
        }

        private void UpdateDeck()
        {
            var alreadyAssignedCards = this.cardPanels.Select(o => o.Card).ToList();
            var cardsToAssign = this.game.Deck.AvailableCards.Except(alreadyAssignedCards).ToList();

            foreach (var cardToAssign in cardsToAssign)
            {
                var emptyCardsPanels = this.cardPanels.Where(cardPanel => cardPanel.Card == null && cardPanel.Tier == cardToAssign.Tier).ToList();
                emptyCardsPanels.First().Card = cardToAssign;
            }

            this.UpdatePlayersPanels();
        }

        private void UpdateGameState()
        {
            this.UpdateDeck();
            this.UpdateBankPanel();
            this.UpdatePlayersPanels();
            this.UpdateAristocratesPanel();
            this.CheckVictoryCondition();
        }

        private void UpdatePlayersPanels()
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

        #endregion
    }
}