namespace SplendorConsoleServer
{
    #region

    using System;

    using Microsoft.ServiceModel.WebSockets;

    #endregion

    public class Program
    {
        #region Methods

        private static void Main(string[] args)
        {
            var host = new WebSocketHost<EchoService>(new Uri("ws://localhost:8000/echo"));
            host.AddWebSocketEndpoint();

            /*
             * To properly run next line:
             * either it must be run as administrator (simpler for dev)
             * or url needs to be allowed to create by current user in system by command:
             * netsh http add urlacl url=http://+:8000/echo user=<username>
             */
            host.Open();

            Console.Read();

            host.Close();
        }

        #endregion
    }
}