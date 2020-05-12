using System.Text.Json.Serialization;
using TextAnalyzer.Entities.Exceptions;

namespace TextAnalyzer.Entities
{
    public class BaseResponse
    {
        [JsonPropertyName("ErrorCode")]
        public ErrorCodeEnum? ErrorCode { get; set; }

        [JsonPropertyName("ErrorMessage")]
        public string ErrorMessage { get; set; }
    }
}
