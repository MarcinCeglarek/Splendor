namespace ServerDto.Requests.Basic
{
    #region Usings

    using System;

    #endregion

    public class GameRequest : Request
    {
        public Guid GameId { get; set; }
    }
}