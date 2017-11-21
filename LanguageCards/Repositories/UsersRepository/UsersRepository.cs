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
            User user = null;
            try
            {
                ThrowIfUserNotExist(id);
                RunExceptionHandledMethod(() => user = context.Users.SingleOrDefault(u => u.Id == id));
                return user;
            }
            catch { throw; }
        }

        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = null;
            try
            {
                RunExceptionHandledMethod(() => users = context.Users);
                return users;
            }
            catch { throw; }
        }

        public void ThrowIfUserNotExist(int id)
        {
            try
            {
                if (id <= 0)
                    throw new DalOperationException($"Required user's id = {id} must be positive!", DalOperationStatusCode.Error);
                bool userIdExist = false;
                RunExceptionHandledMethod(() => userIdExist = context.Users.Any(u => u.Id == id));
                if (!userIdExist)
                    throw new DalOperationException($"User with id = {id} hasn't been found!", DalOperationStatusCode.UserNotFound);
            }
            catch { throw; }
        }

        private void RunExceptionHandledMethod(Action method)
        {
            try
            {
                method();
            }
            catch (Exception e)
            {
                throw new DalOperationException("An inner exception occurred on users' request!", DalOperationStatusCode.InnerExceptionOccurred, e);
            }
        }
    }
}
