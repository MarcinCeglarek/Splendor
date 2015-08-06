namespace SplendorCommonLibrary.Models.ChipsModels
{
    public class WhiteChip : Chip
    {
        #region Constructors and Destructors

        public WhiteChip()
            : this(0)
        {
        }

        public WhiteChip(int value)
            : base(Color.White, value)
        {
        }

        #endregion
    }
}