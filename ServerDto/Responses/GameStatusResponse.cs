﻿namespace ServerDto.Responses
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using ServerDto.Messages.Basic;

    using SplendorCore.Models;

    #endregion

    public class GameStatusResponse : GameMessage
    {
        public List<Aristocrate> Aristocrates { get; set; }

        public Chips Bank { get; set; }

        public Guid? CurrentPlayer { get; set; }

        public Guid? FirstPlayer { get; set; }

        public bool HasStarted { get; set; }

        public bool HasFinished { get; set; }

        public List<Card> Cards { get; set; }

        public List<Player> Players { get; set; }
    }
}