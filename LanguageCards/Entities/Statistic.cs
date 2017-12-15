using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    public class Statistic
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AttemptsNum { get; set; }
        public int SuccessfulAttemptsNum { get; set; }
        public long BeginTime { get; set; }
        public long FinishTime { get; set; }
    }
}
