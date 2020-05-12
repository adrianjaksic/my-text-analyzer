using Microsoft.Extensions.DependencyInjection;
using TextAnalizer.WordCounter;
using TextAnalyzer.Interfaces.WordCounter;

namespace TextAnalyzer.Helpers
{
    public static class RegisterAppServicesHelper
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddScoped<IWordCounterService, WordCounterService>();
            return services;
        }
    }
}
