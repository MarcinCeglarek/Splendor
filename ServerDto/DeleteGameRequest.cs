namespace ServerDto
{
    #region Usings

    using System;

    using ServerDto.Abstract;

    #endregion

    public class DeleteGameRequest : Request
    {
        public Guid GameId { get; set; }
    }
}