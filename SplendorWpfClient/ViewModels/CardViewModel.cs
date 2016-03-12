namespace SplendorWpfClient.ViewModels
{
    #region

    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Media;

    using SplendorCore.Models;

    #endregion

    public class CardViewModel : AbstractViewModel
    {
        #region Fields

        private Card card;

        #endregion

        #region Constructors and Destructors

        public CardViewModel()
        {
            this.VisibleCost = new ObservableCollection<ChipsViewModel>();
        }

        #endregion

        #region Public Properties

        public SolidColorBrush Background
        {
            get
            {
                return this.IsCardPresent ? new SolidColorBrush(GetBackColor(this.card.Color)) : null;
            }
        }

        public Card Card
        {
            get { return this.card; }
            set
            {
                this.card = value;

                this.VisibleCost = new ObservableCollection<ChipsViewModel>();
                foreach (var cost in
                    this.card.Cost.Where(cost => cost.Value > 0).OrderByDescending(cost => cost.Key).Select(cost => new ChipsViewModel(cost, this.card.Color)))
                {
                    this.VisibleCost.Add(cost);
                }

                this.OnPropertyChanged("IsCardPresent");
                this.OnPropertyChanged("IsVictoryPointsPresent");
                this.OnPropertyChanged("VictoryPoints");
                this.OnPropertyChanged("VisibleCost");
                this.OnPropertyChanged("ForeColor");
            }
        }

        public SolidColorBrush ForeColor { get { return this.IsCardPresent ? new SolidColorBrush(GetForeColor(this.card.Color)) : new SolidColorBrush(Colors.Gold); } }

        public bool IsCardPresent { get { return this.Card != null; } }

        public bool IsVictoryPointsPresent { get { return this.IsCardPresent && this.Card.VictoryPoints != 0; } }

        public int VictoryPoints { get { return this.IsCardPresent ? this.card.VictoryPoints : -1; } }

        public ObservableCollection<ChipsViewModel> VisibleCost { get; set; }

        #endregion
    }
}