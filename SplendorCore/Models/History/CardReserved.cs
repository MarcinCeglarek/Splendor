namespace SplendorCore.Models.History
{
    public class CardReserved : HistoryEntry
    {
        #region Constructors and Destructors

        public CardReserved(Player player, Card card)
            : base(player)
        {
            this.Card = card;
        }

        #endregion

        #region Public Properties

        public Card Card { get; private set; }

        #endregion
    }
}