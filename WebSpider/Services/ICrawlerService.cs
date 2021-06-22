using HtmlAgilityPack;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebSpider.Services
{
    public interface ICrawlerService
    {
       Dictionary<string,string> GetAllLinks(HtmlDocument Doc);
        Task<HtmlDocument> GetDocumentAsync(string Url);
    }
}
