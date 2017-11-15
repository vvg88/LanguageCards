using LanguageCards.Data;
using LanguageCards.Data.AccessLayer;
using LanguageCards.Data.Entities;
using LanguageCards.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;

namespace LanguageCards
{
    class Program
    {
        static void Main(string[] args)
        {
            using (LanguageCardsContext CardsDataBase = new LanguageCardsContext())
            {
                DbInitializer.InitializeContext(CardsDataBase);
                var user = new UsersRepository(CardsDataBase).GetUsers().FirstOrDefault();
                var cardsRep = new CardsRepository(CardsDataBase);
                var cards = cardsRep.GetCards(user.Id, 3);
                foreach (var card in cards)
                {
                    Console.WriteLine($"{card.Word.Text}: ");
                }
                Console.WriteLine();

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
