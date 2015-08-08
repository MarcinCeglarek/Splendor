namespace SplendorCommonLibrary.Models
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

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

        public Chips Chips { get; set; }

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

        public string Name { get; set; }

        public List<Card> OwnedCards { get; set; }

        public IList<Card> ReservedCards { get; set; }

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

        #endregion
    }
}