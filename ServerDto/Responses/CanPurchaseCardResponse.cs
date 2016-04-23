namespace ServerDto.Responses
{
    using ServerDto.Messages.Basic;

    #region Usings

    #endregion

    public class CanPurchaseCardResponse : GamePlayerCardMessage
    {
        public bool Result { get; set; }
    }
}