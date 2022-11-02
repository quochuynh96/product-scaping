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
    public class ScrapperController : ControllerBase
    {
        private readonly ILogger<ScrapperController> _logger;
        private IScrapperServices _scrapperServices;

        public ScrapperController(ILogger<ScrapperController> logger, IScrapperServices scrapperServices)
        {
            _logger = logger;
            _scrapperServices = scrapperServices;
        }

        [HttpPost]
        public async Task<Product> FetchProductAsync([FromQuery] string url)
        {
            return await _scrapperServices.FetchProductAsync(url);
        }
    }
}

