using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TextConverter.Domain.Entities
{
    public class Sentence
    {
        private static char[] _wordSeparatorsList = new char[] { ' ', ',', '(', ')', ':', '"', '{', '}'};
        
        private List<Word> _wordList;

        public List<Word> WordList { get { return _wordList; } }

        private Sentence()
        {
            _wordList = new List<Word>();            
        }

        public static Sentence ConvertTextToSentence(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            var wordTextList = text.Split(_wordSeparatorsList, StringSplitOptions.RemoveEmptyEntries);
            var sentence = new Sentence();
            for (int i = 0; i < wordTextList.Length; i++)
            {
                var word = Word.ConvertTextToWord(wordTextList[i]);
                if (word != null)
                {
                    sentence.WordList.Add(word);
                }                
            }
            if (sentence.WordList.Count == 0)
            {
                return null;
            }

            return sentence;
        }
    }
}