using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards
{
    public class Word
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Language { get; set; }
        public WordClass ClassOfWord { get; set; }
    }
}
