namespace ServerDto.Messages
{
    #region Usings

    using ServerDto.Messages.Basic;

    using SplendorCore.Models;

    #endregion

    public class ChipsTakenMessage : GamePlayerMessage
    {
        public Chips Chips { get; set; }
    }
}