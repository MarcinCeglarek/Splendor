namespace SplendorCommonLibrary.Models
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    using SplendorCommonLibrary.Helpers;

    public class Deck
    {
        private const int VisibleCardsCount = 4;

        private readonly IList<Card> allCards;

        private readonly IList<Card> cardsInBank;

        private readonly IList<Aristocrate> allAristocrates;

        private readonly IList<Aristocrate> availableAristocrates;
 
        public Deck(string deckFilePath, string aristocratesFilePath)
        {
            var deckFileText = GetTextFromFile(deckFilePath);

            this.allCards = JsonConvert.DeserializeObject<List<Card>>(deckFileText);
            this.cardsInBank = this.allCards.Shuffle();

            var aristocratesFileText = GetTextFromFile(aristocratesFilePath);

            this.allAristocrates = JsonConvert.DeserializeObject<List<Aristocrate>>(aristocratesFileText);
            this.availableAristocrates = this.allAristocrates.Shuffle().Take(5).ToList();
        }

        private static string GetTextFromFile(string deckFilePath)
        {
            if (!File.Exists(deckFilePath))
            {
                throw new FileNotFoundException("Data file not found: " + deckFilePath);
            }

            var jsonString = File.ReadAllText(deckFilePath);
            return jsonString;
        }

        public IList<Card> AllCards
        {
            get
            {
                return this.allCards;
            }
        }

        public IList<Aristocrate> AllAristocrates
        {
            get
            {
                return this.allAristocrates;
            }
        }

        public IList<Aristocrate> AvailableAristocrates
        {
            get
            {
                return this.availableAristocrates;
            }
        }

        public IDictionary<int, ICollection<Card>> AvailableCards
        {
            get
            {
                var retVal = new Dictionary<int, ICollection<Card>>();
                for (var i = 1; i <= 3; i++)
                {
                    retVal.Add(i, this.GetVisibleCardsOfTier(i));
                }

                return retVal;
            }
        }


        private ICollection<Card> GetVisibleCardsOfTier(int i)
        {
            return this.cardsInBank.Where(card => card.Tier == i).Take(VisibleCardsCount).ToArray();
        }
    }
}