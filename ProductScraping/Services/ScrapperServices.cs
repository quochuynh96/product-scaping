using System;
using System.Xml.Linq;
using ProductScraping.Models;

namespace ProductScraping.Services
{
    public class ScrapperServices : IScrapperServices
    {
        public ScrapperServices()
        {
        }

        public async Task<Product> FetchProductAsync(string url)
        {
            XDocument doc = XDocument.Load(url);
            return new Product();
        }
    }
}

