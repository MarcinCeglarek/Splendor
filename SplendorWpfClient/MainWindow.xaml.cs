namespace SplendorWpfClient
{
    #region

    using System;
    using System.Windows;
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

            this.BorderBanksChipsToShowBlack.MouseEnter += (sender, args) => this.BorderMouseEnter(sender, args, game.BanksChipsToShowBlack);
            this.BorderBanksChipsToShowBlue.MouseEnter += (sender, args) => this.BorderMouseEnter(sender, args, game.BanksChipsToShowBlue);
            this.BorderBanksChipsToShowGreen.MouseEnter += (sender, args) => this.BorderMouseEnter(sender, args, game.BanksChipsToShowGreen);
            this.BorderBanksChipsToShowRed.MouseEnter += (sender, args) => this.BorderMouseEnter(sender, args, game.BanksChipsToShowRed);
            this.BorderBanksChipsToShowWhite.MouseEnter += (sender, args) => this.BorderMouseEnter(sender, args, game.BanksChipsToShowWhite);

            this.BorderBanksChipsToShowBlack.MouseLeave += (sender, args) => this.BorderMouseLeave(sender, args, game.BanksChipsToShowBlack);
            this.BorderBanksChipsToShowBlue.MouseLeave += (sender, args) => this.BorderMouseLeave(sender, args, game.BanksChipsToShowBlue);
            this.BorderBanksChipsToShowGreen.MouseLeave += (sender, args) => this.BorderMouseLeave(sender, args, game.BanksChipsToShowGreen);
            this.BorderBanksChipsToShowRed.MouseLeave += (sender, args) => this.BorderMouseLeave(sender, args, game.BanksChipsToShowRed);
            this.BorderBanksChipsToShowWhite.MouseLeave += (sender, args) => this.BorderMouseLeave(sender, args, game.BanksChipsToShowWhite);

            this.BorderBanksChipsToTakeBlack.MouseEnter += (sender, args) => this.BorderMouseEnter(sender, args, game.BanksChipsToTakeBlack);
            this.BorderBanksChipsToTakeBlue.MouseEnter += (sender, args) => this.BorderMouseEnter(sender, args, game.BanksChipsToTakeBlue);
            this.BorderBanksChipsToTakeGreen.MouseEnter += (sender, args) => this.BorderMouseEnter(sender, args, game.BanksChipsToTakeGreen);
            this.BorderBanksChipsToTakeRed.MouseEnter += (sender, args) => this.BorderMouseEnter(sender, args, game.BanksChipsToTakeRed);
            this.BorderBanksChipsToTakeWhite.MouseEnter += (sender, args) => this.BorderMouseEnter(sender, args, game.BanksChipsToTakeWhite);

            this.BorderBanksChipsToTakeBlack.MouseLeave += (sender, args) => this.BorderMouseLeave(sender, args, game.BanksChipsToTakeBlack);
            this.BorderBanksChipsToTakeBlue.MouseLeave += (sender, args) => this.BorderMouseLeave(sender, args, game.BanksChipsToTakeBlue);
            this.BorderBanksChipsToTakeGreen.MouseLeave += (sender, args) => this.BorderMouseLeave(sender, args, game.BanksChipsToTakeGreen);
            this.BorderBanksChipsToTakeRed.MouseLeave += (sender, args) => this.BorderMouseLeave(sender, args, game.BanksChipsToTakeRed);
            this.BorderBanksChipsToTakeWhite.MouseLeave += (sender, args) => this.BorderMouseLeave(sender, args, game.BanksChipsToTakeWhite);
        }

        #endregion

        #region Public Methods and Operators

        public static void GiveBackChips(Player player, Color color)
        {
            game.GiveBackChips(player, color);
        }

        public static void PurchaseOrReserveCard(Card card)
        {
            game.PurchaseOrReserveCard(card);
        }

        public static void PurchaseReservedCard(Card card)
        {
            game.PurchaseCard(card);
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

        private void BankShowBlackMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToTake(Color.Black);
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

        private void BankShowWhiteMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToTake(Color.White);
        }

        private void BankTakeBlackMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToShow(Color.Black);
        }

        private void BankTakeBlueMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToShow(Color.Blue);
        }

        private void BankTakeButtonClick(object sender, RoutedEventArgs e)
        {
            if (game.CanCurrentPlayerTakeChips(game.BankChipsToTake))
            {
                game.TakeChips(game.BankChipsToTake);
            }
        }

        private void BankTakeGreenMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToShow(Color.Green);
        }

        private void BankTakeRedMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToShow(Color.Red);
        }

        private void BankTakeWhiteMouseUp(object sender, MouseButtonEventArgs e)
        {
            game.MoveChipToChipsToShow(Color.White);
        }

        private void BorderMouseEnter(object sender, MouseEventArgs e, ChipsViewModel chipsViewModel)
        {
            if (chipsViewModel != null)
            {
                chipsViewModel.IsMouseHover = true;
                game.NotifyBankHover(chipsViewModel);
            }
        }

        private void BorderMouseLeave(object sender, MouseEventArgs e, ChipsViewModel chipsViewModel)
        {
            if (chipsViewModel != null)
            {
                chipsViewModel.IsMouseHover = false;
                game.NotifyBankHover(chipsViewModel);
            }
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            game = new GameViewModel();
            this.DataContext = game;

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
            if (game.Players.Count <= 0)
            {
                return;
            }

            this.PlayerPanel1.DataContext = game.Players[0];
            this.PlayerPanel1.AttachReservedCards();

            if (game.Players.Count <= 1)
            {
                return;
            }

            this.PlayerPanel2.DataContext = game.Players[1];
            this.PlayerPanel2.AttachReservedCards();

            if (game.Players.Count <= 2)
            {
                return;
            }

            this.PlayerPanel3.DataContext = game.Players[2];
            this.PlayerPanel3.AttachReservedCards();

            if (game.Players.Count <= 3)
            {
                return;
            }

            this.PlayerPanel4.DataContext = game.Players[3];
            this.PlayerPanel4.AttachReservedCards();
        }

        private void SendChatButtonClick(object sender, RoutedEventArgs e)
        {
            game.SendChat(this.ChatMessage.Text);
            this.ChatMessage.Text = string.Empty;
        }

        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            game.Start();

            this.Card11.DataContext = game.AvailableCards[0];
            this.Card12.DataContext = game.AvailableCards[1];
            this.Card13.DataContext = game.AvailableCards[2];
            this.Card14.DataContext = game.AvailableCards[3];

            this.Card21.DataContext = game.AvailableCards[4];
            this.Card22.DataContext = game.AvailableCards[5];
            this.Card23.DataContext = game.AvailableCards[6];
            this.Card24.DataContext = game.AvailableCards[7];

            this.Card31.DataContext = game.AvailableCards[8];
            this.Card32.DataContext = game.AvailableCards[9];
            this.Card33.DataContext = game.AvailableCards[10];
            this.Card34.DataContext = game.AvailableCards[11];

            this.PopulatePlayerPanels();
            this.PopulateAristocrates();
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        #endregion
    }
}