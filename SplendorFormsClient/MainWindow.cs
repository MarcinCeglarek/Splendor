namespace SplendorFormsClient
{
    #region

    using System;
    using System.Windows.Forms;

    using SplendorCore.Data;
    using SplendorCore.Models;

    #endregion

    public partial class MainWindow : Form
    {
        #region Constructors and Destructors

        public MainWindow()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        private void FillDeck()
        {
            this.userControl11.Card = this.game.Deck.AvailableCards[0];
            this.userControl12.Card = this.game.Deck.AvailableCards[1];
            this.userControl13.Card = this.game.Deck.AvailableCards[2];
            this.userControl14.Card = this.game.Deck.AvailableCards[3];

            this.userControl15.Card = this.game.Deck.AvailableCards[4];
            this.userControl16.Card = this.game.Deck.AvailableCards[5];
            this.userControl17.Card = this.game.Deck.AvailableCards[6];
            this.userControl18.Card = this.game.Deck.AvailableCards[7];

            this.userControl19.Card = this.game.Deck.AvailableCards[8];
            this.userControl110.Card = this.game.Deck.AvailableCards[9];
            this.userControl111.Card = this.game.Deck.AvailableCards[10];
            this.userControl112.Card = this.game.Deck.AvailableCards[11];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.game.Players.Add(this.player1);
            this.game.Players.Add(this.player2);
            this.game.Players.Add(this.player3);
            this.game.Players.Add(this.player4);

            this.playerPanel1.Player = this.player1;
            this.playerPanel1.CurrentPlayer = this.game.CurrentPlayer;

            this.playerPanel2.Player = this.player2;
            this.playerPanel2.CurrentPlayer = this.game.CurrentPlayer;
            this.playerPanel3.Player = this.player3;
            this.playerPanel3.CurrentPlayer = this.game.CurrentPlayer;
            this.playerPanel4.Player = this.player4;
            this.playerPanel4.CurrentPlayer = this.game.CurrentPlayer;

            this.game.Deck = new Deck(this.game, CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);
            this.game.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FillDeck();
        }

        #endregion
    }
}