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
using LanguageCards.Data.DalOperation;
using LanguageCards.WebApp.Models;
using LanguageCards.Data.Models;

namespace LanguageCards.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/cards")]
    public class CardsApiController : Controller
    {
        private LanguageCardsContext lcContext;
        private IUsersRepository usersRepository;
        private ICardsRepository cardsRepository;
        private ICardStatusesRepository cardStatusesRepository;
        private ICardProgressesRepository cardProgressesRepository;
        private static IEnumerable<CardModel> cardModels;
        private static User user;

        public CardsApiController()
        {
            lcContext = new LanguageCardsContext();
            usersRepository = RepositoryProvider.GetUsersRepository(lcContext);
            cardsRepository = RepositoryProvider.GetCardsRepository(lcContext);
            cardStatusesRepository = RepositoryProvider.GetCardStatusesRepository(lcContext);
            cardProgressesRepository = RepositoryProvider.GetCardProgressesRepository(lcContext);
        }

        [HttpGet]
        public IEnumerable<CardModel> GetCards()
        {
            IEnumerable<Card> cards;
            try
            {
                user = usersRepository.GetUsers().FirstOrDefault();
                cards = cardsRepository.GetCards(user.Id, 5);
                cardsRepository.SetCardsInProgress(cards, user.Id);
                return cardModels = cards.Select(c => (CardModel)c);
            }
            catch (DalOperationException)
            {
                return Enumerable.Empty<CardModel>();
            }
        }

        // POST: api/cards/    
        [HttpPost]
        public void Post([FromBody]IEnumerable<AnsweredCardModel> answeredCardModels)
        {
            try
            {
                answeredCardModels = answeredCardModels.Select(ac => new AnsweredCardModel() { Answer = ac.Answer, Card = cardModels.SingleOrDefault(cm => cm.Id == ac.Card.Id) });
                var answeredCards = answeredCardModels.Select(acm => (AnsweredCard)acm);
                cardProgressesRepository.SetAnsweredCardsProgress(answeredCards, user.Id);
            }
            catch (DalOperationException)
            {

            }
        }
    }
}