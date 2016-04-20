namespace ServerDto.Requests
{
    #region Usings

    using ServerDto.Messages.Basic;

    #endregion

    #region Usings

    #endregion

    public class JoinGameRequest : GameMessage
    {
        public string PlayerName { get; set; }
    }
}