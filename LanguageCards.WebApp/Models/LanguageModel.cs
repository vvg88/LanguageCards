using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class LanguageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator Language(LanguageModel languageModel)
        {
            return new Language()
            {
                Id = languageModel.Id,
                Name = languageModel.Name,
            };
        }

        public static explicit operator LanguageModel(Language language)
        {
            return new LanguageModel()
            {
                Id = language.Id,
                Name = language.Name,
            };
        }
    }
}
