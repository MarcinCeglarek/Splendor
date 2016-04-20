namespace ServerDto.Messages.Basic
{
    #region Usings

    using System;

    #endregion

    public class GamePlayerMessage : GameMessage
    {
        public Guid PlayerId { get; set; }
    }
}