using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageCards
{
    public class Card
    {
        public int Id { get; set; }

        /// <summary>
        /// Word itself
        /// </summary>
        public Word Word { get; set; }

        /// <summary>
        /// Represents the definition of the word
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Represents the translations of the word
        /// </summary>
        public ICollection<Word> Translations { get; set; }

        /// <summary>
        /// Represents an example (or examoles) containing this word
        /// </summary>
        public string Example { get; set; }
    }
}
