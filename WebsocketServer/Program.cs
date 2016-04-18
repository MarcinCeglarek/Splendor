namespace WebsocketServer
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Fleck;

    #endregion

    internal class Program
    {
        private static WebSocketServer server;

        private static readonly List<IWebSocketConnection> SocketClients = new List<IWebSocketConnection>();

        private static void Main(string[] args)
        {
            server = new WebSocketServer("ws://0.0.0.0:8181");

            FleckLog.LogAction = (level, message, ex) =>
            {
                switch (level)
                {
                    case LogLevel.Debug:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(message, ex);
                        break;
                    case LogLevel.Error:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(message, ex);
                        break;
                    case LogLevel.Warn:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(message, ex);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(message, ex);
                        break;
                }
            };

            server.Start(
                socket =>
                {
                    socket.OnOpen = () => { SocketClients.Add(socket); };
                    socket.OnClose = () => { SocketClients.Remove(socket); };
                    socket.OnMessage = message => { OnConnectionMessage(socket, message); };
                });

            Console.ReadLine();
        }

        private static async void OnConnectionMessage(IWebSocketConnection socket, string message)
        {
            try
            {
                Console.WriteLine(message);
                var response = await GameProcessor.Instance().ProcessMessage(message);
                await socket.Send(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}