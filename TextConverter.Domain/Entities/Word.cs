using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextConverter.Domain.Entities
{
    public class Word 
    {
        private string _text = string.Empty;        

        public string Text { get { return _text; } }

        private Word(string text)
        {
            _text = text;
        }        

        public static Word ConvertTextToWord(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            var startIndex = text.IndexOf(text.FirstOrDefault(c => char.IsLetterOrDigit(c)));
            if (startIndex < 0)
            {
                return null;
            }

            var result = text.Substring(startIndex);
            var endIndex = result.LastIndexOf(result.Last(c => char.IsLetterOrDigit(c)));
            return new Word(result.Substring(0, endIndex + 1));
        }
    }
}