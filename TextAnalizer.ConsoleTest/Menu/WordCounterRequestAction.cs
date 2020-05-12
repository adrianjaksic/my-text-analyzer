using System;
using TextAnalizer.ConsoleTest.Request;
using TextAnalyzer.Entities.WordCounter;

namespace TextAnalizer.ConsoleTest.Menu
{
    public class WordCounterRequestAction
    {
        private const string WordCounterApi = "https://localhost:5001/api/wordcounter";
        private readonly string _text;

        public WordCounterRequestAction(string text)
        {
            _text = text;
        }

        public void Do()
        {
            var request = new WordCounterRequest()
            {
                Text = _text,
            };

            Console.WriteLine();
            Console.WriteLine($"Text: {request.Text}");

            var response = RequestHelper.Post<WordCounterRequest, WordCounterResponse>(WordCounterApi, request);

            if (response != null)
            {
                if (response.ErrorCode.HasValue)
                {
                    Console.WriteLine($"Error happened (code {response.ErrorCode}), message: {response.ErrorMessage}");
                }
                else
                {
                    Console.WriteLine($"Number of words: {response.NumberOfWords}");
                }
            }
            else
            {
                Console.WriteLine($"No response.");
            }
        }
    }
}
