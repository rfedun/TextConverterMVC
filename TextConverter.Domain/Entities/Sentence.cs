using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TextConverter.Domain.Entities
{
    public class Sentence
    {
        private char[] _wordSeparatorsList = new char[] { ' ', ',', '(', ')', ':', '"', '{', '}'};
        private string _sentenceTag = "sentence";
        private List<Word> _wordList;

        public List<Word> WordList { get { return _wordList; } }

        public Sentence(string sentenceText)
        {
            _wordList = new List<Word>();
            ConvertTextToWords(sentenceText);
        }

        private void ConvertTextToWords(string sentenceText)
        {
            if (string.IsNullOrEmpty(sentenceText))
                return;

            var wordTextList = sentenceText.Split(_wordSeparatorsList, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < wordTextList.Length; i++)
            {
                WordList.Add(new Word(wordTextList[i]));
            }
        }

        public string ConvertToXML()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"<{_sentenceTag}>");
            foreach (var word in _wordList.OrderBy(word => word.Text))
            {
                sb.AppendLine(word.ConvertToXML());
            }
            sb.Append($"</{_sentenceTag}>");
            return sb.ToString();
        }

        public string ConvertToCSV()
        {
            var sb = new StringBuilder();
            foreach (var word in _wordList.OrderBy(word => word.Text))
            {
                sb.Append(word.Text + ", ");
            }
            return sb.Remove(sb.Length-2, 2).ToString();                
        }
    }
}