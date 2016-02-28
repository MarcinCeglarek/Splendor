namespace SplendorCore.Models.Exceptions.OperationExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class TakeChipsActionException : SplendorCardOperationException
    {
        #region Constructors and Destructors

        public TakeChipsActionException(Player player, Card card)
            : base(player, card)
        {
        }

        #endregion
    }
}