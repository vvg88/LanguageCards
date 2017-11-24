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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LanguageCards.WebApp.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/cards")]
    public class CardsApiController : Controller
    {
        private readonly LanguageCardsContext lcContext;
        private readonly IUsersRepository usersRep;
        private readonly ICardsRepository cardsRep;
        private readonly ICardStatusesRepository cardStatusesRep;
        private readonly ICardProgressesRepository cardProgsRep;
        private readonly UserManager<IdentityUser> userManager;
        private const int requestedCardsNum = 5;

        public CardsApiController(LanguageCardsContext context, UserManager<IdentityUser> userManager)
        {
            lcContext = context;
            usersRep = RepositoryProvider.GetUsersRepository(lcContext);
            cardsRep = RepositoryProvider.GetCardsRepository(lcContext);
            cardStatusesRep = RepositoryProvider.GetCardStatusesRepository(lcContext);
            cardProgsRep = RepositoryProvider.GetCardProgressesRepository(lcContext);
            this.userManager = userManager;
        }

        [HttpGet]
        public IEnumerable<CardModel> GetCards()
        {
            IEnumerable<Card> cards;
            try
            {
                var user = GetUser().Result;
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
                var user = GetUser().Result;
                var answeredCards = answeredCardModels.Select(acm => (AnsweredCard)acm);
                cardProgsRep.SetAnsweredCardsProgress(answeredCards, user.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<User> GetUser()
        {
            try
            {
                User user = null;
                var identityUser = await userManager.GetUserAsync(User);
                if (identityUser != null)
                {
                    user = usersRep.GetUser(identityUser.Id);
                }
                else
                {
                    throw new DalOperationException("Required user identity has not been found!", DalOperationStatusCode.Error);
                }
                return user;
            }
            catch { throw; }
        }
    }
}