namespace SplendorConsoleServer
{
    using System;

    using Microsoft.ServiceModel.WebSockets;

    public class EchoService : WebSocketService
    {
        #region Public Methods and Operators

        public override void OnMessage(string message)
        {
            Console.WriteLine("Echoing to client:");
            Console.WriteLine(message);

            this.Send(message);
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