﻿namespace SplendorCommonLibrary.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Player
    {
        #region Fields

        private readonly Chips chips = new Chips();

        private readonly List<Card> ownedCards = new List<Card>();

        private readonly List<Card> reservedCards = new List<Card>();

        #endregion

        #region Constructors and Destructors

        public Player()
        {
            this.Id = Guid.NewGuid();
        }

        #endregion

        #region Public Properties

        public Chips ChipsAndCards
        {
            get
            {
                var retVal = new Chips
                                 {
                                     White = this.chips.White + this.ownedCards.Count(o => o.Color == Color.White), 
                                     Blue = this.chips.Blue + this.ownedCards.Count(o => o.Color == Color.Blue), 
                                     Green = this.chips.Green + this.ownedCards.Count(o => o.Color == Color.Green), 
                                     Red = this.chips.Red + this.ownedCards.Count(o => o.Color == Color.Red), 
                                     Black = this.chips.Black + this.ownedCards.Count(o => o.Color == Color.Black), 
                                     Gold = this.chips.Gold
                                 };
                return retVal;
            }
        }

        public Game Game { get; set; }

        public Guid Id { get; private set; }

        public string Name { get; set; }

        public IList<Card> ReservedCards
        {
            get
            {
                return this.reservedCards;
            }
        }

        public int VictoryPoints
        {
            get
            {
                return this.ownedCards.Sum(card => card.VictoryPoints);
            }
        }

        #endregion

        #region Public Methods and Operators

        public bool CanReserveCard(Guid cardId)
        {
            var cardToReserve = this.Game.Deck.AvailableCards.SelectMany(o => o.Value).FirstOrDefault(card => card.Id == cardId);

            if (cardToReserve == null)
            {
                return false;
            }

            return this.reservedCards.Count < 3;
        }

        public bool Equals(Player obj)
        {
            return this.Id == obj.Id;
        }

        public bool ReserveCard(Guid cardId)
        {
            if (this.CanReserveCard(cardId))
            {
                var cardToReserve = this.Game.Deck.AvailableCards.SelectMany(o => o.Value).FirstOrDefault(card => card.Id == cardId);

                this.reservedCards.Add(cardToReserve);
                this.chips.Gold++;
            }

            return true;
        }

        #endregion
    }
}