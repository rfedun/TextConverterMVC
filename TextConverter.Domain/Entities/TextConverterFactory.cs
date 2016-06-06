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

    public class TextConverterFactory
    {
        public static ITextConverter GetTextConverter(ConverterTypes type)
        {
            switch (type)
            {
                case ConverterTypes.TextToXML:
                    return new XMLConverter();
                case ConverterTypes.TextToCSV:
                    return new CSVConverter();
                default:
                    return new XMLConverter();
            }
        }        
    }
}