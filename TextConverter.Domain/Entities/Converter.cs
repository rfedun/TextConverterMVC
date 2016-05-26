using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace TextConverter.Domain.Entities
{
    public class Converter
    {
        private TextModel _textModel;

        public Converter(TextModel textModel)
        {
            _textModel = textModel;
        }

        public static TextModel CreateTextModel(string text)
        {
            return new TextModel("");
        }

        public static string ConvertToXML(TextModel textModel)
        {
            return string.Empty;
        }

        public string ConvertToCSV()
        {
            return string.Empty;
        }
    }
}