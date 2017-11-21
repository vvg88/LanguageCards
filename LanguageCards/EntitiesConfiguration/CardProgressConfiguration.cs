using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    static class CardProgressConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardProgress>()
                        .Property(cp => cp.MaxScore)
                        .HasDefaultValue(5);
        }
    }
}
