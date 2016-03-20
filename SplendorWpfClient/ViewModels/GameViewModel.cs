namespace SplendorWpfClient.ViewModels
{
    #region

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Media;

    using SplendorCore.Data;
    using SplendorCore.Models;

    using Color = SplendorCore.Models.Color;

    #endregion

    internal class GameViewModel : AbstractViewModel
    {
        #region Fields

        private readonly List<CardViewModel> availableCards;

        private readonly ObservableCollection<PlayerViewModel> players;

        private readonly CardsHeapViewModel tier1 = new CardsHeapViewModel() { Count = 0, Background = new RadialGradientBrush(Colors.LimeGreen, Colors.DarkGreen) };

        private readonly CardsHeapViewModel tier2 = new CardsHeapViewModel() { Count = 0, Background = new RadialGradientBrush(Colors.Orange, Colors.SaddleBrown) };

        private readonly CardsHeapViewModel tier3 = new CardsHeapViewModel() { Count = 0, Background = new RadialGradientBrush(Colors.DodgerBlue, Colors.Blue) };

        #endregion

        #region Constructors and Destructors

        public GameViewModel()
        {
            Debug.WriteLine("GameViewModel:ctor");
            this.Game = new Game(CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);
            this.History = new ObservableCollection<HistoryEntry>(this.Game.History);

            this.players = new ObservableCollection<PlayerViewModel>();
            this.Players = new ReadOnlyObservableCollection<PlayerViewModel>(this.players);

            this.AllCards = new ObservableCollection<Card>(this.Game.AllCards);
            this.AllCards.CollectionChanged += this.AllCardsCollectionChanged;

            this.availableCards = this.Game.AvailableCards.Select(card => new CardViewModel() { Card = card }).ToList();
            this.AvailableCards = new ObservableCollection<CardViewModel>(this.availableCards);
            this.AvailableCards.CollectionChanged += this.AvailableCardsCollectionChanged;

            this.AvailableAristocrates = new ObservableCollection<Aristocrate>(this.Game.AvailableAristocrates);

            this.BankChipsToShow = new Chips();
            this.BankChipsToTake = new Chips();
        }

        #endregion

        #region Public Properties

        public ObservableCollection<Card> AllCards { get; set; }

        public ObservableCollection<Aristocrate> AvailableAristocrates { get; set; }

        public ObservableCollection<CardViewModel> AvailableCards { get; set; }

        public ObservableCollection<HistoryEntry> History { get; set; } 

        public Chips BankChipsToShow { get; set; }

        public Chips BankChipsToTake { get; set; }

        public ChipsViewModel BanksChipsToShowBlack { get { return new ChipsViewModel(Color.Black, this.BankChipsToShow.Black - this.BankChipsToTake.Black); } }

        public ChipsViewModel BanksChipsToShowBlue { get { return new ChipsViewModel(Color.Blue, this.BankChipsToShow.Blue - this.BankChipsToTake.Blue); } }

        public ChipsViewModel BanksChipsToShowGold { get { return new ChipsViewModel(Color.Gold, this.BankChipsToShow.Gold - this.BankChipsToTake.Gold); } }

        public ChipsViewModel BanksChipsToShowGreen { get { return new ChipsViewModel(Color.Green, this.BankChipsToShow.Green - this.BankChipsToTake.Green); } }

        public ChipsViewModel BanksChipsToShowRed { get { return new ChipsViewModel(Color.Red, this.BankChipsToShow.Red - this.BankChipsToTake.Red); } }

        public ChipsViewModel BanksChipsToShowWhite { get { return new ChipsViewModel(Color.White, this.BankChipsToShow.White - this.BankChipsToTake.White); } }

        public ChipsViewModel BanksChipsToTakeBlack { get { return new ChipsViewModel(Color.Black, this.BankChipsToTake.Black); } }

        public ChipsViewModel BanksChipsToTakeBlue { get { return new ChipsViewModel(Color.Blue, this.BankChipsToTake.Blue); } }

        public ChipsViewModel BanksChipsToTakeGold { get { return new ChipsViewModel(Color.Gold, this.BankChipsToTake.Gold); } }

        public ChipsViewModel BanksChipsToTakeGreen { get { return new ChipsViewModel(Color.Green, this.BankChipsToTake.Green); } }

        public ChipsViewModel BanksChipsToTakeRed { get { return new ChipsViewModel(Color.Red, this.BankChipsToTake.Red); } }

        public ChipsViewModel BanksChipsToTakeWhite { get { return new ChipsViewModel(Color.White, this.BankChipsToTake.White); } }

        public bool CanGameBeStarted { get { return this.Game != null && !this.Game.HasStarted && this.Game.Players.Count >= 2; } }

        public bool CanPlayerBeAdded { get { return this.Game != null && this.Game.Players.Count < 4 && !this.Game.IsActive; } }

        public bool IsActive { get { return this.Game != null && this.Game.IsActive; } }

        public bool IsNotStarted { get { return this.Game == null || !this.Game.HasStarted; } }

        public bool IsStarted { get { return this.Game != null && this.Game.HasStarted; } }

        public ReadOnlyObservableCollection<PlayerViewModel> Players { get; set; }

        public CardsHeapViewModel Tier1
        {
            get
            {
                this.tier1.Count = this.GetRemainingCardsOfTier(1);
                return this.tier1;
            }
        }

        public CardsHeapViewModel Tier2
        {
            get
            {
                this.tier2.Count = this.GetRemainingCardsOfTier(2);
                return this.tier2;
            }
        }

        public CardsHeapViewModel Tier3
        {
            get
            {
                this.tier3.Count = this.GetRemainingCardsOfTier(3);
                return this.tier3;
            }
        }

        #endregion

        #region Properties

        private Game Game { get; set; }

        #endregion

        #region Public Methods and Operators

        public void AddPlayer(Player player)
        {
            Debug.WriteLine("GameViewModel:AddPlayer");
            if (!this.Game.HasStarted)
            {
                this.Game.AddPlayer(player);
                this.players.Add(new PlayerViewModel() { Player = player });
                this.OnPropertyChanged("CanGameBeStarted");
                this.OnPropertyChanged("CanPlayerBeAdded");
                this.UpdateHistory();
            }
        }

        public bool CanCurrentPlayerTakeChips(Chips chips)
        {
            return this.Game.CanTakeChips(this.Game.CurrentPlayer, this.Game.CurrentPlayer.Chips + this.BankChipsToTake);
        }

        public void MoveChipToChipsToShow(Color color)
        {
            if (!this.Game.IsActive)
            {
                return;
            }

            var oneChip = new Chips();
            oneChip[color]++;

            if (this.Game.CanTakeChips(this.Game.CurrentPlayer, this.Game.CurrentPlayer.Chips + this.BankChipsToTake - oneChip))
            {
                this.BankChipsToTake[color]--;

                this.NotifyBankChanges();
            }
        }

        public void MoveChipToChipsToTake(Color color)
        {
            if (!this.Game.IsActive)
            {
                return;
            }

            var oneChip = new Chips();
            oneChip[color]++;

            if (this.Game.CanTakeChips(this.Game.CurrentPlayer, this.Game.CurrentPlayer.Chips + this.BankChipsToTake + oneChip))
            {
                this.BankChipsToTake[color]++;

                this.NotifyBankChanges();
            }
        }

        public void NotifyBankHover(ChipsViewModel chipsViewModel)
        {
            this.OnPropertyChanged("BanksChipsToShowBlack");
            this.OnPropertyChanged("BanksChipsToShowBlue");
            this.OnPropertyChanged("BanksChipsToShowGreen");
            this.OnPropertyChanged("BanksChipsToShowRed");
            this.OnPropertyChanged("BanksChipsToShowWhite");

            this.OnPropertyChanged("BanksChipsToTakeBlack");
            this.OnPropertyChanged("BanksChipsToTakeBlue");
            this.OnPropertyChanged("BanksChipsToTakeGreen");
            this.OnPropertyChanged("BanksChipsToTakeRed");
            this.OnPropertyChanged("BanksChipsToTakeWhite");
        }

        public void PurchaseCard(Card card)
        {
            if (!this.Game.IsActive)
            {
                return;
            }

            Debug.WriteLine("GameViewModel:PurchaseCard");

            if (this.Game.CanPurchaseCard(this.Game.CurrentPlayer, card))
            {
                this.Game.PurchaseCard(this.Game.CurrentPlayer, card);

                this.UpdateBank();
                this.UpdateDeck();
                this.UpdatePlayerPanels();
                this.UpdateHistory();
            }
        }

        public void PurchaseOrReserveCard(Card card)
        {
            if (!this.Game.IsActive)
            {
                return;
            }

            Debug.WriteLine("GameViewModel:PurchaseOrReserveCard");

            if (this.Game.CanPurchaseCard(this.Game.CurrentPlayer, card))
            {
                this.Game.PurchaseCard(this.Game.CurrentPlayer, card);

                this.UpdateBank();
                this.UpdateDeck();
                this.UpdatePlayerPanels();
                this.UpdateHistory();
            }
            else if (this.Game.CanReserveCard(this.Game.CurrentPlayer, card))
            {
                this.Game.ReserveCard(this.Game.CurrentPlayer, card);

                this.UpdateBank();
                this.UpdateDeck();
                this.UpdatePlayerPanels();
                this.UpdateHistory();
            }
        }

        public void ReserveCard(Card card)
        {
            if (!this.Game.IsActive)
            {
                return;
            }

            Debug.WriteLine("GameViewModel:ReserveCard");
            if (this.Game.CanReserveCard(this.Game.CurrentPlayer, card))
            {
                this.Game.ReserveCard(this.Game.CurrentPlayer, card);

                this.UpdateBank();
                this.UpdateDeck();
                this.UpdatePlayerPanels();
                this.UpdateHistory();
            }
        }

        public void Start()
        {
            if (this.Game.HasStarted)
            {
                return;
            }

            Debug.WriteLine("GameViewModel:Start");
            this.Game.Start();
            this.AllCards.Clear();
            foreach (var card in this.Game.AllCards)
            {
                this.AllCards.Add(card);
            }

            this.availableCards.Clear();
            foreach (var card in this.Game.AvailableCards)
            {
                this.availableCards.Add(new CardViewModel(card));
            }

            this.AvailableCards = new ObservableCollection<CardViewModel>(this.availableCards);

            this.AvailableAristocrates.Clear();
            foreach (var aristocrate in this.Game.AvailableAristocrates)
            {
                this.AvailableAristocrates.Add(aristocrate);
            }

            this.players.Clear();
            foreach (var player in this.Game.Players)
            {
                this.players.Add(new PlayerViewModel() { Player = player });
            }

            this.NotifyGameStarts();
            this.NotifyPlayersChanges();
            this.UpdatePlayerPanels();
            this.UpdateBank();
            this.UpdateHistory();
            this.NotifyDeckChanges();
        }

        public void TakeChips(Chips chips)
        {
            if (!this.Game.IsActive)
            {
                return;
            }

            Debug.WriteLine("GameViewModel:TakeChips");
            this.Game.TakeChips(this.Game.CurrentPlayer, this.Game.CurrentPlayer.Chips + chips);

            this.UpdateBank();
            this.UpdatePlayerPanels();
            this.UpdateHistory();
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
            var allGameCards = this.Game.AllCards.Count(card => card.Tier == i);
            var availableGameCards = this.Game.AvailableCards.Count(card => card.Tier == i);
            return allGameCards - availableGameCards;
        }

        private void NotifyBankChanges()
        {
            this.OnPropertyChanged("BanksChipsToShowWhite");
            this.OnPropertyChanged("BanksChipsToShowBlue");
            this.OnPropertyChanged("BanksChipsToShowGreen");
            this.OnPropertyChanged("BanksChipsToShowRed");
            this.OnPropertyChanged("BanksChipsToShowBlack");
            this.OnPropertyChanged("BanksChipsToShowGold");

            this.OnPropertyChanged("BanksChipsToTakeWhite");
            this.OnPropertyChanged("BanksChipsToTakeBlue");
            this.OnPropertyChanged("BanksChipsToTakeGreen");
            this.OnPropertyChanged("BanksChipsToTakeRed");
            this.OnPropertyChanged("BanksChipsToTakeBlack");
        }

        private void NotifyDeckChanges()
        {
            this.OnPropertyChanged("Tier1");
            this.OnPropertyChanged("Tier2");
            this.OnPropertyChanged("Tier3");

            this.Tier1.Update();
            this.Tier2.Update();
            this.Tier3.Update();
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

        private void UpdateBank()
        {
            this.BankChipsToShow = this.Game.Bank;
            this.BankChipsToTake = new Chips();

            this.NotifyBankChanges();
        }

        private void UpdateHistory()
        {
            this.History.Clear();
            foreach (var historyEntry in this.Game.History)
            {
                this.History.Add(historyEntry);
            }
        }

        private void UpdateDeck()
        {
            foreach (var availableCard in this.availableCards)
            {
                if (availableCard.Card == null || !this.Game.AvailableCards.Contains(availableCard.Card))
                {
                    var firstNotUsedCard = this.Game.AvailableCards.Except(this.availableCards.Select(cvm => cvm.Card)).FirstOrDefault();
                    availableCard.Card = firstNotUsedCard;
                }
            }

            this.NotifyDeckChanges();
        }

        private void UpdatePlayerPanels()
        {
            foreach (var playerViewModel in this.Players)
            {
                playerViewModel.IsCurrentPlayer = playerViewModel.Player == this.Game.CurrentPlayer;
                playerViewModel.NotifyPropertyChanged();
            }

            foreach (var cardViewModel in this.availableCards)
            {
                cardViewModel.CanBePurchased = this.Game.CanPurchaseCard(this.Game.CurrentPlayer, cardViewModel.Card);
            }
        }

        #endregion
    }
}