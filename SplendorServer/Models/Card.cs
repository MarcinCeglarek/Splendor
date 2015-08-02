namespace SplendorServer.Models
{
    using System;
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [DataContract]
    public class Card
    {
        public Guid Id { get; set; }

        [DataMember]
        public int Tier { get; set; }

        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public CardType Color { get; set; }

        [DataMember]
        public Chips Cost { get; set; }

        [DataMember]
        public int VictoryPoints { get; set; }

        public bool CanBuy(Chips chips)
        {
            var result = chips - this.Cost;
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

            return missingChips <= chips.Gold;
        }
    }
}