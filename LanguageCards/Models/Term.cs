using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Models
{
    public class Term : Word
    {
        /// <summary>
        /// Represents the definition of the word
        /// </summary>
        public string Definition { get; set; }
        /// <summary>
        /// Represents the translations of the word
        /// </summary>
        public ICollection<Word> Translations { get; set; }
        /// <summary>
        /// Represents an example (or examples) containing this word
        /// </summary>
        public string Example { get; set; }
    }
}
