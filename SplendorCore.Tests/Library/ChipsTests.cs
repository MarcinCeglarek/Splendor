namespace SplendorCore.Tests.Library
{
    #region

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    #endregion

    [TestClass]
    public class ChipsTests
    {
        #region Public Methods and Operators

        [TestMethod]
        public void DifferentObject()
        {
            Assert.AreNotEqual(1, new Chips(1, 1, 1, 1, 1, 1));
            Assert.AreNotEqual(0, new Chips());
            Assert.AreNotEqual("String", new Chips(2, 2, 2, 2, 2, 2));
        }

        [TestMethod]
        public void EqualityTest()
        {
            var a1 = new Chips(1, 2, 3, 4, 5, 6);
            var a2 = new Chips { White = 1, Blue = 2, Green = 3, Red = 4, Black = 5, Gold = 6 };

            Assert.AreEqual(a1, a2);

            var b1 = new Chips(1, 0, 0, 0, 0, 2);
            var b2 = new Chips(1, 0, 1, 0, 0, 2);

            Assert.AreNotEqual(b1, b2);
        }

        [TestMethod]
        public void EqualityTestWithCopyConstructor()
        {
            var chips1 = new Chips(1, 2, 3, 4, 5, 6);
            var chips2 = new Chips(chips1);

            Assert.AreEqual(chips1, chips2);
        }

        [TestMethod]
        public void ListsOperatorsAddition()
        {
            var a = new Chips { Black = 2, Blue = 2, Green = 2 };
            var b = new Chips { Red = 2, White = 2 };

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
        public void ListsOperatorsSubstraction()
        {
            var a = new Chips { Black = 2, Blue = 2, Red = 2, Green = 2 };
            var b = new Chips { Blue = 1, Red = 3, White = 3 };

            var result = a - b;

            Assert.AreEqual(6, result.Count);
            Assert.AreEqual(2, result.Black);
            Assert.AreEqual(2, result.Green);
            Assert.AreEqual(1, result.Blue);
            Assert.AreEqual(-1, result.Red);
            Assert.AreEqual(-3, result.White);
        }

        [TestMethod]
        public void OperatorsLessThen()
        {
            var c1 = new Chips(2, 2, 2, 1, 1, 1);
            var c2 = new Chips(3, 0, 0, 0, 0, 0);
            var c3 = new Chips(1, 1, 1, 0, 0, 0);
            var c4 = new Chips(1, 0, 0, 0, 0, 0);
            Assert.IsFalse(c1 < c2);
            Assert.IsFalse(c2 < c1);

            Assert.IsFalse(c1 < c3);
            Assert.IsTrue(c3 < c1);

            Assert.IsFalse(c1 < c4);
            Assert.IsTrue(c4 < c1);

            Assert.IsFalse(c2 < c3);
            Assert.IsFalse(c3 < c2);

            Assert.IsFalse(c2 < c4);
            Assert.IsTrue(c4 < c2);

            Assert.IsFalse(c3 < c4);
            Assert.IsFalse(c4 < c3);
        }

        [TestMethod]
        public void OperatorsLessOrEqualThen()
        {
            var c1 = new Chips(2, 2, 2, 1, 1, 1);
            var c2 = new Chips(3, 0, 0, 0, 0, 0);
            var c3 = new Chips(1, 1, 1, 0, 0, 0);
            var c4 = new Chips(1, 0, 0, 0, 0, 0);
            Assert.IsFalse(c1 <= c2);
            Assert.IsFalse(c2 <= c1);

            Assert.IsFalse(c1 <= c3);
            Assert.IsTrue(c3 <= c1);

            Assert.IsFalse(c1 <= c4);
            Assert.IsTrue(c4 <= c1);

            Assert.IsFalse(c2 <= c3);
            Assert.IsFalse(c3 <= c2);

            Assert.IsFalse(c2 <= c4);
            Assert.IsTrue(c4 <= c2);

            Assert.IsFalse(c3 <= c4);
            Assert.IsTrue(c4 <= c3);
        }

        [TestMethod]
        public void OperatorsGreaterThen()
        {
            var c1 = new Chips(2, 2, 2, 1, 1, 1);
            var c2 = new Chips(3, 0, 0, 0, 0, 0);
            var c3 = new Chips(1, 1, 1, 0, 0, 0);
            var c4 = new Chips(1, 0, 0, 0, 0, 0);

            Assert.IsFalse(c1 > c2);
            Assert.IsFalse(c2 > c1);

            Assert.IsTrue(c1 > c3);
            Assert.IsFalse(c3 > c1);

            Assert.IsTrue(c1 > c4);
            Assert.IsFalse(c4 > c1);

            Assert.IsFalse(c2 > c3);
            Assert.IsFalse(c3 > c2);

            Assert.IsTrue(c2 > c4);
            Assert.IsFalse(c4 > c2);

            Assert.IsFalse(c3 > c4);
            Assert.IsFalse(c4 > c3);
        }

        [TestMethod]
        public void OperatorsGreaterOrEqualThen()
        {
            var c1 = new Chips(2, 2, 2, 1, 1, 1);
            var c2 = new Chips(3, 0, 0, 0, 0, 0);
            var c3 = new Chips(1, 1, 1, 0, 0, 0);
            var c4 = new Chips(1, 0, 0, 0, 0, 0);

            Assert.IsFalse(c1 >= c2);
            Assert.IsFalse(c2 >= c1);

            Assert.IsTrue(c1 >= c3);
            Assert.IsFalse(c3 >= c1);

            Assert.IsTrue(c1 >= c4);
            Assert.IsFalse(c4 >= c1);

            Assert.IsFalse(c2 >= c3);
            Assert.IsFalse(c3 >= c2);

            Assert.IsTrue(c2 >= c4);
            Assert.IsFalse(c4 >= c2);

            Assert.IsTrue(c3 >= c4);
            Assert.IsFalse(c4 >= c3);
        }

        [TestMethod]
        public void SettersAndGetters()
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

        #endregion
    }
}