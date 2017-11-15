using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LanguageCards.Data.Entities;

namespace LanguageCards.Data.AccessLayer
{
    public class DbAccessLayer : IDisposable
    {
        private LanguageCardsContext cardsDb;
        private Random cardsRandomizer;
        private List<Card> requestedCardsList;
        private static DbAccessLayer dbAccessProvider;

        public static DbAccessLayer DbAccessProvider => dbAccessProvider ?? (dbAccessProvider = new DbAccessLayer());

        private DbAccessLayer()
        {
            cardsRandomizer = new Random();
            cardsDb = new LanguageCardsContext();
            requestedCardsList = new List<Card>();
            DbInitializer.InitializeContext(cardsDb);
        }
        
        public IEnumerable<Card> GetRandomCards(int cardsNumber, User user, int scoreLessThan = 5)
        {
            if (requestedCardsList.Count == 0)
            {
                requestedCardsList = RequestCards(user).ToList();
            }
            else if (requestedCardsList.Count < cardsNumber)
            {
                requestedCardsList.AddRange(RequestCards(user).Except(requestedCardsList));
            }
            var randomIndexes = GetRandomSet(cardsNumber, requestedCardsList.Count);
            var randomCards = randomIndexes.Select(i => requestedCardsList[i]).ToList();
            requestedCardsList = requestedCardsList.Where((card, i) => !randomIndexes.Contains(i)).ToList();
            return randomCards;
        }

        public IEnumerable<User> GetUsers() => cardsDb.Users;

        private IEnumerable<Card> RequestCards(User user, int defaultCardsNum = 50)
        {
            var targetCards = cardsDb.CardProgresses.Where(cs => (CardStatusEnum)cs.CardStatus.Value == CardStatusEnum.InProgress && cs.User.Id == user.Id)
                                                        .Select(cs => cs.Card);
            if (targetCards.Count() == 0)
            {
                targetCards = cardsDb.CardProgresses.Where(cs => cs.User.Id == user.Id)
                                     .Select(cs => cs.Card)
                                     .Take(defaultCardsNum);
            }
            targetCards.Include(card => card.Word).Load();
            return targetCards;
        }
        
        private IEnumerable<int> GetRandomSet(int setSize, int setMax)
        {
            if (setSize > setMax)
                throw new ArgumentException("Required size of random non-negative integers collection should be more than maximum value!");

            var rndList = new List<int>(setSize);
            while (rndList.Count < setSize)
            {
                var rndVal = cardsRandomizer.Next(setMax);
                if (!rndList.Contains(rndVal))
                {
                    rndList.Add(rndVal);
                }
            }
            return rndList;
        }

        public void Dispose()
        {
            cardsDb.Dispose();
        }
    }
}
