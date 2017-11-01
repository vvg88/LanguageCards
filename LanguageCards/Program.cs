using Microsoft.EntityFrameworkCore;
using System;

namespace LanguageCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void InitializeContext(CardsDb context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Cards.Add(new Card("creation", "The act of creating something, or the thing that is created", "Создание", new[] { "The creation of a new political party.", "Their policies all emphasize the creation of wealth.", "This 25-foot-high sculpture is her latest creation." }));
            context.Cards.Add(new Card("", "", "", new[] { "", "", "" }));
            context.Cards.Add(new Card("", "", "", new[] { "", "", "" }));
            context.Cards.Add(new Card("", "", "", new[] { "", "", "" }));
            context.Cards.Add(new Card("", "", "", new[] { "", "", "" }));
            context.Cards.Add(new Card("", "", "", new[] { "", "", "" }));
            context.Cards.Add(new Card("", "", "", new[] { "", "", "" }));
            context.Cards.Add(new Card("", "", "", new[] { "", "", "" }));
            context.Cards.Add(new Card("", "", "", new[] { "", "", "" }));
            context.Cards.Add(new Card("", "", "", new[] { "", "", "" }));
        }
    }
}
