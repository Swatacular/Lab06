using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab06;

namespace PigLatinTranslator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void translateWord()
        {
            string RealWord = Program.TranslateWord("this");
            string ExpectedWord = "isthay";
            Assert.AreEqual(ExpectedWord, RealWord);

        }

        [TestMethod]
        public void translateWords()
        {
            string RealWord = Program.TranslateWords("this sentence");
            string ExpectedWord = "Isthay entencesay";
            Assert.AreEqual(ExpectedWord, RealWord.Trim());
          
        }
        [TestMethod]
        public void translateWordsToLower()
        {
            string RealWord = Program.TranslateWord("this");
            string ExpectedWord = "isthay";
            Assert.AreEqual(ExpectedWord, RealWord);

        }
    }
}
