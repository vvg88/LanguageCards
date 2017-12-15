using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Repositories
{
    public interface IStatisticRepository
    {
        void AddStatistic(CardProgress cardProgress);

        IEnumerable<Statistic> GetStatistic(int userId);
    }
}
