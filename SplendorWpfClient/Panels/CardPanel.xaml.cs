namespace SplendorWpfClient.Panels
{
    #region

    using System.Windows;
    using System.Windows.Controls;

    using SplendorCore.Models;

    #endregion

    public partial class CardPanel : UserControl
    {
        #region Fields

        private Card card;

        #endregion

        #region Constructors and Destructors

        public CardPanel()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

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
                    this.Visibility = Visibility.Hidden;
                    return;
                }

                this.Visibility = Visibility.Visible;
            }
        }

        #endregion
    }
}