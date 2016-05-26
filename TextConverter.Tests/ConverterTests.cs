using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextConverter.Domain.Entities;

namespace TextConverter.Tests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void ConvertToXMLTest()
        {
            //Arrange
            var text = "sentence1. sentence2!sentence3?sentence4... sentence5.";
            var textModel = new TextModel(text);

            //Act
            var xml = Converter.ConvertToXML(textModel);

            //Assert
            Assert.AreEqual(5, textModel.SentenceList.Count);
        }
    }
}
