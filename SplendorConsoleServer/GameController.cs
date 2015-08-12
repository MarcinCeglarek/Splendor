namespace SplendorConsoleServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SplendorCommonLibrary.Models;

    public class GameController
    {
        private static GameController instance;

        private readonly List<Game> games;
 
        private GameController()
        {
            this.games = new List<Game>();
        }

        public static GameController Instance 
        {
            get
            {
                return instance ?? (instance = new GameController());
            }
        }

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
    }
}
