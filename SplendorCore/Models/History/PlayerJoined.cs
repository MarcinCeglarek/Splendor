namespace SplendorCore.Models.History
{
    public class PlayerJoined : HistoryEntry
    {
        #region Constructors and Destructors

        public PlayerJoined(Player player)
            : base(player)
        {
        }

        #endregion
    }
}