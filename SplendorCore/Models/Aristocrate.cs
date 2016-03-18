namespace SplendorCore.Models
{
    public class Aristocrate
    {
        #region Fields

        private readonly Chips requiredCards;

        private readonly int victoryPoints;

        #endregion

        #region Constructors and Destructors

        public Aristocrate(Chips requiredCards, int victoryPoints)
        {
            this.requiredCards = requiredCards;
            this.victoryPoints = victoryPoints;
        }

        #endregion

        #region Public Properties

        public Chips RequiredCards { get { return new Chips(this.requiredCards); } }

        public int VictoryPoints { get { return this.victoryPoints; } }

        #endregion
    }
}