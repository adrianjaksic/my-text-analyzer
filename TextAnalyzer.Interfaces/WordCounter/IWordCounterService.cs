using System.Threading.Tasks;
using TextAnalyzer.Entities.WordCounter;

namespace TextAnalyzer.Interfaces.WordCounter
{
    public interface IWordCounterService
    {        
        /// <summary>
        /// Returns number of word for a given text.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        WordCounterResponse GetResult(WordCounterRequest data);
    }
}
