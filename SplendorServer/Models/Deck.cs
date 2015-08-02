namespace SplendorServer.Models
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Newtonsoft.Json;

    using SplendorServer.Helpers;

    public class Deck
    {
        private readonly IList<Card> allCards;

        private readonly IList<Card> cardsInBank; 

        private const int VisibleCardsCount = 4;

        public Deck(string deckFilePath)
        {
            if (!File.Exists(deckFilePath))
            {
                throw new FileNotFoundException("Deck file not found: " + deckFilePath);
            }

            var jsonString = File.ReadAllText(deckFilePath);

            this.allCards = JsonConvert.DeserializeObject<List<Card>>(jsonString);
            this.cardsInBank = this.allCards.Shuffle();
        }

        public IList<Card> AllCards
        {
            get
            {
                return this.allCards;
            }
        } 

        public IDictionary<int, ICollection<Card>> GetVisibleCards()
        {
            var retVal = new Dictionary<int, ICollection<Card>>();
            for (var i = 1; i <= 3; i++)
            {
                retVal.Add(i, this.GetVisibleCardsOfTier(i));
            }

            return retVal;
        }

        private ICollection<Card> GetVisibleCardsOfTier(int i)
        {
            return this.cardsInBank.Where(card => card.Tier == i).Take(VisibleCardsCount).ToArray();
        }
    }
}