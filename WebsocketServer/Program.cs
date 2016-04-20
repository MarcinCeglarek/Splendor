namespace WebsocketServer
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fleck;

    using Newtonsoft.Json;

    using ServerDto.Enums;
    using ServerDto.Messages;
    using ServerDto.Messages.Basic;
    using ServerDto.Requests;
    using ServerDto.Responses;

    using SplendorCore.Models;

    #endregion

    public class Program
    {
        private static WebSocketServer server;

        private static readonly List<Game> games = new List<Game>();

        private static readonly List<IWebSocketConnection> socketClients = new List<IWebSocketConnection>();

        public static Game GetGame(Guid id)
        {
            return games.SingleOrDefault(game => game.Id == id);
        }

        private static void Main(string[] args)
        {
            server = new WebSocketServer("ws://0.0.0.0:8181");
            FleckLog.LogAction = (level, message, ex) =>
            {
                switch (level)
                {
                    case LogLevel.Debug:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(message, ex);
                        break;
                    case LogLevel.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(message, ex);
                        break;
                    case LogLevel.Warn:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(message, ex);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(message, ex);
                        break;
                }
            };

            server.Start(
                socket =>
                {
                    socket.OnOpen = () => { socketClients.Add(socket); };
                    socket.OnClose = () => { socketClients.Remove(socket); };
                    socket.OnMessage = message => { OnConnectionMessage(socket, message); };
                });

            Console.ReadLine();
        }

        private static async void OnConnectionMessage(IWebSocketConnection socket, string message)
        {
            try
            {
                Console.WriteLine(message);
                var response = await ProcessMessage(socket, message);
                if (response != null)
                {
                    await socket.Send(response);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static Message CreateGame()
        {
            var game = new Game();
            games.Add(game);
            return new CreateGameResponse { GameId = game.Id, MessageType = MessageType.GameCreated };
        }

        public static bool DeleteGame(Guid id)
        {
            var game = GetGame(id);

            if (game != null && !game.HasStarted && game.Players.Count == 0)
            {
                games.Remove(game);
                return true;
            }

            return false;
        }

        public static async Task<string> ProcessMessage(IWebSocketConnection socket, string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Message>(request));
            Message response = null;

            switch (message.MessageType)
            {
                case MessageType.ShowGames:
                    response = ShowGames();
                    break;

                case MessageType.CreateGame:
                    response = CreateGame();
                    break;

                case MessageType.DeleteGame:
                    response = await DeleteGame(request);
                    break;

                case MessageType.JoinGame:
                    response = await JoinGame(socket, request);
                    break;

                case MessageType.GameStatus:
                    response = await GameStatus(request);
                    break;

                case MessageType.GameStarted:
                    await StartGame(request);
                    break;

                case MessageType.Subscribe:
                    Subscribe(socket, request);
                    break;

                case MessageType.Unsubscribe:
                    Unsubscribe(socket, request);
                    break;

                case MessageType.CanTakeChips:
                    response = await CanTakeChips(request);
                    break;

                case MessageType.TakeChips:
                    response = await TakeChips(request);
                    break;


                default:
                    throw new NotImplementedException();
            }

            return await Task.Factory.StartNew(() => JsonConvert.SerializeObject(response));
        }

        private static async Task StartGame(string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<GameMessage>(request));
            var game = GetGame(message.GameId);

            game?.Start();
        }

        private static async void Unsubscribe(IWebSocketConnection socket, string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<GameMessage>(request));
            var game = GetGame(message.GameId);

            throw new NotImplementedException();
        }

        private static async void Subscribe(IWebSocketConnection socket, string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<GameMessage>(request));
            var game = GetGame(message.GameId);
            game?.Subscribe(new Broadcaster(socket));
        }

        private static async Task<Message> CanTakeChips(string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CanTakeChipsRequest>(request));
            var game = GetGame(message.GameId);

            var result = game.CanTakeChips(game.Players.Single(p => p.Id == message.PlayerId), message.Chips);
            return new CanTakeChipsResponse { MessageType = MessageType.CanTakeChips, GameId = game.Id, PlayerId = message.PlayerId, CanTakeChips = result };
        }

        private static async Task<Message> TakeChips(string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CanTakeChipsRequest>(request));
            var game = GetGame(message.GameId);

            game.TakeChips(game.Players.Single(p => p.Id == message.PlayerId), message.Chips);
            return new ChipsTakenMessage { MessageType = MessageType.TakeChips, GameId = game.Id, PlayerId = message.PlayerId };
        }

        private static async Task<Message> DeleteGame(string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<DeleteGameRequest>(request));
            var result = DeleteGame(message.GameId);

            return result ? new DeleteGameResponse { MessageType = MessageType.GameDeleted } : null;
        }

        private static async Task<JoinGameResponse> JoinGame(IWebSocketConnection socket, string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<JoinGameRequest>(request));
            var game = GetGame(message.GameId);

            if (game == null)
            {
                return null;
            }

            game.Subscribe(new Broadcaster(socket));

            var player = new Player { Name = message.PlayerName };
            game.AddPlayer(player);

            return new JoinGameResponse { GameId = game.Id, MessageType = MessageType.GameJoined, PlayerId = player.Id };
        }

        private static ShowGamesResponse ShowGames()
        {
            var retVal = new ShowGamesResponse { MessageType = MessageType.ShowGames, Games = new List<ShowGamesResponse.GameInfo>() };

            foreach (var game in games)
            {
                retVal.Games.Add(new ShowGamesResponse.GameInfo { GameId = game.Id, IsStarted = game.HasStarted, Players = game.Players.Count });
            }

            return retVal;
        }

        private static async Task<GameStatusResponse> GameStatus(string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<GameMessage>(request));
            var game = GetGame(message.GameId);

            var players = game.Players.ToList();
            var cards = game.AvailableCards.ToList();
            var aristocrates = game.AvailableAristocrates.ToList();

            var retVal = new GameStatusResponse
                         {
                             Aristocrates = aristocrates,
                             GameId = game.Id,
                             Cards = cards,
                             CurrentPlayer = game.CurrentPlayer?.Id,
                             FirstPlayer = game.FirstPlayer?.Id,
                             HasFinished = game.HasFinished,
                             HasStarted = game.HasStarted,
                             MessageType = MessageType.GameStatus,
                             Players = players
                         };

            return retVal;
        }
    }
}