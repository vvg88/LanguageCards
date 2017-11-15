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

        public CardsRepository(LanguageCardsContext context)
        {
            this.context = context;
        }

        public IEnumerable<Card> GetCards(int userId, int cardsNumber)
        {
            var cardsInProgress = context.CardProgresses.Where(cp => cp.UserId == userId && cp.CardStatus.Id == (int)CardStatusEnum.InProgress)
                                                        .Select(cp => cp.Card)
                                                        .Include(c => c.Word)
                                                        .ToList()
                                                        .Take(cardsNumber);
            var cardsInProgressNum = cardsInProgress.Count();
            if (cardsInProgressNum < cardsNumber)
            {
                var cardsNotStudied = context.Cards.Where(c => !cardsInProgress.Contains(c))
                                                   .Include(c => c.Word)
                                                   .ToList()
                                                   .Take(cardsNumber - cardsInProgressNum);
                cardsInProgress = cardsInProgress.Concat(cardsNotStudied);
            }
            
            return cardsInProgress;
        }
    }
}
