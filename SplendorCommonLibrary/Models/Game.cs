namespace SplendorCommonLibrary.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using SplendorCommonLibrary.Data;
    using SplendorCommonLibrary.Helpers;
    using SplendorCommonLibrary.Interfaces;
    using SplendorCommonLibrary.Models.Exceptions;

    #endregion

    [DataContract]
    public class Game : IGameActions
    {
        #region Fields

        private readonly List<IBroadcastMessages> subscribers;

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
        public Chips Bank { get; set; }

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
                        return Constants.Game.NumberOfNormalChips2Players;
                    case 3:
                        return Constants.Game.NumberOfNormalChips3Players;
                    case 4:
                        return Constants.Game.NumberOfNormalChips4Players;
                }

                throw new SplendorGameException("Unsupported number of players");
            }
        }

        #endregion

        #region Public Methods and Operators

        public bool CanPurchaseCard(Player player, Card card)
        {
            this.VerifyThatGameIsActive();
            this.VerifyPlayerEligibleForMove(player);

            if (!this.Deck.AvailableCards.Contains(card) && !this.CurrentPlayer.ReservedCards.Contains(card))
            {
                throw new SplendorGamePurchaseCardException(Messages.Error_ThisCardIsUnavailable);
            }

            // Two strategies - which one is better
            // 1
            if (!card.CanBuy(player.ChipsAndCards))
            {
                throw new SplendorGamePurchaseCardException(Messages.Error_PlayerCantAffordCard);
            }

            // 2
            var cost = this.CurrentPlayer.GetCardCost(card);

            return true;
        }

        public bool CanReserveCard(Player player, Card card)
        {
            this.VerifyThatGameIsActive();
            this.VerifyPlayerEligibleForMove(player);

            if (this.CurrentPlayer.ReservedCards.Count >= Constants.Game.MaximumNumberOfReservedCards)
            {
                throw new SplendorGameReserveActionException(Messages.Error_MaximumNumberOfReservedCardsReached);
            }

            if (!this.Deck.AvailableCards.Contains(card))
            {
                throw new SplendorGameReserveActionException(Messages.Error_ThisCardIsUnavailable);
            }

            return true;
        }

        public bool CanTakeChips(Player player, Chips chips)
        {
            this.VerifyThatGameIsActive();
            this.VerifyPlayerEligibleForMove(player);

            var diff = chips - player.Chips;

            // simplyfying this would be greatly appreciated
            if (diff.Gold != 0)
            {
                throw new SplendorGameTakeActionException(Messages.Errror_CantTakeGoldenChipsInThisMoveType);
            }

            if (chips.Where(c => c.Key != Color.Gold).Sum(c => c.Value) > 10)
            {
                throw new SplendorGameTakeActionException(Messages.Error_PlayerCantHoldOver10Chips);
            }

            if (diff.Count(o => o.Value > 0) > Constants.Game.MaximumNumberOfChipsTakenPerAction
                || diff.Where(o => o.Value > 0).Sum(o => o.Value) > Constants.Game.MaximumNumberOfChipsTakenPerAction)
            {
                throw new SplendorGameTakeActionException("You cannot take more than 3 chips at a time");
            }

            if (diff.Any(o => o.Value > Constants.Game.MaximumNumberOfOneColorChipsTakerPerAction))
            {
                throw new SplendorGameTakeActionException("You cannot take 3 chips of the same color");
            }

            if (diff.Any(o => o.Value == Constants.Game.MaximumNumberOfOneColorChipsTakerPerAction))
            {
                if (diff.Count(o => o.Value > 0) != 1)
                {
                    throw new SplendorGameTakeActionException("You cannot take any additional chips if you took 2 of the same color");
                }

                var twoChips = diff.Single(o => o.Value == Constants.Game.MaximumNumberOfOneColorChipsTakerPerAction);
                if (this.Bank[twoChips.Key] < Constants.Game.MinimumNumberOfChipsToAllowTwoChipsTake)
                {
                    throw new SplendorGameTakeActionException("You cannot take 2 chips if less then 4 are available");
                }
            }

            if (this.Bank.Any(chip => this.Bank[chip.Key] < -chip.Value))
            {
                throw new SplendorGameTakeActionException("Bank doesn't have enough chips");
            }

            return true;
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
                throw new SplendorGameException("Player not found");
            }
        }

        public void PurchaseCard(Player player, Card card)
        {
            this.CanPurchaseCard(player, card);

            this.Deck.AllCards.Remove(card);
            var cost = this.CurrentPlayer.GetCardCost(card);

            this.CurrentPlayer.Chips -= cost;
            this.Bank += cost;
            this.CurrentPlayer.OwnedCards.Add(card);

            this.PlayerFinished();
            this.subscribers.ForEach(subscriber => subscriber.CardPurchased(this));
        }

        public void ReserveCard(Player player, Card card)
        {
            this.CanReserveCard(player, card);

            this.Deck.AllCards.Remove(card);
            this.CurrentPlayer.ReservedCards.Add(card);

            if (this.Bank.Gold > 0)
            {
                this.Bank.Gold--;
                this.CurrentPlayer.Chips.Gold++;
            }

            this.PlayerFinished();
            this.subscribers.ForEach(subscriber => subscriber.CardReserved(this));
        }

        public void Start()
        {
            if (this.HasFinished)
            {
                throw new SplendorGameException(Messages.Error_GameHasFinished);
            }

            if (this.HasStarted)
            {
                throw new SplendorGameException(Messages.Error_GameIsAlreadyStarted);
            }

            if (this.Deck == null)
            {
                throw new SplendorGameException(Messages.Error_DeckIsNotPresent);
            }

            if (this.Players.Count < 2)
            {
                throw new SplendorGameException(Messages.Error_ThereHaveToBeTwoPlayers);
            }

            if (this.Players.Count > 4)
            {
                throw new SplendorGameException(Messages.Error_ThereHaveToBeFourPlayers);
            }

            this.HasStarted = true;
            this.Deck.Initialize();
            this.Players = this.Players.Shuffle().ToList();
            this.firstPlayer = this.Players.First();

            var chipCount = this.TotalNumberOfNormalChips;
            this.Bank = new Chips() { White = chipCount, Blue = chipCount, Green = chipCount, Red = chipCount, Black = chipCount, Gold = Constants.Game.NumberOfGoldChips };

            this.subscribers.ForEach(subscriber => subscriber.GameStarted(this));
        }

        public void Subscribe(IBroadcastMessages subscriber)
        {
            this.subscribers.Add(subscriber);
        }

        public void TakeChips(Player player, Chips chips)
        {
            this.CanTakeChips(player, chips);

            var diff = chips - player.Chips;
            this.Bank -= diff;
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
            var currentUser = this.CurrentPlayer;
            this.Players.RemoveAt(0);
            this.Players.Insert(this.Players.Count, currentUser);

            this.CheckEndGameCondition();
        }

        private void VerifyPlayerEligibleForMove(Player player)
        {
            if (player != this.CurrentPlayer)
            {
                throw new SplendorGameException(Messages.Error_PlayerNotEligibleForMove);
            }
        }

        private void VerifyThatGameIsActive()
        {
            if (!this.HasStarted)
            {
                throw new SplendorGameException(Messages.Error_GameHasNotStartedYet);
            }

            if (this.HasFinished)
            {
                throw new SplendorGameException(Messages.Error_GameHasFinished);
            }
        }

        #endregion
    }
}