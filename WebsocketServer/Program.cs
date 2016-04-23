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
    using ServerDto.Messages.Basic;
    using ServerDto.Requests;
    using ServerDto.Responses;
    using SplendorCore.Models;

    #endregion

    public class Program
    {
        private static WebSocketServer server;

        private static readonly List<Game> Games = new List<Game>();

        private static readonly List<IWebSocketConnection> SocketClients = new List<IWebSocketConnection>();

        private static Game GetGame(Guid id)
        {
            return Games.SingleOrDefault(game => game.Id == id);
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
                    socket.OnOpen = () => { SocketClients.Add(socket); };
                    socket.OnClose = () => { SocketClients.Remove(socket); };
                    socket.OnMessage = message => { OnMessage(socket, message); };
                });

            Console.ReadLine();
        }

        private static async void OnMessage(IWebSocketConnection socket, string message)
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

        private static async Task<string> ProcessMessage(IWebSocketConnection socket, string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Message>(request));
            Message response = null;

            switch (message.MessageType)
            {
                case MessageType.ShowGames:
                    response = ShowGames();
                    break;

                case MessageType.CreateGame:
                    await CreateGame();
                    break;

                case MessageType.DeleteGame:
                    await DeleteGame(request);
                    break;

                case MessageType.JoinGame:
                    response = await JoinGame(socket, request);
                    break;

                case MessageType.GameStatus:
                    response = await GameStatus(request);
                    break;

                case MessageType.Subscribe:
                    Subscribe(socket, request);
                    break;

                case MessageType.Unsubscribe:
                    Unsubscribe(socket, request);
                    break;

                case MessageType.GameStarted:
                    await StartGame(request);
                    break;

                case MessageType.CanTakeChips:
                    response = await CanTakeChips(request);
                    break;

                case MessageType.CanPurchaseCard:
                    response = await CanPurchaseCard(request);
                    break;

                case MessageType.CanReserveCard:
                    response = await CanReserveCard(request);
                    break;

                case MessageType.TakeChips:
                    await TakeChips(request);
                    break;

                case MessageType.ReserveCard:
                    await ReserveCard(request);
                    break;

                case MessageType.PurchaseCard:
                    await PurchaseCard(request);
                    break;


                default:
                    throw new NotImplementedException();
            }

            return await Task.Factory.StartNew(() => JsonConvert.SerializeObject(response));
        }

        #region Games management

        private static ShowGamesResponse ShowGames()
        {
            var retVal = new ShowGamesResponse
            {
                MessageType = MessageType.ShowGames,
                Games = new List<ShowGamesResponse.GameInfo>()
            };

            foreach (var game in Games)
            {
                retVal.Games.Add(new ShowGamesResponse.GameInfo
                {
                    GameId = game.Id,
                    IsStarted = game.HasStarted,
                    Players = game.Players.Count
                });
            }

            return retVal;
        }

        private static async Task CreateGame()
        {
            var game = new Game();
            Games.Add(game);
            await BroadcastMessage(new CreateGameResponse {GameId = game.Id, MessageType = MessageType.GameCreated});
        }

        private static async Task DeleteGame(string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<DeleteGameRequest>(request));
            if (DeleteGame(message.GameId))
            {
                await
                    BroadcastMessage(new CreateGameResponse
                    {
                        GameId = message.GameId,
                        MessageType = MessageType.GameDeleted
                    });
            }
        }

        private static bool DeleteGame(Guid id)
        {
            var game = GetGame(id);

            if (game != null && !game.HasStarted && game.Players.Count == 0)
            {
                Games.Remove(game);
                return true;
            }

            return false;
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

            var player = new Player {Name = message.PlayerName};
            game.AddPlayer(player);

            await
                BroadcastMessage(new CreateGameResponse
                {
                    GameId = message.GameId,
                    MessageType = MessageType.PlayerJoined
                });

            return new JoinGameResponse {GameId = game.Id, MessageType = MessageType.GameJoined};
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

        private static async Task StartGame(string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<GameMessage>(request));
            var game = GetGame(message.GameId);


            game?.Start();
            if (game != null && game.HasStarted)
            {
                await
                    BroadcastMessage(new CreateGameResponse
                    {
                        GameId = message.GameId,
                        MessageType = MessageType.GameStarted
                    });
            }
        }

        #endregion

        private static async Task<Message> CanTakeChips(string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CanTakeChipsRequest>(request));
            var game = GetGame(message.GameId);

            var result = game.CanTakeChips(game.Players.Single(p => p.Id == message.PlayerId), message.Chips);
            return new CanTakeChipsResponse
            {
                MessageType = MessageType.CanTakeChips,
                GameId = game.Id,
                PlayerId = message.PlayerId,
                Result = result
            };
        }

        private static async Task<Message> CanReserveCard(string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<GamePlayerCardMessage>(request));
            var game = GetGame(message.GameId);

            var result = game.CanReserveCard(game.Players.Single(p => p.Id == message.PlayerId), game.AllCards.Single(c => c.Id == message.CardId));
            return new CanReserveCardResponse
            {
                MessageType = MessageType.CanReserveCard,
                GameId = game.Id,
                PlayerId = message.PlayerId,
                CardId = message.CardId,
                Result = result
            };
        }

        private static async Task<Message> CanPurchaseCard(string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<GamePlayerCardMessage>(request));
            var game = GetGame(message.GameId);

            var result = game.CanPurchaseCard(game.Players.Single(p => p.Id == message.PlayerId), game.AllCards.Single(c => c.Id == message.CardId));
            return new CanPurchaseCardResponse
            {
                MessageType = MessageType.CanPurchaseCard,
                GameId = game.Id,
                PlayerId = message.PlayerId,
                CardId = message.CardId,
                Result = result
            };
        }

        private static async Task TakeChips(string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<CanTakeChipsRequest>(request));
            var game = GetGame(message.GameId);

            game.TakeChips(game.Players.Single(p => p.Id == message.PlayerId), message.Chips);
        }

        private static async Task ReserveCard(string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<GamePlayerCardMessage>(request));
            var game = GetGame(message.GameId);

            game.ReserveCard(game.Players.Single(p => p.Id == message.PlayerId), game.AllCards.Single(c => c.Id == message.CardId));
        }

        private static async Task PurchaseCard(string request)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<GamePlayerCardMessage>(request));
            var game = GetGame(message.GameId);

            game.PurchaseCard(game.Players.Single(p => p.Id == message.PlayerId), game.AllCards.Single(c => c.Id == message.CardId));
        }

        #region Utilities

        private static async Task BroadcastMessage(Message message)
        {
            var messageString = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(message));

            foreach (var connection in SocketClients)
            {
                await connection.Send(messageString);
            }
        }

        #endregion
    }
}