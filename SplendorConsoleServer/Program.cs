namespace SplendorConsoleServer
{
    #region

    using System;
    using System.Collections.Generic;

    using Microsoft.ServiceModel.WebSockets;

    #endregion

    public class Program
    {
        #region Public Properties

        public static List<SplendorService> Clients { get; set; }

        #endregion

        #region Methods

        private static void Main()
        {
            const string Uri = "ws://localhost:8000/echo";

            Clients = new List<SplendorService>();
            var host = new WebSocketHost<SplendorService>(new Uri(Uri));
            host.AddWebSocketEndpoint();

            /*
             * To properly run next line:
             * either it must be run as administrator (simpler for dev)
             * or url needs to be allowed to create by current user in system by command:
             * netsh http add urlacl url=http://+:8000/echo user=<username>
             */
            host.Open();
            Console.ReadLine();
            host.Close();
        }

        #endregion
    }
}