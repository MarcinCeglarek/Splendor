namespace ServerDto
{
    #region Usings

    using System;

    using ServerDto.Abstract;

    #endregion

    public class CreateGameResponse : Response
    {
        public Guid GameId;
    }
}