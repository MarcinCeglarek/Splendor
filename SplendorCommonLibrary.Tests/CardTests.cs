﻿namespace SplendorCommonLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCommonLibrary.Models;

    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void Card_CanBuy_NormalTest()
        {
            var card = new Card() { Color = Color.White, Cost = new Chips() { Black = 2, Blue = 2, Green = 2, Red = 2, White = 2 } };

            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 5, Green = 5, Red = 5, White = 5}));

            Assert.IsTrue(card.CanBuy(new Chips() { Black = 2, Blue = 5, Green = 5, Red = 5, White = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 2, Green = 5, Red = 5, White = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 5, Green = 2, Red = 5, White = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 5, Green = 5, Red = 2, White = 5 }));
            Assert.IsTrue(card.CanBuy(new Chips() { Black = 5, Blue = 5, Green = 5, Red = 5, White = 2 }));
            
        }

        [TestMethod]
        public void Card_CanBuy_UseGoldTest()
        {
            var card = new Card() { Color = Color.White, Cost = new Chips() { Black = 2, Blue = 2, Green = 2, Red = 2, White = 2 } };

            Assert.IsTrue(card.CanBuy(new Chips() { Black = 0, Blue = 5, Green = 5, Red = 5, White = 5, Gold = 2}));
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

        [TestMethod]
        public void Card_CanBuy_NegativeTest()
        {
            var card = new Card() { Color = Color.White, Cost = new Chips() { Black = 2, Blue = 2, Green = 2, Red = 2, White = 2 } };

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
    }
}