using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class CardStatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator CardStatusModel(CardStatus card)
        {
            return new CardStatusModel()
            {
                Id = card.Id,
                Name = card.Name,
            };
        }
    }
}
