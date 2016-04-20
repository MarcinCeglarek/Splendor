namespace ServerDto.Responses
{
    #region Usings

    using ServerDto.Messages.Basic;

    #endregion

    public class CanTakeChipsResponse : GamePlayerMessage
    {
        public bool CanTakeChips { get; set; }
    }
}