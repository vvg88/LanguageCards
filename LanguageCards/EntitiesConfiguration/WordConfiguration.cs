using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{ 
    static class WordConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
                        .Property(w => w.Text)
                        .IsRequired();

            modelBuilder.Entity<Word>()
                        .Property(w => w.Definition)
                        .IsRequired();

            modelBuilder.Entity<Word>()
                        .Property(w => w.Example)
                        .IsRequired();
        }
    }
}
