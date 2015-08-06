namespace SplendorCommonLibrary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCommonLibrary.Data;
    using SplendorCommonLibrary.Models;

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TwoPlayersQueue()
        {
            var game = new Game();
            game.Deck = new Deck(game, Constants.DeckFilePath, Constants.AristocratesFilePath);

            game.Players.Add(new Player());
            game.Players.Add(new Player());
            game.Start();

            var firstPlayer = game.CurrentPlayer;

            game.TakeChips(game.CurrentPlayer);
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer);
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            game.ReserveCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, new Card());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);
        }

        [TestMethod]
        public void ThreePlayersQueue()
        {
            var game = new Game();
            game.Deck = new Deck(game, Constants.DeckFilePath, Constants.AristocratesFilePath);
            
            game.Players.Add(new Player());
            game.Players.Add(new Player());
            game.Players.Add(new Player());
            game.Start();

            var firstPlayer = game.CurrentPlayer;

            game.TakeChips(game.CurrentPlayer);
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer);
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer);
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            game.ReserveCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, new Card());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);
        }

        [TestMethod]
        public void FourPlayersQueue()
        {
            var game = new Game();
            game.Deck = new Deck(game, Constants.DeckFilePath, Constants.AristocratesFilePath);

            game.Players.Add(new Player());
            game.Players.Add(new Player());
            game.Players.Add(new Player());
            game.Players.Add(new Player());
            game.Start();

            var firstPlayer = game.CurrentPlayer;

            game.TakeChips(game.CurrentPlayer);
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer);
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer);
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer);
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            game.ReserveCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, new Card());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);
        }
    }
}
