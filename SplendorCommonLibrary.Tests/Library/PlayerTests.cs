namespace SplendorCore.Tests.Library
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCore.Models;

    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void PlayerEquality()
        {
            var a = new Player();
            var b = new Player();

            Assert.AreNotEqual(a, b);

            var c = a; 

            Assert.AreEqual(a, c);
        }
    }
}
