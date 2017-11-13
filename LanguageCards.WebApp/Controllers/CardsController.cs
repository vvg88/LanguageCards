using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LanguageCards.Data.AccessLayer;

namespace LanguageCards.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Cards")]
    public class CardsController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Cards> GetCards()
        {
            IEnumerable<Card> cards;
            var accessProvider = DbAccessLayer.DbAccessProvider;
            var user = accessProvider.GetUsers().FirstOrDefault();
            cards = accessProvider.GetRandomCards(5, user);
            return cards.Select(c => new Cards() { Word = c.Word.Text, Definition = c.Word.Definition, Example = c.Word.Example });
        }
    }

    public class Cards
    {
        public string Word { get; set; }
        public string Definition { get; set; }
        public string Example { get; set; }
    }
}