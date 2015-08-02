namespace MvcApplication1.Controllers
{
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Configuration;
    using System.Web.Http;

    using MvcApplication1.Models;

    public class GameController : ApiController
    {
        private Deck deck;

        public GameController()
        {

            var deckFilePath = HttpContext.Current.Server.MapPath("~/App_Data/" + WebConfigurationManager.AppSettings["DeckJsonFilename"]);
            this.deck = new Deck(deckFilePath);
        }

        // GET api/game
        public IDictionary<int, ICollection<Card>> Get()
        {
            return this.JSON(this.deck.GetVisibleCards());
        }

        // GET api/game/5
        public string Get(int id)
        {
            return "value";
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
