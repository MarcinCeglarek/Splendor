namespace SplendorWpfClient.Panels
{
    #region

    using System.Windows.Controls;
    using System.Windows.Input;

    using SplendorCore.Models;

    using SplendorWpfClient.ViewModels;

    #endregion

    public partial class PlayerPanel : UserControl
    {
        #region Constructors and Destructors

        public PlayerPanel()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Methods and Operators

        public void AttachReservedCards()
        {
            this.ReservedCard1.DataContext = ((PlayerViewModel)this.DataContext).ReservedCard1;
            this.ReservedCard2.DataContext = ((PlayerViewModel)this.DataContext).ReservedCard2;
            this.ReservedCard3.DataContext = ((PlayerViewModel)this.DataContext).ReservedCard3;
        }

        #endregion

        #region Methods

        private void CostBorderMouseUp(object sender, MouseButtonEventArgs e)
        {
            var color = (Color)((Border)sender).ToolTip;
            var player = ((PlayerViewModel)this.DataContext).Player;
            MainWindow.GiveBackChips(player, color);
        }

        private void ReservedCard1MouseUp(object sender, MouseButtonEventArgs e)
        {
            var card = this.ReservedCard3.DataContext as Card;
            if (card != null)
            {
                MainWindow.PurchaseReservedCard(card);
            }
        }

        private void ReservedCard2MouseUp(object sender, MouseButtonEventArgs e)
        {
            var card = this.ReservedCard2.DataContext as Card;
            if (card != null)
            {
                MainWindow.PurchaseReservedCard(card);
            }
        }

        private void ReservedCard3MouseUp(object sender, MouseButtonEventArgs e)
        {
            var card = this.ReservedCard1.DataContext as Card;
            if (card != null)
            {
                MainWindow.PurchaseReservedCard(card);
            }
        }

        #endregion
    }
}