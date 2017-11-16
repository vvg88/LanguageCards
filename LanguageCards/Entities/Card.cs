using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageCards.Data.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public Word Word { get; set; }
    }
}
