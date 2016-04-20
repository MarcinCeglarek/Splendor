namespace ServerDto.Messages.Basic
{
    #region Usings

    using System;

    #endregion

    public class GameMessage : Message
    {
        public Guid GameId { get; set; }
    }
}