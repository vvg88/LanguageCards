using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LanguageCards.Data.Entities;
using LanguageCards.Data;
using LanguageCards.Data.Repositories;
using LanguageCards.Data.Enums;

namespace LanguageCards.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/cards")]
    public class CardsApiController : Controller
    {
        LanguageCardsContext lcContext;
        IUsersRepository usersRepository;
        ICardsRepository cardsRepository;

        public CardsApiController()
        {
            lcContext = new LanguageCardsContext();
            usersRepository = RepositoryProvider.GetUsersRepository(lcContext);
            cardsRepository = RepositoryProvider.GetCardsRepository(lcContext);
        }

        [HttpGet]
        public IEnumerable<Cards> GetCards()
        {
            IEnumerable<Card> cards;
            var user = usersRepository.GetUsers().FirstOrDefault();
            cards = cardsRepository.GetCards(user.Id, 5);
            var cs = lcContext.Statuses.SingleOrDefault(s => s.Id == (int)CardStatusEnum.InProgress);
            foreach (var card in cards)
            {
                var cardProgress = new CardProgress() { Card = card, CardStatus = cs, User = user };
                lcContext.CardProgresses.Add(cardProgress);
            }
            lcContext.SaveChanges();
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