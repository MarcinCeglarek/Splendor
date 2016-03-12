namespace SplendorWpfClient
{
    #region

    using System.Windows;

    using SplendorCore.Models;

    using SplendorWpfClient.ViewModels;

    #endregion

    public partial class MainWindow : Window
    {
        #region Fields

        private GameViewModel game;

        #endregion

        #region Constructors and Destructors

        public MainWindow()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Methods and Operators

        public void AddPlayer(string name)
        {
            this.game.Players.Add(new Player { Name = name });
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
            this.game = new GameViewModel();
            this.DataContext = this.game;
            this.game.Players.Add(new Player { Name = "AA" });
            this.game.Players.Add(new Player { Name = "BB" });
        }

        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            this.game.Start();

            this.Card11.DataContext = new CardViewModel() { Card = this.game.AvailableCards[0] };
            this.Card12.DataContext = new CardViewModel() { Card = this.game.AvailableCards[1] };
            this.Card13.DataContext = new CardViewModel() { Card = this.game.AvailableCards[2] };
            this.Card14.DataContext = new CardViewModel() { Card = this.game.AvailableCards[3] };

            this.Card21.DataContext = new CardViewModel() { Card = this.game.AvailableCards[4] };
            this.Card22.DataContext = new CardViewModel() { Card = this.game.AvailableCards[5] };
            this.Card23.DataContext = new CardViewModel() { Card = this.game.AvailableCards[6] };
            this.Card24.DataContext = new CardViewModel() { Card = this.game.AvailableCards[7] };

            this.Card31.DataContext = new CardViewModel() { Card = this.game.AvailableCards[8] };
            this.Card32.DataContext = new CardViewModel() { Card = this.game.AvailableCards[9] };
            this.Card33.DataContext = new CardViewModel() { Card = this.game.AvailableCards[10] };
            this.Card34.DataContext = new CardViewModel() { Card = this.game.AvailableCards[11] };

            this.PlayerPanel1.DataContext = new PlayerViewModel() { Player = this.game.Players[0], IsActivePlayer = true};
            this.PlayerPanel2.DataContext = new PlayerViewModel() { Player = this.game.Players[1] };

            if (this.game.Players.Count > 2)
            {
                this.PlayerPanel3.DataContext = new PlayerViewModel() { Player = this.game.Players[2] };

                if (this.game.Players.Count > 3)
                {
                    this.PlayerPanel4.DataContext = new PlayerViewModel() { Player = this.game.Players[3] };   
                }
            }
        }

        #endregion
    }
}