using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextConverter.Domain.Interfaces;

namespace TextConverter.Domain.Entities
{
    public class XMLConverter : ITextConverter
    {        
        private string _textTag = "text";
        private string _sentenceTag = "sentence";
        private string _wordTag = "word";

        public string Convert(ITextModel textModel)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            sb.AppendLine($"<{_textTag}>");
            foreach (var sentence in textModel.SentenceList)
            {
                sb.AppendLine(ConvertSentenceToXML(sentence));
            }
            sb.Append($"</{_textTag}>");
            return sb.ToString();
        }

        private string ConvertSentenceToXML(Sentence sentence)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"\t<{_sentenceTag}>");
            foreach (var word in sentence.WordList.OrderBy(word => word.Text))
            {
                sb.AppendLine("\t\t" + ConvertWordToXML(word));
            }
            sb.Append($"\t</{_sentenceTag}>");
            return sb.ToString();
        }

        private string ConvertWordToXML(Word word)
        {
            return $"<{_wordTag}>{word.Text}</{_wordTag}>";
        }
    }
}
