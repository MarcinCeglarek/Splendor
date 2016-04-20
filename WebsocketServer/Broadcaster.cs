namespace WebsocketServer
{
    #region Usings

    using System.Threading.Tasks;

    using Fleck;

    using Newtonsoft.Json;

    using ServerDto.Enums;
    using ServerDto.Messages;
    using ServerDto.Messages.Basic;

    using SplendorCore.Interfaces;
    using SplendorCore.Models;
    using SplendorCore.Models.History;

    #endregion

    public class Broadcaster : IBroadcastMessages
    {
        private readonly IWebSocketConnection socket;

        public Broadcaster(IWebSocketConnection socket)
        {
            this.socket = socket;
        }

        public async void CardPurchased(Game game, Player player, Card card)
        {
            var message =
                await
                Task.Factory.StartNew(
                    () =>
                    JsonConvert.SerializeObject(new GamePlayerCardMessage { GameId = game.Id, PlayerId = player.Id, CardId = card.Id, MessageType = MessageType.PurchaseCard }));
            await this.SendMessage(message);
        }

        public async void CardReserved(Game game, Player player, Card card)
        {
            var message =
                await
                Task.Factory.StartNew(
                    () =>
                    JsonConvert.SerializeObject(new GamePlayerCardMessage { GameId = game.Id, PlayerId = player.Id, CardId = card.Id, MessageType = MessageType.PurchaseCard }));
            await this.SendMessage(message);
        }

        public async void ChatMessage(Game game, ChatEntry chatEntry)
        {
        }

        public async void ChipsTaken(Game game, Player player, Chips chips)
        {
            var message =
                await
                Task.Factory.StartNew(
                    () => JsonConvert.SerializeObject(new ChipsTakenMessage { GameId = game.Id, PlayerId = player.Id, Chips = chips, MessageType = MessageType.PurchaseCard }));
            await this.SendMessage(message);
        }

        public async void GameEnded(Game game)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(new GameMessage { GameId = game.Id, MessageType = MessageType.GameFinished }));
            await this.SendMessage(message);
        }

        public async void GameStarted(Game game)
        {
            var message = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(new GameMessage { GameId = game.Id, MessageType = MessageType.GameStarted }));
            await this.SendMessage(message);
        }

        public async void PlayerJoined(Game game, Player player)
        {
            var message =
                await
                Task.Factory.StartNew(() => JsonConvert.SerializeObject(new PlayerJoinedMessage { GameId = game.Id, PlayerId = player.Id, MessageType = MessageType.PlayerJoined }));
            await this.SendMessage(message);
        }

        public async void PlayerLeft(Game game, Player player)
        {
            var message =
                await
                Task.Factory.StartNew(() => JsonConvert.SerializeObject(new PlayerLeftMessage { GameId = game.Id, PlayerId = player.Id, MessageType = MessageType.PlayerLeft }));
            await this.SendMessage(message);
        }

        private async Task SendMessage(string message)
        {
            if (this.socket.IsAvailable)
            {
                await this.socket.Send(message);
            }
        }
    }
}