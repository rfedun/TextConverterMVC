using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextConverter.Domain.Entities
{
    public class Word
    {
        private string _text = string.Empty;
        private string _xmlTag = "word";

        public string Text { get { return _text; } }

        public Word(string text)
        {
            ConvertTextToWord(text);
        }

        public string ConvertToXML()
        {
            return $"<{_xmlTag}>{_text}</{_xmlTag}>";
        }

        private void ConvertTextToWord(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                _text = string.Empty;
                return;
            }

            var startIndex = text.IndexOf(text.First(c => char.IsLetterOrDigit(c)));
            var result = text.Substring(startIndex);
            var endIndex = result.LastIndexOf(result.Last(c => char.IsLetterOrDigit(c)));
            _text = result.Substring(0, endIndex + 1);
        }
    }
}