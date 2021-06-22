using HtmlAgilityPack;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebSpider.Services
{
    public class CrawlerService : ICrawlerService
    {
        private readonly HtmlWeb web;
        public CrawlerService(HtmlWeb htmlWeb)
        {
            web = htmlWeb;
        }
        public  Dictionary<string, string> GetAllLinks(HtmlDocument doc)
        {
            try
            {
                Dictionary<string, string> links = new Dictionary<string, string>();
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    string LinkAddress = link.Attributes["href"].Value;
                    if (!LinkAddress.StartsWith("#"))
                        links.TryAdd(link.InnerText, LinkAddress);
                }
                return links;
            }
            catch (System.Exception ex)
            {
                //Log ex

                return default;
            }
       
        }

        public async Task<HtmlDocument> GetDocumentAsync(string Url)
        {
            try
            {
                return await web.LoadFromWebAsync(Url);

            }
            catch (System.Exception ex)
            {
                //Log ex
                return default;
            }
        }
    }
}
