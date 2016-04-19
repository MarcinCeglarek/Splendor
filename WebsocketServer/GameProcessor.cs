namespace WebsocketServer
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using ServerDto;
    using ServerDto.Enums;
    using ServerDto.Requests;
    using ServerDto.Requests.Basic;
    using ServerDto.Responses;
    using ServerDto.Responses.Basic;

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

                case MessageType.DeleteGame:
                    response = await this.DeleteGame(request);
                    break;

                case MessageType.JoinGame:
                    response = await this.Connect(request);
                    break;

                case MessageType.CanTakeChips:
                    response = await this.CanTakeChips(request);
                    break;

                case MessageType.TakeChips:
                    response = await this.TakeChips(request);
                    break;
                
                case MessageType.GameStatus:
                    response = await this.GameStatus(request);
                    break;

                default:
                    throw new NotImplementedException();
            }

            return await JsonConvert.SerializeObjectAsync(response);
        }

        private async Task<Response> CanTakeChips(string request)
        {
            var message = await JsonConvert.DeserializeObjectAsync<CanTakeChipsRequest>(request);
            var game = this.games.Single(g => g.Id == message.GameId);

            var result = game.CanTakeChips(game.Players.Single(p => p.Id == message.PlayerId), message.Chips);
            return new CanTakeChipsResponse() { MessageType = MessageType.CanTakeChips, CanTakeChips = result };
        }

        private async Task<Response> TakeChips(string request)
        {
            var message = await JsonConvert.DeserializeObjectAsync<CanTakeChipsRequest>(request);
            var game = this.games.Single(g => g.Id == message.GameId);

            game.TakeChips(game.Players.Single(p => p.Id == message.PlayerId), message.Chips);
            return new Response() { MessageType = MessageType.TakeChips };
        }

        private Response CreateGame()
        {
            var game = new Game();
            this.games.Add(game);
            return new CreateGameResponse { GameId = game.Id, MessageType = MessageType.GameCreated };
        }

        private async Task<Response> DeleteGame(string request)
        {
            var message = await JsonConvert.DeserializeObjectAsync<DeleteGameRequest>(request);
            var game = this.games.Single(g => g.Id == message.GameId);
            if (!game.HasStarted && game.Players.Count == 0)
            {
                this.games.Remove(game);
            }

            return new DeleteGameResponse { MessageType = MessageType.GameDeleted };
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

        private async Task<GameStatusResponse> GameStatus(string request)
        {
            var message = await JsonConvert.DeserializeObjectAsync<GameRequest>(request);
            var game = this.games.Single(g => g.Id == message.GameId);

            var retVal = new GameStatusResponse()
                         {
                             Aristocrates = game.AvailableAristocrates.ToList(),
                             Id = game.Id,
                             Cards = game.AvailableCards.ToList(),
                             CurrentPlayer = game.CurrentPlayer.Id,
                             FirstPlayer = game.FirstPlayer.Id,
                             HasFinished = game.HasFinished,
                             HasStarted = game.HasStarted,
                             MessageType = MessageType.GameStatus,
                             Players = game.Players.ToList()
                         };

            return retVal;
        }
    }
}