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
            var sentence = Sentence.ConvertTextToSentence(sentenceText);

            //Assert
            Assert.AreEqual(8, sentence.WordList.Count);
        }        
    }    
}
