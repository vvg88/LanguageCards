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
        private ICardStatusesRepository csRepository;
        private IUsersRepository usersRepository;

        public CardsRepository(LanguageCardsContext context)
        {
            this.context = context;
            csRepository = RepositoryProvider.GetCardStatusesRepository(context);
            usersRepository = RepositoryProvider.GetUsersRepository(context);
        }

        public IEnumerable<Card> GetCards(int userId, int cardsNumber)
        {
            if (!UserIdOk(userId))
                throw new DalOperation.DalOperationException($"User with id = { userId } hasn't been found!", DalOperation.DalOperationStatusCode.UserNotFound);

            if (cardsNumber < 0)
                throw new ArgumentOutOfRangeException("Number of requested cards can not be negative!");

            try
            {
                var cardsInProgress = GetCardsInProgress(userId, cardsNumber);
                var cardsInProgressNum = cardsInProgress.Count();
                if (cardsInProgressNum < cardsNumber)
                {
                    RunExceptionHandledMethod(() =>
                    {
                        var cardsNotStudied = context.Cards.Include(c => c.Word)
                                                           .AsEnumerable()
                                                           .Except(GetCardsInProgressTable(userId), new CardsComparer())
                                                           .Take(cardsNumber - cardsInProgressNum)
                                                           .ToList();
                        cardsInProgress = cardsInProgress.Concat(cardsNotStudied);
                    });
                }
                return cardsInProgress;
            }
            catch { throw; }
        }

        public void SetCardsInProgress(IEnumerable<Card> cards, int userId)
        {
            if (!UserIdOk(userId))
                throw new DalOperationException($"User with id = { userId } hasn't been found!", DalOperationStatusCode.UserNotFound);

            if (cards.Count() == 0)
                return;

            try
            {
                var cardsInProgress = context.CardProgresses.AsNoTracking().Select(cp => cp.Card);
                var cardsToBeSetInProgress = cards.Except(cardsInProgress, new CardsComparer());

                var cardStat = csRepository.GetCardStatus(CardStatusEnum.InProgress);
                foreach (var card in cardsToBeSetInProgress)
                {
                    context.CardProgresses.Add(new CardProgress() { Card = card, CardStatus = cardStat, User = usersRepository.GetUser(userId), MaxScore = 5 });
                }
                context.SaveChanges();
            }
            catch (DalOperationException) { throw; }
            catch (Exception e)
            {
                throw new DalOperationException("An inner exception occurred on setting cards in progress!", DalOperationStatusCode.InnerExceptionOccurred, e);
            }
        }

        private bool UserIdOk(int userId) => userId > 0 && context.Users.AsNoTracking().Select(u => u.Id).Contains(userId);

        public IEnumerable<Card> GetCardsInProgress(int userId, int cardsNumber)
        {
            IEnumerable<Card> cardsInProgress = Enumerable.Empty<Card>();
            try
            {
                RunExceptionHandledMethod(() =>
                {
                    cardsInProgress = context.CardProgresses.Where(cp => cp.UserId == userId && cp.CardStatus.Id == (int)CardStatusEnum.InProgress)
                                                            .Select(cp => cp.Card)
                                                            .Include(c => c.Word)
                                                            .Take(cardsNumber)
                                                            .ToList();
                });
                return cardsInProgress;
            }
            catch { throw; }
        }

        private IQueryable<Card> GetCardsInProgressTable(int userId)
        {
            IQueryable<Card> cardsInProgTable = null;
            try
            {
                RunExceptionHandledMethod(() =>
                {
                    cardsInProgTable = context.CardProgresses.Where(cp => cp.UserId == userId && (cp.CardStatusId == (int)CardStatusEnum.InProgress || cp.CardStatusId == (int)CardStatusEnum.Finished))
                                                             .Select(cp => cp.Card)
                                                             .Include(c => c.Word);
                });
                return cardsInProgTable;
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
