using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    static class CardStatusConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardStatus>()
                        .Property(cs => cs.Id)
                        .ValueGeneratedNever();
        }
    }
}
