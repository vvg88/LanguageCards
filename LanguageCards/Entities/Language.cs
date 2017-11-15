using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards.Data.Entities
{
    public class Language
    {
        public int Id { get; set; }
        /// <summary>
        /// Name of language in english
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Name of language in native language
        /// </summary>
        public string NativeName { get; set; }
    }
}
