using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using TextConverter.Domain.Interfaces;

namespace TextConverter.Domain.Entities
{
    public class TextModel
    {
        private static char[] _sentenceSeparatorsList = new char[] { '.', '!', '?' };
        private List<Sentence> _sentenceList;

        public List<Sentence> SentenceList { get { return _sentenceList; } }

        private TextModel()
        {
            _sentenceList = new List<Sentence>();
        }

        public static TextModel ConvertTextToModel(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            var tempText = text.Replace(Environment.NewLine, " ");

            var sentencesTextList = tempText.Split(_sentenceSeparatorsList, StringSplitOptions.RemoveEmptyEntries);
            var textModel = new TextModel();
            for (int i = 0; i < sentencesTextList.Length; i++)
            {
                var sentence = Sentence.ConvertTextToSentence(sentencesTextList[i]);
                if (sentence != null)
                {
                    textModel.SentenceList.Add(sentence);
                }                
            }
            if (textModel.SentenceList.Count == 0)
            {
                return null;
            }
            return textModel;
        }
    }
}