namespace SplendorCore.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using SplendorCore.Data;
    using SplendorCore.Helpers;
    using SplendorCore.Interfaces;
    using SplendorCore.Models.Exceptions.AbstractExceptions;
    using SplendorCore.Models.Exceptions.CardExceptions;
    using SplendorCore.Models.Exceptions.ChipOperationExceptions;
    using SplendorCore.Models.Exceptions.DeckExceptions;
    using SplendorCore.Models.Exceptions.GameExceptions;
    using SplendorCore.Models.Exceptions.OperationExceptions;
    using SplendorCore.Models.Exceptions.PlayerExceptions;

    #endregion

    [DataContract]
    public class Game : IGameActions
    {
        #region Fields

        private readonly List<IBroadcastMessages> subscribers;

        private Chips bank;

        private Player firstPlayer;

        #endregion

        #region Constructors and Destructors

        public Game()
        {
            this.Id = Guid.NewGuid();
            this.Players = new List<Player>();
            this.subscribers = new List<IBroadcastMessages>();
            this.Chat = new List<ChatEntry>();
            this.History = new List<HistoryEntry>();
            this.HasStarted = false;
            this.HasFinished = false;
        }

        #endregion

        #region Public Properties

        [DataMember]
        public Chips Bank
        {
            get
            {
                return new Chips(this.bank.White, this.bank.Blue, this.bank.Green, this.bank.Red, this.bank.Black, this.bank.Gold);
            }
        }

        [DataMember]
        public List<ChatEntry> Chat { get; set; }

        [DataMember]
        public Player CurrentPlayer
        {
            get
            {
                return this.Players.FirstOrDefault();
            }
        }

        [DataMember]
        public Deck Deck { get; set; }

        [DataMember]
        public bool HasFinished { get; private set; }

        [DataMember]
        public bool HasStarted { get; private set; }

        [DataMember]
        public List<HistoryEntry> History { get; set; }

        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public List<Player> Players { get; set; }

        public int TotalNumberOfNormalChips
        {
            get
            {
                switch (this.Players.Count)
                {
                    case 2:
                        return CoreConstants.Game.NumberOfNormalChips2Players;
                    case 3:
                        return CoreConstants.Game.NumberOfNormalChips3Players;
                    case 4:
                        return CoreConstants.Game.NumberOfNormalChips4Players;
                }

                throw new InvalidNumberOfPlayersException(this);
            }
        }

        #endregion

        #region Public Methods and Operators

        public bool CanPurchaseCard(Player player, Card card)
        {
            try
            {
                this.PurchaseCardVerification(player, card);
                return true;
            }
            catch (SplendorCardOperationException)
            {
                return false;
            }
            catch (SplendorCardException)
            {
                return false;
            }
        }

        public bool CanReserveCard(Player player, Card card)
        {
            try
            {
                this.ReserveCardVerification(player, card);
                return true;
            }
            catch (SplendorCardOperationException)
            {
                return false;
            }
        }

        public bool CanTakeChips(Player player, Chips chips)
        {
            try
            {
                this.TakeChipVerification(player, chips);
                return true;
            }
            catch (SplendorChipOperationException)
            {
                return false;
            }
        }

        public void ChatMessage(Player player, string message)
        {
            if (this.Players.Contains(player))
            {
                var entry = new ChatEntry(player, message);
                this.Chat.Add(entry);
                this.subscribers.ForEach(subscriber => subscriber.ChatMessage(entry));
            }
            else
            {
                throw new InvalidPlayerException(player);
            }
        }

        public void PurchaseCard(Player player, Card card)
        {
            this.PurchaseCardVerification(player, card);

            this.Deck.AllCards.Remove(card);
            this.CurrentPlayer.ReservedCards.Remove(card);

            var cost = this.CurrentPlayer.GetCardCost(card);

            this.CurrentPlayer.Chips -= cost;
            this.bank += cost;
            this.CurrentPlayer.OwnedCards.Add(card);

            this.PlayerFinished();
            this.subscribers.ForEach(subscriber => subscriber.CardPurchased(this));
        }

        public void ReserveCard(Player player, Card card)
        {
            this.ReserveCardVerification(player, card);

            this.Deck.AllCards.Remove(card);
            this.CurrentPlayer.ReservedCards.Add(card);

            if (this.bank.Gold > 0)
            {
                this.bank.Gold--;
                this.CurrentPlayer.Chips.Gold++;
            }

            this.PlayerFinished();
            this.subscribers.ForEach(subscriber => subscriber.CardReserved(this));
        }

        public void Start()
        {
            if (this.HasFinished)
            {
                throw new GameFinishedException(this);
            }

            if (this.HasStarted)
            {
                throw new GameAlreadyStartedException(this);
            }

            if (this.Deck == null)
            {
                throw new DeckNotPresentException(this);
            }

            if (this.Players.Count < 2 || this.Players.Count > 4)
            {
                throw new InvalidNumberOfPlayersException(this);
            }

            this.HasStarted = true;
            this.Deck.Initialize();
            this.Players = this.Players.Shuffle().ToList();
            this.firstPlayer = this.Players.First();

            var chipCount = this.TotalNumberOfNormalChips;
            this.bank = new Chips() { White = chipCount, Blue = chipCount, Green = chipCount, Red = chipCount, Black = chipCount, Gold = CoreConstants.Game.NumberOfGoldChips };

            this.subscribers.ForEach(subscriber => subscriber.GameStarted(this));
        }

        public void Subscribe(IBroadcastMessages subscriber)
        {
            this.subscribers.Add(subscriber);
        }

        public void TakeChips(Player player, Chips chips)
        {
            this.TakeChipVerification(player, chips);

            var diff = chips - player.Chips;
            this.bank -= diff;
            this.CurrentPlayer.Chips += diff;

            this.PlayerFinished();
            this.subscribers.ForEach(subscriber => subscriber.ChipsTaken(this));
        }

        public void Unsubscribe(IBroadcastMessages subscriber)
        {
            this.subscribers.Remove(subscriber);
        }

        #endregion

        #region Methods

        private void CheckEndGameCondition()
        {
            if (this.Players.Any(p => p.VictoryPoints >= 15) && this.firstPlayer == this.CurrentPlayer)
            {
                this.GameEnded();
            }
        }

        private void GameEnded()
        {
            this.HasFinished = true;
            this.subscribers.ForEach(subscriber => subscriber.GameEnded(this));
        }

        private void PlayerFinished()
        {
            this.CheckAristocrates();
            var currentUser = this.CurrentPlayer;
            this.Players.RemoveAt(0);
            this.Players.Insert(this.Players.Count, currentUser);

            this.CheckEndGameCondition();
        }

        private void CheckAristocrates()
        {
            var eligableAristocrates = this.Deck.AvailableAristocrates.Where(aristocrate => this.CurrentPlayer.Cards >= aristocrate.RequiredCards).ToList();

            if (!eligableAristocrates.Any())
            {
                return;
            }

            var firstAristocrate = eligableAristocrates.First();

            this.Deck.AvailableAristocrates.Remove(firstAristocrate);
            this.CurrentPlayer.OwnedAristocrates.Add(firstAristocrate);
        }

        private void PurchaseCardVerification(Player player, Card card)
        {
            this.VerifyThatGameIsActive();
            this.VerifyPlayerEligibleForMove(player);

            if (!this.Deck.AvailableCards.Contains(card) && !this.Players.Single(o => o == player).ReservedCards.Contains(card))
            {
                throw new CardUnavailableException(card);
            }

            if (!card.CanBuy(player.ChipsAndCards))
            {
                throw new InsuficentPlayerResourcesException(player, card);
            }
        }

        private void ReserveCardVerification(Player player, Card card)
        {
            this.VerifyThatGameIsActive();
            this.VerifyPlayerEligibleForMove(player);

            if (this.CurrentPlayer.ReservedCards.Count >= CoreConstants.Game.MaximumNumberOfReservedCards)
            {
                throw new CardReservationException(player, card);
            }

            if (!this.Deck.AvailableCards.Contains(card))
            {
                throw new CardUnavailableException(card);
            }
        }

        private void TakeChipVerification(Player player, Chips chips)
        {
            this.VerifyThatGameIsActive();
            this.VerifyPlayerEligibleForMove(player);

            var diff = chips - player.Chips;

            if (diff.Gold != 0)
            {
                throw new TakeGoldChipsNotAllowed(player, chips);
            }

            if (chips.Where(c => c.Key != Color.Gold).Sum(c => c.Value) > 10)
            {
                throw new ResourcesOverflowException(player, chips);
            }

            if (diff.Count(o => o.Value > 0) > CoreConstants.Game.MaximumNumberOfChipsTakenPerAction
                || diff.Where(o => o.Value > 0).Sum(o => o.Value) > CoreConstants.Game.MaximumNumberOfChipsTakenPerAction)
            {
                throw new InvalidTakeActionException(player, chips);
            }

            if (diff.Any(o => o.Value > CoreConstants.Game.MaximumNumberOfOneColorChipsTakerPerAction))
            {
                throw new InvalidTakeActionException(player, chips);
            }

            if (diff.Any(o => o.Value == CoreConstants.Game.MaximumNumberOfOneColorChipsTakerPerAction))
            {
                if (diff.Count(o => o.Value > 0) != 1)
                {
                    throw new InvalidTakeActionException(player, chips);
                }

                var twoChips = diff.Single(o => o.Value == CoreConstants.Game.MaximumNumberOfOneColorChipsTakerPerAction);
                if (this.bank[twoChips.Key] < CoreConstants.Game.MinimumNumberOfChipsToAllowTwoChipsTake)
                {
                    throw new TwoChipsOperationNotPermitted(player, chips);
                }
            }

            if (this.bank.Any(chip => this.bank[chip.Key] < diff[chip.Key]))
            {
                throw new BankResourcesExhaustedException(player, chips);
            }
        }

        private void VerifyPlayerEligibleForMove(Player player)
        {
            if (player != this.CurrentPlayer)
            {
                throw new InvalidPlayerException(player);
            }
        }

        private void VerifyThatGameIsActive()
        {
            if (!this.HasStarted)
            {
                throw new GameNotStartedException(this);
            }

            if (this.HasFinished)
            {
                throw new GameFinishedException(this);
            }
        }

        #endregion
    }
}