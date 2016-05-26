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
            var word1 = Word.ConvertTextToWord(inputText1);
            var word2 = Word.ConvertTextToWord(inputText2);
            var word3 = Word.ConvertTextToWord(inputText3);

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
            var word1 = Word.ConvertTextToWord(inputText1);
            var word2 = Word.ConvertTextToWord(inputText2);
            var word3 = Word.ConvertTextToWord(inputText3);

            //Assert
            Assert.AreEqual("text", word1.Text);
            Assert.AreEqual("text", word2.Text);
            Assert.AreEqual("text", word3.Text);
        }
    }
}
