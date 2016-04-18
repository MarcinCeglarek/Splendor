namespace ServerDto
{
    using System;

    using ServerDto.Abstract;

    #region Usings

    

    #endregion

    public class JoinGameRequest : Request
    {
        public Guid GameId { get; set; }

        public string PlayerName { get; set; }
    }
}