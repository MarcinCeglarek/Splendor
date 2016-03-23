namespace SplendorCore.Models.History
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
}