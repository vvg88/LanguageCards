using LanguageCards.Data.Entities;
using LanguageCards.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Repositories
{
    public interface ICardStatusesRepository
    {
        CardStatus GetCardStatus(CardStatusEnum cardStatus);
    }
}
