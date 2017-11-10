using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LanguageCards.Data.Models
{
    public class Session
    {
        public int Id { get; set; }
        public long SessionTime { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public ICollection<Card> SessionCards { get; set; }
    }
}
