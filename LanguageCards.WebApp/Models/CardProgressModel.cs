using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class CardProgressModel
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public int CardId { get; set; }
        public CardModel Card { get; set; }
        public int CardStatusId { get; set; }
        public CardStatusModel CardStatus { get; set; }

        public static explicit operator CardProgressModel(CardProgress cardProg)
        {
            return new CardProgressModel()
            {
                Id = cardProg.Id,
                Score = cardProg.Score,
                MaxScore = cardProg.MaxScore,
                CardId = cardProg.CardId,
                Card = (CardModel)cardProg.Card,
                CardStatusId = cardProg.CardStatusId,
                CardStatus = (CardStatusModel)cardProg.CardStatus,
            };
        }
    }
}
