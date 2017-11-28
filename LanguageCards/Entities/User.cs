using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(string firstName, string lastName, string userName) : base(userName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public User(string firstName, string lastName) : base()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public User() : base()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }
    }
}
