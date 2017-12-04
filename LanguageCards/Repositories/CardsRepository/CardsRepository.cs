using System;
using System.Collections.Generic;
using System.Text;
using LanguageCards.Data.Entities;
using System.Linq;
using LanguageCards.Data.Enums;
using Microsoft.EntityFrameworkCore;
using LanguageCards.Data.DalOperation;

namespace LanguageCards.Data.Repositories
{
    class CardsRepository : ICardsRepository
    {
        private LanguageCardsContext context;
        private ICardProgressesRepository cardProgsRep;
        private IUsersRepository usersRep;

        public CardsRepository(LanguageCardsContext context)
        {
            this.context = context;
            cardProgsRep = RepositoryProvider.GetCardProgressesRepository(context, this);
            usersRep = RepositoryProvider.GetUsersRepository(context);
        }

        public Card GetCard(int cardId)
        {
            if (cardId <= 0)
                throw new DalOperationException("Requested card ID can not be negative!", DalOperationStatusCode.Error);
            try
            {
                Card card = null;
                RunExceptionHandledMethod(() => card = context.Cards.Include(c => c.Word).SingleOrDefault(c => c.Id == cardId));
                if (card == null)
                    throw new DalOperationException($"Requested card with ID = {cardId} has not been found!", DalOperationStatusCode.EntityNotFound);
                return card;
            }
            catch { throw; }
        }

        public IEnumerable<Card> GetCards(int userId, int cardsNumber)
        {
            if (cardsNumber < 0)
                throw new DalOperationException("Number of requested cards can not be negative!", DalOperationStatusCode.Error);

            try
            {
                usersRep.ThrowIfUserNotExist(userId);
                var cardsInProgress = cardProgsRep.GetCardsInProgress(userId, cardsNumber);
                var cardsInProgressNum = cardsInProgress.Count();
                if (cardsInProgressNum < cardsNumber)
                {
                    RunExceptionHandledMethod(() =>
                    {
                        context.Cards.SelectMany(c => c.Word.Translations)
                                     .Include(t => t.Language)
                                     .Include(t => t.SpeechPart)
                                     .Load();
                        var cardsNotStudied = context.Cards.Include(c => c.Word).ThenInclude(w => w.Language)
                                                           .Include(c => c.Word).ThenInclude(w => w.SpeechPart)
                                                           .Include(c => c.Word).ThenInclude(w => w.Translations).AsQueryable()
                                                           .AsEnumerable()
                                                           .Except(cardProgsRep.GetCardsInProgressAndFinished(userId), new CardsComparer())
                                                           .Take(cardsNumber - cardsInProgressNum)
                                                           .ToList();
                        cardsInProgress = cardsInProgress.Concat(cardsNotStudied);
                    });
                }
                return cardsInProgress;
            }
            catch { throw; }
        }

        private void RunExceptionHandledMethod(Action method)
        {
            try
            {
                method();
            }
            catch (Exception e)
            {
                throw new DalOperationException("An inner exception occurred on cards' request!", DalOperationStatusCode.InnerExceptionOccurred, e);
            }
        }
    }
}
