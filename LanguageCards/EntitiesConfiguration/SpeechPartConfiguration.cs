using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    static class SpeechPartConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeechPart>()
                        .Property(cs => cs.Id)
                        .ValueGeneratedNever();
        }
    }
}
