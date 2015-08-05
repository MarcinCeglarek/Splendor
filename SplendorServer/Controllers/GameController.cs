/*
namespace SplendorServer.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.Http;
    using System.Web.Providers.Entities;

    using SplendorServer.Models;

    public class GameController : ApiController
    {
        private readonly Deck deck;

        private readonly GameStatus gameStatus;

        public GameController()
        {

            var deckFilePath = HttpContext.Current.Server.MapPath("~/App_Data/" + WebConfigurationManager.AppSettings["DeckJsonFilename"]);
            var aristocratesFilePath = HttpContext.Current.Server.MapPath("~/App_Data/" + WebConfigurationManager.AppSettings["AristocratesJsonFilename"]);
            this.deck = new Deck(deckFilePath, aristocratesFilePath);

            var users = new List<User>() { new User() { Name = "user1" }, new User() { Name = "user2" }, new User() { Name = "user3" } };

            this.gameStatus = new GameStatus(this.deck, users);
        }

        // GET api/game
        [HttpGet]
        public Game GameStatus()
        {
            return this.gameStatus;
        } 

        // GET api/game/5
        [HttpGet]
        public IDictionary<string, Chips> GetStatistics()
        {
            var retVal = new Dictionary<string, Chips>();
            var cardsInTier = this.deck.AllCards.GroupBy(card => card.Tier);

            foreach (var tier in cardsInTier)
            {
                var cardsByColor = tier.GroupBy(card => card.Color);
                foreach (var color in cardsByColor)
                {
                    var thisColorCost = new Chips();
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
*/
