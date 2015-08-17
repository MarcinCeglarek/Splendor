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

    public class EchoService : WebSocketService, IBroadcastMessages
    {
        #region Fields

        private Game game;

        private Player player;

        #endregion

        #region Constructors and Destructors

        public EchoService()
        {
            Program.Clients.Add(this);
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

        public void CardPurchased()
        {
            throw new NotImplementedException();
        }

        public void CardReserved()
        {
            throw new NotImplementedException();
        }

        public void ChipsTaken()
        {
            throw new NotImplementedException();
        }

        public void GameEnded()
        {
            throw new NotImplementedException();
        }

        public void GameStarted()
        {
            throw new NotImplementedException();
        }

        public override void OnMessage(string message)
        {
            var method = JsonConvert.DeserializeObject<Request>(message).Method;

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
            }

            this.Send(message);
        }

        public override void OnOpen()
        {
            base.OnOpen();
            this.Log("Socket opened");
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
            this.Log("Socket closed");
        }

        protected override void OnError()
        {
            this.Log("Socket error occured.");
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

        private void HandleConnectMessage(string message)
        {
            this.Log("HandleConnect Request: " + message);
            var request = JsonConvert.DeserializeObject<ConnectRequest>(message);

            this.GetGameFromRequest(request);

            var response = new ConnectResponse() { GameId = this.game.Id, UserId = this.player.Id };
            var responseJson = JsonConvert.SerializeObject(response);
            this.Log("HandleConnect Response: " + responseJson);
            this.Send(responseJson);
        }

        private void HandleGetGameStatus(string message)
        {
            var request = JsonConvert.DeserializeObject<GameRequest>(message);
            this.ValidateRequest(request);

            throw new NotImplementedException();
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
            this.Log("HandleStartGame Request: " + message);
            var request = JsonConvert.DeserializeObject<GameRequest>(message);

            try
            {
                this.game.Start();
                var response = JsonConvert.SerializeObject(new Response() { Type = ResponseType.Ok, Message = Messages.GameStarted });
                this.Log("HandleStartGame Response: " + response);
                this.Send(response);
            }
            catch (SplendorGameException exception)
            {
                var response = JsonConvert.SerializeObject(new Response() { Type = ResponseType.Error, Message = exception.Message });
                this.Log("HandleStartGame Response: " + response);
                this.Send(response);
            }
        }

        private void HandleTakeChips(string message)
        {
            var request = JsonConvert.DeserializeObject<TakeChipsRequest>(message);
            this.ValidateRequest(request);

            throw new NotImplementedException();
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
        }

        private void ValidateRequest(GameRequest request)
        {
            if (this.GameId != request.GameId)
            {
                throw new SplendorServiceInvalidRequestException();
            }
        }

        #endregion
    }
}