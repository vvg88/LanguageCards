using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCards.Data.Entities
{
    [Table("WordsTranslations")]
    public class WordTranslation
    {
        public int Id { get; set; }
        public int? WordId { get; set; }
        public Word Word { get; set; }
        public int? TranslationId { get; set; }
        public Word Translation { get; set; }
    }
}
