using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVP.Views;
using MyEventsAdoNetDB.Repositories;
using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsEntityFrameworkDb.DbContexts;
using MyEventsEntityFrameworkDb.EFRepositories;
using MyEventsEntityFrameworkDb.EFRepositories.Contracts;
using MyEventsWF.Forms;
using MyEventsWF.Helpers;
using MyEventsWF.PRESENTERS;
using System.Data;
using System.Data.SqlClient;

namespace MyEventsWF
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // GENERIC HOST
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
                {
                    hostBuilderContext.HostingEnvironment.EnvironmentName = 
                        Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT") ?? "Development";
                    var env = hostBuilderContext.HostingEnvironment;

                    configurationBuilder.AddEnvironmentVariables();
                    configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    configurationBuilder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((hostBuilderContext, serviceCollection) =>
                {
                    string connectionString = hostBuilderContext.Configuration.GetConnectionString("MSSQLConnection") 
                        ?? "Server=(localdb)\\mssqllocaldb;Database=MyEventsDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";

                    // Connection/Transaction for ADO.NET/DAPPER database
                    serviceCollection.AddScoped((s) => new SqlConnection(connectionString));
                    serviceCollection.AddScoped<IDbTransaction>(s =>
                    {
                        var conn = s.GetRequiredService<SqlConnection>();
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }
                        return conn.BeginTransaction();
                    });

                    // Connection for EF database + DbContext
                    serviceCollection.AddDbContext<MyEventsDbContext>(options =>
                    {
                        options.UseSqlServer(connectionString);
                    });

                    // Dependency Injection for Repositories/UOW from ADO.NET DAL
                    serviceCollection.AddScoped<IEventRepository, EventRepository>();
                    serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
                    serviceCollection.AddScoped<IUserProfileRepository, UserProfileRepository>();
                    serviceCollection.AddScoped<IGalleryRepository, GalleryRepository>();
                    serviceCollection.AddScoped<IMessageRepository, MessageRepository>();
                    serviceCollection.AddScoped<IImageRepository, ImageRepository>();
                    serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

                    // Dependency Injection for Repositories/UOW from EF DAL
                    serviceCollection.AddScoped<IEFEventRepository, EFEventRepository>();
                    serviceCollection.AddScoped<IEFCategoryRepository, EFCategoryRepository>();
                    serviceCollection.AddScoped<IEFUserProfileRepository, EFUserProfileRepository>();
                    serviceCollection.AddScoped<IEFGalleryRepository, EFGalleryRepository>();
                    serviceCollection.AddScoped<IEFMessageRepository, EFMessageRepository>();
                    serviceCollection.AddScoped<IEFImageRepository, EFImageRepository>();
                    serviceCollection.AddScoped<IEFUnitOfWork, EFUnitOfWork>();

                    // Service for argument pass between forms
                    serviceCollection.AddSingleton<ServiceArgs>();

                    // Forms
                    serviceCollection.AddTransient<AllEventsForm>();
                    serviceCollection.AddTransient<CategoryForm>();
                    serviceCollection.AddTransient<DetaisOfEventForm>();
                    serviceCollection.AddTransient<ForumForm>();
                    serviceCollection.AddTransient<GalleryForm>();
                    serviceCollection.AddTransient<ProfileForm>();

                    // MVP
                    serviceCollection.AddSingleton<IMainMenuView, MainMenuView>();
                    serviceCollection.AddSingleton<MainMenuPresenter>();
                    serviceCollection.AddTransient<GalleryPresenter>();
                })
                .Build();

            IMainMenuView mainMenuView = host.Services.GetRequiredService<IMainMenuView>();
            host.Services.GetRequiredService<MainMenuPresenter>();
            Application.Run((Form)mainMenuView);
        }
    }
}
