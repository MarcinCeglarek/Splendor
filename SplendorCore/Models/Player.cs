namespace SplendorCore.Models
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using SplendorCore.Models.Exceptions.CardExceptions;
    using SplendorCore.Models.Exceptions.CardOperationExceptions;

    #endregion

    public class Player
    {
        #region Constructors and Destructors

        public Player()
        {
            this.Id = Guid.NewGuid();
            this.Chips = new Chips();

            this.ownedCards = new List<Card>();
            this.reservedCards = new List<Card>();
            this.ownedAristocrates = new List<Aristocrate>();

            this.OwnedCards = new ReadOnlyCollection<Card>(this.ownedCards);
            this.ReservedCards = new ReadOnlyCollection<Card>(this.reservedCards);
            this.OwnedAristocrates = new ReadOnlyCollection<Aristocrate>(this.ownedAristocrates);
        }

        #endregion

        #region Fields

        private readonly List<Aristocrate> ownedAristocrates;

        private readonly List<Card> ownedCards;

        private readonly List<Card> reservedCards;

        #endregion

        #region Public Properties

        public Chips Cards
        {
            get
            {
                return new Chips(
                    this.OwnedCards.Count(o => o.Color == Color.White),
                    this.OwnedCards.Count(o => o.Color == Color.Blue),
                    this.OwnedCards.Count(o => o.Color == Color.Green),
                    this.OwnedCards.Count(o => o.Color == Color.Red),
                    this.OwnedCards.Count(o => o.Color == Color.Black),
                    0);
            }
        }

        public Chips Chips { get; set; }

        public Chips ChipsAndCards
        {
            get
            {
                var retVal = this.Chips + this.Cards;
                return retVal;
            }
        }

        public Game Game { get; set; }

        public Guid Id { get; }

        public string Name { get; set; }

        public ReadOnlyCollection<Aristocrate> OwnedAristocrates { get; }

        public ReadOnlyCollection<Card> OwnedCards { get; }

        public ReadOnlyCollection<Card> ReservedCards { get; private set; }

        public int VictoryPoints { get { return this.OwnedCards.Sum(card => card.VictoryPoints) + this.OwnedAristocrates.Sum(aristocrate => aristocrate.VictoryPoints); } }

        #endregion

        #region Public Methods and Operators

        public void AddOwnedAristocrate(Aristocrate aristocrate)
        {
            this.ownedAristocrates.Add(aristocrate);
        }

        public void AddOwnedCard(Card card)
        {
            if (this.ownedCards.Contains(card))
            {
                throw new InvalidCardException(card);
            }

            this.ownedCards.Add(card);
        }

        public void AddReservedCard(Card card)
        {
            if (this.reservedCards.Contains(card) || this.reservedCards.Count >= 3)
            {
                throw new CardReservationException(this, card);
            }

            this.reservedCards.Add(card);
        }

        public bool Equals(Player player)
        {
            return this.Id == player.Id;
        }

        public Chips GetCardCost(Card card)
        {
            var result = new Chips();
            var costReducesOfMines = card.Cost - this.Cards;

            foreach (var cardChipCost in costReducesOfMines.Where(color => color.Value > 0))
            {
                if (cardChipCost.Value > this.Chips[cardChipCost.Key])
                {
                    var requiredGold = cardChipCost.Value - this.Chips[cardChipCost.Key];
                    if (requiredGold > this.Chips[Color.Gold])
                    {
                        throw new PurchaseCardException(this, card);
                    }

                    result[cardChipCost.Key] = this.Chips[cardChipCost.Key];
                    result[Color.Gold] += requiredGold;
                }
                else
                {
                    result[cardChipCost.Key] = cardChipCost.Value;
                }
            }

            return result;
        }

        public void RemoveReservedCard(Card card)
        {
            if (this.reservedCards.Contains(card))
            {
                this.reservedCards.Remove(card);
            }
        }

        public override string ToString()
        {
            return this.Name;
        }

        #endregion
    }
}