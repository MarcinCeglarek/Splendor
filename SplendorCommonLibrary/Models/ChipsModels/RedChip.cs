namespace SplendorCommonLibrary.Models.ChipsModels
{
    public class RedChip : Chip
    {
        public RedChip()
            : this(0)
        {    
        }

        public RedChip(int value)
            : base(Color.Red, value)
        {
        }
    }
}