using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Models
{
    public class AnsweredCard
    {
        public Card Card { get; }
        public string Answer { get; }

        public AnsweredCard(Card card, string answer)
        {
            Card = card;
            Answer = answer;
        }
    }
}
