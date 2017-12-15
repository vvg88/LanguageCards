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
    /// <summary>
    /// Provides methods for getting cards and saving answers in a database
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/cards")]
    public class CardsController : Controller
    {
        private readonly LanguageCardsContext lcContext;
        private readonly IUsersRepository usersRep;
        private readonly ICardsRepository cardsRep;
        private readonly ICardStatusesRepository cardStatusesRep;
        private readonly ICardProgressesRepository cardProgsRep;
        private readonly IStatisticRepository statRepo;
        private readonly UserManager<User> userManager;
        private const int requestedCardsNum = 5;

        public CardsController(LanguageCardsContext context, UserManager<User> userManager)
        {
            lcContext = context;
            usersRep = RepositoryProvider.GetUsersRepository(lcContext);
            cardsRep = RepositoryProvider.GetCardsRepository(lcContext);
            cardStatusesRep = RepositoryProvider.GetCardStatusesRepository(lcContext);
            cardProgsRep = RepositoryProvider.GetCardProgressesRepository(lcContext);
            statRepo = RepositoryProvider.GetStatisticRepository(lcContext);
            this.userManager = userManager;
        }

        /// <summary>
        /// Gets a set of cards for the authorized user
        /// </summary>
        /// <returns> A set of requested cards </returns>
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
            catch { throw; }
        }

        [HttpGet("statistic")]
        public IEnumerable<StatisticModel> GetStatistic()
        {
            try
            {
                var user = GetUser().Result;
                var stat = statRepo.GetStatistic(user.Id);
                return stat.Select(s => (StatisticModel)s);
            }
            catch { throw; }
        }

        // POST: api/cards/ 
        /// <summary>
        /// Sets a score and a status for the answered cards and saves the result in a database
        /// </summary>
        /// <param name="answeredCardModels"> A collection that contains answers and cards' ids </param>
        [HttpPost]
        public void Post([FromBody]IEnumerable<AnsweredCardModel> answeredCardModels)
        {
            try
            {
                var user = GetUser().Result;
                var cardsProgresses = cardProgsRep.GetProgresses(user.Id);
                var answeredCards = cardsProgresses.Join(answeredCardModels,
                                                         cp => cp.CardId,
                                                         acm => acm.CardId,
                                                         (cp, acm) => new { CardProgress = cp, AnswerIsCorrect = acm.Answer.Equals(cp.Card.Word.Text) });

                foreach (var answeredCard in answeredCards)
                {
                    if (answeredCard.AnswerIsCorrect
                        && ++answeredCard.CardProgress.Score == answeredCard.CardProgress.MaxScore)
                    {
                        answeredCard.CardProgress.CardStatusId = (int)CardStatusEnum.Finished;
                    }
                }
                cardProgsRep.UpdateCardsInProgress();
            }
            catch { throw; }
        }

        private async Task<User> GetUser()
        {
            try
            {
                var identityUser = await userManager.GetUserAsync(User);
                if (identityUser != null)
                {
                    return identityUser;
                }
                else
                {
                    throw new DalOperationException("Required user identity has not been found!", DalOperationStatusCode.Error);
                }
            }
            catch { throw; }
        }
    }
}