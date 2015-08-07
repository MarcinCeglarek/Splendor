namespace SplendorCommonLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCommonLibrary.Models;

    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void Card_CanBuy_NormalTest()
        {
            var card = new Card() { Color = Color.White, Cost = new Chips() { Black = 2, Blue = 2, Red = 2, White = 2 } };

            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 5, Red = 5, White = 5}));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 2, Blue = 5, Red = 5, White = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 2, Red = 2, White = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 5, Red = 5, White = 2 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 2, Blue = 2, Red = 2, White = 2 }));
        }

        [TestMethod]
        public void Card_CanBuy_UseGoldTest()
        {
            var card = new Card() { Color = Color.White, Cost = new Chips() { Black = 2, Blue = 2, Red = 2, White = 2 } };

            Assert.IsTrue(card.CanBuy(new Chips() { Blue = 5, Red = 5, White = 5, Gold = 2}));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 2, Red = 5, White = 5, Gold = 2 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 2, White = 5, Gold = 2 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 5, Red = 5, Gold = 2 }));

            Assert.IsTrue(card.CanBuy(new Chips() { Blue = 1, Red = 5, Gold = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 1, Red = 5, Gold = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 1, Blue = 5, Gold = 5 }));

            Assert.IsTrue(card.CanBuy(new Chips() { Black = 1, Blue = 1, Gold = 6 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Gold = 8 }));
        }

        [TestMethod]
        public void Card_CanBuy_NegativeTest()
        {
            var card = new Card() { Color = Color.White, Cost = new Chips() { Black = 2, Blue = 2, Red = 2, White = 2 } };

            Assert.IsFalse(card.CanBuy(new Chips()));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 1, Blue = 1, Red = 1, White = 1 }));
            
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 1, Blue = 2, Red = 2, White = 2 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Blue = 1, Red = 2, White = 2 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Blue = 2, Red = 1, White = 2 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Blue = 2, Red = 2, White = 1 }));

            Assert.IsFalse(card.CanBuy(new Chips() { Blue = 2, Red = 2, White = 2, Gold = 1 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Red = 2, White = 2, Gold = 1 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Blue = 2, White = 2, Gold = 1 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Black = 2, Blue = 2, Red = 2, Gold = 1 }));

            Assert.IsFalse(card.CanBuy(new Chips() { Black = 1, Blue = 1, Gold = 5 }));
            Assert.IsFalse(card.CanBuy(new Chips() { Gold = 7 }));
        }
    }
}
