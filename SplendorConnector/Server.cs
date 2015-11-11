namespace SplendorConnector
{
    #region

    using System;
    using System.Net;
    using System.Net.Sockets;

    #endregion

    public class Server
    {
        #region Fields

        private TcpListener Listener;

        private Logger logger;

        #endregion

        #region Constructors and Destructors

        public Server(IPAddress ipAddress, int port)
        {
            this.logger = Logger.Instance();
            this.Listener = new TcpListener(ipAddress, port);
            this.Listener.Start();
            this.logger.Message(string.Format("Server has started on {0}:{1}. Awaiting connection...", ipAddress, port));


            var client = this.Listener.AcceptTcpClient();

            this.logger.Message("A client connected.");
        }

        #endregion
    }
}