namespace SplendorWpfClient.ViewModels
{
    #region

    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Media;

    using SplendorCore.Models;

    using Color = System.Windows.Media.Color;

    #endregion

    public class CardViewModel : AbstractViewModel
    {
        #region Static Fields

        private static readonly Color Black = Colors.Black;

        private static readonly Color Blue = Colors.RoyalBlue;

        private static readonly Color Gold = Colors.Gold;

        private static readonly Color Green = Colors.LimeGreen;

        private static readonly Color Red = Colors.OrangeRed;

        private static readonly Color White = Colors.GhostWhite;

        #endregion

        #region Fields

        private Card card;

        #endregion

        #region Constructors and Destructors

        public CardViewModel()
        {
            this.VisibleCost = new ObservableCollection<DisplayInfo>();
        }

        #endregion

        #region Public Properties

        public SolidColorBrush Background
        {
            get
            {
                if (this.IsCardPresent)
                {
                    return new SolidColorBrush(BackColor(this.card.Color));
                }

                return null;
            }
        }

        public Card Card
        {
            get { return this.card; }
            set
            {
                this.card = value;

                this.VisibleCost = new ObservableCollection<DisplayInfo>();
                foreach (var cost in
                    this.card.Cost.Where(cost => cost.Value > 0)
                        .OrderByDescending(cost => cost.Key)
                        .Select(
                            cost =>
                            new DisplayInfo { BackColor = new SolidColorBrush(BackColor(cost.Key)), ForeColor = new SolidColorBrush(ForeColor(cost.Key)), Value = cost.Value }))
                {
                    this.VisibleCost.Add(cost);
                }

                this.OnPropertyChanged("IsCardPresent");
                this.OnPropertyChanged("IsVictoryPointsPresent");
                this.OnPropertyChanged("VictoryPoints");
                this.OnPropertyChanged("VisibleCost");
            }
        }

        public bool IsCardPresent { get { return this.Card != null; } }

        public bool IsVictoryPointsPresent { get { return this.IsCardPresent && this.Card.VictoryPoints != 0; } }

        public int VictoryPoints { get { return this.IsCardPresent ? this.card.VictoryPoints : -1; } }

        public ObservableCollection<DisplayInfo> VisibleCost { get; set; }

        #endregion

        #region Methods

        private static Color BackColor(SplendorCore.Models.Color color)
        {
            switch (color)
            {
                case SplendorCore.Models.Color.Black:
                    return Black;
                case SplendorCore.Models.Color.Blue:
                    return Blue;
                case SplendorCore.Models.Color.Gold:
                    return Gold;
                case SplendorCore.Models.Color.Green:
                    return Green;
                case SplendorCore.Models.Color.Red:
                    return Red;
                case SplendorCore.Models.Color.White:
                    return White;
            }

            throw new NotSupportedException();
        }

        private static Color ForeColor(SplendorCore.Models.Color color)
        {
            switch (color)
            {
                case SplendorCore.Models.Color.Black:
                    return White;
                case SplendorCore.Models.Color.Blue:
                    return Black;
                case SplendorCore.Models.Color.Gold:
                    return Black;
                case SplendorCore.Models.Color.Green:
                    return Black;
                case SplendorCore.Models.Color.Red:
                    return Black;
                case SplendorCore.Models.Color.White:
                    return Black;
            }

            throw new NotSupportedException();
        }

        #endregion

        public class DisplayInfo
        {
            #region Public Properties

            public SolidColorBrush BackColor { get; set; }

            public SolidColorBrush ForeColor { get; set; }

            public int Value { get; set; }

            #endregion
        }
    }
}