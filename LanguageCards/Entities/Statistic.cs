using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    public class Statistic
    {
        public int Id { get; set; }
        public int CardProgressId { get; set; }
        public CardProgress CardProgress { get; set; }
        public int AttemptsNum { get; set; }
        public int SuccessfulAttemptsNum { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime TimeFinish { get; set; }
    }
}
