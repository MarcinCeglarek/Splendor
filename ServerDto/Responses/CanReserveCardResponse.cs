using ServerDto.Messages.Basic;

namespace ServerDto.Responses
{
    #region Usings

    

    #endregion

    public class CanReserveCardResponse : GamePlayerCardMessage
    {
        public bool Result { get; set; }
    }
}