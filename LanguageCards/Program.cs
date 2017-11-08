using LanguageCards.Data;
using LanguageCards.Data.Models;
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
                var sortedCards = CardsDataBase.Cards.Include(card => card.Word)
                                                     .Include(card => card.Word.Language)
                                                     .Include(card => card.Word.Translations)
                                                     .OrderBy(card => card.Word.Text);
                var words = CardsDataBase.Words.Include(wrd => wrd.Language).Include(wrd => wrd.ClassOfWord);

                foreach (var card in sortedCards)
                {
                    Console.WriteLine($"{card.Word.Text}: ");
                }
                Console.Write("Type a word: ");
                var word = Console.ReadLine();
                var foundCard = sortedCards.FirstOrDefault(card => card.Word.Text == word);
                if (foundCard != null)
                {
                    Console.WriteLine(foundCard.Word.Definition);
                    Console.WriteLine(foundCard.Word.Translations.FirstOrDefault().Text);
                    Console.WriteLine(foundCard.Word.Example);
                }
            }

            Console.Read();
        }
    }
}
