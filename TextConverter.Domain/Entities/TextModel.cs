using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TextConverter.Domain.Entities
{
    public class TextModel
    {
        private char[] _sentenceSeparatorsList = new char[] { '.', '!', '?' };
        private List<Sentence> _sentenceList;
        private string _textTag = "text";
        private string _sentenceCSVName = "Sentence";
        private string _wordCSVName = "Word";
        
        public List<Sentence> SentenceList { get { return _sentenceList; } }        

        public TextModel(string text)
        {
            _sentenceList = new List<Sentence>();
            ConvertTextToSentences(text);
        }

        private void ConvertTextToSentences(string text)
        {
            if (string.IsNullOrEmpty(text))
                return;

            var sentencesTextList = text.Split(_sentenceSeparatorsList, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < sentencesTextList.Length; i++)
            {
                SentenceList.Add(new Sentence(sentencesTextList[i]));
            }
        }

        public string ConvertToXML()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF - 8\" standalone=\"yes\"?>");
            sb.AppendLine($"<{_textTag}>");
            foreach (var sentence in _sentenceList)
            {
                sb.AppendLine(sentence.ConvertToXML());
            }
            sb.Append($"</{_textTag}>");
            return sb.ToString();
        }

        public string ConvertToCSV()
        {
            var sb = new StringBuilder();            
            int maxWordCount = _sentenceList.Max(sentence => sentence.WordList.Count);
            for (int i = 1; i <= maxWordCount; i++)
            {
                sb.Append($", {_wordCSVName} {i}");
            }
            sb.AppendLine();
            int rowNumber = 1;
            foreach (var sentence in _sentenceList)
            {
                sb.Append($"{_sentenceCSVName} {rowNumber++}, ");
                sb.AppendLine(sentence.ConvertToCSV());
            }
            sb.Remove(sb.Length - 2, 2); // Remove Last NewLine
            return sb.ToString();
        }
    }
}