﻿namespace ServerDto.Requests
{
    #region Usings

    using ServerDto.Messages.Basic;

    using SplendorCore.Models;

    #endregion

    public class CanTakeChipsRequest : GamePlayerMessage
    {
        public Chips Chips { get; set; }
    }
}