using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    public class AnsweredCard
    {
        public int CardId { get; }
        public string Answer { get; }

        public AnsweredCard(int cardId, string answer)
        {
            CardId = cardId;
            Answer = answer;
        }
    }
}
