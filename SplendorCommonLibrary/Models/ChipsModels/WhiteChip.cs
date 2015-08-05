namespace SplendorCommonLibrary.Models.ChipsModels
{
    public class WhiteChip : Chip
    {
        public WhiteChip()
            : this(0)
        {
        }

        public WhiteChip(int value)
            : base(Color.White, value)
        {
        }
    }
}