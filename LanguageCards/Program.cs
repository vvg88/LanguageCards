using Microsoft.EntityFrameworkCore;
using System;

namespace LanguageCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (CardsDb CardsDataBase = new CardsDb())
            {
                InitializeContext(CardsDataBase);
            }

            Console.Read();
        }

        static void InitializeContext(CardsDb context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Cards.Add(new Card("creation", "The act of creating something, or the thing that is created", "Создание", new[] { new Example("The creation of a new political party."), new Example("Their policies all emphasize the creation of wealth."), new Example("This 25-foot-high sculpture is her latest creation.") }));
            context.Cards.Add(new Card("redundant", "(Especially of a word, phrase, etc.) unnecessary because it is more than is needed", "Излишний", new[] { new Example("In the sentence \"She is a single unmarried woman\", the word \"unmarried\" is redundant.") }));
            context.Cards.Add(new Card("avalanche", "A large amount of ice, snow, and rock falling quickly down the side of a mountain", "Лавина", new[] { new Example("A huge avalanche destroyed a town.") }));
            context.Cards.Add(new Card("ice", "Water that has frozen and become solid, or pieces of this", "Лёд", new[] { new Example("The pond was covered in ice all winter."), new Example("He slipped on a patch of ice.") }));
            context.Cards.Add(new Card("patch", "A small area that is different in some way from the area that surrounds it", "Пятно", new[] { new Example("Our dog has a black patch on his back."), new Example("The hotel walls were covered in damp patches."), new Example("There were lots of icy patches on the road this morning.") }));
            context.Cards.Add(new Card("snow", "The small, soft, white pieces of ice that sometimes fall from the sky when it is cold, or the white layer on the ground and other surfaces that it forms", "Снег", new[] { new Example("Outside the snow began to fall."), new Example("A blanket of snow lay on the ground.") }));
            context.Cards.Add(new Card("glacier", "A large mass of ice that moves slowly", "Ледник", new[] { new Example("A glacier is like a river of ice."), new Example("As the weather got warmer, the glacier started to melt.") }));
            context.Cards.Add(new Card("snowflake", "A small piece of snow that falls from the sky. Snowflakes are sometimes represented as six-sided crystals on Christmas cards, decorations, etc.", "Снежинка", new[] { new Example("On day 9, the snowflakes became very big.") }));
            context.Cards.Add(new Card("hail", "Small, hard balls of ice that fall from the sky like rain", "Град", new[] { new Example("There will be widespread showers of rain and hail.") }));
            context.Cards.Add(new Card("ice cream", "A very cold, sweet food made from frozen milk or cream, sugar, and a flavour", "Мороженое", new[] { new Example("Danny, come here and choose your ice cream."), new Example("We sell 32 different flavours of ice cream."), new Example("A tub of ice cream.") }));
        }
    }
}
