using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    public class Translation
    {
        public int Id { get; set; }

        /// <summary>
        /// Retrieves a string representation of the word
        /// </summary>
        public string Text { get; set; }

        public int LanguageId { get; set; }
        /// <summary>
        /// Retrieves the language of the word
        /// </summary>
        public Language Language { get; set; }

        public int SpeechPartId { get; set; }
        /// <summary>
        /// Retrieves the part of speech
        /// </summary>
        public SpeechPart SpeechPart { get; set; }
    }
}
