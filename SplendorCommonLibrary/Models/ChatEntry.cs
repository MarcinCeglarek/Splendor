namespace SplendorCore.Models
{
    #region

    using System;

    #endregion

    public class ChatEntry
    {
        #region Constructors and Destructors

        public ChatEntry(Player player, string message)
        {
            this.DateTime = DateTime.Now;
            this.Player = player;
            this.Message = message;
        }

        #endregion

        #region Public Properties

        public DateTime DateTime { get; private set; }

        public string Message { get; private set; }

        public Player Player { get; private set; }

        #endregion
    }
}