namespace ServerDto.Responses
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using ServerDto.Messages.Basic;

    #endregion

    public class ShowGamesResponse : Message
    {
        public List<GameInfo> Games { get; set; }

        public class GameInfo
        {
            public Guid GameId { get; set; }

            public bool IsStarted { get; set; }

            public int Players { get; set; }
        }
    }
}