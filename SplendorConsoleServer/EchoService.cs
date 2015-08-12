namespace SplendorConsoleServer
{
    #region

    using System;

    using Microsoft.ServiceModel.WebSockets;

    using Newtonsoft.Json;

    using SplendorCommonLibrary.Models;
    using SplendorCommonLibrary.Models.Exceptions;

    using SplendorConsoleServer.Models;
    using SplendorConsoleServer.Models.Enums;
    using SplendorConsoleServer.Resources;

    #endregion

    public class EchoService : WebSocketService
    {
        #region Public Methods and Operators

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

        private void HandleStartGame(string message)
        {
            this.Log("HandleStartGame Request: " + message);
            var request = JsonConvert.DeserializeObject<GameRequest>(message);
            var game = GameController.Instance.GetGameById(request.GameId);

            try
            {
                game.Start();
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

        public override void OnOpen()
        {
            base.OnOpen();
            Console.WriteLine("WebSocket opened.");
        }

        #endregion

        #region Methods

        protected override void OnClose()
        {
            base.OnClose();
            Console.WriteLine("WebSocket closed.");
        }

        protected override void OnError()
        {
            base.OnError();
            Console.WriteLine("WebSocket error occured.");
        }

        private void HandleConnectMessage(string message)
        {
            this.Log("HandleConnect Request: " + message);
            var request = JsonConvert.DeserializeObject<ConnectRequest>(message);
            var player = new Player()
                           {
                               Name = request.UserName
                           };

            var game = GameController.Instance.GetUnstartedGame();
            game.Players.Add(player);

            var response = new ConnectResponse() { GameId = game.Id, UserId = player.Id };
            var responseJson = JsonConvert.SerializeObject(response);
            this.Log("HandleConnect Response: " + responseJson);
            this.Send(responseJson);
        }

        private void HandleGetGameStatus(string message)
        {
            var request = JsonConvert.DeserializeObject<GameRequest>(message);
            var game = GameController.Instance.GetGameById(request.GameId);

            throw new NotImplementedException();
        }

        private void HandlePurchaseCard(string message)
        {
            var request = JsonConvert.DeserializeObject<GetCardRequest>(message);
            var game = GameController.Instance.GetGameById(request.GameId);

            throw new NotImplementedException();
        }

        private void HandleReserveCard(string message)
        {
            var request = JsonConvert.DeserializeObject<GetCardRequest>(message);
            var game = GameController.Instance.GetGameById(request.GameId);

            throw new NotImplementedException();
        }

        private void HandleTakeChips(string message)
        {
            var request = JsonConvert.DeserializeObject<TakeChipsRequest>(message);
            var game = GameController.Instance.GetGameById(request.GameId);

            throw new NotImplementedException();
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
        }

        #endregion
    }
}