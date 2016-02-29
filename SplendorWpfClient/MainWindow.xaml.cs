namespace SplendorWpfClient
{
    #region

    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;

    using SplendorCore.Data;
    using SplendorCore.Models;

    using SplendorWpfClient.Panels;

    #endregion

    public partial class MainWindow : Window
    {
        private readonly List<CardPanel> cardPanels = new List<CardPanel>();

        private readonly Game game;

        private Chips bankChips = new Chips();

        private Chips chipsToTake = new Chips();

        #region Constructors and Destructors

        public MainWindow()
        {
            this.game = new Game();
            this.game.Players.Add(new Player());
            this.game.Players.Add(new Player());
            this.game.Deck = new Deck(this.game, CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);
            this.game.Start();
            this.InitializeComponent();


            this.Card11.Card = this.game.Deck.AvailableCards.First();
        }

        #endregion
    }
}