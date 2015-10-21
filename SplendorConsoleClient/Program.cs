namespace SplendorConsoleClient
{
    #region

    using System;
    using System.Threading;

    #endregion

    public class Program
    {
        #region Public Methods and Operators

        public static void Main()
        {
            Thread.Sleep(1000);
            var websocket = WebSocketClient.Connect("ws://localhost:8000/echo").Result;
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        #endregion
    }
}