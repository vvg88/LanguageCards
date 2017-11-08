using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Models
{
    public class Word
    {
        public int Id { get; set; }
        /// <summary>
        /// Retrieves a string representation of the word
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Retrieves the language of the word
        /// </summary>
        public Language Language { get; set; }
        /// <summary>
        /// Retrieves the part of speech
        /// </summary>
        public SpeechPart ClassOfWord { get; set; }
    }
}
