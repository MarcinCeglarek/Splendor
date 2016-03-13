namespace SplendorWpfClient.Panels
{
    #region

    using System.Windows.Controls;

    using SplendorWpfClient.ViewModels;

    #endregion

    public partial class CardPanel : UserControl
    {
        #region Constructors and Destructors

        public CardPanel()
        {
            this.InitializeComponent();
        }

        #endregion

        private void Border_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow.BuyCard(((CardViewModel)this.DataContext).Card);
        }
    }
}