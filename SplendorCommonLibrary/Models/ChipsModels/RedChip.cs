namespace SplendorCommonLibrary.Models.ChipsModels
{
    public class RedChip : Chip
    {
        #region Constructors and Destructors

        public RedChip()
            : this(0)
        {
        }

        public RedChip(int value)
            : base(Color.Red, value)
        {
        }

        #endregion
    }
}