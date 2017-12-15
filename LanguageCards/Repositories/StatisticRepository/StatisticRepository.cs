using LanguageCards.Data.DalOperation;
using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
            });
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
