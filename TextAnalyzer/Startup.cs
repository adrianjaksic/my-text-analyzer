using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TextAnalyzer.Common;
using TextAnalyzer.Helpers;

namespace TextAnalyzer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var clientUrl = Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>().ClientUrl;

            services
                .AddOptions()
                .AddHttpClient()
                .Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)))
                .RegisterAppServices()
                .RegisterAppCors(clientUrl)
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var loggerFactory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<Startup>();

            app.RegisterExceptionHandling(logger)
                .UseCors(RegisterAppCorsHelper.AppCorsPolicyName)
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
