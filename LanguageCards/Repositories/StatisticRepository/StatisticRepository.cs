using LanguageCards.Data.DalOperation;
using LanguageCards.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LanguageCards.Data.Repositories
{
    class StatisticRepository : IStatisticRepository
    {
        private LanguageCardsContext context;

        public StatisticRepository(LanguageCardsContext context)
        {
            this.context = context;
        }

        public void AddStatistic(CardProgress cardProgress)
        {
            RunExceptionHandledMethod(() =>
            {
                context.Statistics.Add(new Statistic() { CardProgress = cardProgress, BeginTime = DateTime.Now.Ticks });
                context.SaveChanges();
            }, "An inner exception occurred on statistics addition!");
        }

        public IEnumerable<Statistic> GetStatistic(int userId)
        {
            var statistic = Enumerable.Empty<Statistic>();
            RunExceptionHandledMethod(() =>
            {
                statistic = context.Statistics.AsNoTracking()
                                              .Where(s => s.CardProgress.UserId == userId)
                                              .Include(s => s.CardProgress.Card.Word)
                                              .Include(s => s.CardProgress.Card.Word.SpeechPart)
                                              .Include(s => s.CardProgress.CardStatus)
                                              .ToList();
            });
            return statistic;
        }

        private void RunExceptionHandledMethod(Action method)
        {
            RunExceptionHandledMethod(method, "An inner exception occurred on statistics request!");
        }

        private void RunExceptionHandledMethod(Action method, string message)
        {
            try
            {
                method();
            }
            catch (Exception e)
            {
                throw new DalOperationException(message, DalOperationStatusCode.InnerExceptionOccurred, e);
            }
        }
    }
}
