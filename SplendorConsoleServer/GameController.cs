﻿namespace SplendorConsoleServer
{
    #region

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SplendorCommonLibrary.Models;

    #endregion

    public class GameController
    {
        #region Static Fields

        private static GameController instance;

        #endregion

        #region Fields

        private readonly List<Game> games;

        #endregion

        #region Constructors and Destructors

        private GameController()
        {
            this.games = new List<Game>();
        }

        #endregion

        #region Public Properties

        public static GameController Instance
        {
            get
            {
                return instance ?? (instance = new GameController());
            }
        }

        #endregion

        #region Public Methods and Operators

        public Game CreateGame()
        {
            var game = new Game();
            this.games.Add(game);
            return game;
        }

        public Game GetGameById(Guid id)
        {
            return this.games.Single(game => game.Id == id);
        }

        public Game GetUnstartedGame()
        {
            var unstartedGames = this.games.Where(game => game.HasStarted == false && game.Players.Count < 4).ToArray();
            if (unstartedGames.Any())
            {
                return unstartedGames.First();
            }

            var newGame = new Game();
            this.games.Add(newGame);
            return newGame;
        }

        #endregion
    }
}