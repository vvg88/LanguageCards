using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data
{
    class CardsComparer : IEqualityComparer<Card>
    {
        public bool Equals(Card x, Card y)
        {
            if (x.Equals(y))
                return true;
            return x.Id == y.Id;
        }

        public int GetHashCode(Card obj)
        {
            return obj.Id ^ obj.WordId;
        }
    }
}
