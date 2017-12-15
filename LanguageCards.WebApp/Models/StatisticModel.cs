using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class StatisticModel
    {
        public int Id { get; set; }
        public int CardProgressId { get; set; }
        public CardProgressModel CardProgress { get; set; }
        public int AttemptsNum { get; set; }
        public int SuccessfulAttemptsNum { get; set; }
        public long BeginTime { get; set; }
        public long FinishTime { get; set; }

        public static explicit operator StatisticModel(Statistic stat)
        {
            return new StatisticModel()
            {
                Id = stat.Id,
                CardProgressId = stat.CardProgressId,
                CardProgress = (CardProgressModel)stat.CardProgress,
                AttemptsNum = stat.AttemptsNum,
                SuccessfulAttemptsNum = stat.SuccessfulAttemptsNum,
                BeginTime = stat.BeginTime,
                FinishTime = stat.FinishTime,
            };
        }
    }
}
