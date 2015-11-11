namespace SplendorConsoleClient
{
    #region

    using System;
    using System.Threading;
    using System.Xml;

    using Newtonsoft.Json;

    using SplendorConsoleServer.Models;

    #endregion

    public class Program
    {
        #region Public Methods and Operators

        public static void Main()
        {
            Thread.Sleep(1000);
            var websocket = WebSocketClient.Connect("ws://localhost:8000/echo").Result;
            
            var x = WebSocketClient.Send(websocket, JsonConvert.SerializeObject(new ConnectRequest() { UserName = "Player 1" }));
            x.Start();
           

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        #endregion
    }
}