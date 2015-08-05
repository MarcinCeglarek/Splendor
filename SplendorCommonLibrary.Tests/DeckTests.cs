namespace SplendorCommonLibrary.Tests
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCommonLibrary.Data;
    using SplendorCommonLibrary.Models;

    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void DeckCardNumber()
        {
            var deck = new Deck(Constants.DeckFilePath, Constants.AristocratesFilePath);

            Assert.AreEqual(90, deck.AllCards.Count);
            Assert.AreEqual(3, deck.GetVisibleCards().Keys.Count);

            foreach (var visibleCard in deck.GetVisibleCards())
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
        public void DeckCardPoints()
        {
            var deck = new Deck(Constants.DeckFilePath, Constants.AristocratesFilePath);

            Assert.AreEqual(5, deck.AllCards.Where(o => o.Tier == 1).Sum(c => c.VictoryPoints));
            Assert.AreEqual((5 + 4 + 4 + 3) * 5, deck.AllCards.Where(o => o.Tier == 3).Sum(c => c.VictoryPoints));
        }
    }
}
