namespace MvcApplication1.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class User
    {
        #region Fields

        private readonly ChipState chipState = new ChipState();

        private readonly List<Card> ownedCards = new List<Card>();

        #endregion

        #region Public Properties

        public ChipState ChipState
        {
            get
            {
                var retVal = new ChipState
                                 {
                                     White = this.chipState.White + this.ownedCards.Count(o => o.Type == CardType.White), 
                                     Blue = this.chipState.Blue + this.ownedCards.Count(o => o.Type == CardType.Blue), 
                                     Green = this.chipState.Green + this.ownedCards.Count(o => o.Type == CardType.Green), 
                                     Red = this.chipState.Red + this.ownedCards.Count(o => o.Type == CardType.Red), 
                                     Black = this.chipState.Black + this.ownedCards.Count(o => o.Type == CardType.Black), 
                                     Gold = this.chipState.Gold
                                 };
                return retVal;
            }
        }

        public int VictoryPoints
        {
            get
            {
                return this.ownedCards.Sum(card => card.VictoryPoints);
            }
        }

        public string Name { get; set; }

        #endregion
    }
}