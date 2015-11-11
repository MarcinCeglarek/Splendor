namespace SplendorConsoleClient
{
    #region

    using System;
    using System.Net.WebSockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    #endregion

    public class WebSocketClient
    {
        #region Constants

        private const int ReceiveChunkSize = 256;

        private const int SendChunkSize = 256;

        private const bool Verbose = true;

        #endregion

        #region Static Fields

        private static readonly object ConsoleLock = new object();

        private static readonly TimeSpan Delay = TimeSpan.FromMilliseconds(30000);

        private static readonly UTF8Encoding Encoder = new UTF8Encoding();

        #endregion

        #region Public Methods and Operators

        public static async Task<ClientWebSocket> Connect(string uri)
        {
            ClientWebSocket webSocket = null;

            try
            {
                webSocket = new ClientWebSocket();
                await webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex);
            }
            finally
            {
                if (webSocket != null)
                {
                    webSocket.Dispose();
                }

                Console.WriteLine();

                lock (ConsoleLock)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("WebSocket closed.");
                    Console.ResetColor();
                }
            }

            return webSocket;
        }

        #endregion

        #region Methods

        private static void LogStatus(bool receiving, byte[] buffer, int length)
        {
            lock (ConsoleLock)
            {
                Console.ForegroundColor = receiving ? ConsoleColor.Green : ConsoleColor.Gray;

                // Console.WriteLine("{0} ", receiving ? "Received" : "Sent");
                if (Verbose)
                {
                    Console.WriteLine(Encoder.GetString(buffer));
                }

                Console.ResetColor();
            }
        }

        public static async Task Receive(ClientWebSocket webSocket)
        {
            var buffer = new byte[ReceiveChunkSize];
            while (webSocket.State == WebSocketState.Open)
            {
                var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                }
                else
                {
                    LogStatus(true, buffer, result.Count);
                }
            }
        }

        public static async Task Send(ClientWebSocket webSocket, string message)
        {
            var buffer = Encoder.GetBytes(message);
            await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);

            while (webSocket.State == WebSocketState.Open)
            {
                LogStatus(false, buffer, buffer.Length);
                await Task.Delay(Delay);
            }
        }

        #endregion
    }
}