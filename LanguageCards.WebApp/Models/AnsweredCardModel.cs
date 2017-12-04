using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class AnsweredCardModel
    {
        public string Answer { get; set; }
        public int CardId { get; set; }

        public static explicit operator AnsweredCard(AnsweredCardModel answeredCardModel)
        {
            return new AnsweredCard(answeredCardModel.CardId, answeredCardModel.Answer);
        }
    }
}
