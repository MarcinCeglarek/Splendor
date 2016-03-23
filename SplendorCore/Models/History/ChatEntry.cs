namespace SplendorCore.Models.History
{
    public class ChatEntry : HistoryEntry
    {
        #region Constructors and Destructors

        public ChatEntry(Player player, string message)
            : base(player)
        {
            this.Message = message;
        }

        #endregion

        #region Public Properties

        public string Message { get; set; }

        #endregion
    }
}