using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductScraping.Models;
using ProductScraping.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductScraping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrapperController : Controller
    {
        private readonly ILogger<ScrapperController> _logger;
        private IScrapperServices scrapperServices;

        public ScrapperController(ILogger<ScrapperController> logger, IServiceProvider provider)
        {
            _logger = logger;
            scrapperServices = provider.GetRequiredService<ScrapperServices>();
        }

        [HttpPost]
        public async Task<Product> FetchProductAsync([FromBody] string url)
        {
            return await scrapperServices.FetchProductAsync(url);
        }
    }
}

