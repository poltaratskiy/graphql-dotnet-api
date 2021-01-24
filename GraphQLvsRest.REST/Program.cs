using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace GraphQLvsRest.REST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            new HostBuilder()
            .ConfigureAppConfiguration(cfg => cfg
                .AddJsonFile("appsettings.json")
                .AddCommandLine(args)
                .AddEnvironmentVariables())
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseKestrel(serverOptions =>
                {
                    // Set properties and call methods on options
                })
                .UseStartup<Startup>();
            });
    }
}
