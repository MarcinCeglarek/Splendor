﻿namespace SplendorCore.Tests.Library
{
    #region

    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SplendorCore.Data;
    using SplendorCore.Models;
    using SplendorCore.Models.Exceptions.CardExceptions;
    using SplendorCore.Models.Exceptions.CardOperationExceptions;
    using SplendorCore.Models.Exceptions.ChipOperationExceptions;
    using SplendorCore.Models.Exceptions.GameExceptions;
    using SplendorCore.Models.Exceptions.PlayerExceptions;

    #endregion

    [TestClass]
    public class GameTests : TestsBase
    {
        #region Public Methods and Operators

        [TestMethod]
        public void AddAndRemovePlayer()
        {
            var game = new Game(CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);
            var player = new Player();
            game.AddPlayer(player);
            game.RemovePlayer(player);

            Assert.AreEqual(0, game.Players.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(GameAlreadyStartedException))]
        public void AddPlayerAfterGameIsStarted()
        {
            var game = this.InitializeGame(3);
            game.AddPlayer(new Player());
        }

        [TestMethod]
        public void AddSinglePlayer()
        {
            var game = new Game(CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);
            game.AddPlayer(new Player());

            Assert.AreEqual(1, game.Players.Count);
        }

        [TestMethod]
        public void FourPlayersQueue()
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

            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfPlayersException))]
        public void InvalidFivePlayer()
        {
            this.InitializeGame(5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfPlayersException))]
        public void InvalidOnePlayer()
        {
            this.InitializeGame(1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfPlayersException))]
        public void InvalidTenPlayers()
        {
            this.InitializeGame(10);
        }

        [TestMethod]
        [ExpectedException(typeof(InsuficentPlayerResourcesException))]
        public void PurchaseCardInsufficient()
        {
            var game = this.InitializeGame();
            var player = game.CurrentPlayer;
            var card = game.AvailableCards.First();

            game.PurchaseCard(player, card);
        }

        [TestMethod]
        [ExpectedException(typeof(CardUnavailableException))]
        public void PurchaseCardInvalidCard()
        {
            var game = this.InitializeGame();
            var player = game.CurrentPlayer;
            var invalidCard = this.GetInvalidCard(game);

            game.PurchaseCard(player, invalidCard);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPlayerException))]
        public void RemoveInvalidPlayer()
        {
            var game = new Game(CoreConstants.DeckFilePath, CoreConstants.AristocratesFilePath);
            game.RemovePlayer(new Player());
        }

        [TestMethod]
        [ExpectedException(typeof(GameAlreadyStartedException))]
        public void RemovePlayerAfterGameIsStarted()
        {
            var game = this.InitializeGame(3);
            game.RemovePlayer(game.Players.First());
        }

        [TestMethod]
        public void ReserveCard1()
        {
            var game = this.InitializeGame();
            var player = game.CurrentPlayer;
            var card = game.AvailableCards.First();

            game.ReserveCard(player, card);
            Assert.AreEqual(3 * CoreConstants.Deck.NumberOfVisibleCards, game.AvailableCards.Count);
            Assert.AreEqual(1, player.ReservedCards.Count);
            Assert.IsTrue(player.ReservedCards.Contains(card));
            Assert.AreEqual(1, player.Chips.Gold);

            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());

            card = game.AvailableCards.First();
            game.ReserveCard(player, card);
            Assert.AreEqual(3 * CoreConstants.Deck.NumberOfVisibleCards, game.AvailableCards.Count);
            Assert.AreEqual(2, player.ReservedCards.Count);
            Assert.IsTrue(player.ReservedCards.Contains(card));
            Assert.AreEqual(2, player.Chips.Gold);

            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());

            card = game.AvailableCards.First();
            game.ReserveCard(player, card);
            Assert.AreEqual(3 * CoreConstants.Deck.NumberOfVisibleCards, game.AvailableCards.Count);
            Assert.AreEqual(3, player.ReservedCards.Count);
            Assert.IsTrue(player.ReservedCards.Contains(card));
            Assert.AreEqual(3, player.Chips.Gold);

            var player2 = game.CurrentPlayer;
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            Assert.AreEqual(2, player2.Chips.Gold);
        }

        [TestMethod]
        [ExpectedException(typeof(CardReservationException))]
        public void ReserveCardReserve4()
        {
            var game = this.InitializeGame();
            var player1 = game.CurrentPlayer;
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            var player2 = game.CurrentPlayer;
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());

            Assert.AreEqual(3, game.Bank.Gold);

            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());

            Assert.AreEqual(1, game.Bank.Gold);

            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());

            Assert.AreEqual(3, player1.Chips.Gold);
            Assert.AreEqual(2, player2.Chips.Gold);
            Assert.AreEqual(0, game.Bank.Gold);

            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
        }

        [TestMethod]
        [ExpectedException(typeof(CardUnavailableException))]
        public void ReserveCardReserveUnavailableCard()
        {
            var game = this.InitializeGame();
            game.ReserveCard(game.CurrentPlayer, game.AllCards.Except(game.AvailableCards).Last());
        }

        [TestMethod]
        [ExpectedException(typeof(GameAlreadyStartedException))]
        public void StartAlreadyStartedException()
        {
            var game = this.InitializeGame();
            game.Start();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfPlayersException))]
        public void StartInsufficientPlayersException()
        {
            var game = this.InitializeGame(1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidNumberOfPlayersException))]
        public void StartTooMuchPlayersException()
        {
            var game = this.InitializeGame(5);
        }

        [TestMethod]
        [ExpectedException(typeof(TwoChipsOperationNotPermitted))]
        public void TakeChipsExhaustBank1()
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
        [ExpectedException(typeof(BankResourcesExhaustedException))]
        public void TakeChipsExhaustBank2()
        {
            var game = this.InitializeGame(2);
            var player = game.CurrentPlayer;

            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 1, Blue = 1, Red = 1, Green = 0, White = 0 });
            this.VerityChipsCountIntegrity(game);
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 1, Blue = 1, Red = 1, Green = 0, White = 0 });
            this.VerityChipsCountIntegrity(game);
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 1, Blue = 1, Red = 1, Green = 0, White = 0 });
            this.VerityChipsCountIntegrity(game);
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 1, Blue = 1, Red = 1, Green = 0, White = 0 });
            this.VerityChipsCountIntegrity(game);
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 1, Blue = 1, Red = 1, Green = 0, White = 0 });
            this.VerityChipsCountIntegrity(game);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTakeActionException))]
        public void TakeChipsInvalidTake3()
        {
            var game = this.InitializeGame(4);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Blue = 3 });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTakeActionException))]
        public void TakeChipsInvalidTake4()
        {
            var game = this.InitializeGame(4);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Black = 1, Blue = 1, Red = 1, Green = 1 });
        }

        [TestMethod]
        [ExpectedException(typeof(TakeGoldChipsNotAllowed))]
        public void TakeChipsInvalidTakeGold()
        {
            var game = this.InitializeGame(4);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Black = 1, Green = 1, Gold = 1 });
        }

        [TestMethod]
        [ExpectedException(typeof(TakeGoldChipsNotAllowed))]
        public void TakeChipsInvalidTakeGold2()
        {
            var game = this.InitializeGame(4);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Gold = 2 });
        }

        [TestMethod]
        [ExpectedException(typeof(TakeGoldChipsNotAllowed))]
        public void TakeChipsInvalidTakeGold3()
        {
            var game = this.InitializeGame(4);
            var player = game.CurrentPlayer;

            game.TakeChips(player, player.Chips + new Chips() { Gold = 1 });
        }

        [TestMethod]
        [ExpectedException(typeof(ResourcesOverflowException))]
        public void TakeChipsInvalidTakeOver10()
        {
            var game = this.InitializeGame(3);

            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 1, Blue = 1, Green = 1, Red = 0, White = 0 });
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 0, Blue = 1, Green = 1, Red = 1, White = 0 });
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());

            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 0, Blue = 0, Green = 1, Red = 1, White = 1 });
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 1, Blue = 0, Green = 0, Red = 1, White = 1 });
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());

            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 1, Blue = 1, Green = 0, Red = 0, White = 1 });
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 1, Blue = 1, Green = 1, Red = 0, White = 0 });
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());

            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 0, Blue = 1, Green = 1, Red = 1, White = 0 });
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 0, Blue = 0, Green = 1, Red = 1, White = 1 });
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
        }

        [TestMethod]
        public void TakeChipsTake1()
        {
            var game = this.InitializeGame();
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
        public void TakeChipsTake2()
        {
            var game = this.InitializeGame();
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
        public void TakeChipsTake3()
        {
            var game = this.InitializeGame();
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
        public void ThreePlayersQueue()
        {
            var game = this.InitializeGame(3);
            var firstPlayer = game.CurrentPlayer;

            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 2 });
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Blue = 2 });
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Green = 2 });
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);
        }

        [TestMethod]
        public void TwoPlayersQueue()
        {
            var game = this.InitializeGame();

            var firstPlayer = game.CurrentPlayer;

            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Black = 2 });
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.TakeChips(game.CurrentPlayer, game.CurrentPlayer.Chips + new Chips() { Blue = 2 });
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);

            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            Assert.AreNotEqual(firstPlayer, game.CurrentPlayer);
            game.ReserveCard(game.CurrentPlayer, game.AvailableCards.First());
            Assert.AreEqual(firstPlayer, game.CurrentPlayer);
        }

        #endregion
    }
}