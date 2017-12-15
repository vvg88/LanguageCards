using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static explicit operator UserModel(User user)
        {
            return user == null ? new UserModel()
                                : new UserModel()
                                  {
                                      FirstName = user.FirstName,
                                      LastName = user.LastName,
                                  };
        }
    }
}
