namespace SplendorCommonLibrary.Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCommonLibrary.Data;
    using SplendorCommonLibrary.Models;
    using SplendorCommonLibrary.Models.Exceptions;

    [TestClass]
    public class DeckTests
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
            var game = new Game();
            game.Deck = new Deck(game, Constants.DeckFilePath, Constants.AristocratesFilePath);
            
            game.Players.Add(new Player());
            game.Players.Add(new Player());
            game.Start();
            var deck = game.Deck;

            Assert.AreEqual(90, deck.AllCards.Count);
            Assert.AreEqual(3, deck.AvailableCards.Keys.Count);

            foreach (var visibleCard in deck.AvailableCards)
            {
                Assert.AreEqual(4, visibleCard.Value.Count);
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
            var deck = new Deck(null, Constants.DeckFilePath, Constants.AristocratesFilePath);

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
            var deck = new Deck(null, Constants.DeckFilePath, Constants.AristocratesFilePath);

            Assert.AreEqual(10, deck.AllAristocrates.Count);
            var sumOfAllCards = new Chips();

            foreach (var aristocrate in deck.AllAristocrates)
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
            var deck = new Deck(null, Constants.DeckFilePath, Constants.AristocratesFilePath);

            foreach (var aristocrate in deck.AllAristocrates)
            {
                Assert.AreEqual(3, aristocrate.VictoryPoints);
            }
        }
    }
}
