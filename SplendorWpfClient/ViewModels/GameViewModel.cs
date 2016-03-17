namespace SplendorWpfClient.ViewModels
{
    #region

    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Windows.Media;

    using SplendorCore.Data;
    using SplendorCore.Models;

    #endregion

    internal class GameViewModel : AbstractViewModel
    {
        #region Fields

        private readonly ObservableCollection<PlayerViewModel> players;

        #endregion

        #region Constructors and Destructors

        public GameViewModel()
        {
            this.Game = new Game(CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);

            this.players = new ObservableCollection<PlayerViewModel>();
            this.players.CollectionChanged += this.PlayersCollectionChanged;
            this.Players = new ReadOnlyObservableCollection<PlayerViewModel>(this.players);

            this.AllCards = new ObservableCollection<Card>(this.Game.AllCards);
            this.AllCards.CollectionChanged += this.AllCardsCollectionChanged;

            this.AvailableCards = new ObservableCollection<Card>(this.Game.AvailableCards);
            this.AvailableCards.CollectionChanged += this.AvailableCardsCollectionChanged;

            this.AvailableAristocrates = new ObservableCollection<Aristocrate>(this.Game.AvailableAristocrates);
        }

        #endregion

        #region Public Properties

        public ObservableCollection<Card> AllCards { get; set; }

        public ObservableCollection<Aristocrate> AvailableAristocrates { get; set; }

        public ObservableCollection<Card> AvailableCards { get; set; }

        public bool CanGameBeStarted { get { return this.Game != null && !this.Game.HasStarted && this.Game.Players.Count >= 2; } }

        public bool CanPlayerBeAdded { get { return this.Game != null && this.Game.Players.Count < 4 && !this.Game.IsActive; } }

        public bool IsActive { get { return this.Game != null && this.Game.IsActive; } }

        public bool IsNotStarted { get { return this.Game == null || !this.Game.HasStarted; } }

        public bool IsStarted { get { return this.Game != null && this.Game.HasStarted; } }

        public ReadOnlyObservableCollection<PlayerViewModel> Players { get; set; }

        public CardsHeapViewModel Tier1
        {
            get { return new CardsHeapViewModel() { Count = this.GetRemainingCardsOfTier(1), Background = new RadialGradientBrush(Colors.LimeGreen, Colors.DarkGreen) }; }
        }

        public CardsHeapViewModel Tier2
        {
            get { return new CardsHeapViewModel() { Count = this.GetRemainingCardsOfTier(2), Background = new RadialGradientBrush(Colors.Orange, Colors.SaddleBrown) }; }
        }

        public CardsHeapViewModel Tier3
        {
            get { return new CardsHeapViewModel() { Count = this.GetRemainingCardsOfTier(3), Background = new RadialGradientBrush(Colors.DodgerBlue, Colors.Blue) }; }
        }

        #endregion

        #region Properties

        private Game Game { get; set; }

        #endregion

        #region Public Methods and Operators

        public void AddPlayer(Player player)
        {
            this.players.Add(new PlayerViewModel() { Player = player });
        }

        public void PurchaseCard(Card card)
        {
            if (this.Game.CanPurchaseCard(this.Game.CurrentPlayer, card))
            {
                this.Game.PurchaseCard(this.Game.CurrentPlayer, card);
                this.NotifyDeckChanges();
                this.UpdatePlayerPanels();
            }
        }

        public void ReserveCard(Card card)
        {
            if (this.Game.CanReserveCard(this.Game.CurrentPlayer, card))
            {
                this.Game.ReserveCard(this.Game.CurrentPlayer, card);
                this.NotifyDeckChanges();
                this.UpdatePlayerPanels();
            }
        }

        public void Start()
        {
            this.Game.Start();
            this.AllCards.Clear();
            foreach (var card in this.Game.AllCards)
            {
                this.AllCards.Add(card);
            }

            this.AvailableCards.Clear();
            foreach (var card in this.Game.AvailableCards)
            {
                this.AvailableCards.Add(card);
            }

            this.AvailableAristocrates.Clear();
            foreach (var aristocrate in this.Game.AvailableAristocrates)
            {
                this.AvailableAristocrates.Add(aristocrate);
            }

            this.NotifyGameStarts();
            this.NotifyPlayersChanges();
            this.UpdatePlayerPanels();
            this.NotifyDeckChanges();
        }

        public void TakeChips(Chips chips)
        {
            this.Game.TakeChips(this.Game.CurrentPlayer, chips);

            this.NotifyBankChanges();
            this.UpdatePlayerPanels();
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

        private int GetRemainingCardsOfTier(int i)
        {
            return this.Game.AllCards.Count(card => card.Tier == i) - this.Game.AvailableCards.Count(card => card.Tier == i);
        }

        private void NotifyBankChanges()
        {
            throw new NotImplementedException();
        }

        private void NotifyDeckChanges()
        {
            this.OnPropertyChanged("Tier1");
            this.OnPropertyChanged("Tier2");
            this.OnPropertyChanged("Tier3");
        }

        private void NotifyGameStarts()
        {
            this.OnPropertyChanged("IsActive");
            this.OnPropertyChanged("IsStarted");
            this.OnPropertyChanged("IsNotStarted");
        }

        private void NotifyPlayersChanges()
        {
            this.OnPropertyChanged("CanGameBeStarted");
            this.OnPropertyChanged("CanPlayerBeAdded");
            this.OnPropertyChanged("Players");
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

            this.NotifyPlayersChanges();
        }

        private void UpdatePlayerPanels()
        {
            foreach (var playerViewModel in this.Players)
            {
                playerViewModel.IsCurrentPlayer = playerViewModel.Player == this.Game.CurrentPlayer;
                playerViewModel.NotifyPropertyChanged();
            }
        }

        #endregion
    }
}