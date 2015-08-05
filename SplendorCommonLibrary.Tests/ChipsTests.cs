namespace SplendorCommonLibrary.Tests
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCommonLibrary.Models;
    using SplendorCommonLibrary.Models.ChipsModels;

    [TestClass]
    public class ChipsTests
    {
        [TestMethod]
        public void ChipSettersAndGetters()
        {
            var a = new Chips { Black = 5 };

            Assert.AreEqual(a.Black, 5);
            Assert.AreEqual(a.Single(o => o.Color == Color.Black).Value, 5);

            a.Gold = 2;

            Assert.AreEqual(a.Gold, 2);
            Assert.AreEqual(a.Single(o => o.Color == Color.Gold).Value, 2);

            a.Black = 12;

            Assert.AreEqual(a.Black, 12);
            Assert.AreEqual(a.Single(o => o.Color == Color.Black).Value, 12);
        }

        [TestMethod]
        public void ChipListsOperatorsAddition()
        {
            var a = new Chips() { Black = 2, Blue = 2 };
            var b = new Chips() { Red = 2, White = 2 };

            var result = a + b;

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(2, result.Black);
            Assert.AreEqual(2, result.Blue);
            Assert.AreEqual(2, result.Red);
            Assert.AreEqual(2, result.White);

            a.Red = 4;
            a.Gold = 6;
            b.Black = 4;

            var result2 = a + b;

            Assert.AreEqual(5, result2.Count);
            Assert.AreEqual(6, result2.Black);
            Assert.AreEqual(2, result2.Blue);
            Assert.AreEqual(6, result2.Red);
            Assert.AreEqual(2, result2.White);
            Assert.AreEqual(6, result2.Gold);
        }

        [TestMethod]
        public void ChipListsOperatorsSubstraction()
        {
            var a = new Chips() { Black = 2, Blue = 2, Red = 2};
            var b = new Chips() { Blue = 1, Red = 3, White = 3 };

            var result = a - b;

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(2, result.Black);
            Assert.AreEqual(1, result.Blue);
            Assert.AreEqual(-1, result.Red);
            Assert.AreEqual(-3, result.White);
        }
    }
}
