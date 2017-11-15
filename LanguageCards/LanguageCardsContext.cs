﻿using LanguageCards.Data.Entities;
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
        public DbSet<Translation> Translations { get; set; }
        public DbSet<CardStatus> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LanguageCards;Trusted_Connection=True;");
        }
    }
}
