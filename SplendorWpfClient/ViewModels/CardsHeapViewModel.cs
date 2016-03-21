namespace SplendorWpfClient.ViewModels
{
    #region

    using System.Windows.Media;

    #endregion

    public class CardsHeapViewModel : AbstractViewModel
    {
        #region Fields

        private int count;

        #endregion

        #region Public Properties

        public RadialGradientBrush Background { get; set; }

        public int Count
        {
            get { return this.count; }
            set
            {
                this.count = value;
                this.OnPropertyChanged();
                this.OnPropertyChanged("IsCountPositive");
            }
        }

        public bool IsCountPositive { get { return this.Count > 0; } }

        #endregion
    }
}