namespace SplendorCore.Models.Exceptions.ChipOperationExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class TakeGoldChipsNotAllowed : SplendorChipOperationException
    {
        #region Constructors and Destructors

        public TakeGoldChipsNotAllowed(Player player, Chips chips)
            : base(player, chips)
        {
        }

        #endregion
    }
}