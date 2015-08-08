namespace SplendorCommonLibrary.Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCommonLibrary.Data;
    using SplendorCommonLibrary.Models;
    using SplendorCommonLibrary.Models.Exceptions;

    [TestClass]
    public class DeckTests : TestsBase
    {
        [TestMethod]
        [ExpectedException(typeof(SplendorFileNotFoundException))]
        public void Deck_Exception()
        {
            var deck = new Deck(null, string.Empty, string.Empty);
        }

        [TestMethod]
        public void Deck_CardsNumber()
        {
            var game = this.InitializeGame(2);
            var deck = game.Deck;

            Assert.AreEqual(90, deck.AllCards.Count);
            Assert.AreEqual(3 * Constants.Deck.NumberOfVisibleCards, deck.AvailableCards.Count);

            for (var i = 1; i <= 3; i++)
            {
                Assert.AreEqual(Constants.Deck.NumberOfVisibleCards, deck.AvailableCards.Count(o => o.Tier == i));
            }

            Assert.AreEqual(10, deck.AllAristocrates.Count);

            Assert.AreEqual(40, deck.AllCards.Count(o => o.Tier == 1));
            Assert.AreEqual(30, deck.AllCards.Count(o => o.Tier == 2));
            Assert.AreEqual(20, deck.AllCards.Count(o => o.Tier == 3));

            Assert.AreEqual(90 / 5, deck.AllCards.Count(o => o.Color == Color.Black));
            Assert.AreEqual(90 / 5, deck.AllCards.Count(o => o.Color == Color.Blue));
            Assert.AreEqual(90 / 5, deck.AllCards.Count(o => o.Color == Color.Green));
            Assert.AreEqual(90 / 5, deck.AllCards.Count(o => o.Color == Color.Red));
            Assert.AreEqual(90 / 5, deck.AllCards.Count(o => o.Color == Color.White));

            Assert.AreEqual(0, deck.AllCards.Count(o => o.Color == Color.Gold));
        }

        [TestMethod]
        public void Deck_CarsdPoints()
        {
            var game = this.InitializeGame(2);
            var deck = game.Deck;

            foreach (var color in Enum.GetValues(typeof(Color)).Cast<Color>().Where(c => c != Color.Gold))
            {
                Assert.AreEqual(1, deck.AllCards.Where(o => o.Tier == 1 && o.Color == color).Sum(c => c.VictoryPoints));
                Assert.AreEqual(11, deck.AllCards.Where(o => o.Tier == 2 && o.Color == color).Sum(c => c.VictoryPoints));
                Assert.AreEqual(16, deck.AllCards.Where(o => o.Tier == 3 && o.Color == color).Sum(c => c.VictoryPoints));
            }

            Assert.AreEqual(0, deck.AllCards.Where(o => o.Tier == 1 && o.Color == Color.Gold).Sum(c => c.VictoryPoints));
            Assert.AreEqual(0, deck.AllCards.Where(o => o.Tier == 2 && o.Color == Color.Gold).Sum(c => c.VictoryPoints));
            Assert.AreEqual(0, deck.AllCards.Where(o => o.Tier == 3 && o.Color == Color.Gold).Sum(c => c.VictoryPoints));
        }

        [TestMethod]
        public void Deck_Aristocrates_Number()
        {
            var game = this.InitializeGame(2);

            Assert.AreEqual(10, game.Deck.AllAristocrates.Count);
            var sumOfAllCards = new Chips();

            foreach (var aristocrate in game.Deck.AllAristocrates)
            {
                Assert.IsNotNull(aristocrate.RequiredCards);
                sumOfAllCards += aristocrate.RequiredCards;
            }

            foreach (var sumForColor in sumOfAllCards.Where(o => o.Key != Color.Gold))
            {
                 Assert.AreEqual(17, sumForColor.Value);
            }

            Assert.AreEqual(0, sumOfAllCards[Color.Gold]);
        }

        [TestMethod]
        public void Deck_Aristocrates_VictoryPoints()
        {
            var game = this.InitializeGame(2);

            foreach (var aristocrate in game.Deck.AllAristocrates)
            {
                Assert.AreEqual(3, aristocrate.VictoryPoints);
            }
        }
    }
}
