namespace SplendorCore.Models.Exceptions.ChipOperationExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class BankResourcesExhaustedException : SplendorChipOperationException
    {
        #region Constructors and Destructors

        public BankResourcesExhaustedException(Player player, Chips chips)
            : base(player, chips)
        {
        }

        #endregion
    }
}