namespace SplendorCommonLibrary.Models
{
    #region

    using System;

    #endregion

    public abstract class HistoryEntry
    {
        #region Constructors and Destructors

        protected HistoryEntry(Player player)
        {
            this.Player = player;
            this.DateTime = DateTime.Now;
        }

        #endregion

        #region Public Properties

        public DateTime DateTime { get; private set; }

        public Player Player { get; set; }

        #endregion
    }

    public class ReserveCardsEntry : HistoryEntry
    {
        #region Constructors and Destructors

        public ReserveCardsEntry(Player player, Card card)
            : base(player)
        {
            this.Card = card;
        }

        #endregion

        #region Public Properties

        public Card Card { get; private set; }

        #endregion
    }

    public class PurchasedCardsEntry : HistoryEntry
    {
        #region Constructors and Destructors

        public PurchasedCardsEntry(Player player, Card card)
            : base(player)
        {
            this.Card = card;
        }

        #endregion

        #region Public Properties

        public Card Card { get; private set; }

        #endregion
    }

    public class TakeChipsEntry : HistoryEntry
    {
        #region Constructors and Destructors

        public TakeChipsEntry(Player player)
            : base(player)
        {
            this.Chips = new Chips() + player.Chips;
        }

        #endregion

        #region Public Properties

        public Chips Chips { get; private set; }

        #endregion
    }
}