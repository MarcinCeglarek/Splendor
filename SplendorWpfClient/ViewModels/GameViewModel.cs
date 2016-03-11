namespace SplendorWpfClient.ViewModels
{
    #region

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;

    using SplendorCore.Data;
    using SplendorCore.Models;

    #endregion

    internal class GameViewModel : AbstractViewModel
    {
        #region Constructors and Destructors

        public GameViewModel()
        {
            this.Game = new Game();
            this.Game.Deck = new Deck(this.Game, CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);
            this.Players = new ObservableCollection<Player>();
            this.Players.CollectionChanged += this.PlayersCollectionChanged;

            this.AllCards = new ObservableCollection<Card>(this.Game.Deck.AllCards);
            this.AllCards.CollectionChanged += this.AllCardsCollectionChanged;

            this.AvailableCards = new ObservableCollection<Card>(this.Game.Deck.AvailableCards);
            this.AvailableCards.CollectionChanged += this.AvailableCardsCollectionChanged;
        }

        #endregion

        #region Public Properties

        public ObservableCollection<Card> AllCards { get; set; }

        public ObservableCollection<Card> AvailableCards { get; set; }

        public bool CanGameBeStarted { get { return this.Game != null && !this.Game.HasStarted && this.Game.Players.Count >= 2; } }

        public bool CanPlayerBeAdded { get { return this.Game != null && this.Game.Players.Count < 4 && !this.Game.IsActive; } }

        public bool IsActive { get { return this.Game != null && this.Game.IsActive; } }

        public bool IsStarted { get { return this.Game != null && this.Game.HasStarted; } }

        public bool IsNotStarted { get { return this.Game == null || !this.Game.HasStarted; } }

        public ObservableCollection<Player> Players { get; set; }

        #endregion

        #region Properties

        private Game Game { get; set; }

        #endregion

        #region Public Methods and Operators

        public void Start()
        {
            this.Game.Start();
            this.AllCards.Clear();
            foreach (var card in this.Game.Deck.AllCards)
            {
                this.AllCards.Add(card);
            }

            this.AvailableCards.Clear();
            foreach (var card in this.Game.Deck.AvailableCards)
            {
                this.AvailableCards.Add(card);
            }

            this.OnPropertyChanged("CanGameBeStarted");
            this.OnPropertyChanged("CanPlayerBeAdded");
            this.OnPropertyChanged("IsActive");
            this.OnPropertyChanged("IsStarted");
            this.OnPropertyChanged("IsNotStarted");
        }

        #endregion

        #region Methods

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
            this.Game.Players = new List<Player>(this.Players);

            this.OnPropertyChanged("CanGameBeStarted");
            this.OnPropertyChanged("CanPlayerBeAdded");
            this.OnPropertyChanged("Players");
        }

        #endregion
    }
}