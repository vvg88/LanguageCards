using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class CardModel
    {
        public int Id { get; set; }
        public WordModel Word { get; set; }

        public static explicit operator CardModel(Card card)
        {
            return new CardModel()
            {
                Id = card.Id,
                Word = (WordModel)card.Word,
            };
        }

        public static explicit operator Card(CardModel cardModel)
        {
            return new Card()
            {
                Id = cardModel.Id,
                Word = (Word)cardModel.Word,
            };
        }
    }
}
