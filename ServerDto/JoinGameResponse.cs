namespace ServerDto
{
    #region Usings

    using System;

    using ServerDto.Abstract;

    #endregion

    public class JoinGameResponse : Response
    {
        public Guid GameId { get; set; }

        public Guid PlayerId { get; set; }
    }
}