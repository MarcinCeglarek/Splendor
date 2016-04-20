namespace SplendorCore.Models
{
    #region

    using System;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    using SplendorCore.Helpers;

    #endregion

    public class Card
    {
        #region Fields

        private readonly Color color;

        private readonly Chips cost;

        private readonly int tier;

        private readonly int victoryPoints;

        #endregion

        #region Constructors and Destructors

        public Card(Chips cost, Color color = Color.Gold, int tier = 0, int victoryPoints = 0)
        {
            this.Id = Guid.NewGuid();
            this.color = color;
            this.tier = tier;
            this.cost = cost;
            this.victoryPoints = victoryPoints;
        }

        #endregion

        #region Public Properties

        [JsonConverter(typeof(StringEnumConverter))]
        public Color Color { get { return this.color; } }

        public Chips Cost { get { return new Chips(this.cost); } }

        public Guid Id { get; private set; }

        public int Tier { get { return this.tier; } }

        public int VictoryPoints { get { return this.victoryPoints; } }

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

        public override string ToString()
        {
            return string.Format("{0}: {1} ({2} pts.)", this.tier, this.Color, this.VictoryPoints);
        }

        #endregion
    }
}