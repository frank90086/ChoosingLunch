using ChoosingBot.Enricher;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ChoosingBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((w, s) =>
                {
                    var host = w.HostingEnvironment;
                    s.SetBasePath(host.ContentRootPath)
                        .AddJsonFile("appsettings.json", false, true)
                        .AddJsonFile($"appsettings.{host.EnvironmentName}.json", true, true)
                        .AddEnvironmentVariables();
                }).UseSerilog((hostingContext, loggerConfiguration) => {
                    var env = hostingContext.HostingEnvironment;
                    var builder = new ConfigurationBuilder()
                        .SetBasePath(env.ContentRootPath)
                        .AddJsonFile("serilog.json", false, true)
                        .AddJsonFile("serilog.{env.EnvironmentName}.json", true)
                        .AddEnvironmentVariables();
                    var config = builder.Build();

                    loggerConfiguration.ReadFrom.Configuration(config)
                        .AddCustomEnrichers(config);
                })
                .UseStartup<Startup>();
        }
    }
}
