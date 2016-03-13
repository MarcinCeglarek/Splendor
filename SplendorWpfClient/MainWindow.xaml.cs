namespace SplendorWpfClient
{
    #region

    using System;
    using System.Windows;

    using SplendorCore.Models;

    using SplendorWpfClient.ViewModels;

    #endregion

    public partial class MainWindow : Window
    {
        #region Static Fields

        private static GameViewModel game;

        #endregion

        #region Constructors and Destructors

        public MainWindow()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Methods and Operators

        public static void BuyCard(Card card)
        {
            game.BuyCard(card);
        }

        public static void GiveBackChips()
        {
            throw new NotImplementedException();
        }

        public static void ReserveCard()
        {
            throw new NotImplementedException();
        }

        public static void TakeChips()
        {
            throw new NotImplementedException();
        }

        public void AddPlayer(string name)
        {
            game.AddPlayer(new Player() { Name = name });
            this.PopulatePlayerPanels();
        }

        #endregion

        #region Methods

        private void AddPlayerClick(object sender, RoutedEventArgs e)
        {
            var playerWindow = new PlayerWindow(this);
            playerWindow.ShowDialog();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            game = new GameViewModel();
            this.DataContext = game;
            game.AddPlayer(new Player() { Name = "AA" });
            game.AddPlayer(new Player() { Name = "BB" });

            this.PopulatePlayerPanels();
        }

        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            game.Start();

            this.Card11.DataContext = new CardViewModel() { Card = game.AvailableCards[0] };
            this.Card12.DataContext = new CardViewModel() { Card = game.AvailableCards[1] };
            this.Card13.DataContext = new CardViewModel() { Card = game.AvailableCards[2] };
            this.Card14.DataContext = new CardViewModel() { Card = game.AvailableCards[3] };

            this.Card21.DataContext = new CardViewModel() { Card = game.AvailableCards[4] };
            this.Card22.DataContext = new CardViewModel() { Card = game.AvailableCards[5] };
            this.Card23.DataContext = new CardViewModel() { Card = game.AvailableCards[6] };
            this.Card24.DataContext = new CardViewModel() { Card = game.AvailableCards[7] };

            this.Card31.DataContext = new CardViewModel() { Card = game.AvailableCards[8] };
            this.Card32.DataContext = new CardViewModel() { Card = game.AvailableCards[9] };
            this.Card33.DataContext = new CardViewModel() { Card = game.AvailableCards[10] };
            this.Card34.DataContext = new CardViewModel() { Card = game.AvailableCards[11] };

            this.PopulatePlayerPanels();
        }

        private void PopulatePlayerPanels()
        {
            this.PlayerPanel1.DataContext = game.Players[0];
            this.PlayerPanel2.DataContext = game.Players[1];

            if (game.Players.Count > 2)
            {
                this.PlayerPanel3.DataContext = game.Players[2];

                if (game.Players.Count > 3)
                {
                    this.PlayerPanel4.DataContext = game.Players[3];
                }
            }
        }

        #endregion
    }
}