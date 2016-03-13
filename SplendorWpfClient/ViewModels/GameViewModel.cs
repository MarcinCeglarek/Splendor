namespace SplendorWpfClient.ViewModels
{
    #region

    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;

    using SplendorCore.Data;
    using SplendorCore.Models;

    #endregion

    internal class GameViewModel : AbstractViewModel
    {
        private ObservableCollection<PlayerViewModel> players;

        #region Constructors and Destructors

        public GameViewModel()
        {
            this.Game = new Game();
            this.Game.Deck = new Deck(this.Game, CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);
            this.players = new ObservableCollection<PlayerViewModel>();
            this.players.CollectionChanged += this.PlayersCollectionChanged;
            this.Players = new ReadOnlyObservableCollection<PlayerViewModel>(this.players);

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

        public bool IsNotStarted { get { return this.Game == null || !this.Game.HasStarted; } }

        public bool IsStarted { get { return this.Game != null && this.Game.HasStarted; } }

        public ReadOnlyObservableCollection<PlayerViewModel> Players { get; set; }

        #endregion

        #region Properties

        private Game Game { get; set; }

        #endregion

        #region Public Methods and Operators

        public void AddPlayer(Player player)
        {
            this.players.Add(new PlayerViewModel() { Player = player });
        }

        public void BuyCard(Card card)
        {
            this.Game.PurchaseCard(this.Game.CurrentPlayer, card);
        }

        public void ReserveCard(Card card)
        {
            this.Game.ReserveCard(this.Game.CurrentPlayer, card);
        }

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
            foreach (var player in this.Game.Players.ToList())
            {
                this.Game.RemovePlayer(player);
            }

            foreach (var player in this.Players.Select(playerViewModel => playerViewModel.Player))
            {
                this.Game.AddPlayer(player);
            }

            this.OnPropertyChanged("CanGameBeStarted");
            this.OnPropertyChanged("CanPlayerBeAdded");
            this.OnPropertyChanged("Players");
        }

        #endregion
    }
}