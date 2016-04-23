﻿namespace ServerDto.Responses
{
    #region Usings

    using ServerDto.Messages.Basic;

    #endregion

    public class CanTakeChipsResponse : GamePlayerMessage
    {
        public bool Result { get; set; }
    }
}