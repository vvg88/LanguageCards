using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LanguageCards.Data.DalOperation;
using LanguageCards.Data.Entities;
using LanguageCards.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace LanguageCards.Data.Repositories
{
    class CardProgressesRepository : ICardProgressesRepository
    {
        private LanguageCardsContext context;
        private ICardsRepository cardsRepository;
        private IUsersRepository usersRepository;
        private ICardStatusesRepository cardStatusesRepository;

        public CardProgressesRepository(LanguageCardsContext context, ICardsRepository cardsRep)
        {
            this.context = context;
            cardsRepository = cardsRep;
            usersRepository = RepositoryProvider.GetUsersRepository(context);
            cardStatusesRepository = RepositoryProvider.GetCardStatusesRepository(context);
        }

        public CardProgressesRepository(LanguageCardsContext context) : this(context, RepositoryProvider.GetCardsRepository(context)) { }

        public CardProgress GetCardProgress(int userId, int cardId)
        {
            try
            {
                CardProgress cardProgress = null;
                RunExceptionHandledMethod(() => cardProgress = context.CardProgresses.SingleOrDefault(cp => cp.CardId == cardId && cp.UserId == userId),
                                          $"An inner exception occurred on request of card progress entity for user ID = {userId} and card ID = {cardId}!");
                if (cardProgress == null)
                    throw new DalOperationException($"A required card progress entity for user ID = {userId} and card ID = {cardId} has not been found!", DalOperationStatusCode.EntityNotFound);
                return cardProgress;
            }
            catch { throw; }
        }

        /// <summary>
        /// Reveals all the cards for particular user that are finished
        /// </summary>
        /// <param name="userId"> User's id </param>
        /// <param name="cardsNumber"> Required number of cards. If this parameter is 0, the method returns all the available cards </param>
        /// <returns> Required number of cards </returns>
        public IEnumerable<Card> GetCardsInProgress(int userId, int cardsNumber) => GetCardsWithStatus(userId, CardStatusEnum.InProgress, cardsNumber);

        /// <summary>
        /// Reveals all the cards for particular user that are finished
        /// </summary>
        /// <param name="userId"> User's id </param>
        /// <param name="cardsNumber"> Required number of cards. If this parameter is 0, the method returns all the available cards </param>
        /// <returns> Required number of cards </returns>
        public IEnumerable<Card> GetCardsFinished(int userId, int cardsNumber) => GetCardsWithStatus(userId, CardStatusEnum.Finished, cardsNumber);

        /// <summary>
        /// Reveals all the cards for particular user that are in progress and finished
        /// </summary>
        /// <param name="userId"> User's id </param>
        /// <returns> Required cards </returns>
        public IEnumerable<Card> GetCardsInProgressAndFinished(int userId) => GetCardsInProgress(userId, 0).Concat(GetCardsFinished(userId, 0));

        public void SetCardsInProgress(IEnumerable<Card> cards, int userId)
        {
            if (cards.Count() == 0)
                return;

            try
            {
                usersRepository.ThrowIfUserNotExist(userId);
                RunExceptionHandledMethod(() =>
                {
                    var cardsInProgress = GetCardsInProgress(userId, 0);
                    var cardsToBeSetInProgress = cards.Except(cardsInProgress, new CardsComparer());

                    var cardStat = cardStatusesRepository.GetCardStatus(CardStatusEnum.InProgress);
                    var user = usersRepository.GetUser(userId);
                    foreach (var card in cardsToBeSetInProgress)
                    {
                        context.CardProgresses.Add(new CardProgress() { Card = card, CardStatus = cardStat, User = user });
                    }
                    context.SaveChanges();
                }, "An inner exception occurred on setting cards in progress!");
            }
            catch { throw; }
        }

        public void SetAnsweredCardsProgress(IEnumerable<AnsweredCard> answeredCards, int userId)
        {
            if (answeredCards == null)
                throw new NullReferenceException($"Parameter {nameof(answeredCards)} can not be null!");

            if (answeredCards.Count() == 0)
                return;

            try
            {
                usersRepository.ThrowIfUserNotExist(userId);
                RunExceptionHandledMethod(() =>
                {
                    foreach (var answeredCard in answeredCards)
                    {
                        var card = cardsRepository.GetCard(answeredCard.CardId);
                        if (answeredCard.Answer == card.Word.Text)
                        {
                            var cardProgress = GetCardProgress(userId, answeredCard.CardId);
                            if (++cardProgress.Score == cardProgress.MaxScore)
                            {
                                cardProgress.CardStatusId = (int)CardStatusEnum.Finished;
                            }
                        }
                    }
                    context.SaveChanges();
                }, $"An inner exception occurred on setting of card progress entity for user ID = {userId}!");
            }
            catch { throw; }
        }

        /// <summary>
        /// Reveals required number of cards for particular user with status <see cref="CardStatusEnum"/>
        /// </summary>
        /// <param name="userId"> User's id </param>
        /// <param name="cardStatus"> Status of card </param>
        /// <param name="cardsNumber"> Required number of cards. If this parameter is 0, the method returns all the available cards </param>
        /// <returns> Required number of cards </returns>
        private IEnumerable<Card> GetCardsWithStatus(int userId, CardStatusEnum cardStatus, int cardsNumber = 0)
        {
            if (cardsNumber < 0)
                throw new DalOperationException($"The parameter {nameof(cardsNumber)} must be non negative!", DalOperationStatusCode.Error);

            IEnumerable<Card> requestedСards = Enumerable.Empty<Card>();
            try
            {
                usersRepository.ThrowIfUserNotExist(userId);
                RunExceptionHandledMethod(() =>
                {
                    var cardsQuery = context.CardProgresses.Where(cp => cp.UserId == userId && cp.CardStatus.Id == (int)cardStatus)
                                                           .Select(cp => cp.Card)
                                                           .Include(c => c.Word);

                    requestedСards = (cardsNumber == 0 ? cardsQuery.Take(cardsNumber) : cardsQuery).ToList();
                });
                return requestedСards;
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
                throw new DalOperationException("An inner exception occurred on cards' progresses request!", DalOperationStatusCode.InnerExceptionOccurred, e);
            }
        }

        private void RunExceptionHandledMethod(Action method, string message)
        {
            try
            {
                method();
            }
            catch (Exception e)
            {
                throw new DalOperationException(message, DalOperationStatusCode.InnerExceptionOccurred, e);
            }
        }
    }
}
