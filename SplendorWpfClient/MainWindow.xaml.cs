namespace SplendorWpfClient
{
    #region

    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Forms.VisualStyles;
    using System.Windows.Input;

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
            game.PurchaseCard(card);
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

            this.CardsTier1.DataContext = game.Tier1;
            this.CardsTier2.DataContext = game.Tier2;
            this.CardsTier3.DataContext = game.Tier3;

            this.PopulatePlayerPanels();
        }

        private void PopulateAristocrates()
        {
            this.Aristocrate1.DataContext = new AristocrateViewModel() { Aristocrate = game.AvailableAristocrates[0] };
            this.Aristocrate2.DataContext = new AristocrateViewModel() { Aristocrate = game.AvailableAristocrates[1] };
            this.Aristocrate3.DataContext = new AristocrateViewModel() { Aristocrate = game.AvailableAristocrates[2] };

            if (game.Players.Count > 2)
            {
                this.Aristocrate4.DataContext = new AristocrateViewModel() { Aristocrate = game.AvailableAristocrates[3] };

                if (game.Players.Count > 3)
                {
                    this.Aristocrate5.DataContext = new AristocrateViewModel() { Aristocrate = game.AvailableAristocrates[4] };
                }
            }
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
            this.PopulateAristocrates();
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        #endregion

        private void BankShowWhiteMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToTake(Color.White);
        }

        private void BankShowBlueMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToTake(Color.Blue);
        }

        private void BankShowGreenMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToTake(Color.Green);
        }

        private void BankShowRedMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToTake(Color.Red);
        }

        private void BankShowBlackMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToTake(Color.Black);
        }

        private void BankTakeWhiteMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToShow(Color.White);
        }

        private void BankTakeBlueMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToShow(Color.Blue);
        }

        private void BankTakeGreenMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToShow(Color.Green);
        }

        private void BankTakeRedMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToShow(Color.Red);
        }

        private void BankTakeBlackMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToShow(Color.Black);
        }

        private void BankTakeButtonClick(object sender, RoutedEventArgs e)
        {
            if (game.CanCurrentPlayerTakeChips(game.BankChipsToTake))
            {
                game.TakeChips(game.BankChipsToTake);
            }
        }
    }
}