namespace SplendorCore.Models.History
{
    public class GameEnded : HistoryEntry
    {
        #region Constructors and Destructors

        public GameEnded(Player player)
            : base(player)
        {
        }

        #endregion
    }
}