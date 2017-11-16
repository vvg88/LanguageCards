using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Repositories
{
    public static class RepositoryProvider
    {
        public static ICardsRepository GetCardsRepository(LanguageCardsContext context) => new CardsRepository(context);

        public static IUsersRepository GetUsersRepository(LanguageCardsContext context) => new UsersRepository(context);
    }
}
