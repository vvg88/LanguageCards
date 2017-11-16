using LanguageCards.Data;
using LanguageCards.Data.Repositories;
using System;
using System.Linq;

namespace LanguageCards.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (LanguageCardsContext CardsDataBase = new LanguageCardsContext())
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
