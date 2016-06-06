using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextConverter.Models
{
    public class TextForConverting
    {
        public enum TextFormats { XML, CSV }

        public string InputText { get; set; }        
        public TextFormats TextFormat { get; set; }
        public string ConvertedText { get; set; }
    }
}