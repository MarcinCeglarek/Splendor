namespace SplendorCore.Models.Exceptions.ChipOperationExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class InvalidTakeActionException : SplendorChipOperationException
    {
        #region Constructors and Destructors

        public InvalidTakeActionException(Player player, Chips chips)
            : base(player, chips)
        {
        }

        #endregion
    }
}