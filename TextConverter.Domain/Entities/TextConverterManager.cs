using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using TextConverter.Domain.Interfaces;

namespace TextConverter.Domain.Entities
{
    public enum ConverterTypes { TextToXML, TextToCSV }

    public class TextConverterManager
    {
        public static ITextConverter GetTextConverter(ConverterTypes type, TextModel textModel)
        {
            switch (type)
            {
                case ConverterTypes.TextToXML:
                    return new XMLConverter(textModel);
                case ConverterTypes.TextToCSV:
                    return new CSVConverter(textModel);
                default:
                    return new XMLConverter(textModel);
            }
        }        
    }
}