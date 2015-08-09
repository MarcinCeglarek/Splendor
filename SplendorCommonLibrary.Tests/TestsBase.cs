namespace SplendorCommonLibrary.Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCommonLibrary.Data;
    using SplendorCommonLibrary.Models;

    public abstract class TestsBase
    {
        protected Game InitializeGame(int numberOfPlayers = 2)
        {
            var game = new Game();
            game.Deck = new Deck(game, Constants.DeckFilePath, Constants.AristocratesFilePath);

            for (var i = 0; i < numberOfPlayers; i++)
            {
                game.Players.Add(new Player());
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

            Assert.AreEqual(Constants.Game.NumberOfGoldChips, game.Players.Sum(p => p.Chips[Color.Gold]) + game.Bank[Color.Gold]);
        }

        protected Card GetInvalidCard(Game game)
        {
            return game.Deck.AllCards.First(card => !game.Deck.AvailableCards.Contains(card));
        }
    }
}
