using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TextAnalyzer.Common;
using TextAnalyzer.Entities.WordCounter;
using TextAnalyzer.Interfaces.WordCounter;

namespace TextAnalyzer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WordCounterController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IWordCounterService _wordCounterService;

        public WordCounterController(IWordCounterService wordCounterService, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _wordCounterService = wordCounterService;
        }

        [HttpPost]
        public WordCounterResponse Post(WordCounterRequest data)
        {            
            return _wordCounterService.GetResult(data);
        }
    }
}
