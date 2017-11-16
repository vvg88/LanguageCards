using System;
using System.Collections.Generic;
using System.Text;
using LanguageCards.Data.Entities;
using LanguageCards.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LanguageCards.Data.Repositories
{
    class CardStatusesRepository : ICardStatusesRepository
    {
        private LanguageCardsContext context;

        public CardStatusesRepository(LanguageCardsContext context)
        {
            this.context = context;
        }

        public CardStatus GetCardStatus(CardStatusEnum cardStatus) => context.Statuses
                                                                             .AsNoTracking()
                                                                             .SingleOrDefault(s => s.Id == (int)CardStatusEnum.InProgress);
    }
}
