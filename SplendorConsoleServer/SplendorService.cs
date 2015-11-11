namespace SplendorConsoleServer
{
    #region

    using System;
    using System.Linq;

    using Microsoft.ServiceModel.WebSockets;

    using Newtonsoft.Json;

    using SplendorCommonLibrary.Interfaces;
    using SplendorCommonLibrary.Models;
    using SplendorCommonLibrary.Models.Exceptions;

    using SplendorConsoleServer.Models;
    using SplendorConsoleServer.Models.Enums;
    using SplendorConsoleServer.Models.Exceptions;
    using SplendorConsoleServer.Resources;

    #endregion

    public class SplendorService : WebSocketService, IBroadcastMessages
    {
        #region Fields

        private readonly Logger log;

        private Game game;

        private Player player;

        #endregion

        #region Constructors and Destructors

        public SplendorService()
        {
            Program.Clients.Add(this);
            this.log = new Logger();
            this.log.Message("Client added");
        }

        #endregion

        #region Public Properties

        public Guid GameId
        {
            get
            {
                return this.game.Id;
            }
        }

        public Guid PlayerId
        {
            get
            {
                return this.player.Id;
            }
        }

        #endregion

        #region Public Methods and Operators

        public void CardPurchased(Game game)
        {
            this.log.Message("CardPurchased");

            throw new NotImplementedException();
        }

        public void CardReserved(Game game)
        {
            this.log.Message("CardRserverd");
            throw new NotImplementedException();
        }

        public void ChatMessage(ChatEntry chatEntry)
        {
            this.log.Message("ChatMessage");
            this.SendObject(chatEntry);
        }

        public void ChipsTaken(Game game)
        {
            this.log.Message("ChipsTaken");
            throw new NotImplementedException();
        }

        public void GameEnded(Game game)
        {
            this.log.Message("GameEnded");
            throw new NotImplementedException();
        }

        public void GameStarted(Game game)
        {
            this.log.Message("GameStarted");
            throw new NotImplementedException();
        }

        public override void OnMessage(string message)
        {
            this.log.Message("OnMessage:" + message);
            MethodType method;
            try
            {
                method = JsonConvert.DeserializeObject<Request>(message).Method;
            }
            catch (JsonSerializationException e)
            {
                this.log.Error(e.Message);
                return;
            }

            try
            {
                switch (method)
                {
                    case MethodType.Connect:
                        this.HandleConnectMessage(message);
                        break;
                    case MethodType.StartGame:
                        this.HandleStartGame(message);
                        break;
                    case MethodType.GetGameStatus:
                        this.HandleGetGameStatus(message);
                        break;
                    case MethodType.PurchaseCard:
                        this.HandlePurchaseCard(message);
                        break;
                    case MethodType.ReserveCard:
                        this.HandleReserveCard(message);
                        break;
                    case MethodType.TakeChips:
                        this.HandleTakeChips(message);
                        break;
                    case MethodType.ChatMessage:
                        this.HandleChatMessage(message);
                        break;
                    default:
                        this.HandleInvalidMessage(message);
                        break;
                }
            }
            catch (SplendorServiceException e)
            {
                this.log.Error(e.Message);
            }
        }

        public override void OnOpen()
        {
            base.OnOpen();
            this.log.Message("Socket opened");
        }

        #endregion

        #region Methods

        protected override void Dispose(bool disposing)
        {
            if (this.game != null)
            {
                this.game.Unsubscribe(this);
            }

            if (Program.Clients.Contains(this))
            {
                Program.Clients.Remove(this);
            }

            base.Dispose(disposing);
        }

        protected override void OnClose()
        {
            base.OnClose();
            this.log.Message("Socket closed");
        }

        protected override void OnError()
        {
            this.log.Message("Socket error occured.");
            base.OnError();
        }

        private void GetGameFromRequest(ConnectRequest request)
        {
            if (request.GameId == null && request.PlayerId == null)
            {
                this.game = GameController.Instance.GetUnstartedGame();
                this.player = new Player() { Name = request.UserName };
                this.game.Players.Add(this.player);
            }
            else if (request.GameId.HasValue && request.PlayerId.HasValue)
            {
                this.game = GameController.Instance.GetGameById(request.GameId.Value);
                this.player = this.game.Players.Single(gamePlayer => gamePlayer.Id == request.PlayerId);
            }
            else
            {
                throw new SplendorServiceInvalidRequestException();
            }

            this.game.Subscribe(this);
        }

        private void HandleChatMessage(string message)
        {
            var request = JsonConvert.DeserializeObject<ChatMessage>(message);
            this.ValidateRequest(request);

            this.game.ChatMessage(this.player, request.Message);
        }

        private void HandleConnectMessage(string message)
        {
            this.log.Message("HandleConnect Request: " + message);
            var request = JsonConvert.DeserializeObject<ConnectRequest>(message);

            this.GetGameFromRequest(request);

            var response = new ConnectResponse() { GameId = this.game.Id, UserId = this.player.Id };
            this.SendObject(response);
        }

        private void HandleGetGameStatus(string message)
        {
            var request = JsonConvert.DeserializeObject<GameRequest>(message);
            this.ValidateRequest(request);

            throw new NotImplementedException();
        }

        private void HandleInvalidMessage(string message)
        {
            this.log.Message("HandleInvalidMessage");
            this.Send("Invalid message");
        }

        private void HandlePurchaseCard(string message)
        {
            var request = JsonConvert.DeserializeObject<GetCardRequest>(message);
            this.ValidateRequest(request);

            throw new NotImplementedException();
        }

        private void HandleReserveCard(string message)
        {
            var request = JsonConvert.DeserializeObject<GetCardRequest>(message);
            this.ValidateRequest(request);

            throw new NotImplementedException();
        }

        private void HandleStartGame(string message)
        {
            this.log.Message("HandleStartGame Request: " + message);
            var request = JsonConvert.DeserializeObject<GameRequest>(message);

            try
            {
                this.game.Start();
                var response = JsonConvert.SerializeObject(new Response() { Type = ResponseType.Ok, Message = Messages.GameStarted });
                this.log.Message("HandleStartGame Response: " + response);
                this.Send(response);
            }
            catch (SplendorGameException exception)
            {
                var response = JsonConvert.SerializeObject(new Response() { Type = ResponseType.Error, Message = exception.Message });
                this.log.Message("HandleStartGame Response: " + response);
                this.Send(response);
            }
        }

        private void HandleTakeChips(string message)
        {
            var request = JsonConvert.DeserializeObject<TakeChipsRequest>(message);
            this.ValidateRequest(request);

            throw new NotImplementedException();
        }

        private void SendObject(object objectToSend)
        {
            var responseJson = JsonConvert.SerializeObject(objectToSend);
            this.log.Debug("Sending: " + responseJson);
            this.Send(responseJson);
        }

        private void ValidateRequest(GameRequest request)
        {
            if (this.GameId != request.GameId)
            {
                var message = "Invalid game ID: " + request.GameId;
                this.Send(message);
                throw new SplendorServiceInvalidRequestException(message);
            }

            if (this.game.CurrentPlayer.Id != request.UserId)
            {
                var message = "Invalid user ID: " + request.UserId;
                this.Send(message);
                throw new SplendorServiceInvalidRequestException(message);
            }
        }

        #endregion
    }
}