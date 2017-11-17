using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class LanguageModel
    {
        public static explicit operator Language(LanguageModel languageModel)
        {
            return new Language();
        }

        public static explicit operator LanguageModel(Language languageModel)
        {
            return new LanguageModel();
        }
    }
}
