namespace SplendorCore.Models.Exceptions.ChipOperationExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class ResourcesOverflowException : SplendorChipOperationException
    {
        #region Constructors and Destructors

        public ResourcesOverflowException(Player player, Chips chips)
            : base(player, chips)
        {
        }

        #endregion
    }
}