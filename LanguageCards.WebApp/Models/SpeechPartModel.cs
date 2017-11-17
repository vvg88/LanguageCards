using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class SpeechPartModel
    {
        public static explicit operator SpeechPart(SpeechPartModel languageModel)
        {
            return new SpeechPart();
        }

        public static explicit operator SpeechPartModel(SpeechPart languageModel)
        {
            return new SpeechPartModel();
        }
    }
}
