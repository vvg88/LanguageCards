using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    public class CardStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CardProgress> CardProgresses { get; set; }
    }
}
