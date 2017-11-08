using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Models
{
    /// <summary>
    /// The score for a card for each user
    /// </summary>
    public class CardScore
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public Card Card { get; set; }
        public User User { get; set; }
    }
}
