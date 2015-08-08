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

        public Chips ChipsAndCards
        {
            get
            {
                var retVal = new Chips
                                 {
                                     White = this.Chips.White + this.OwnedCards.Count(o => o.Color == Color.White), 
                                     Blue = this.Chips.Blue + this.OwnedCards.Count(o => o.Color == Color.Blue), 
                                     Green = this.Chips.Green + this.OwnedCards.Count(o => o.Color == Color.Green), 
                                     Red = this.Chips.Red + this.OwnedCards.Count(o => o.Color == Color.Red), 
                                     Black = this.Chips.Black + this.OwnedCards.Count(o => o.Color == Color.Black), 
                                     Gold = this.Chips.Gold
                                 };
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