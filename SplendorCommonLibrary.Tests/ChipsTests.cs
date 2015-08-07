namespace SplendorCommonLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCommonLibrary.Models;

    [TestClass]
    public class ChipsTests
    {
        [TestMethod]
        public void Chip_SettersAndGetters()
        {
            var a = new Chips { Black = 5 };

            Assert.AreEqual(5, a.Black);
            Assert.AreEqual(5, a[Color.Black]);

            a.Gold = 2;

            Assert.AreEqual(2, a.Gold);
            Assert.AreEqual(2, a[Color.Gold]);

            a.Black = 12;

            Assert.AreEqual(12, a.Black, 12);
            Assert.AreEqual(12, a[Color.Black]);
        }

        [TestMethod]
        public void Chip_ListsOperatorsAddition()
        {
            var a = new Chips() { Black = 2, Blue = 2, Green = 2};
            var b = new Chips() { Red = 2, White = 2 };

            var result = a + b;

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(2, result.Black);
            Assert.AreEqual(2, result.Blue);
            Assert.AreEqual(2, result.Green);
            Assert.AreEqual(2, result.Red);
            Assert.AreEqual(2, result.White);

            a.Red = 4;
            a.Gold = 6;
            b.Black = 4;

            var result2 = a + b;

            Assert.AreEqual(6, result2.Count);
            Assert.AreEqual(6, result2.Black);
            Assert.AreEqual(2, result2.Blue);
            Assert.AreEqual(2, result.Green);
            Assert.AreEqual(6, result2.Red);
            Assert.AreEqual(2, result2.White);
            Assert.AreEqual(6, result2.Gold);
        }

        [TestMethod]
        public void Chip_ListsOperatorsSubstraction()
        {
            var a = new Chips() { Black = 2, Blue = 2, Red = 2, Green = 2};
            var b = new Chips() { Blue = 1, Red = 3, White = 3 };

            var result = a - b;

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(2, result.Black);
            Assert.AreEqual(2, result.Green);
            Assert.AreEqual(1, result.Blue);
            Assert.AreEqual(-1, result.Red);
            Assert.AreEqual(-3, result.White);
        }
    }
}
