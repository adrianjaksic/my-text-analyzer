using System.Text.Json.Serialization;

namespace TextAnalyzer.Entities.WordCounter
{
    public class WordCounterRequest
    {
        [JsonPropertyName("Text")]
        public string Text { get; set; }
    }
}
