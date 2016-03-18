namespace SplendorCore.Models.Exceptions.CardExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    internal class InvalidCardException : SplendorCardException
    {
        public InvalidCardException(Card card)
            : base(card)
        {
        }
    }
}