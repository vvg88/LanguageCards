using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageCards
{
    public class Example
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public Example(string text)
        {
            Text = text;
        }
    }
}
