namespace SplendorWpfClient.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Linq;

    using SplendorCore.Models;

    public class AristocrateViewModel : AbstractViewModel
    {
        private Aristocrate aristocrate;

        public Aristocrate Aristocrate
        {
            get { return this.aristocrate; }
            set
            {
                this.aristocrate = value;

                this.VisibleRequiredCards = new ObservableCollection<ChipsViewModel>();
                foreach (var cost in
                    this.aristocrate.RequiredCards.Where(cost => cost.Value > 0).OrderByDescending(cost => cost.Key).Select(cost => new ChipsViewModel(cost, cost.Key)))
                {
                    this.VisibleRequiredCards.Add(cost);
                }

                this.OnPropertyChanged("IsAristocratePresent");
                this.OnPropertyChanged("VictoryPoints");
                this.OnPropertyChanged("IsVictoryPointsPresent");
                this.OnPropertyChanged("VisibleRequiredCards");
            }
        }

        public bool IsAristocratePresent
        {
            get { return this.aristocrate != null; }
        }

        public int VictoryPoints
        {
            get { return this.IsAristocratePresent ? this.aristocrate.VictoryPoints : -1; }
        }

        public bool IsVictoryPointsPresent
        {
            get { return this.VictoryPoints > 0; }
        }

        public ObservableCollection<ChipsViewModel> VisibleRequiredCards { get; set; }
    }
}