namespace ServerDto
{
    #region Usings

    using System;

    #endregion

    public class ChatMessage 
    {
        public Guid GameId { get; set; }

        public Guid PlayerId { get; set; }

        public string Message { get; set; }
    }
}