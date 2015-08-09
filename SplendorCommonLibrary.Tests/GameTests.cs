namespace SplendorCommonLibrary.Tests
{
    using System.Linq;
    using System.Runtime.CompilerServices;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCommonLibrary.Data;
    using SplendorCommonLibrary.Models;
    using SplendorCommonLibrary.Models.Exceptions;

    [TestClass]
    public class GameTests : TestsBase
    {
        [TestMethod]
        [ExpectedException(typeof(SplendorGameException))]
        public void Game_Start_AlreadyStartedException()
        {
            var game = this.InitializeGame(2);
            game.Start();
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGameException))]
        public void Game_Start_InsufficientPlayersException()
        {
            var game = this.InitializeGame(1);
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGameException))]
        public void Game_Start_TooMuchPlayersException()
        {
            var game = this.InitializeGame(5);
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGameException))]
        public void Game_Start_DeckNotPresentException()
        {
            var game = new Game();
            game.Players.Add(new Player());
            game.Players.Add(new Player());
            game.Start();
        }

        [TestMethod]
        public void Game_TwoPlayersQueue()
        {
            var game = this.InitializeGame(2);

            var firstPlayer = game.CurrentPlayer;

            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 2 });
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Blue = 2 });
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            /*game.PurchaseCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.PurchaseCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);*/
        }

        [TestMethod]
        public void Game_ThreePlayersQueue()
        {
            var game = this.InitializeGame(3);
            var firstPlayer = game.CurrentPlayer;

            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 2 });
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Blue = 2 });
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Green = 2 });
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            /*game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);*/
        }

        [TestMethod]
        public void Game_FourPlayersQueue()
        {
            var game = this.InitializeGame(4);
            var firstPlayer = game.CurrentPlayer;

            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Blue = 2 });
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Green = 2 });
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Red = 2 });
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { White = 2 });
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            /*game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.PurchaseCard(game.CurrentPlayer, new Card());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);*/
        }

        [TestMethod]
        public void Game_TakeChips_Take3()
        {
            var game = this.InitializeGame(2);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Blue = 1, Black = 1, Green = 1 });
            Assert.AreEqual(1, player.Chips.Blue);
            Assert.AreEqual(1, player.Chips.Black);
            Assert.AreEqual(1, player.Chips.Green);
            Assert.AreEqual(0, player.Chips.Red);
            Assert.AreEqual(0, player.Chips.White);
            Assert.AreEqual(0, player.Chips.Gold);
            this.VerityChipsCountIntegrity(game);

            game.TakeChips(game.CurrentPlayer, new Chips() { Blue = 1, Black = 1, Green = 1 });
            this.VerityChipsCountIntegrity(game);

            game.TakeChips(player, player.Chips + new Chips() { Red = 1, White = 1, Green = 1 });
            Assert.AreEqual(1, player.Chips.Black);
            Assert.AreEqual(1, player.Chips.Blue);
            Assert.AreEqual(2, player.Chips.Green);
            Assert.AreEqual(1, player.Chips.Red);
            Assert.AreEqual(1, player.Chips.White);
            Assert.AreEqual(0, player.Chips.Gold);
            this.VerityChipsCountIntegrity(game);
        }

        [TestMethod]
        public void Game_TakeChips_Take2()
        {
            var game = this.InitializeGame(2);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Blue = 2 });
            Assert.AreEqual(2, player.Chips.Blue);
            Assert.AreEqual(0, player.Chips.Black);
            Assert.AreEqual(0, player.Chips.Green);
            Assert.AreEqual(0, player.Chips.Red);
            Assert.AreEqual(0, player.Chips.White);
            Assert.AreEqual(0, player.Chips.Gold);
            this.VerityChipsCountIntegrity(game);

            game.TakeChips(game.CurrentPlayer, new Chips() { Red = 2 });
            this.VerityChipsCountIntegrity(game);

            game.TakeChips(player, player.Chips + new Chips() { Black = 2 });
            Assert.AreEqual(2, player.Chips.Black);
            Assert.AreEqual(2, player.Chips.Blue);
            Assert.AreEqual(0, player.Chips.Green);
            Assert.AreEqual(0, player.Chips.Red);
            Assert.AreEqual(0, player.Chips.White);
            Assert.AreEqual(0, player.Chips.Gold);
            this.VerityChipsCountIntegrity(game);
        }

        [TestMethod]
        public void Game_TakeChips_Take1()
        {
            var game = this.InitializeGame(2);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Blue = 1 });
            Assert.AreEqual(1, player.Chips.Blue);
            Assert.AreEqual(0, player.Chips.Black);
            Assert.AreEqual(0, player.Chips.Green);
            Assert.AreEqual(0, player.Chips.Red);
            Assert.AreEqual(0, player.Chips.White);
            Assert.AreEqual(0, player.Chips.Gold);
            this.VerityChipsCountIntegrity(game);
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGameTakeActionException))]
        public void Game_TakeChips_InvalidTake3()
        {
            var game = this.InitializeGame(4);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Blue = 3 });
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGameTakeActionException))]
        public void Game_TakeChips_InvalidTake4()
        {
            var game = this.InitializeGame(4);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Black = 1, Blue = 1, Red = 1, Green = 1});
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGameTakeActionException))]
        public void Game_TakeChips_InvalidTakeGold()
        {
            var game = this.InitializeGame(4);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Black = 1, Green = 1, Gold = 1 });
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGameTakeActionException))]
        public void Game_TakeChips_InvalidTakeGold2()
        {
            var game = this.InitializeGame(4);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Gold = 2 });
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGameTakeActionException))]
        public void Game_TakeChips_InvalidTakeGold3()
        {
            var game = this.InitializeGame(4);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Gold = 1 });
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGameTakeActionException))]
        public void Game_TakeChips_ExhaustBank1()
        {
            var game = this.InitializeGame(2);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Blue = 2 });
            Assert.AreEqual(2, player.Chips.Blue);
            Assert.AreEqual(0, player.Chips.Black);
            Assert.AreEqual(0, player.Chips.Green);
            Assert.AreEqual(0, player.Chips.Red);
            Assert.AreEqual(0, player.Chips.White);
            Assert.AreEqual(0, player.Chips.Gold);
            this.VerityChipsCountIntegrity(game);

            game.TakeChips(game.CurrentPlayer, new Chips() { Blue = 2 });
            this.VerityChipsCountIntegrity(game);
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGameTakeActionException))]
        public void Game_TakeChips_ExhaustBank2()
        {
            var game = this.InitializeGame(2);
            var player = game.CurrentPlayer;

            game.TakeChips(game.CurrentPlayer, player.Chips + new Chips() { Black = 1, Blue = 1, Red = 1});
            this.VerityChipsCountIntegrity(game);
            game.TakeChips(game.CurrentPlayer, player.Chips + new Chips() { Black = 0, Blue = 1, Red = 1, Green = 1});
            this.VerityChipsCountIntegrity(game);
            game.TakeChips(game.CurrentPlayer, player.Chips + new Chips() { Black = 0, Blue = 0, Red = 1, Green = 1, White = 1});
            this.VerityChipsCountIntegrity(game);
            game.TakeChips(game.CurrentPlayer, player.Chips + new Chips() { Black = 1, Blue = 0, Red = 0, Green = 1, White = 1 });
            this.VerityChipsCountIntegrity(game);
            game.TakeChips(game.CurrentPlayer, player.Chips + new Chips() { Black = 1, Blue = 1, Red = 0, Green = 0, White = 1 });
            this.VerityChipsCountIntegrity(game);
            game.TakeChips(game.CurrentPlayer, player.Chips + new Chips() { Black = 1, Blue = 1, Red = 1, Green = 0, White = 0 });
            this.VerityChipsCountIntegrity(game);
            game.TakeChips(game.CurrentPlayer, player.Chips + new Chips() { Black = 0, Blue = 1, Red = 1, Green = 1, White = 0 });
            this.VerityChipsCountIntegrity(game);
            game.TakeChips(game.CurrentPlayer, player.Chips + new Chips() { Black = 0, Blue = 0, Red = 1, Green = 1, White = 1 });
            this.VerityChipsCountIntegrity(game);
            game.TakeChips(game.CurrentPlayer, player.Chips + new Chips() { Black = 1, Blue = 0, Red = 0, Green = 1, White = 1 });
            this.VerityChipsCountIntegrity(game);
        }

        [TestMethod]
        public void Game_ReserveCard_1()
        {
            var game = this.InitializeGame(2);
            var player = game.CurrentPlayer;
            var card = game.Deck.AvailableCards.First();

            game.ReserveCard(player, card);
            Assert.AreEqual(3 * Constants.Deck.NumberOfVisibleCards, game.Deck.AvailableCards.Count);
            Assert.AreEqual(1, player.ReservedCards.Count);
            Assert.IsTrue(player.ReservedCards.Contains(card));
            Assert.AreEqual(1, player.Chips.Gold);

            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());

            card = game.Deck.AvailableCards.First();
            game.ReserveCard(player, card);
            Assert.AreEqual(3 * Constants.Deck.NumberOfVisibleCards, game.Deck.AvailableCards.Count);
            Assert.AreEqual(2, player.ReservedCards.Count);
            Assert.IsTrue(player.ReservedCards.Contains(card));
            Assert.AreEqual(2, player.Chips.Gold);

            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());

            card = game.Deck.AvailableCards.First();
            game.ReserveCard(player, card);
            Assert.AreEqual(3 * Constants.Deck.NumberOfVisibleCards, game.Deck.AvailableCards.Count);
            Assert.AreEqual(3, player.ReservedCards.Count);
            Assert.IsTrue(player.ReservedCards.Contains(card));
            Assert.AreEqual(3, player.Chips.Gold);

            var player2 = game.CurrentPlayer;
            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            Assert.AreEqual(2, player2.Chips.Gold);
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGameReserveActionException))]
        public void Game_ReserveCard_Reserve4()
        {
            var game = this.InitializeGame(2);
            var player1 = game.CurrentPlayer;
            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            var player2 = game.CurrentPlayer;
            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());

            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());

            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());

            Assert.AreEqual(3, player1.Chips.Gold);
            Assert.AreEqual(2, player2.Chips.Gold);

            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
            game.ReserveCard(game.CurrentPlayer, game.Deck.AvailableCards.First());
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGameReserveActionException))]
        public void Game_ReserveCard_ReserveUnavailableCard()
        {
            var game = this.InitializeGame(2);
            game.ReserveCard(game.CurrentPlayer, game.Deck.AllCards.Last());
        }

        [TestMethod]
        public void Game_PurchaseCard_Normal()
        {
            var game = this.InitializeGame(2);
            var player = game.CurrentPlayer;
            var card = game.Deck.AvailableCards.First();

            game.CurrentPlayer.Chips += new Chips(4, 4, 4, 4, 4, 0);

            game.PurchaseCard(player, card);
            Assert.AreEqual(1, player.OwnedCards.Count);
            Assert.AreEqual(card,player.OwnedCards.Single());
            Assert.AreEqual(new Chips(4, 4, 4, 4, 4, 0), player.Chips + card.Cost);
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGamePurchaseCardException))]
        public void Game_PurchaseCard_Insufficient()
        {
            var game = this.InitializeGame(2);
            var player = game.CurrentPlayer;
            var card = game.Deck.AvailableCards.First();

            game.PurchaseCard(player, card);
        }

        [TestMethod]
        [ExpectedException(typeof(SplendorGamePurchaseCardException))]
        public void Game_PurchaseCard_InvalidCard()
        {
            var game = this.InitializeGame(2);
            var player = game.CurrentPlayer;
            var invalidCard = this.GetInvalidCard(game);

            game.PurchaseCard(player, invalidCard);
        }
    }
}
