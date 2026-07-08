using Microsoft.Extensions.Configuration;
using System;

namespace AppSettingSysVariable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            var appSettings = configuration.Get<AppSettings>();
            Console.WriteLine($"Source : [{appSettings.Source.IsEnabled}, {appSettings.Source.Url}] \nDestination : [{appSettings.Destination.IsEnabled}, {appSettings.Destination.Url}]");
        }
    }
}
