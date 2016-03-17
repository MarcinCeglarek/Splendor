namespace SplendorCore.Tests.Library
{
    #region

    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCore.Data;
    using SplendorCore.Models;

    #endregion

    public abstract class TestsBase
    {
        #region Methods

        protected Card GetInvalidCard(Game game)
        {
            return game.AllCards.First(card => !game.AvailableCards.Contains(card));
        }

        protected Game InitializeGame(int numberOfPlayers = 2)
        {
            var game = new Game(CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);

            for (var i = 0; i < numberOfPlayers; i++)
            {
                game.AddPlayer(new Player());
            }

            game.Start();

            return game;
        }

        protected void VerityChipsCountIntegrity(Game game)
        {
            foreach (var color in Enum.GetValues(typeof(Color)).Cast<Color>().Where(o => o != Color.Gold))
            {
                Assert.AreEqual(game.TotalNumberOfNormalChips, game.Players.Sum(p => p.Chips[color]) + game.Bank[color]);
            }

            Assert.AreEqual(CoreConstants.Game.NumberOfGoldChips, game.Players.Sum(p => p.Chips[Color.Gold]) + game.Bank[Color.Gold]);
        }

        #endregion
    }
}