namespace MvcApplication1.Models
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class Card
    {
        public Guid Id { get; set; }

        [DataMember]
        public int Tier { get; set; }

        [DataMember]
        public CardType Type { get; set; }

        [DataMember]
        public ChipState Cost { get; set; }

        [DataMember]
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