using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextConverter.Domain.Entities;

namespace TextConverter.Tests
{
    [TestClass]
    public class WordTests
    {
        [TestMethod]
        public void CheckSpaces()
        {
            //Arrange
            var inputText1 = "  text  ";
            var inputText2 = "text  ";
            var inputText3 = "   text";

            //Act
            var word1 = new Word(inputText1);
            var word2 = new Word(inputText2);
            var word3 = new Word(inputText3);

            //Assert
            Assert.AreEqual("text", word1.Text);
            Assert.AreEqual("text", word2.Text);
            Assert.AreEqual("text", word3.Text);
        }

        [TestMethod]
        public void CheckPunctuations()
        {
            //Arrange
            var inputText1 = "\"text\"";
            var inputText2 = "text\"";
            var inputText3 = "\"text";

            //Act
            var word1 = new Word(inputText1);
            var word2 = new Word(inputText2);
            var word3 = new Word(inputText3);

            //Assert
            Assert.AreEqual("text", word1.Text);
            Assert.AreEqual("text", word2.Text);
            Assert.AreEqual("text", word3.Text);
        }

        [TestMethod]
        public void CheckGetXML()
        {
            //Arrange
            var word = new Word("wordText");

            //Act
            var wordXML = word.ConvertToXML();

            //Assert
            Assert.AreEqual("<word>wordText</word>", wordXML);
        }

    }
}
