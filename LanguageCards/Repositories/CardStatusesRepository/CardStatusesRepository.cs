using System;
using System.Collections.Generic;
using System.Text;
using LanguageCards.Data.Entities;
using LanguageCards.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LanguageCards.Data.DalOperation;

namespace LanguageCards.Data.Repositories
{
    class CardStatusesRepository : ICardStatusesRepository
    {
        private LanguageCardsContext context;

        public CardStatusesRepository(LanguageCardsContext context)
        {
            this.context = context;
        }

        public CardStatus GetCardStatus(CardStatusEnum cardStatus)
        {
            try
            {
                return context.Statuses.SingleOrDefault(s => s.Id == (int)cardStatus);
            }
            catch (Exception e)
            {
                throw new DalOperationException("An inner exception occurred on card's status request!", DalOperationStatusCode.InnerExceptionOccurred, e);
            }
        }
    }
}
