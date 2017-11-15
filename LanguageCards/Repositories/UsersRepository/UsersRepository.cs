using System;
using System.Collections.Generic;
using System.Text;
using LanguageCards.Data.Entities;
using System.Linq;
using LanguageCards.Data.DalOperation;

namespace LanguageCards.Data.Repositories
{
    class UsersRepository : IUsersRepository
    {
        private LanguageCardsContext context;

        public UsersRepository(LanguageCardsContext context)
        {
            this.context = context;
        }

        public User GetUser(int id)
        {
            var user = context.Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
                throw new DalOperationException($"User with id = {id} hasn't been found!", DalOperationStatusCode.UserNotFound);
            return user;
        }

        public IEnumerable<User> GetUsers() => context.Users;
    }
}
