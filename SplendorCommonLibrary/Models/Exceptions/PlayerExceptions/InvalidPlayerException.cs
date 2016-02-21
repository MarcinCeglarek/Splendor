namespace SplendorCore.Models.Exceptions.PlayerExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class InvalidPlayerException : SplendorPlayerException
    {
        #region Constructors and Destructors

        public InvalidPlayerException(Player player)
            : base(player)
        {
        }

        #endregion
    }
}