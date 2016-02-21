namespace SplendorCore.Models.Exceptions.OperationExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class InsuficentPlayerResourcesException : SplendorCardOperationException
    {
        #region Constructors and Destructors

        public InsuficentPlayerResourcesException(Player player, Card card)
            : base(player, card)
        {
        }

        #endregion
    }
}