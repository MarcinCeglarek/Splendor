﻿namespace SplendorCore.Models
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using SplendorCore.Data;
    using SplendorCore.Helpers;
    using SplendorCore.Interfaces;
    using SplendorCore.Models.Exceptions.AbstractExceptions;
    using SplendorCore.Models.Exceptions.CardExceptions;
    using SplendorCore.Models.Exceptions.CardOperationExceptions;
    using SplendorCore.Models.Exceptions.ChipOperationExceptions;
    using SplendorCore.Models.Exceptions.GameExceptions;
    using SplendorCore.Models.Exceptions.PlayerExceptions;
    using SplendorCore.Models.History;

    #endregion

    public class Game : IGameActions
    {
        #region Properties

        private Deck Deck { get; }

        #endregion

        #region Fields

        private readonly List<HistoryEntry> history;

        private readonly List<IBroadcastMessages> subscribers;

        private Chips bank;

        private List<Player> players;

        #endregion

        #region Constructors and Destructors

        public Game()
            : this(CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath)
        {
        }

        public Game(string deckFilePath, string aristocratesFilePath)
        {
            this.Id = Guid.NewGuid();
            this.players = new List<Player>();
            this.Players = new ReadOnlyCollection<Player>(this.players);
            this.subscribers = new List<IBroadcastMessages>();
            this.history = new List<HistoryEntry>();
            this.History = new ReadOnlyCollection<HistoryEntry>(this.history);
            this.HasStarted = false;
            this.HasFinished = false;
            this.bank = new Chips();

            this.Deck = new Deck(this, deckFilePath, aristocratesFilePath);
        }

        #endregion

        #region Public Properties

        public ReadOnlyCollection<Aristocrate> AllAristocrates { get { return this.Deck.AllAristocrates; } }

        public ReadOnlyCollection<Card> AllCards { get { return this.Deck.AllCards; } }

        public ReadOnlyCollection<Aristocrate> AvailableAristocrates { get { return this.Deck.AvailableAristocrates; } }

        public ReadOnlyCollection<Card> AvailableCards { get { return this.Deck.AvailableCards; } }

        public Chips Bank { get { return new Chips(this.bank); } }

        public ReadOnlyCollection<ChatEntry> Chat { get; private set; }

        public Player CurrentPlayer { get { return this.players.FirstOrDefault(); } }

        public Player FirstPlayer { get; private set; }

        public bool HasFinished { get; private set; }

        public bool HasStarted { get; private set; }

        public ReadOnlyCollection<HistoryEntry> History { get; private set; }

        public Guid Id { get; private set; }

        public bool IsActive { get { return this.HasStarted && !this.HasFinished; } }

        public ReadOnlyCollection<Player> Players { get; private set; }

        public int TotalNumberOfNormalChips
        {
            get
            {
                switch (this.players.Count)
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

        public void AddPlayer(Player player)
        {
            if (this.HasStarted)
            {
                throw new GameAlreadyStartedException(this);
            }

            if (this.players.Count >= 4)
            {
                throw new InvalidNumberOfPlayersException(this);
            }

            this.players.Add(player);
            this.history.Add(new PlayerJoined(player));
            this.subscribers.ForEach(subscriber => subscriber.PlayerJoined(this, player));
        }

        public bool CanPurchaseCard(Player player, Card card)
        {
            try
            {
                this.PurchaseCardVerification(player, card);
                return true;
            }
            catch (SplendorException)
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
            catch (SplendorException)
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
            catch (SplendorException)
            {
                return false;
            }
        }

        public void SendMessage(Player player, string message)
        {
            if (this.players.Contains(player))
            {
                var entry = new ChatEntry(player, message);
                this.history.Add(entry);
                this.subscribers.ForEach(subscriber => subscriber.ChatMessage(this, entry));
            }
            else
            {
                throw new InvalidPlayerException(player);
            }
        }

        public void PurchaseCard(Player player, Card card)
        {
            this.PurchaseCardVerification(player, card);

            this.Deck.RemoveCard(card);
            this.CurrentPlayer.RemoveReservedCard(card);

            var cost = this.CurrentPlayer.GetCardCost(card);

            this.CurrentPlayer.Chips -= cost;
            this.bank += cost;
            this.CurrentPlayer.AddOwnedCard(card);
            this.history.Add(new CardPurchased(this.CurrentPlayer, card));
            this.subscribers.ForEach(subscriber => subscriber.CardPurchased(this, player, card));

            this.PlayerFinished();
        }

        public int RemainingCardsOfTier(int i)
        {
            return this.Deck.RemainingCardsOfTier(i);
        }

        public void RemovePlayer(Player player)
        {
            if (this.HasStarted)
            {
                throw new GameAlreadyStartedException(this);
            }

            if (this.players.Contains(player))
            {
                this.players.Remove(player);
                this.history.Add(new PlayerLeft(player));
                this.subscribers.ForEach(subscriber => subscriber.PlayerLeft(this, player));

                return;
            }

            throw new InvalidPlayerException(player);
        }

        public void ReserveCard(Player player, Card card)
        {
            this.ReserveCardVerification(player, card);

            this.Deck.RemoveCard(card);
            this.CurrentPlayer.AddReservedCard(card);

            if (this.bank.Gold > 0)
            {
                this.bank.Gold--;
                this.CurrentPlayer.Chips.Gold++;
            }

            this.history.Add(new CardReserved(this.CurrentPlayer, card));
            this.subscribers.ForEach(subscriber => subscriber.CardReserved(this, player, card));

            this.PlayerFinished();
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

            if (this.players.Count < 2 || this.players.Count > 4)
            {
                throw new InvalidNumberOfPlayersException(this);
            }

            this.HasStarted = true;
            this.Deck.Initialize();
            this.players = this.players.Shuffle().ToList();
            this.FirstPlayer = this.players.First();

            var chipCount = this.TotalNumberOfNormalChips;
            this.bank = new Chips { White = chipCount, Blue = chipCount, Green = chipCount, Red = chipCount, Black = chipCount, Gold = CoreConstants.Game.NumberOfGoldChips };
            this.history.Add(new GameStarted());
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
            this.history.Add(new ChipsTaken(this.CurrentPlayer, diff));
            this.subscribers.ForEach(subscriber => subscriber.ChipsTaken(this, player, chips));

            this.PlayerFinished();
        }

        public void Unsubscribe(IBroadcastMessages subscriber)
        {
            this.subscribers.Remove(subscriber);
        }

        #endregion

        #region Methods

        private void CheckAristocrates()
        {
            var eligableAristocrates = this.Deck.AvailableAristocrates.Where(aristocrate => this.CurrentPlayer.Cards >= aristocrate.RequiredCards).ToList();

            if (!eligableAristocrates.Any())
            {
                return;
            }

            var firstEligableAristocrate = eligableAristocrates.First();

            this.Deck.RemoveAristocrate(firstEligableAristocrate);
            this.CurrentPlayer.AddOwnedAristocrate(firstEligableAristocrate);
        }

        private void CheckEndGameCondition()
        {
            if (this.players.Any(p => p.VictoryPoints >= 15) && this.FirstPlayer == this.CurrentPlayer)
            {
                this.EndGame();
            }
        }

        private void EndGame()
        {
            this.HasFinished = true;
            this.history.Add(new GameEnded(this.players.Last(player => player.VictoryPoints == this.players.Max(p => p.VictoryPoints))));
            this.subscribers.ForEach(subscriber => subscriber.GameEnded(this));
        }

        private void PlayerFinished()
        {
            this.CheckAristocrates();
            var currentUser = this.CurrentPlayer;
            this.players.RemoveAt(0);
            this.players.Insert(this.players.Count, currentUser);

            this.CheckEndGameCondition();
        }

        private void PurchaseCardVerification(Player player, Card card)
        {
            this.VerifyThatGameIsActive();
            this.VerifyPlayerEligibleForMove(player);

            if (!this.Deck.AvailableCards.Contains(card) && !this.players.Single(o => o == player).ReservedCards.Contains(card))
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