namespace SplendorWpfClient.ViewModels
{
    #region

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Media;

    using SplendorCore.Models;

    using Color = SplendorCore.Models.Color;

    #endregion

    public class PlayerViewModel : AbstractViewModel
    {
        #region Fields

        private Player player;

        #endregion

        #region Constructors and Destructors

        public PlayerViewModel()
        {
            this.ReservedCard1 = new CardViewModel();
            this.ReservedCard2 = new CardViewModel();
            this.ReservedCard3 = new CardViewModel();
        }

        #endregion

        #region Public Properties

        public SolidColorBrush BorderColor { get { return this.IsCurrentPlayer ? new SolidColorBrush(Colors.Fuchsia) : new SolidColorBrush(Colors.Gray); } }

        public IEnumerable<ChipsViewModel> Cards
        {
            get { return this.IsPlayerPresent ? this.player.Cards.Select(card => new ChipsViewModel(card, Color.White)) : new List<ChipsViewModel>(); }
        }

        public IEnumerable<ChipsViewModel> Chips
        {
            get { return this.IsPlayerPresent ? this.player.Chips.Select(card => new ChipsViewModel(card, Color.White)) : new List<ChipsViewModel>(); }
        }

        public bool IsCurrentPlayer { get; set; }

        public bool IsPlayerPresent { get { return this.player != null; } }

        public string Name { get { return this.IsPlayerPresent ? this.player.Name : string.Empty; } }

        public Player Player
        {
            get { return this.player; }
            set
            {
                this.player = value;
                this.UpdateReservedCards();
                this.NotifyPropertyChanged();
            }
        }

        public CardViewModel ReservedCard1 { get; private set; }

        public CardViewModel ReservedCard2 { get; private set; }

        public CardViewModel ReservedCard3 { get; private set; }

        public ObservableCollection<CardViewModel> ReservedCards { get; set; }

        public int VictoryPoints { get { return this.player != null ? this.player.VictoryPoints : -1; } }

        #endregion

        #region Public Methods and Operators

        public void NotifyPropertyChanged()
        {
            this.UpdateReservedCards();

            this.OnPropertyChanged("BorderColor");
            this.OnPropertyChanged("Cards");
            this.OnPropertyChanged("Chips");
            this.OnPropertyChanged("IsCurrentPlayer");
            this.OnPropertyChanged("IsPlayerPresent");
            this.OnPropertyChanged("VictoryPoints");
        }

        #endregion

        #region Methods

        private void UpdateReservedCards()
        {
            if (this.player != null)
            {
                if (this.player.ReservedCards.Count > 0)
                {
                    this.ReservedCard1.Card = this.player.ReservedCards[0];
                    this.OnPropertyChanged("ReservedCard1");
                }
                else
                {
                    this.ReservedCard1.Card = null;
                    this.ReservedCard2.Card = null;
                    this.ReservedCard3.Card = null;
                    return;
                }

                if (this.player.ReservedCards.Count > 1)
                {
                    this.ReservedCard2.Card = this.player.ReservedCards[1];
                    this.OnPropertyChanged("ReservedCard2");
                }
                else
                {
                    this.ReservedCard2.Card = null;
                    this.ReservedCard3.Card = null;
                    return;
                }

                if (this.player.ReservedCards.Count > 2)
                {
                    this.ReservedCard3.Card = this.player.ReservedCards[2];
                    this.OnPropertyChanged("ReservedCard3");
                }
                else
                {
                    this.ReservedCard3.Card = null;
                    return;
                }
            }
        }

        #endregion
    }
}