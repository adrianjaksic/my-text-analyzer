using System;
using TextAnalizer.WordCounter.Helpers;
using TextAnalyzer.Entities.WordCounter;
using TextAnalyzer.Interfaces.WordCounter;

namespace TextAnalizer.WordCounter
{
    public class WordCounterService : IWordCounterService
    {
        public WordCounterResponse GetResult(WordCounterRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            return new WordCounterResponse()
            {
                NumberOfWords = request.Text.SplitWords().Length,
            };
        }
    }
}
