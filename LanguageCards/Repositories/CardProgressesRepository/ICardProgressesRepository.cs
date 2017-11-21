using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Repositories
{
    public interface ICardProgressesRepository
    {
        CardProgress GetCardProgress(int userId, int cardId);
        IEnumerable<Card> GetCardsInProgress(int userId, int cardsNumber);
        IEnumerable<Card> GetCardsFinished(int userId, int cardsNumber);
        IEnumerable<Card> GetCardsInProgressAndFinished(int userId);
        void SetCardsInProgress(IEnumerable<Card> cards, int userId);
        void SetAnsweredCardsProgress(IEnumerable<AnsweredCard> answeredCards, int userId);
    }
}
