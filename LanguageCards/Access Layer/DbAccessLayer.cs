using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LanguageCards.Data.Models;

namespace LanguageCards.Data.Access_Layer
{
    public class DbAccessLayer : IDisposable
    {
        private CardsDb cardsDb;
        private int[] randomIntegers;
        private int rndIntegersPosition;
        private Random cardsRandomizer;
        private static DbAccessLayer dbAccessProvider;

        public static DbAccessLayer DbAccessProvider => dbAccessProvider ?? (dbAccessProvider = new DbAccessLayer());

        private DbAccessLayer()
        {
            cardsRandomizer = new Random();
            cardsDb = new CardsDb();
            DbInitializer.InitializeContext(cardsDb);
        }

        /*public IEnumerable<Card> GetRandomCards(int cardsNumber, User user, UserProgress session, int scoreLessThan = 5)
        {
            //var targetCards = cardsDb.Cards.Include(card => card.Word)
            //                               .Include(card => card.Word.Language)
            //                               .Include(card => card.Word.Translations);
            //.Where();
            var sessionCards = session?.SessionCards;
            var targetCards = cardsDb.CardScores.Include(cs => cs.Card)
                                                .Include(cs => cs.User)
                                                .Where(cs => cs.Score < scoreLessThan && cs.User.Id == user.Id)
                                                .Select(cs => cs.Card);
            //var a = sessionCards.Intersect(targetCards);
            throw new NotImplementedException();
        }*/

        public IEnumerable<Card> GetRandomCards(int cardsNumber, User user, int scoreLessThan = 5)
        {
            var targetCards = cardsDb.CardScoresStatuses.Where(cs => cs.Score < scoreLessThan && cs.User.Id == user.Id)
                                                .Select(cs => cs.Card);
            var cardsAsList = targetCards.Include(c => c.Word).ToList();
            var rndArr = GetRandomSet(cardsNumber, 0, cardsAsList.Count);
            return rndArr.Select(i => cardsAsList[i]);
        }

        public IEnumerable<User> GetUsers() => cardsDb.Users;

        /*public IEnumerable<UserProgress> GetSessions(User user) => cardsDb.Sessions.Include(s => s.SessionCards)
                                                                              .Include(s => s.User)
                                                                              .Where(s => s.User.Id == user.Id);*/

        private IEnumerable<int> GetRandomSet(int setSize, int setMinVal, int setMaxVal)
        {
            if (randomIntegers == null || rndIntegersPosition >= randomIntegers.Length)
                InitRandomSet(setMaxVal - setMinVal);

            var setToReturn = randomIntegers.Skip(rndIntegersPosition).Take(setSize);
            rndIntegersPosition += setSize;
            return setToReturn;
        }

        private void InitRandomSet(int setSize)
        {
            randomIntegers = new int[setSize];
            rndIntegersPosition = 0;
            var rndList = new List<int>(setSize);
            while (rndList.Count < setSize)
            {
                var rndVal = cardsRandomizer.Next(setSize);
                if (!rndList.Contains(rndVal))
                {
                    rndList.Add(rndVal);
                }
            }
            randomIntegers = rndList.ToArray();
        }

        public void Dispose()
        {
            cardsDb.Dispose();
        }
    }
}
