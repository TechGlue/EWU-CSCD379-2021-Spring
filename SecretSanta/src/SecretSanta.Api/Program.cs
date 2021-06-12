using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace SecretSanta.Api
{
    public class Program
    {
        public static ILoggerFactory LoggerFactory { get; set; }
        public Microsoft.Extensions.Logging.ILogger Logger { get; }
            = Program.LoggerFactory.CreateLogger<Program>();
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File("Log.txt")
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Starting build....build running");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "build terminated");
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        
        
    }
}
