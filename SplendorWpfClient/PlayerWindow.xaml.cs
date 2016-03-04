namespace SplendorWpfClient
{
    #region

    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    #endregion

    public partial class PlayerWindow : Window
    {
        #region Fields

        private readonly MainWindow mainWindow;

        #endregion

        #region Constructors and Destructors

        public PlayerWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.CloseWindowAction();
        }

        private void OkClick(object sender, RoutedEventArgs e)
        {
            this.AddPlayerAction();
        }

        private void PlayerNameTextChanged(object sender, TextChangedEventArgs e)
        {
            this.Ok.IsEnabled = !string.IsNullOrWhiteSpace(this.PlayerName.Text);
        }

        #endregion

        private void PlayerNameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.AddPlayerAction();
            }

            if (e.Key == Key.Escape)
            {
                this.CloseWindowAction();
            }
        }

        private void AddPlayerAction()
        {
            if (!string.IsNullOrWhiteSpace(this.PlayerName.Text))
            {
                this.mainWindow.AddPlayer(this.PlayerName.Text);
            }
            
            this.CloseWindowAction();
        }

        private void CloseWindowAction()
        {
            this.PlayerName.Text = string.Empty;
            this.Hide();
        }
    }
}