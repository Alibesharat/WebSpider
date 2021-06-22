using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using WebSpider.Services;

namespace WebSpider.Insfrastracture.Diextensions
{
    public static class Diextension
    {

        public static IServiceProvider ConfigureServices()
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false)
           .AddEnvironmentVariables()
           .Build();

            var StorageOptions = configuration.GetSection("StorageOptions");
           var storagetype = (StorageType) Enum.Parse(typeof(StorageType), StorageOptions.GetSection("StorageType").Value, true);


            return Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<StorageOptions>(StorageOptions);
                    services.AddStoreService(storagetype);
                    services.AddSingleton<HtmlWeb>();
                    services.AddSingleton<ICrawlerService, CrawlerService>();

                }).Build().Services;

        }






        public static void AddStoreService(this IServiceCollection services, StorageType storageType)
        {

            
            switch (storageType)
            {
                case StorageType.Filing:
                    services.AddSingleton<IStoreService, StoreFilingService>();
                    break;
                case StorageType.Database:
                    services.AddSingleton<IStoreService, StoreDataBaseService>();
                    break;
                default:
                    throw new NotImplementedException($"there is No ipmlemention for {storageType}");
            }
        }

    }
}
