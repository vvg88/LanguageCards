using LanguageCards.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LanguageCards.Data.Entities
{
    /// <summary>
    /// The progress of a card for each user
    /// </summary>
    public class CardProgress
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CardStatusId { get; set; }
        public CardStatus CardStatus { get; set; }
    }
}
