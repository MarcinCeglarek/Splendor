namespace SplendorCommonLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SplendorCommonLibrary.Models.ChipsModels;

    public class User
    {
        #region Fields


        private readonly Chips chips = new Chips();

        private readonly List<Card> ownedCards = new List<Card>();

        private readonly List<Card> reservedCards = new List<Card>(); 

        #endregion

        #region Public Properties

        public Game Game { get; set; }

        public User()
        {
        }

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

        public bool CanReserveCard(Guid cardId)
        {
            var cardToReserve = this.Game.Deck.AvailableCards().SelectMany(o => o.Value).FirstOrDefault(card => card.Id == cardId);

            if (cardToReserve == null)
            {
                return false;
            }

            return this.reservedCards.Count < 3;
        }

        public bool ReserveCard(Guid cardId)
        {
            if (this.CanReserveCard(cardId))
            {
                var cardToReserve = this.Game.Deck.AvailableCards().SelectMany(o => o.Value).FirstOrDefault(card => card.Id == cardId);

                this.reservedCards.Add(cardToReserve);
                this.chips.Gold++;
            }

            return true;
        }

        public string Name { get; set; }

        #endregion
    }
}