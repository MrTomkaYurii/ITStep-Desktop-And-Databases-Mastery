using EX_02_Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


//конфігруруємо хост
IHostBuilder CreateHostBuilder() =>
    Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration(app =>
    {
        app.AddJsonFile("appsetting.json");
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<Worker>();
    });

//білдимо хост
var host = CreateHostBuilder().Build();

// отримуємо сервіса
using IServiceScope serviceScope = host.Services.CreateScope();
IServiceProvider provider = serviceScope.ServiceProvider;

// отримуємо сервіс Worker та виконуємо необхідні задачі
var workerInstance = provider.GetRequiredService<Worker>();
workerInstance.DoWork();