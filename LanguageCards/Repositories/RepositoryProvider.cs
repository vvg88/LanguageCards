using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Repositories
{
    public static class RepositoryProvider
    {
        public static ICardsRepository GetCardsRepository(LanguageCardsContext context) => new CardsRepository(context);

        public static IUsersRepository GetUsersRepository(LanguageCardsContext context) => new UsersRepository(context);

        public static ICardStatusesRepository GetCardStatusesRepository(LanguageCardsContext context) => new CardStatusesRepository(context);

        public static ICardProgressesRepository GetCardProgressesRepository(LanguageCardsContext context) => new CardProgressesRepository(context);

        public static ICardProgressesRepository GetCardProgressesRepository(LanguageCardsContext context, ICardsRepository cardsRep) => new CardProgressesRepository(context, cardsRep);

        public static IStatisticRepository GetStatisticRepository(LanguageCardsContext context) => new StatisticRepository(context);
    }
}
