using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    /// <summary>
    /// Represents part of speech
    /// </summary>
    public class SpeechPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Word> Words { get; set; }
        public ICollection<Translation> Translations { get; set; }
    }
}
