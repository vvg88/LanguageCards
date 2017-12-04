using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    static class WordTranslationConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordTranslation>().HasKey(wt => new { wt.WordId, wt.TranslationId });
            modelBuilder.Entity<WordTranslation>().HasOne(wt => wt.Word)
                                                  .WithMany()
                                                  .HasForeignKey(wt => wt.WordId)
                                                  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WordTranslation>().HasOne(wt => wt.Translation)
                                                  .WithMany()
                                                  .HasForeignKey(wt => wt.TranslationId);
        }
    }
}
