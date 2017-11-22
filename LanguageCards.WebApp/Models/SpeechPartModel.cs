using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class SpeechPartModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator SpeechPart(SpeechPartModel speechPartModel)
        {
            return new SpeechPart()
            {
                Id = speechPartModel.Id,
                Name = speechPartModel.Name,
            };
        }

        public static explicit operator SpeechPartModel(SpeechPart speechPart)
        {
            return new SpeechPartModel()
            {
                Id = speechPart.Id,
                Name = speechPart.Name,
            };
        }
    }
}
