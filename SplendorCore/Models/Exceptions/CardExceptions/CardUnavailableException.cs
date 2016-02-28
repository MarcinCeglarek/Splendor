namespace SplendorCore.Models.Exceptions.CardExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class CardUnavailableException : SplendorCardException
    {
        #region Constructors and Destructors

        public CardUnavailableException(Card card)
            : base(card)
        {
        }

        #endregion
    }
}