using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LanguageCards.Data.Entities
{
    /// <summary>
    /// Represents an entity of <see cref="SpeechPartEnum"/>
    /// </summary>
    public class SpeechPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Word> Words { get; set; }
    }
}
