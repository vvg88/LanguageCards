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
            using (CardsDb CardsDataBase = new CardsDb())
            {
                DbInitializer.InitializeContext(CardsDataBase);

                var sortedCards = CardsDataBase.Cards.OrderBy(card => card.Word.Text);

                foreach (var card in CardsDataBase.Cards)
                {
                    Console.WriteLine($"{card.Word.Text}: ");
                }

                Console.Write("Type a word: ");
                var word = Console.ReadLine();
                var foundCard = sortedCards.FirstOrDefault(card => card.Word.Text == word);
                /*if (foundCard != null)
                {
                    Console.WriteLine(foundCard.Definition);
                    Console.WriteLine(foundCard.Translations.FirstOrDefault());
                    Console.WriteLine(foundCard.Example);
                }*/
            }

            Console.Read();
        }
    }
}
