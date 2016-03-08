namespace SplendorWpfClient.ViewModels
{
    #region

    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using SplendorCore.Data;
    using SplendorCore.Models;

    #endregion

    internal class GameViewModel : INotifyPropertyChanged
    {
        #region Constructors and Destructors

        public GameViewModel()
        {
            this.Game = new Game();
            this.Game.Deck = new Deck(this.Game, CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);
            this.Players = new ObservableCollection<Player>();

            this.AllCards = new ObservableCollection<Card>(this.Game.Deck.AllCards);
            this.AvailableCards = new ObservableCollection<Card>(this.Game.Deck.AvailableCards);
            this.Players.CollectionChanged += this.PlayersCollectionChanged;
            this.AvailableCards.CollectionChanged += this.AvailableCardsCollectionChanged;
            this.AllCards.CollectionChanged += this.AllCardsCollectionChanged;
        }

        #endregion

        #region Public Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        public ObservableCollection<Card> AllCards { get; set; }

        public ObservableCollection<Card> AvailableCards { get; set; }

        public bool CanGameBeStarted { get { return this.Game != null && !this.Game.HasStarted && this.Game.Players.Count >= 2; } }

        public bool CanPlayerBeAdded { get { return this.Game != null && this.Game.Players.Count < 4; } }

        public ObservableCollection<Player> Players { get; set; }

        #endregion

        #region Properties

        private Game Game { get; set; }

        #endregion

        #region Public Methods and Operators

        public void Start()
        {
            this.Game.Start();
        }

        #endregion

        #region Methods

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void AllCardsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.OnPropertyChanged("AllCards");
        }

        private void AvailableCardsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.OnPropertyChanged("AvailableCards");
        }

        private void PlayersCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.OnPropertyChanged("CanGameBeStarted");
            this.OnPropertyChanged("CanPlayerBeAdded");
            this.OnPropertyChanged("Players");
        }

        #endregion
    }
}