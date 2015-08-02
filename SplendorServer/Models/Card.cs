namespace MvcApplication1.Models
{
    public class Card
    {
        public CardTier Tier { get; set; }

        public CardType Type { get; set; }

        public ChipState Cost { get; set; }

        public int VictoryPoints { get; set; }

        public bool CanBuy(ChipState chipState)
        {
            var result = chipState - this.Cost;
            var missingChips = 0;
            if (result.Black < 0)
            {
                missingChips -= result.Black;
            }

            if (result.Blue < 0)
            {
                missingChips -= result.Blue;
            }

            if (result.Green < 0)
            {
                missingChips -= result.Green;
            }

            if (result.Red < 0)
            {
                missingChips -= result.Red;
            }

            if (result.White < 0)
            {
                missingChips -= result.White;
            }

            return missingChips <= chipState.Gold;
        }
    }
}