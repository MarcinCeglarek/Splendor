namespace ServerDto.Responses
{
    #region Usings

    using System;

    using ServerDto.Responses.Basic;

    #endregion

    public class JoinGameResponse : Response
    {
        public Guid GameId { get; set; }

        public Guid PlayerId { get; set; }
    }
}