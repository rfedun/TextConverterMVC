using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextConverter.Domain.Interfaces;

namespace TextConverter.Domain.Entities
{
    public class CSVConverter : ITextConverter
    {
        private string _sentenceName = "Sentence";
        private string _wordName = "Word";

        public string Convert(ITextModel textModel)
        {
            if (textModel.SentenceList.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();
            int maxWordCount = textModel.SentenceList.Max(sentence => sentence.WordList.Count);
            for (int i = 1; i <= maxWordCount; i++)
            {
                sb.Append($", {_wordName} {i}");
            }
            sb.AppendLine();
            int rowNumber = 1;
            foreach (var sentence in textModel.SentenceList)
            {
                sb.Append($"{_sentenceName} {rowNumber++}, ");
                sb.AppendLine(ConvertSentenceToCSV(sentence));
            }
            sb.Remove(sb.Length - 2, 2); // Remove Last NewLine
            return sb.ToString();
        }

        private string ConvertSentenceToCSV(Sentence sentence)
        {
            if (sentence.WordList.Count == 0)
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var word in sentence.WordList.OrderBy(word => word.Text))
            {
                sb.Append(word.Text + ", ");
            }
            return sb.Remove(sb.Length - 2, 2).ToString();
        }
    }
}
