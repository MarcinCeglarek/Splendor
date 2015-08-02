namespace SplendorServer.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.Http;

    using SplendorServer.Models;

    public class GameController : ApiController
    {
        private readonly Deck deck;

        public GameController()
        {

            var deckFilePath = HttpContext.Current.Server.MapPath("~/App_Data/" + WebConfigurationManager.AppSettings["DeckJsonFilename"]);
            this.deck = new Deck(deckFilePath);
        }

        // GET api/game
        public IDictionary<int, ICollection<Card>> Get()
        {
            return this.deck.GetVisibleCards();
        } 

        // GET api/game/5
        public IDictionary<string, ChipState> Get(int cardType)
        {
            var retVal = new Dictionary<string, ChipState>();
            var cardsInTier = this.deck.AllCards.GroupBy(card => card.Tier);

            foreach (var tier in cardsInTier)
            {
                var cardsByColor = tier.GroupBy(card => card.Color);
                foreach (var color in cardsByColor)
                {
                    var thisColorCost = new ChipState();
                    thisColorCost = color.Aggregate(thisColorCost, (current, card) => current + card.Cost);

                    retVal.Add(string.Format("{0} {1}", color.First().Tier, color.First().Color), thisColorCost);
                }
            }

            return retVal;
        }

        // POST api/game
        public void Post([FromBody]string value)
        {
        }

        // PUT api/game/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/game/5
        public void Delete(int id)
        {
        }
    }
}
