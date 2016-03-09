namespace SplendorWpfClient
{
    #region

    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;

    using SplendorCore.Data;
    using SplendorCore.Models;

    using SplendorWpfClient.Panels;
    using SplendorWpfClient.ViewModels;

    #endregion

    public partial class MainWindow : Window
    {
        #region Fields

        private readonly List<CardPanel> cardPanels = new List<CardPanel>();

        private GameViewModel game;

        private Chips bankChips = new Chips();

        private Chips chipsToTake = new Chips();

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

        #endregion

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
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.game = new GameViewModel();
            this.DataContext = this.game;
        }
    }
}