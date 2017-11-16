using LanguageCards.Data.Entities;
using LanguageCards.Data.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LanguageCards.Data
{
    static class DbInitializer
    {
        public static void InitializeContext(LanguageCardsContext context)
        {
            //context.Database.EnsureDeleted();
            var b = context.Database.EnsureCreated();

            if (context.Cards.Any())
            {
                return;
            }

            var user = AddUser(context, "Vladimir", "Grishanin");
            
            var originalLang = AddLanguage(context, CultureInfo.CurrentCulture);
            var translateLang = AddLanguage(context, CultureInfo.GetCultures(CultureTypes.AllCultures)
                                                                .FirstOrDefault(cultInf => cultInf.Name == "ru"));

            var speechParts = new Dictionary<SpeechPartEnum, SpeechPart>
            {
                { SpeechPartEnum.Noun, AddSpeechPart(context, SpeechPartEnum.Noun) },
                { SpeechPartEnum.Adjective, AddSpeechPart(context, SpeechPartEnum.Adjective) },
                { SpeechPartEnum.Adverb, AddSpeechPart(context, SpeechPartEnum.Adverb) },
                { SpeechPartEnum.Verb, AddSpeechPart(context, SpeechPartEnum.Verb) },
                { SpeechPartEnum.Pronoun, AddSpeechPart(context, SpeechPartEnum.Pronoun) },
            };

            var cardStatuses = new Dictionary<CardStatusEnum, CardStatus>
            {
                {CardStatusEnum.InProgress, AddCardStatus(context, CardStatusEnum.InProgress) },
                {CardStatusEnum.Finished, AddCardStatus(context, CardStatusEnum.Finished) },
            };

            #region Cards adding

            var card = AddCard(
                contxt: context,
                txt: "creation",
                lang: originalLang,
                wClass: speechParts[SpeechPartEnum.Noun],
                defStr: "The act of creating something, or the thing that is created",
                examp: "The creation of a new political party.",
                translations: new[]
                {
                    new Translation() { Text = "Создание", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] },
                    new Translation() { Text = "Творчество", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] },
                    new Translation() { Text = "Созидание", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] }
                });

            card = AddCard(
                contxt: context,
                txt: "redundant",
                lang: originalLang,
                wClass: speechParts[SpeechPartEnum.Adjective],
                defStr: "(Especially of a word, phrase, etc.) unnecessary because it is more than is needed",
                examp: "In the sentence \"She is a single unmarried woman\", the word \"unmarried\" is redundant.",
                translations: new[]
                {
                    new Translation() { Text = "Излишний", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Adjective] },
                    new Translation() { Text = "Избыточный", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Adjective] },
                    new Translation() { Text = "Чрезмерный", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Adjective] }
                });

            card = AddCard(
                contxt: context,
                txt: "avalanche",
                lang: originalLang,
                wClass: speechParts[SpeechPartEnum.Noun],
                defStr: "A large amount of ice, snow, and rock falling quickly down the side of a mountain.",
                examp: "A huge avalanche destroyed a town.",
                translations: new[]
                {
                    new Translation() { Text = "Лавина", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] },
                    new Translation() { Text = "Обвал", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] },
                    new Translation() { Text = "Масса", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] }
                });

            card = AddCard(
                contxt: context,
                txt: "ice",
                lang: originalLang,
                wClass: speechParts[SpeechPartEnum.Noun],
                defStr: "Water that has frozen and become solid, or pieces of this.",
                examp: "He slipped on a patch of ice.",
                translations: new[]
                {
                    new Translation() { Text = "Лёд", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] },
                    new Translation() { Text = "Ледяной", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Adjective] },
                    new Translation() { Text = "Покрываться льдом", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Verb] }
                });

            card = AddCard(
                contxt: context,
                txt: "patch",
                lang: originalLang,
                wClass: speechParts[SpeechPartEnum.Noun],
                defStr: "A small area that is different in some way from the area that surrounds it",
                examp: "The hotel walls were covered in damp patches.",
                translations: new[]
                {
                    new Translation() { Text = "Пятно", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] },
                    new Translation() { Text = "Заплата", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] },
                    new Translation() { Text = "Латать", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Verb] }
                });

            card = AddCard(
                contxt: context,
                txt: "snow",
                lang: originalLang,
                wClass: speechParts[SpeechPartEnum.Noun],
                defStr: "The small, soft, white pieces of ice that sometimes fall from the sky when it is cold, or the white layer on the ground and other surfaces that it forms.",
                examp: "A blanket of snow lay on the ground.\nOutside the snow began to fall.",
                translations: new[]
                {
                    new Translation() { Text = "Снег", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] },
                    new Translation() { Text = "Снежный", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Adjective] },
                    new Translation() { Text = "Заносить снегом", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Verb] }
                });

            card = AddCard(
                contxt: context,
                txt: "glacier",
                lang: originalLang,
                wClass: speechParts[SpeechPartEnum.Noun],
                defStr: "A large mass of ice that moves slowly.",
                examp: "A glacier is like a river of ice.\nAs the weather got warmer, the glacier started to melt.",
                translations: new[]
                {
                    new Translation() { Text = "Ледник", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] }
                });

            card = AddCard(
                contxt: context,
                txt: "snowflake",
                lang: originalLang,
                wClass: speechParts[SpeechPartEnum.Noun],
                defStr: "A small piece of snow that falls from the sky. Snowflakes are sometimes represented as six-sided crystals on Christmas cards, decorations, etc.",
                examp: "On day 9, the snowflakes became very big.",
                translations: new[]
                {
                    new Translation() { Text = "Снежинка", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] },
                });

            card = AddCard(
                contxt: context,
                txt: "hail",
                lang: originalLang,
                wClass: speechParts[SpeechPartEnum.Noun],
                defStr: "Small, hard balls of ice that fall from the sky like rain.",
                examp: "There will be widespread showers of rain and hail.",
                translations: new[]
                {
                    new Translation() { Text = "Град", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] },
                    new Translation() { Text = "Оклик", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] },
                    new Translation() { Text = "Приветствовать", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Verb] }
                });

            card = AddCard(
                contxt: context,
                txt: "ice cream",
                lang: originalLang,
                wClass: speechParts[SpeechPartEnum.Noun],
                defStr: "A very cold, sweet food made from frozen milk or cream, sugar, and a flavour.",
                examp: "Danny, come here and choose your ice cream.\nWe sell 32 different flavours of ice cream.\nA tub of ice cream.",
                translations: new[]
                {
                    new Translation() { Text = "Мороженое", Language = translateLang, SpeechPart = speechParts[SpeechPartEnum.Noun] }
                });

            #endregion

            context.SaveChanges();
        }

        private static User AddUser(LanguageCardsContext context, string firstName, string lastName)
        {
            var newUser = new User() { FirstName = firstName, LastName = lastName };
            context.Users.Add(newUser);
            return newUser;
        }

        private static Language AddLanguage(LanguageCardsContext contxt, CultureInfo cInf)
        {
            var newLang = new Language() { Name = cInf.EnglishName, NativeName = cInf.NativeName };
            contxt.Languages.Add(newLang);
            return newLang;
        }

        private static Card AddCard(LanguageCardsContext contxt, string txt, Language lang, SpeechPart wClass, string defStr, string examp, IEnumerable<Translation> translations)
        {
            var word = new Word() { Text = txt, Language = lang, SpeechPart = wClass, Definition = defStr, Example = examp, Translations = translations.ToArray() };
            var card = new Card() { Word = word };
            contxt.Cards.Add(card);
            return card;
        }

        private static SpeechPart AddSpeechPart(LanguageCardsContext contxt, SpeechPartEnum sp)
        {
            var speechPart = new SpeechPart() { Id = (int)sp, Name = sp.ToString() };
            contxt.SpeechParts.Add(speechPart);
            return speechPart;
        }

        private static CardProgress AddProgress(LanguageCardsContext contxt, Card card, User user, CardStatus cardStat)
        {
            var cardScore = new CardProgress() { Card = card, User = user, Score = 0, MaxScore = 5, CardStatus = cardStat };
            contxt.CardProgresses.Add(cardScore);
            return cardScore;
        }

        private static CardStatus AddCardStatus(LanguageCardsContext contxt, CardStatusEnum cStat)
        {
            var crdStat = new CardStatus() { Id = (int)cStat, Name = cStat.ToString() };
            contxt.Statuses.Add(crdStat);
            return crdStat;
        }
    }
}
