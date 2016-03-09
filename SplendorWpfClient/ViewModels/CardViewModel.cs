namespace SplendorWpfClient.ViewModels
{
    #region

    using System;
    using System.Collections.Generic;
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
            this.VisibleCost = new ObservableCollection<KeyValuePair<SplendorCore.Models.Color, int>>();
        }

        #endregion

        #region Public Properties

        public SolidColorBrush Background
        {
            get
            {
                if (this.IsCardPresent)
                {
                    return new SolidColorBrush(ForeColor(this.card.Color));
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

                this.VisibleCost = new ObservableCollection<KeyValuePair<SplendorCore.Models.Color, int>>();
                foreach (var cost in this.card.Cost.Where(cost => cost.Value > 0).OrderByDescending(cost => cost.Key))
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

        public int VictoryPoints { get { return this.IsCardPresent ? this.card.VictoryPoints : 0; } }

        public ObservableCollection<KeyValuePair<SplendorCore.Models.Color, int>> VisibleCost { get; set; }

        #endregion

        #region Public Methods and Operators

        public static Color ForeColor(SplendorCore.Models.Color color)
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

        #endregion
    }
}