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
    public class SentenceTests
    {
        [TestMethod]
        public void TestSplitingTextToWords()
        {
            //Arrange
            var sentenceText = "word1  word2,word3:word4\"word5(word6){word7} word8? ";

            //Act
            var sentence = new Sentence(sentenceText);

            //Assert
            Assert.AreEqual(8, sentence.WordList.Count);
        }

        [TestMethod]
        public void GetSentenceXML()
        {
            //Arrange
            var sentenceText = "word1 word8? ";
            var sentence = new Sentence(sentenceText);
            var nl = Environment.NewLine;

            //Act
            var sentenceXML = sentence.ConvertToXML();

            //Assert
            Assert.AreEqual($"<sentence>{nl}<word>word1</word>{nl}<word>word8</word>{nl}</sentence>", sentenceXML);
        }

        [TestMethod]
        public void GetSentenceCSV()
        {
            //Arrange
            var sentenceText = "word1 word8? ";
            var sentence = new Sentence(sentenceText);            

            //Act
            var sentenceCSV = sentence.ConvertToCSV();

            //Assert
            Assert.AreEqual("word1, word8", sentenceCSV);
        }
    }
}
