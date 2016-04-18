namespace WebsocketServer
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using ServerDto;
    using ServerDto.Abstract;
    using ServerDto.Enums;

    using SplendorCore.Models;

    #endregion

    internal class GameProcessor
    {
        private static GameProcessor gameProcessor;

        private readonly List<Game> games;

        private GameProcessor()
        {
            this.games = new List<Game>();
        }

        public static GameProcessor Instance()
        {
            return gameProcessor ?? (gameProcessor = new GameProcessor());
        }

        public async Task<string> ProcessMessage(string request)
        {
            var message = await JsonConvert.DeserializeObjectAsync<Request>(request);
            Response response;

            switch (message.MessageType)
            {
                case MessageType.ShowGames:
                    response = this.ShowGames();
                    break;

                case MessageType.CreateGame:
                    response = this.CreateGame();
                    break;

                case MessageType.JoinGame:
                    response = await this.Connect(request);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return await JsonConvert.SerializeObjectAsync(response);
        }

        private Response CreateGame()
        {
            var game = new Game();
            this.games.Add(game);
            return new CreateGameResponse { GameId = game.Id, MessageType = MessageType.GameCreated };
        }

        private async Task<JoinGameResponse> Connect(string request)
        {
            var message = await JsonConvert.DeserializeObjectAsync<JoinGameRequest>(request);

            var game = this.games.Single(g => g.Id == message.GameId);
            var player = new Player { Name = message.PlayerName };
            game.AddPlayer(player);

            return new JoinGameResponse { GameId = game.Id, MessageType = MessageType.GameJoined, PlayerId = player.Id };
        }

        private ShowGamesResponse ShowGames()
        {
            var retVal = new ShowGamesResponse { MessageType = MessageType.ShowGames, Games = new List<ShowGamesResponse.GameInfo>() };

            foreach (var game in this.games)
            {
                retVal.Games.Add(new ShowGamesResponse.GameInfo { GameId = game.Id, IsStarted = game.HasStarted, Players = game.Players.Count });
            }

            return retVal;
        }
    }
}