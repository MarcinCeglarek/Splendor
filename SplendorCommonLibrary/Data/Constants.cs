namespace SplendorCommonLibrary.Data
{
    public static class Constants
    {
        #region Constants

        public const string AristocratesFilePath = "./Data/Aristocrates.js";

        public const string ChipClassPath = "SplendorCommonLibrary.Models.";

        public const string DeckFilePath = "./Data/Deck.js";

        #endregion

        public static class Deck
        {
            #region Constants

            public const int NumberOfVisibleCards = 4;

            #endregion
        }

        public static class Game
        {
            #region Constants

            public const int MaximumNumberOfChipsPerPlayer = 10;

            public const int MaximumNumberOfChipsTakenPerAction = 3;

            public const int MaximumNumberOfOneColorChipsTakerPerAction = 2;

            public const int MaximumNumberOfReservedCards = 3;

            public const int MinimumNumberOfChipsToAllowTwoChipsTake = 4;

            public const int NumberOfGoldChips = 5;

            public const int NumberOfNormalChips2Players = 4;

            public const int NumberOfNormalChips3Players = 5;

            public const int NumberOfNormalChips4Players = 7;

            public const int VictoryPointsRequiredToWin = 15;

            #endregion
        }
    }
}