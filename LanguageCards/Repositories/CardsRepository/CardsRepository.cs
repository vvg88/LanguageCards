using System;
using System.Collections.Generic;
using System.Text;
using LanguageCards.Data.Entities;
using System.Linq;
using LanguageCards.Data.Enums;
using Microsoft.EntityFrameworkCore;

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

            var cardsInProgress = GetCardsInProgress(userId, cardsNumber);
            var cardsInProgressNum = cardsInProgress.Count();
            if (cardsInProgressNum < cardsNumber)
            {
                var cardsNotStudied = context.Cards.Include(c => c.Word)
                                                   .AsEnumerable()
                                                   .Except(cardsInProgress, new CardsComparer())
                                                   .Take(cardsNumber - cardsInProgressNum)
                                                   .ToList();
                cardsInProgress = cardsInProgress.Concat(cardsNotStudied);
            }
            return cardsInProgress;
        }

        public void SetCardsInProgress(IEnumerable<Card> cards, int userId)
        {
            if (!UserIdOk(userId))
                throw new DalOperation.DalOperationException($"User with id = { userId } hasn't been found!", DalOperation.DalOperationStatusCode.UserNotFound);

            if (cards.Count() == 0)
                return;

            var cardsInProgress = context.CardProgresses.AsNoTracking().Select(cp => cp.Card);
            var cardsToBeSetInProgress = cards.Except(cardsInProgress, new CardsComparer());

            var cardStat = csRepository.GetCardStatus(CardStatusEnum.InProgress);
            foreach(var card in cardsToBeSetInProgress)
            {
                context.CardProgresses.Add(new CardProgress() { Card = card, CardStatus = cardStat, User = usersRepository.GetUser(userId), MaxScore = 5 });
            }
            context.SaveChanges();
        }

        private bool UserIdOk(int userId) => userId > 0 && context.Users.AsNoTracking().Select(u => u.Id).Contains(userId);

        private IEnumerable<Card> GetCardsInProgress(int userId, int cardsNumber)
        {
            var cardsInProgress = context.CardProgresses.Where(cp => cp.UserId == userId && cp.CardStatus.Id == (int)CardStatusEnum.InProgress)
                                                        .Select(cp => cp.Card)
                                                        .Include(c => c.Word)
                                                        .Take(cardsNumber)
                                                        .ToList();
            return cardsInProgress;
        }
    }
}
