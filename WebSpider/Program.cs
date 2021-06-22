using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WebSpider.Insfrastracture.Diextensions;
using WebSpider.Services;

namespace WebSpider
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = Diextension.ConfigureServices(args);
          
            var StoreService = services.GetRequiredService<IStoreService>();
            var Crawler = services.GetRequiredService<ICrawlerService>();

            string BaseUrl = "https://google.com";
            var docs = await Crawler.GetDocumentAsync(BaseUrl);
            var result = await StoreService.SaveAsync(docs.ParsedText, "index");
            Console.WriteLine($"index.html {result.Message}");


            var Links = Crawler.GetAllLinks(docs);
            foreach (var item in Links)
            {
                docs = null;
                docs = await Crawler.GetDocumentAsync(item.Value);
                if (docs == null) continue;
                result = await StoreService.SaveAsync(docs.ParsedText, item.Key);
                Console.WriteLine($"{item.Key}.html {result.Message}");
            }
            Console.WriteLine("Done! Press Enter To Exit");
            Console.ReadLine();




        }









    }
}
