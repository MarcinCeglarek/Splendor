namespace SplendorCommonLibrary.Models.ChipsModels
{
    public class GoldChip : Chip
    {
        public GoldChip()
            : this(0)
        {    
        }

        public GoldChip(int value)
            : base(Color.Gold, value)
        {
        }
    }
}