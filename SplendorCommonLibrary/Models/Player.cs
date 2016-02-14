namespace SplendorCore.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using SplendorCore.Models.Exceptions;

    #endregion

    [DataContract]
    public class Player
    {
        #region Constructors and Destructors

        public Player()
        {
            this.Id = Guid.NewGuid();
            this.Chips = new Chips();
            this.OwnedCards = new List<Card>();
            this.ReservedCards = new List<Card>();
        }

        #endregion

        #region Public Properties

        public Chips Cards
        {
            get
            {
                return new Chips(
                    this.OwnedCards.Count(o => o.Color == Color.White), 
                    this.OwnedCards.Count(o => o.Color == Color.Blue), 
                    this.OwnedCards.Count(o => o.Color == Color.Green), 
                    this.OwnedCards.Count(o => o.Color == Color.Red), 
                    this.OwnedCards.Count(o => o.Color == Color.Black), 
                    0);
            }
        }

        public Chips Chips { get; set; }

        public Chips ChipsAndCards
        {
            get
            {
                var retVal = this.Chips + this.Cards;
                return retVal;
            }
        }

        public Game Game { get; set; }

        public Guid Id { get; private set; }

        [DataMember]
        public string Name { get; set; }

        public IList<Card> OwnedCards { get; set; }

        public IList<Card> ReservedCards { get; set; }

        [DataMember]
        public int VictoryPoints
        {
            get
            {
                return this.OwnedCards.Sum(card => card.VictoryPoints);
            }
        }

        #endregion

        #region Public Methods and Operators

        public bool Equals(Player obj)
        {
            return this.Id == obj.Id;
        }

        public Chips GetCardCost(Card card)
        {
            var result = new Chips();
            var costWithoutMines = card.Cost - this.Cards;

            foreach (var cardChipCost in costWithoutMines.Where(o => o.Value > 0))
            {
                if (cardChipCost.Value > this.Chips[cardChipCost.Key])
                {
                    var requiredGold = this.Chips[cardChipCost.Key] - cardChipCost.Value;
                    if (requiredGold > this.Chips[Color.Gold])
                    {
                        throw new SplendorPlayerChipsException("Player has insufficient chips to purchace this card");
                    }

                    result[cardChipCost.Key] = this.Chips[cardChipCost.Key];
                    result[Color.Gold] += requiredGold;
                }
                else
                {
                    result[cardChipCost.Key] = cardChipCost.Value;
                }
            }

            return result;
        }

        #endregion
    }
}