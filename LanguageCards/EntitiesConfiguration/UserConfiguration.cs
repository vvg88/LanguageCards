using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    static class UserConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                        .Property(u => u.FirstName)
                        .IsRequired();

            modelBuilder.Entity<User>()
                        .Property(u => u.LastName)
                        .IsRequired();
        }
    }
}
