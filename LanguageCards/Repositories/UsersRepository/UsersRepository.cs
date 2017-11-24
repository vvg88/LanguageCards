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

        public User GetUser(string id)
        {
            User user = null;
            try
            {
                bool userIdExist = false;
                RunExceptionHandledMethod(() => userIdExist = context.Users.Any(u => u.UsersDbId == id));
                if (!userIdExist)
                    throw new DalOperationException($"User with UsersDbId = {id} hasn't been found!", DalOperationStatusCode.EntityNotFound);

                RunExceptionHandledMethod(() => user = context.Users.SingleOrDefault(u => u.UsersDbId == id));
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
                    throw new DalOperationException($"User with id = {id} hasn't been found!", DalOperationStatusCode.EntityNotFound);
            }
            catch { throw; }
        }

        public void AddUser(User user)
        {
            if (user == null)
                throw new DalOperationException($"Argument {nameof(user)} is null!", DalOperationStatusCode.Error);

            if (context.Users.Any(u => u.UsersDbId == user.UsersDbId))
                return;

            try
            {
                RunExceptionHandledMethod(() =>
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }, "An inner exception occurred on adding a new user!");
            }
            catch { throw; }
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
