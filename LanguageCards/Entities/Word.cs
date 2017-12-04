using LanguageCards.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCards.Data.Entities
{
    public class Word
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
