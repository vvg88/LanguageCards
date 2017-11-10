using LanguageCards.Data;
using LanguageCards.Data.Access_Layer;
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
                using (var accessProvider = DbAccessLayer.DbAccessProvider)
                {
                    var user = accessProvider.GetUsers().FirstOrDefault();
                    var cards = accessProvider.GetRandomCards(5, user);
                    foreach (var card in cards)
                    {
                        Console.WriteLine($"{card.Word.Text}: ");
                    }
                    Console.WriteLine();

                    cards = accessProvider.GetRandomCards(5, user);
                    foreach (var card in cards)
                    {
                        Console.WriteLine($"{card.Word.Text}: ");
                    }
                    Console.WriteLine();
                    cards = accessProvider.GetRandomCards(5, user);
                    foreach (var card in cards)
                    {
                        Console.WriteLine($"{card.Word.Text}: ");
                    }
                }
                //Console.Write("Type a word: ");
                //var word = Console.ReadLine();
                //var foundCard = cards.FirstOrDefault(card => card.Word.Text == word);
                //if (foundCard != null)
                //{
                //    Console.WriteLine(foundCard.Word.Definition);
                //    Console.WriteLine(foundCard.Word.Translations.FirstOrDefault().Text);
                //    Console.WriteLine(foundCard.Word.Example);
                //}
            }

            Console.Read();
        }
    }
}
