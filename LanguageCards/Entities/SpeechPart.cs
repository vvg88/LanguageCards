using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LanguageCards.Data.Entities
{
    /// <summary>
    /// Represents part of speech
    /// </summary>
    public class SpeechPart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Word> Words { get; set; }
        public ICollection<Translation> Translations { get; set; }
    }
}
