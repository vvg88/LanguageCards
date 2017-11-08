using LanguageCards.Data.Models;
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
        /// 
        /// </summary>
        public Term Word { get; set; }
    }
}
