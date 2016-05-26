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
    public class TextModelTests
    {
        [TestMethod]
        public void TestSplitingTextToSentences()
        {
            //Arrange
            var text = "sentence1. sentence2!sentence3?sentence4... sentence5.";

            //Act
            var textModel = new TextModel(text);

            //Assert
            Assert.AreEqual(5, textModel.SentenceList.Count);
        }

        [TestMethod]
        public void ConvertTextModelToXML()
        {
            //Arrange
            var text = "sentence1. sentence4... sentence5.";
            var textModel = new TextModel(text);
            var nl = Environment.NewLine;

            //Act
            var textXML = textModel.ConvertToXML();

            //Assert
            Assert.AreEqual($"<?xml version=\"1.0\" encoding=\"UTF - 8\" standalone=\"yes\"?>{nl}<text>{nl}<sentence>{nl}<word>sentence1</word>{nl}</sentence>{nl}<sentence>{nl}<word>sentence4</word>{nl}</sentence>{nl}<sentence>{nl}<word>sentence5</word>{nl}</sentence>{nl}</text>", textXML);
        }

        [TestMethod]
        public void ConvertTextModelToCSV()
        {
            //Arrange
            var text = "sentence1 w1. sentence4... sentence5.";
            var textModel = new TextModel(text);
            var nl = Environment.NewLine;

            //Act
            var textCSV = textModel.ConvertToCSV();

            //Assert
            Assert.AreEqual($", Word 1, Word 2{nl}Sentence 1, sentence1, w1{nl}Sentence 2, sentence4{nl}Sentence 3, sentence5", textCSV);
        }
    }
}
