namespace SplendorCommonLibrary.Models.ChipsModels
{
    public class BlackChip : Chip
    {
        public BlackChip()
            : this(0)
        {    
        }

        public BlackChip(int value)
            : base(Color.Black, value)
        {
        }
    }
}