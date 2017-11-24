using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UsersDbId { get; set; }
    }
}
