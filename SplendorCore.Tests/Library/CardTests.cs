namespace SplendorCore.Tests.Library
{
    #region

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCore.Models;

    #endregion

    [TestClass]
    public class CardTests
    {
        #region Public Methods and Operators

        [TestMethod]
        public void CanBuyNegativeTest()
        {
            var card = new Card(new Chips() { Black = 2, Blue = 2, Green = 2, Red = 2, White = 2 });

            Assert.IsFalse(card.CanBuy(new Chips()));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 1, Blue = 1, Red = 1, White = 1 }));

            Assert.IsFalse(card.CanBuy(new Chips() { Black = 0, Blue = 2, Green = 2, Red = 2, White = 2, Gold = 1 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Blue = 0, Green = 2, Red = 2, White = 2, Gold = 1 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Blue = 2, Green = 0, Red = 2, White = 2, Gold = 1 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Blue = 2, Green = 2, Red = 0, White = 2, Gold = 1 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Blue = 2, Green = 2, Red = 2, White = 0, Gold = 1 }));

            Assert.IsFalse(card.CanBuy(new Chips() { Black = 0, Blue = 1, Green = 1, Red = 1, White = 1, Gold = 4 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 1, Blue = 0, Green = 1, Red = 1, White = 1, Gold = 4 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 1, Blue = 1, Green = 0, Red = 1, White = 1, Gold = 4 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 1, Blue = 1, Green = 1, Red = 0, White = 1, Gold = 4 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 1, Blue = 1, Green = 1, Red = 1, White = 0, Gold = 4 }));

            Assert.IsFalse(card.CanBuy(new Chips() { Black = 0, Blue = 2, Green = 2, Red = 2, White = 2, Gold = 1 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Blue = 0, Green = 2, Red = 2, White = 2, Gold = 1 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Blue = 2, Green = 0, Red = 2, White = 2, Gold = 1 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Blue = 2, Green = 2, Red = 0, White = 2, Gold = 1 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Blue = 2, Green = 2, Red = 2, White = 0, Gold = 1 }));

            Assert.IsFalse(card.CanBuy(new Chips() { Black = 1, Blue = 1, Gold = 7 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Gold = 9 }));
        }

        [TestMethod]
        public void CanBuyNormalTest()
        {
            var card = new Card(new Chips() { Black = 2, Blue = 2, Green = 2, Red = 2, White = 2 });

            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 5, Green = 5, Red = 5, White = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 2, Blue = 5, Green = 5, Red = 5, White = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 2, Green = 5, Red = 5, White = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 5, Green = 2, Red = 5, White = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 5, Green = 5, Red = 2, White = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 5, Green = 5, Red = 5, White = 2 }));
        }

        [TestMethod]
        public void CanBuyUseGoldTest()
        {
            var card = new Card(new Chips() { Black = 2, Blue = 2, Green = 2, Red = 2, White = 2 }, Color.Black);

            Assert.IsTrue(card.CanBuy(new Chips() { Black = 0, Blue = 5, Green = 5, Red = 5, White = 5, Gold = 2 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 2, Blue = 0, Green = 5, Red = 5, White = 5, Gold = 2 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 2, Green = 0, Red = 5, White = 5, Gold = 2 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 2, Green = 5, Red = 0, White = 5, Gold = 2 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 5, Green = 5, Red = 5, White = 0, Gold = 2 }));

            Assert.IsTrue(card.CanBuy(new Chips() { Black = 0, Blue = 1, Green = 2, Red = 5, Gold = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 1, Blue = 1, Green = 5, Red = 2, Gold = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 1, Blue = 2, Green = 0, Red = 0, White = 5, Gold = 5 }));

            Assert.IsTrue(card.CanBuy(new Chips() { Black = 1, Blue = 1, Gold = 8 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Gold = 10 }));
        }

        #endregion
    }
}