using LanguageCards.Data.Entities;
using LanguageCards.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Repositories
{
    public interface ICardProgressesRepository
    {
        void SetAnsweredCardsProgress(IEnumerable<AnsweredCard> answeredCards, int userId);

        CardProgress GetCardProgress(int userId, int cardId);
    }
}
