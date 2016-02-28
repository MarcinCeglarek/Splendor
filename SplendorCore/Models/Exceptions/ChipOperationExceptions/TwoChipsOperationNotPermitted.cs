namespace SplendorCore.Models.Exceptions.ChipOperationExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class TwoChipsOperationNotPermitted : SplendorChipOperationException
    {
        #region Constructors and Destructors

        public TwoChipsOperationNotPermitted(Player player, Chips chips)
            : base(player, chips)
        {
        }

        #endregion
    }
}