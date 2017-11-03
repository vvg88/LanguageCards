using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LanguageCards
{
    static class DbInitializer
    {
        public static void InitializeContext(CardsDb context)
        {
            //context.Database.EnsureDeleted();
            var b = context.Database.EnsureCreated();

            if (context.Cards.Any())
            {
                return;
            }

            var originalLang = CultureInfo.CurrentCulture.Name;
            var tranlateLang = CultureInfo.GetCultures(CultureTypes.AllCultures)
                                          .FirstOrDefault(cultInf => cultInf.Name == "ru").Name;
            context.Cards.Add(new Card()
            {
                Word = new Word { Text = "creation", ClassOfWord = WordClass.Noun, Language = originalLang },
                Definition = "The act of creating something, or the thing that is created",
                Example = "The creation of a new political party.",
                Translations = new[]
                {
                    new Word() { Text = "Создание", Language = tranlateLang, ClassOfWord = WordClass.Noun },
                    new Word() { Text = "Творчество", Language = tranlateLang, ClassOfWord = WordClass.Noun },
                    new Word() { Text = "Созидание", Language = tranlateLang, ClassOfWord = WordClass.Noun }
                }
            });
            context.Cards.Add(new Card()
            {
                Word = new Word { Text = "redundant", ClassOfWord = WordClass.Adjective, Language = originalLang },
                Definition = "(Especially of a word, phrase, etc.) unnecessary because it is more than is needed",
                Example = "In the sentence \"She is a single unmarried woman\", the word \"unmarried\" is redundant.",
                Translations = new[]
                {
                    new Word() { Text = "Излишний", Language = tranlateLang, ClassOfWord = WordClass.Adjective },
                    new Word() { Text = "Избыточный", Language = tranlateLang, ClassOfWord = WordClass.Adjective },
                    new Word() { Text = "Чрезмерный", Language = tranlateLang, ClassOfWord = WordClass.Adjective }
                }
            });
            context.Cards.Add(new Card()
            {
                Word = new Word { Text = "avalanche", ClassOfWord = WordClass.Noun, Language = originalLang },
                Definition = "A large amount of ice, snow, and rock falling quickly down the side of a mountain",
                Example = "A huge avalanche destroyed a town.",
                Translations = new[]
                {
                    new Word() { Text = "Лавина", Language = tranlateLang, ClassOfWord = WordClass.Noun },
                    new Word() { Text = "Обвал", Language = tranlateLang, ClassOfWord = WordClass.Noun },
                    new Word() { Text = "Масса", Language = tranlateLang, ClassOfWord = WordClass.Noun }
                }
            });
            context.Cards.Add(new Card()
            {
                Word = new Word { Text = "ice", ClassOfWord = WordClass.Noun, Language = originalLang },
                Definition = "Water that has frozen and become solid, or pieces of this",
                Example = "He slipped on a patch of ice.",
                Translations = new[]
                {
                    new Word() { Text = "Лёд", Language = tranlateLang, ClassOfWord = WordClass.Noun },
                    new Word() { Text = "Ледяной", Language = tranlateLang, ClassOfWord = WordClass.Adjective },
                    new Word() { Text = "Покрываться льдом", Language = tranlateLang, ClassOfWord = WordClass.Verb }
                }
            });
            context.Cards.Add(new Card()
            {
                Word = new Word { Text = "patch", ClassOfWord = WordClass.Noun, Language = originalLang },
                Definition = "A small area that is different in some way from the area that surrounds it",
                Example = "The hotel walls were covered in damp patches.",
                Translations = new[]
                {
                    new Word() { Text = "Пятно", Language = tranlateLang, ClassOfWord = WordClass.Noun },
                    new Word() { Text = "Заплата", Language = tranlateLang, ClassOfWord = WordClass.Noun },
                    new Word() { Text = "Латать", Language = tranlateLang, ClassOfWord = WordClass.Verb }
                }
            });
            context.Cards.Add(new Card()
            {
                Word = new Word { Text = "snow", ClassOfWord = WordClass.Noun, Language = originalLang },
                Definition = "The small, soft, white pieces of ice that sometimes fall from the sky when it is cold, or the white layer on the ground and other surfaces that it forms",
                Example = "A blanket of snow lay on the ground.\nOutside the snow began to fall.",
                Translations = new[]
                {
                    new Word() { Text = "Снег", Language = tranlateLang, ClassOfWord = WordClass.Noun },
                    new Word() { Text = "Снежный", Language = tranlateLang, ClassOfWord = WordClass.Adjective },
                    new Word() { Text = "Заносить снегом", Language = tranlateLang, ClassOfWord = WordClass.Verb }
                }
            });
            context.Cards.Add(new Card()
            {
                Word = new Word { Text = "glacier", ClassOfWord = WordClass.Noun, Language = originalLang },
                Definition = "A large mass of ice that moves slowly",
                Example = "A glacier is like a river of ice.\nAs the weather got warmer, the glacier started to melt.",
                Translations = new[]
                {
                    new Word() { Text = "Ледник", Language = tranlateLang, ClassOfWord = WordClass.Noun },
                }
            });
            context.Cards.Add(new Card()
            {
                Word = new Word { Text = "snowflake", ClassOfWord = WordClass.Noun, Language = originalLang },
                Definition = "A small piece of snow that falls from the sky. Snowflakes are sometimes represented as six-sided crystals on Christmas cards, decorations, etc.",
                Example = "On day 9, the snowflakes became very big.",
                Translations = new[]
                {
                    new Word() { Text = "Снежинка", Language = tranlateLang, ClassOfWord = WordClass.Noun },
                }
            });
            context.Cards.Add(new Card()
            {
                Word = new Word { Text = "hail", ClassOfWord = WordClass.Noun, Language = originalLang },
                Definition = "Small, hard balls of ice that fall from the sky like rain",
                Example = "There will be widespread showers of rain and hail.",
                Translations = new[]
                {
                    new Word() { Text = "Град", Language = tranlateLang, ClassOfWord = WordClass.Noun },
                    new Word() { Text = "Оклик", Language = tranlateLang, ClassOfWord = WordClass.Noun },
                    new Word() { Text = "Приветствовать", Language = tranlateLang, ClassOfWord = WordClass.Verb }
                }
            });
            context.Cards.Add(new Card()
            {
                Word = new Word { Text = "ice cream", ClassOfWord = WordClass.Noun, Language = originalLang },
                Definition = "A very cold, sweet food made from frozen milk or cream, sugar, and a flavour",
                Example = "Danny, come here and choose your ice cream.\nWe sell 32 different flavours of ice cream.\nA tub of ice cream.",
                Translations = new[]
                {
                    new Word() { Text = "Мороженое", Language = tranlateLang, ClassOfWord = WordClass.Noun },
                }
            });

            context.SaveChanges();
        }
    }
}
