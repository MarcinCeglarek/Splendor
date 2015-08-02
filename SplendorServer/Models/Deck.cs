namespace MvcApplication1.Models
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using MvcApplication1.Helpers;

    using Newtonsoft.Json;

    public class Deck
    {
        private ICollection<Card> cards;

        private const int visibleCardsCount = 4;

        public Deck(string deckFilePath)
        {
            if (!File.Exists(deckFilePath))
            {
                throw new FileNotFoundException("Deck file not found: " + deckFilePath);
            }

            var jsonString = File.ReadAllText(deckFilePath);

            this.cards = JsonConvert.DeserializeObject<List<Card>>(jsonString).Shuffle();
        }

        public IDictionary<int, ICollection<Card>> GetVisibleCards()
        {
            var retVal = new Dictionary<int, ICollection<Card>>();
            for (int i = 1; i <= 3; i++)
            {
                retVal.Add(i, this.GetVisibleCardsOfTier(i));
            }

            return retVal;
        }

        private ICollection<Card> GetVisibleCardsOfTier(int i)
        {
            return this.cards.Where(card => card.Tier == i).Take(visibleCardsCount).ToArray();
        }
    }
}