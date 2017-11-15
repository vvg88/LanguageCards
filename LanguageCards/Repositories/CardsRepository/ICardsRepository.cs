using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Repositories
{
    public interface ICardsRepository
    {
        IEnumerable<Card> GetCards(int userId, int cardsNumber);
    }
}
