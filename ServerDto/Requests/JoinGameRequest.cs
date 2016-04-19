namespace ServerDto.Requests
{
    #region Usings

    using ServerDto.Requests.Basic;

    #endregion

    #region Usings

    #endregion

    public class JoinGameRequest : GameRequest
    {
        public string PlayerName { get; set; }
    }
}