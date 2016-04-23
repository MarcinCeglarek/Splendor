using System;
using ServerDto.Messages.Basic;

namespace ServerDto.Messages
{
    #region Usings

    

    #endregion

    public class ChatMessage : GamePlayerMessage
    {
        public DateTime Timestamp { get; set; }

        public string Message { get; set; }
    }
}