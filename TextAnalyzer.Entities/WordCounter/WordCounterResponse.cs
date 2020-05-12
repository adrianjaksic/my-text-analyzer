using System.Text.Json.Serialization;

namespace TextAnalyzer.Entities.WordCounter
{
    public class WordCounterResponse : BaseResponse
    {
        [JsonPropertyName("NumberOfWords")]
        public int NumberOfWords { get; set; }        
    }
}
