namespace SplendorFormsClient
{
    #region

    using System;
    using System.Windows.Forms;

    using SplendorCore.Data;
    using SplendorCore.Models;

    #endregion

    public partial class Form1 : Form
    {
        private Game game = new Game();
        
        private Player player1 = new Player();
        private Player player2 = new Player();
        private Player player3 = new Player();
        private Player player4 = new Player();


        #region Constructors and Destructors

        public Form1()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        private void button1_Click(object sender, EventArgs e)
        {
            this.game.Players.Add(this.player1);
            this.game.Players.Add(this.player2);
            this.game.Players.Add(this.player3);
            this.game.Players.Add(this.player4);


            this.game.Deck = new Deck(this.game, CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);
            this.game.Start();
        }

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

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.FillDeck();
        }
    }
}