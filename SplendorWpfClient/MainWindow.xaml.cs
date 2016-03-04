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
        #region Fields

        private readonly List<CardPanel> cardPanels = new List<CardPanel>();

        private readonly Game game;

        private Chips bankChips = new Chips();

        private Chips chipsToTake = new Chips();

        #endregion

        #region Constructors and Destructors

        public MainWindow()
        {
            this.game = new Game();
            this.InitializeComponent();
        }

        #endregion

        #region Public Methods and Operators

        public void AddPlayer(string name)
        {
            this.game.Players.Add(new Player { Name = name });

            if (this.game.Players.Count >= 2)
            {
                this.StartGameButton.IsEnabled = true;
            }

            if (this.game.Players.Count > 3)
            {
                this.AddPlayerButton.IsEnabled = false;
            }
        }

        #endregion

        #region Methods

        private void AddPlayerClick(object sender, RoutedEventArgs e)
        {
            var playerWindow = new PlayerWindow(this);
            playerWindow.ShowDialog();
        }

        #endregion

        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            this.StartGameButton.Visibility = Visibility.Hidden;
            this.AddPlayerButton.Visibility = Visibility.Hidden;

            this.game.Deck = new Deck(this.game, CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);
            this.game.Start();

            this.Card11.Card = this.game.Deck.AvailableCards.First();
        }
    }
}