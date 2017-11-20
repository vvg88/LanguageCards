using LanguageCards.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageCards.Data
{
    public class LanguageCardsContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CardProgress> CardProgresses { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<SpeechPart> SpeechParts { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<CardStatus> Statuses { get; set; }
        public DbSet<WordTranslation> WordsTranslations { get; set; }

        public LanguageCardsContext(DbContextOptions<LanguageCardsContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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
