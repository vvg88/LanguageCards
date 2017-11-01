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
        public string Word { get; set; }

        /// <summary>
        /// Represents the definition of the word
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Represents the translation of the word
        /// </summary>
        public string Translation { get; set; }

        /// <summary>
        /// Represents a set of examples containing this word
        /// </summary>
        public ICollection<Example> Examples { get; set; }

        public Card(string word, string definition, string translation, IEnumerable<Example> examples)
        {
            Word = word;
            Definition = definition;
            Translation = translation;
            Examples = examples.ToArray();
        }
    }
}
