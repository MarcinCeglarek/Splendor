namespace SplendorCommonLibrary.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SplendorCommonLibrary.Data;
    using SplendorCommonLibrary.Helpers;
    using SplendorCommonLibrary.Models.ChipsModels;
    using SplendorCommonLibrary.Models.Exceptions;

    #endregion

    public class Game
    {
        #region Fields

        private Player firstPlayer;

        private bool hasFinished = false;

        private bool isStarted = false;

        #endregion

        #region Constructors and Destructors

        public Game()
        {
            this.Id = Guid.NewGuid();
            this.Players = new List<Player>();
        }

        #endregion

        #region Public Properties

        public Chips Bank { get; set; }

        public Player CurrentPlayer
        {
            get
            {
                return this.Players.FirstOrDefault();
            }
        }

        public Deck Deck { get; set; }

        public Guid Id { get; private set; }

        public IList<Player> Players { get; set; }

        #endregion

        #region Public Methods and Operators

        public void PurchaseCard(Player player, Card card)
        {
            this.IsGameActive();
            this.IsPlayerEligibleForMove(player);

            this.PlayerFinished();
        }

        public void ReserveCard(Player player, Card card)
        {
            this.IsGameActive();
            this.IsPlayerEligibleForMove(player);

            this.PlayerFinished();
        }

        public void Start()
        {
            if (this.isStarted)
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

            this.isStarted = true;
            this.Deck.Initialize();
            this.Players = this.Players.Shuffle();
            this.firstPlayer = this.Players.First();

            var chipCount = 7;
            switch (this.Players.Count)
            {
                case 2:
                    chipCount = 4;
                    break;
                case 3:
                    chipCount = 5;
                    break;
                case 4:
                    break;
            }

            this.Bank = new Chips() { White = chipCount, Blue = chipCount, Green = chipCount, Red = chipCount, Black = chipCount, Gold = 5 };
        }

        public void TakeChips(Player player)
        {
            this.IsGameActive();
            this.IsPlayerEligibleForMove(player);

            this.PlayerFinished();
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
            this.hasFinished = true;
        }

        private void IsGameActive()
        {
            if (!this.isStarted)
            {
                throw new SplendorGameException(Messages.Error_GameHasNotStartedYet);
            }

            if (this.hasFinished)
            {
                throw new SplendorGameException(Messages.Error_GameHasFinished);
            }
        }

        private void IsPlayerEligibleForMove(Player player)
        {
            if (player != this.CurrentPlayer)
            {
                throw new SplendorGameException(Messages.Error_PlayerNotEligibleForMove);
            }
        }

        private void PlayerFinished()
        {
            var currentUser = this.CurrentPlayer;
            this.Players.RemoveAt(0);
            this.Players.Insert(this.Players.Count, currentUser);

            this.CheckEndGameCondition();
        }

        #endregion
    }
}