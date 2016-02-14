namespace SplendorFormsClient.Panels
{
    using System.Windows.Controls;

    using SplendorCore.Models;

    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private Card card;

        public UserControl1()
        {
            InitializeComponent();
        }

        public Card Card
        {
            get
            {
                return this.card;
            }

            set
            {
                this.card = value;

                if (this.card == null)
                {
                    return;
                }

                this.Black.Content = this.card.Cost.Black;
                this.Blue.Content = this.card.Cost.Blue;
                this.White.Content = this.card.Cost.White;
                this.Green.Content = this.card.Cost.Green;
                this.Red.Content = this.card.Cost.Red;
                this.Points.Content = this.card.VictoryPoints;
                switch (this.card.Color)
                {
                    case SplendorCore.Models.Color.Black:
                        this.Color.Background = Constants.Black.Brush;
                        break;
                    case SplendorCore.Models.Color.Blue:
                        this.Color.Background = Constants.Blue.Brush;
                        break;
                    case SplendorCore.Models.Color.White:
                        this.Color.Background = Constants.White.Brush;
                        break;
                    case SplendorCore.Models.Color.Red:
                        this.Color.Background = Constants.Red.Brush;
                        break;
                    case SplendorCore.Models.Color.Green:
                        this.Color.Background = Constants.Green.Brush;
                        break;
                }
                
            }
        }
    }
}
