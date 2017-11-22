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

namespace LanguageCards.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/cards")]
    public class CardsApiController : Controller
    {
        private LanguageCardsContext lcContext;
        private IUsersRepository usersRep;
        private ICardsRepository cardsRep;
        private ICardStatusesRepository cardStatusesRep;
        private ICardProgressesRepository cardProgsRep;
        private const int requestedCardsNum = 5;

        public CardsApiController(LanguageCardsContext context)
        {
            lcContext = context;
            usersRep = RepositoryProvider.GetUsersRepository(lcContext);
            cardsRep = RepositoryProvider.GetCardsRepository(lcContext);
            cardStatusesRep = RepositoryProvider.GetCardStatusesRepository(lcContext);
            cardProgsRep = RepositoryProvider.GetCardProgressesRepository(lcContext);
        }

        [HttpGet]
        public IEnumerable<CardModel> GetCards()
        {
            IEnumerable<Card> cards;
            try
            {
                var user = usersRep.GetUsers().FirstOrDefault();
                cards = cardsRep.GetCards(user.Id, requestedCardsNum);
                cardProgsRep.SetCardsInProgress(cards, user.Id);
                return cards.Select(c => (CardModel)c);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/cards/    
        [HttpPost]
        public void Post([FromBody]IEnumerable<AnsweredCardModel> answeredCardModels)
        {
            try
            {
                var user = usersRep.GetUsers().FirstOrDefault();
                var answeredCards = answeredCardModels.Select(acm => (AnsweredCard)acm);
                cardProgsRep.SetAnsweredCardsProgress(answeredCards, user.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}