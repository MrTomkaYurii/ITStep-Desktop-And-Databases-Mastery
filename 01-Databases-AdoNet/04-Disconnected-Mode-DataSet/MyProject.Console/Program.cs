// See https://aka.ms/new-console-template for more information

using ConsoleApp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyProject.DAL.Repositories;
using System.Data;
using System.Data.SqlClient;

static class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder();
        BuildConfig(builder);

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                //services.AddTransient<IProductRepository, ProductRepository>();
                services.AddScoped<ICategoryRepository, CategoryRepository>();
                services.AddTransient<IUnitOfWork, UnitOfWork>();
                //services.AddSingleton<IProductService, ProductService>();

                services.AddScoped((s) => new SqlConnection("Server=.;Database=MarketExample;Integrated Security=True;"));
                services.AddScoped<IDbTransaction>(s =>
                {
                    SqlConnection conn = s.GetRequiredService<SqlConnection>();
                    conn.Open();
                    return conn.BeginTransaction();
                });
            })
            .Build();

        var ProductSVC = ActivatorUtilities.CreateInstance<CategoryService>(host.Services);
        ProductSVC.GetAllInfoAboutCategory();
    }



    static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables();
    }
}