using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextAnalizer.WordCounter.Helpers;

namespace TextAnalizer.Tests
{
    [TestClass]
    public class WordCounterTests
    {        
        private string _TextWith0Words;
        private string _TextWith10Words;
        private string _TextWith10WordsAndSymbols;

        private string _TextWith20WordsContainingCharacterSeparatingWords;

        private string _NullText;

        public WordCounterTests()
        {
            SetTextData();
        }

        private void SetTextData()
        {
            _TextWith0Words = @".";
            _TextWith10Words = @"One two three four five sis seven eight nine ten";
            _TextWith10WordsAndSymbols = @"One, two , three , four ; five 'sis. Seven eight. Nine ten.";
            
            _TextWith20WordsContainingCharacterSeparatingWords = @"It's a text for counting of words, with different word boundaries and hyphenated word like the all-clear.Is it OK? ";

            _NullText = null;
        }

        [TestMethod]
        public void WordSplitTest()
        {
            Assert.AreEqual(_TextWith0Words.SplitWords().Length, 0);
            Assert.AreEqual(_TextWith10Words.SplitWords().Length, 10);
            Assert.AreEqual(_TextWith10WordsAndSymbols.SplitWords().Length, 10);
        }

        [TestMethod]
        public void WordSplitWithCharacterSeparatingWordsTest()
        {
            var result = _TextWith20WordsContainingCharacterSeparatingWords.SplitWords();
            Assert.AreEqual(result.Length, 20);
        }

        [TestMethod]
        public void WordSplitWithEmptyTextTest()
        {
            Assert.AreEqual(_NullText.SplitWords().Length, 0);
        }
    }
}
