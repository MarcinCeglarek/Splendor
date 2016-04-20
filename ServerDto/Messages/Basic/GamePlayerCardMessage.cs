namespace ServerDto.Messages.Basic
{
    #region Usings

    using System;

    #endregion

    public class GamePlayerCardMessage : GamePlayerMessage
    {
        public Guid CardId { get; set; }
    }
}