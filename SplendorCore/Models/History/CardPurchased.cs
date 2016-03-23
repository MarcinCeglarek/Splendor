namespace SplendorCore.Models.History
{
    public class CardPurchased : HistoryEntry
    {
        #region Constructors and Destructors

        public CardPurchased(Player player, Card card)
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