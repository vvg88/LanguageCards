using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int id);
    }
}
