using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextConverter.Domain.Entities;
using TextConverter.Models;

namespace TextConverter.Helpers
{
    public class TextConvertingHelper
    {
        public static string GetConvertedText(TextForConverting convertingText)
        {
            var textModel = TextModel.ConvertTextToModel(convertingText.InputText);
            if (textModel != null)
            {
                switch (convertingText.TextFormat)
                {
                    case TextForConverting.TextFormats.XML:
                        return TextConverterFactory.GetTextConverter(ConverterTypes.TextToXML).Convert(textModel);
                    case TextForConverting.TextFormats.CSV:
                        return TextConverterFactory.GetTextConverter(ConverterTypes.TextToCSV).Convert(textModel);
                    default:
                        break;
                }
            }

            return string.Empty;
        }
    }
}