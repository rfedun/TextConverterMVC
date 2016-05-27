using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TextConverter.Models;

namespace TextConverter.Controllers
{
    public class TextConverterController : ApiController
    {
        [HttpPost]
        public string GetConvertedText(TextForConverting convertingText)
        {
            return Helpers.TextConvertingHelper.GetConvertedText(convertingText);
        }
    }
}
