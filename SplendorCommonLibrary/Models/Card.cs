namespace SplendorCommonLibrary.Models
{
    #region

    using System;
    using System.Runtime.Serialization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using SplendorCommonLibrary.Helpers;

    #endregion

    [DataContract]
    public class Card
    {
        #region Constructors and Destructors

        public Card()
        {
            this.Id = Guid.NewGuid();
        }

        #endregion

        #region Public Properties

        [DataMember]
        [JsonConverter(typeof(StringEnumConverter))]
        public Color Color { get; set; }

        [DataMember]
        [JsonConverter(typeof(CardCostConverter))]
        public Chips Cost { get; set; }

        public Guid Id { get; set; }

        [DataMember]
        public int Tier { get; set; }

        [DataMember]
        public int VictoryPoints { get; set; }

        #endregion

        #region Public Methods and Operators

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

        #endregion
    }
}