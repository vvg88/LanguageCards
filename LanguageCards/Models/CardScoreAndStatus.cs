using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LanguageCards.Data.Models
{
    /// <summary>
    /// The score for a card for each user
    /// </summary>
    public class CardScoreAndStatus
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int MaxScore { get; set; }
        public Card Card { get; set; }
        public User User { get; set; }
        public CardStatus CardStatus { get; set; }
        [NotMapped]
        public bool IsFinished => Score >= MaxScore;
    }
}
