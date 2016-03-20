namespace SplendorCore.Models
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

        public string GetTimestamp { get { return this.DateTime.ToString("HH:mm:ss"); } }

        public Player Player { get; set; }

        #endregion
    }

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

    public class ChipsTaken : HistoryEntry
    {
        #region Constructors and Destructors

        public ChipsTaken(Player player, Chips chips)
            : base(player)
        {
            this.Chips = new Chips(chips);
        }

        #endregion

        #region Public Properties

        public Chips Chips { get; private set; }

        #endregion
    }

    public class PlayerJoined : HistoryEntry
    {
        #region Constructors and Destructors

        public PlayerJoined(Player player)
            : base(player)
        {
        }

        #endregion
    }

    public class GameEnded : HistoryEntry
    {
        #region Constructors and Destructors

        public GameEnded(Player player)
            : base(player)
        {
        }

        #endregion
    }

    public class PlayerLeft : HistoryEntry
    {
        #region Constructors and Destructors

        public PlayerLeft(Player player)
            : base(player)
        {
        }

        #endregion
    }

    public class GameStarted : HistoryEntry
    {
        #region Constructors and Destructors

        public GameStarted()
            : base(null)
        {
        }

        #endregion
    }
}