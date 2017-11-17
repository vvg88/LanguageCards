using LanguageCards.Data.Entities;
using LanguageCards.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class AnsweredCardModel
    {
        public string Answer { get; set; }
        public CardModel Card { get; set; }

        public static explicit operator AnsweredCard(AnsweredCardModel answeredCardModel)
        {
            return new AnsweredCard((Card)answeredCardModel.Card, answeredCardModel.Answer);
        }
    }
}
