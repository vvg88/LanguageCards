﻿using LanguageCards.Data;
using LanguageCards.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace LanguageCards.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LanguageCardsContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LanguageCards1;Trusted_Connection=True;");
            using (LanguageCardsContext CardsDataBase = new LanguageCardsContext(optionsBuilder.Options))
            {
                DbInitializer.InitializeContext(CardsDataBase);
                var user = RepositoryProvider.GetUsersRepository(CardsDataBase).GetUsers().FirstOrDefault();
                var cardsRep = RepositoryProvider.GetCardsRepository(CardsDataBase);
                var cards = cardsRep.GetCards(user.Id, 3);
                foreach (var card in cards)
                {
                    Console.WriteLine($"{card.Word.Text}: ");
                }
                Console.WriteLine();
                //cardsRep.SetCardsInProgress(cards, user.Id);

                cards = cardsRep.GetCards(user.Id, 5);
                foreach (var card in cards)
                {
                    Console.WriteLine($"{card.Word.Text}: ");
                }
                Console.WriteLine();
                cards = cardsRep.GetCards(user.Id, 7);
                foreach (var card in cards)
                {
                    Console.WriteLine($"{card.Word.Text}: ");
                }
            }

            Console.Read();
        }
    }
}
