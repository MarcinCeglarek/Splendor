namespace SplendorCore.Models
{
    #region

    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;

    using Newtonsoft.Json;

    using SplendorCore.Helpers;
    using SplendorCore.Models.Exceptions.AristocrateExceptions;
    using SplendorCore.Models.Exceptions.CardExceptions;
    using SplendorCore.Models.Exceptions.FileExceptions;

    #endregion

    [DataContract]
    public class Deck
    {
        #region Constants

        private const int VisibleCardsCount = 4;

        #endregion

        #region Fields

        private readonly List<Card> allCards;

        private readonly Game game;

        private List<Aristocrate> allAristocrates;

        private List<Aristocrate> aristocratesInBank;

        private List<Card> cardsInBank;

        #endregion

        #region Constructors and Destructors

        public Deck(Game game, string deckFilePath, string aristocratesFilePath)
        {
            this.game = game;

            var deckFileText = GetTextFromFile(deckFilePath);
            this.allCards = JsonConvert.DeserializeObject<List<Card>>(deckFileText);
            this.AllCards = new ReadOnlyCollection<Card>(this.allCards);

            var aristocratesFileText = GetTextFromFile(aristocratesFilePath);
            this.AllAristocrates = JsonConvert.DeserializeObject<ReadOnlyCollection<Aristocrate>>(aristocratesFileText);
            this.aristocratesInBank = new List<Aristocrate>();
            this.AvailableAristocrates = new ReadOnlyCollection<Aristocrate>(this.aristocratesInBank);
        }

        #endregion

        #region Public Properties

        public ReadOnlyCollection<Aristocrate> AllAristocrates { get; private set; }

        public ReadOnlyCollection<Card> AllCards { get; private set; }

        [DataMember]
        public ReadOnlyCollection<Aristocrate> AvailableAristocrates { get; private set; }

        [DataMember]
        public ReadOnlyCollection<Card> AvailableCards
        {
            get
            {
                var retVal = new List<Card>();
                for (var i = 1; i <= 3; i++)
                {
                    retVal.AddRange(this.GetVisibleCardsOfTier(i));
                }

                return new ReadOnlyCollection<Card>(retVal);
            }
        }

        #endregion

        #region Public Methods and Operators

        public void Initialize()
        {
            this.cardsInBank = new List<Card>();
            this.cardsInBank.AddRange(this.allCards);
            this.cardsInBank = this.cardsInBank.Shuffle();

            var numberOfAristocrates = this.game.Players.Count + 1;
            this.aristocratesInBank = new List<Aristocrate>();
            this.aristocratesInBank.AddRange(this.AllAristocrates);
            this.aristocratesInBank = this.aristocratesInBank.Shuffle().Take(numberOfAristocrates).ToList();

            this.AvailableAristocrates = new ReadOnlyCollection<Aristocrate>(this.aristocratesInBank);
        }

        public void RemoveAristocrate(Aristocrate aristocrate)
        {
            if (this.aristocratesInBank.Contains(aristocrate))
            {
                this.aristocratesInBank.Remove(aristocrate);
                return;
            }

            throw new AristocrateUnavailableException(aristocrate);
        }

        public void RemoveCard(Card card)
        {
            if (this.cardsInBank.Contains(card))
            {
                this.cardsInBank.Remove(card);
                return;
            }

            throw new CardUnavailableException(card);
        }

        #endregion

        #region Methods

        private static string GetTextFromFile(string deckFilePath)
        {
            if (!File.Exists(deckFilePath))
            {
                throw new DeckFileNotFoundException(deckFilePath);
            }

            var jsonString = File.ReadAllText(deckFilePath);
            return jsonString;
        }

        private IEnumerable<Card> GetVisibleCardsOfTier(int i)
        {
            if (this.cardsInBank == null)
            {
                return new List<Card>();
            }

            return this.cardsInBank.Where(card => card.Tier == i).Take(VisibleCardsCount).ToArray();
        }

        #endregion
    }
}