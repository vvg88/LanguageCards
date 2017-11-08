using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LanguageCards.Data.Models
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

            AddUser(context, "Vladimir", "Grishanin");
            
            var originalLang = AddLang(context, CultureInfo.CurrentCulture);
            var tranlateLang = AddLang(context, CultureInfo.GetCultures(CultureTypes.AllCultures).FirstOrDefault(cultInf => cultInf.Name == "ru"));

            var speechParts = new Dictionary<WordClass, SpeechPart>
            {
                { WordClass.Noun, AddSpeechPart(context, WordClass.Noun) },
                { WordClass.Adjective, AddSpeechPart(context, WordClass.Adjective) },
                { WordClass.Adverb, AddSpeechPart(context, WordClass.Adverb) },
                { WordClass.Verb, AddSpeechPart(context, WordClass.Verb) },
                { WordClass.Pronoun, AddSpeechPart(context, WordClass.Pronoun) },
            };

            #region Cards adding
            AddCard(
                contxt: context,
                txt: "creation",
                lang: originalLang,
                wClass: speechParts[WordClass.Noun],
                defStr: "The act of creating something, or the thing that is created",
                examp: "The creation of a new political party.",
                translations: new[]
                {
                    new Word() { Text = "Создание", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] },
                    new Word() { Text = "Творчество", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] },
                    new Word() { Text = "Созидание", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] }
                });

            AddCard(
                contxt: context,
                txt: "redundant",
                lang: originalLang,
                wClass: speechParts[WordClass.Adjective],
                defStr: "(Especially of a word, phrase, etc.) unnecessary because it is more than is needed",
                examp: "In the sentence \"She is a single unmarried woman\", the word \"unmarried\" is redundant.",
                translations: new[]
                {
                    new Word() { Text = "Излишний", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Adjective] },
                    new Word() { Text = "Избыточный", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Adjective] },
                    new Word() { Text = "Чрезмерный", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Adjective] }
                });

            AddCard(
                contxt: context,
                txt: "avalanche",
                lang: originalLang,
                wClass: speechParts[WordClass.Noun],
                defStr: "A large amount of ice, snow, and rock falling quickly down the side of a mountain.",
                examp: "A huge avalanche destroyed a town.",
                translations: new[]
                {
                    new Word() { Text = "Лавина", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] },
                    new Word() { Text = "Обвал", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] },
                    new Word() { Text = "Масса", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] }
                });

            AddCard(
                contxt: context,
                txt: "ice",
                lang: originalLang,
                wClass: speechParts[WordClass.Noun],
                defStr: "Water that has frozen and become solid, or pieces of this.",
                examp: "He slipped on a patch of ice.",
                translations: new[]
                {
                    new Word() { Text = "Лёд", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] },
                    new Word() { Text = "Ледяной", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Adjective] },
                    new Word() { Text = "Покрываться льдом", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Verb] }
                });

            AddCard(
                contxt: context,
                txt: "patch",
                lang: originalLang,
                wClass: speechParts[WordClass.Noun],
                defStr: "A small area that is different in some way from the area that surrounds it",
                examp: "The hotel walls were covered in damp patches.",
                translations: new[]
                {
                    new Word() { Text = "Пятно", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] },
                    new Word() { Text = "Заплата", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] },
                    new Word() { Text = "Латать", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Verb] }
                });

            AddCard(
                contxt: context,
                txt: "snow",
                lang: originalLang,
                wClass: speechParts[WordClass.Noun],
                defStr: "The small, soft, white pieces of ice that sometimes fall from the sky when it is cold, or the white layer on the ground and other surfaces that it forms.",
                examp: "A blanket of snow lay on the ground.\nOutside the snow began to fall.",
                translations: new[]
                {
                    new Word() { Text = "Снег", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] },
                    new Word() { Text = "Снежный", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Adjective] },
                    new Word() { Text = "Заносить снегом", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Verb] }
                });

            AddCard(
                contxt: context,
                txt: "glacier",
                lang: originalLang,
                wClass: speechParts[WordClass.Noun],
                defStr: "A large mass of ice that moves slowly.",
                examp: "A glacier is like a river of ice.\nAs the weather got warmer, the glacier started to melt.",
                translations: new[]
                {
                    new Word() { Text = "Ледник", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] }
                });

            AddCard(
                contxt: context,
                txt: "snowflake",
                lang: originalLang,
                wClass: speechParts[WordClass.Noun],
                defStr: "A small piece of snow that falls from the sky. Snowflakes are sometimes represented as six-sided crystals on Christmas cards, decorations, etc.",
                examp: "On day 9, the snowflakes became very big.",
                translations: new[]
                {
                    new Word() { Text = "Снежинка", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] },
                });

            AddCard(
                contxt: context,
                txt: "hail",
                lang: originalLang,
                wClass: speechParts[WordClass.Noun],
                defStr: "Small, hard balls of ice that fall from the sky like rain.",
                examp: "There will be widespread showers of rain and hail.",
                translations: new[]
                {
                    new Word() { Text = "Град", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] },
                    new Word() { Text = "Оклик", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] },
                    new Word() { Text = "Приветствовать", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Verb] }
                });
            
            AddCard(
                contxt: context,
                txt: "ice cream",
                lang: originalLang,
                wClass: speechParts[WordClass.Noun],
                defStr: "A very cold, sweet food made from frozen milk or cream, sugar, and a flavour.",
                examp: "Danny, come here and choose your ice cream.\nWe sell 32 different flavours of ice cream.\nA tub of ice cream.",
                translations: new[]
                {
                    new Word() { Text = "Мороженое", Language = tranlateLang, ClassOfWord = speechParts[WordClass.Noun] }
                });
            #endregion

            context.SaveChanges();
        }

        private static void AddUser(CardsDb context, string firstName, string lastName)
        {
            var newUser = new User() { FirstName = firstName, LastName = lastName };
            context.Users.Add(newUser);
        }

        private static Language AddLang(CardsDb contxt, CultureInfo cInf)
        {
            var newLang = new Language() { Name = cInf.EnglishName, NativeName = cInf.NativeName };
            contxt.Languages.Add(newLang);
            return newLang;
        }

        private static void AddCard(CardsDb contxt, string txt, Language lang, SpeechPart wClass, string defStr, string examp, IEnumerable<Word> translations)
        {
            var word = new Term() { Text = txt, Language = lang, ClassOfWord = wClass, Definition = defStr, Example = examp, Translations = translations.ToArray() };
            var card = new Card() { Word = word };
            contxt.Cards.Add(card);
        }

        private static SpeechPart AddSpeechPart(CardsDb contxt, WordClass wc)
        {
            var speechPart = new SpeechPart() { Name = wc.ToString() };
            contxt.SpeechParts.Add(speechPart);
            return speechPart;
        }
    }
}
