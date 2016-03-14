namespace SplendorWpfClient.ViewModels
{
    using System.Windows.Media;

    public class CardsHeapViewModel : AbstractViewModel
    {
        public int Count { get; set; }

        public RadialGradientBrush Background { get; set; }

        public bool IsCountPositive
        {
            get { return this.Count > 0; }
        }
    }
}