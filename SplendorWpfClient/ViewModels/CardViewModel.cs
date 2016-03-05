namespace SplendorWpfClient.ViewModels
{
    #region

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using SplendorCore.Models;

    #endregion

    internal class CardViewModel
    {
        #region Fields

        private Card card;

        #endregion

        #region Constructors and Destructors

        internal CardViewModel()
        {
            this.VisibleCost = new ObservableCollection<KeyValuePair<Color, int>>();
        }

        #endregion

        #region Public Properties

        public Card Card
        {
            get { return this.card; }
            set
            {
                this.card = value;

                this.VisibleCost = new ObservableCollection<KeyValuePair<Color, int>>();
                foreach (var cost in this.card.Cost.Where(cost => cost.Value > 0).OrderByDescending(cost => cost.Key))
                {
                    this.VisibleCost.Add(cost);
                }
            }
        }

        public bool IsCardPresent { get { return this.Card != null; } }

        public bool IsVictoryPointsPresent { get { return this.IsCardPresent && this.Card.VictoryPoints != 0; } }

        public int VictoryPoints { get { return this.card != null ? this.card.VictoryPoints : 0; } }

        public ObservableCollection<KeyValuePair<Color, int>> VisibleCost { get; set; }

        #endregion
    }
}