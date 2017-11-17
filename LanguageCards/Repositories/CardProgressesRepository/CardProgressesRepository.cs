using System;
using System.Collections.Generic;
using System.Text;
using LanguageCards.Data.Models;
using System.Linq;
using LanguageCards.Data.DalOperation;
using LanguageCards.Data.Entities;
using LanguageCards.Data.Enums;

namespace LanguageCards.Data.Repositories
{
    class CardProgressesRepository : ICardProgressesRepository
    {
        private LanguageCardsContext context;

        public CardProgressesRepository(LanguageCardsContext context)
        {
            this.context = context;
        }

        public CardProgress GetCardProgress(int userId, int cardId)
        {
            try
            {
                var cardProgress = context.CardProgresses.SingleOrDefault(cp => cp.CardId == cardId && cp.UserId == userId);
                if (cardProgress == null)
                    throw new DalOperationException($"A required card progress entity for user ID = {userId} and card ID = {cardId} has not been found!", DalOperationStatusCode.EntityNotFound);
                return cardProgress;
            }
            catch (DalOperationException) { throw; }
            catch (Exception e)
            {
                throw new DalOperationException($"An inner exception occurred on request of card progress entity for user ID = {userId} and card ID = {cardId}!",
                                                DalOperationStatusCode.InnerExceptionOccurred, e);
            }
        }

        public void SetAnsweredCardsProgress(IEnumerable<AnsweredCard> answeredCards, int userId)
        {
            if (answeredCards == null)
                throw new NullReferenceException($"Parameter {nameof(answeredCards)} can not be null!");

            if (answeredCards.Count() == 0)
                return;

            try
            {
                foreach(var answeredCard in answeredCards)
                {
                    if (answeredCard.Answer == answeredCard.Card.Word.Text)
                    {
                        var cardProgress = GetCardProgress(userId, answeredCard.Card.Id);
                        if (++cardProgress.Score == cardProgress.MaxScore)
                        {
                            cardProgress.CardStatusId = (int)CardStatusEnum.Finished;
                        }
                    }
                }
                context.SaveChanges();
            }
            catch (DalOperationException) { throw; }
            catch (Exception e)
            {
                throw new DalOperationException($"An inner exception occurred on setting of card progress entity for user ID = {userId}!",
                                                DalOperationStatusCode.InnerExceptionOccurred, e);
            }
        }
    }
}
