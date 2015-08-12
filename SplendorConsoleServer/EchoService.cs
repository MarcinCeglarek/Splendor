namespace SplendorConsoleServer
{
    using System;

    using Microsoft.ServiceModel.WebSockets;

    using Newtonsoft.Json;

    using SplendorConsoleServer.Models;
    using SplendorConsoleServer.Models.Abstract;
    using SplendorConsoleServer.Models.Enums;

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
            }

            this.Send(message);
        }

        private void HandleConnectMessage(string message)
        {
            var connectRequest = JsonConvert.DeserializeObject<ConnectRequest>(message);

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

        #endregion
    }
}