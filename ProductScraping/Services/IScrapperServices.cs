using System;
using ProductScraping.Models;

namespace ProductScraping.Services
{
    public interface IScrapperServices
    {
        public Task<Product> FetchProductAsync(string url);
    }
}

