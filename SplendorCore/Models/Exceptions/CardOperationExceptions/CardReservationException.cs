namespace SplendorCore.Models.Exceptions.CardOperationExceptions
{
    #region

    using SplendorCore.Models.Exceptions.AbstractExceptions;

    #endregion

    public class CardReservationException : SplendorCardOperationException
    {
        #region Constructors and Destructors

        public CardReservationException(Player player, Card card)
            : base(player, card)
        {
        }

        #endregion
    }
}