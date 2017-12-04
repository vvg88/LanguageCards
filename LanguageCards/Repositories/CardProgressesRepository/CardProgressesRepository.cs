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
        public IEnumerable<Card> GetCardsInProgress(int userId, int cardsNumber = 0) => GetCardsWithStatus(userId, CardStatusEnum.InProgress, cardsNumber);

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

        public IEnumerable<CardProgress> GetProgresses(int userId)
        {
            IEnumerable<CardProgress> progresses = Enumerable.Empty<CardProgress>();
            usersRepository.ThrowIfUserNotExist(userId);
            RunExceptionHandledMethod(() =>
            {
                progresses = context.CardProgresses.Where(cp => cp.UserId == userId)
                                                   .Include(cp => cp.Card)
                                                   .ThenInclude(c => c.Word)
                                                   .AsEnumerable();
            });
            return progresses;
        }

        public void SetCardsInProgress(IEnumerable<Card> cards, int userId)
        {
            if (cards.Count() == 0)
                throw new DalOperationException($"The parameter {nameof(cards)} has no cards!", DalOperationStatusCode.Error);

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

        public void SetAnsweredCardsProgress(IEnumerable<AnsweredCard> answeredCards, int userId)
        {
            if (answeredCards == null)
                throw new DalOperationException($"Parameter {nameof(answeredCards)} can not be null!", DalOperationStatusCode.Error);

            if (answeredCards.Count() == 0)
                throw new DalOperationException($"The parameter {nameof(answeredCards)} has no cards!", DalOperationStatusCode.Error);

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

        public void UpdateCardsInProgress()
        {
            RunExceptionHandledMethod(() => context.SaveChanges(), "An inner exception occurred on updating cards in progress!");
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
            usersRepository.ThrowIfUserNotExist(userId);
            RunExceptionHandledMethod(() =>
            {
                context.CardProgresses.SelectMany(cp => cp.Card.Word.Translations)
                                      .Include(t => t.Language)
                                      .Include(t => t.SpeechPart)
                                      .Load();
                var cardsQuery = context.CardProgresses.Where(cp => cp.UserId == userId && cp.CardStatusId == (int)cardStatus)
                                                       .Select(cp => cp.Card)
                                                       .Include(c => c.Word).ThenInclude(w => w.Language)
                                                       .Include(c => c.Word).ThenInclude(w => w.SpeechPart)
                                                       .Include(c => c.Word).ThenInclude(w => w.Translations);

                requestedСards = (cardsNumber == 0 ? cardsQuery : cardsQuery.Take(cardsNumber)).ToList();
            });
            return requestedСards;
        }

        private void RunExceptionHandledMethod(Action method)
        {
            RunExceptionHandledMethod(method, "An inner exception occurred on cards' progresses request!");
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
