﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class AnsweredCardResult
    {
        public int CardId { get; set; }
        public bool IsCorrect { get; set; }
    }
}
