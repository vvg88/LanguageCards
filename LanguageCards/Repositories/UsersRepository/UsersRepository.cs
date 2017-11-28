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
            ThrowIfUserNotExist(id);
            RunExceptionHandledMethod(() => user = context.Users.SingleOrDefault(u => u.Id == id));
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> users = null;
            RunExceptionHandledMethod(() => users = context.Users);
            return users;
        }

        public void ThrowIfUserNotExist(int id)
        {
            if (id <= 0)
                throw new DalOperationException($"Required user's id = {id} must be positive!", DalOperationStatusCode.Error);
            bool userIdExist = false;
            RunExceptionHandledMethod(() => userIdExist = context.Users.Any(u => u.Id == id));
            if (!userIdExist)
                throw new DalOperationException($"User with id = {id} hasn't been found!", DalOperationStatusCode.EntityNotFound);
        }
        
        private void RunExceptionHandledMethod(Action method)
        {
            RunExceptionHandledMethod(method, "An inner exception occurred on users' request!");
        }

        private void RunExceptionHandledMethod(Action method, string message)
        {
            try
            {
                method();
            }
            catch (Exception e)
            {
                throw new DalOperationException(message, DalOperationStatusCode.InnerExceptionOccurred, e);
            }
        }
    }
}
