namespace SplendorWpfClient.Panels
{
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for PlayerPanel.xaml
    /// </summary>
    public partial class PlayerPanel : UserControl
    {
        public PlayerPanel()
        {
            InitializeComponent();
        }

        private void CostBorder_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow.GiveBackChips();
        }
    }
}
