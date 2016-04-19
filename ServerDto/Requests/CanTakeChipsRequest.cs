namespace ServerDto.Requests
{
    #region Usings

    using System;

    using ServerDto.Requests.Basic;

    using SplendorCore.Models;

    #endregion

    public class CanTakeChipsRequest : GameRequest
    {
        public Guid PlayerId { get; set; }

        public Chips Chips { get; set; }
    }
}