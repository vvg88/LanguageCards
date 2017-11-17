using LanguageCards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageCards.WebApp.Models
{
    public class WordModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int LanguageId { get; set; }
        public LanguageModel Language { get; set; }
        public int SpeechPartId { get; set; }
        public SpeechPartModel SpeechPart { get; set; }
        public string Definition { get; set; }
        public ICollection<WordModel> Translations { get; set; }
        public string Example { get; set; }

        public static explicit operator WordModel(Word word)
        {
            return new WordModel()
            {
                Id = word.Id,
                Text = word.Text,
                LanguageId = word.LanguageId,
                Language = (LanguageModel)word.Language,
                SpeechPartId = word.SpeechPartId,
                SpeechPart = (SpeechPartModel)word.SpeechPart,
                Definition = word.Definition,
                Translations = (word.Translations == null || word.Translations.Count == 0) ? Enumerable.Empty<WordModel>().ToList() : word.Translations.Cast<WordModel>().ToList(),
                Example = word.Example,
            };
        }

        public static explicit operator Word(WordModel wordModel)
        {
            return new Word()
            {
                Id = wordModel.Id,
                Text = wordModel.Text,
                LanguageId = wordModel.LanguageId,
                Language = (Language)wordModel.Language,
                SpeechPartId = wordModel.SpeechPartId,
                SpeechPart = (SpeechPart)wordModel.SpeechPart,
                Definition = wordModel.Definition,
                Translations = (wordModel.Translations == null || wordModel.Translations.Count == 0) ? Enumerable.Empty<Word>().ToList() : wordModel.Translations.Cast<Word>().ToList(),
                Example = wordModel.Example,
            };
        }
    }
}
