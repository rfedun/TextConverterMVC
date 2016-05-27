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
            text.ConvertedText = Helpers.TextConvertingHelper.GetConvertedText(text);
            return View(text);
        }
    }
}