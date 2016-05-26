using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextConverter.Domain.Entities;
using TextConverter.Models;

namespace TextConverter.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            return View(new TextForConverting());
        }

        [HttpPost]
        public ViewResult Index(TextForConverting text)
        {
            var textModel = TextModel.ConvertTextToModel(text.InputText);
            if (textModel != null)
            {
                switch (text.TextFormat)
                {
                    case TextForConverting.TextFormats.XML:
                        text.ConvertedText = TextConverterManager.GetTextConverter(ConverterTypes.TextToXML, textModel).Convert();
                        break;
                    case TextForConverting.TextFormats.CSV:
                        text.ConvertedText = TextConverterManager.GetTextConverter(ConverterTypes.TextToCSV, textModel).Convert();
                        break;
                    default:
                        break;
                }
            }
                        
            return View(text);
        }
    }
}