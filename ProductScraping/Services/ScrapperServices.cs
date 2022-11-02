using System;
using System.Xml.Linq;
using HtmlAgilityPack;
using ProductScraping.Models;

namespace ProductScraping.Services
{
    public class ScrapperServices : IScrapperServices
    {
        public ScrapperServices()
        {
        }

        private bool IsValidProperty(string name, HtmlNode? node)
        {
            return node.GetAttributeValue("name", "") == name
                || node.GetAttributeValue("name", "") == "og:" + name
                || node.GetAttributeValue("property", "") == name
                || node.GetAttributeValue("property", "") == "og:" + name;
        }

        /// <summary>
        /// Example
        /// <meta property="og:type" content="og:product" />
        /// <meta property = "og:title" content="My Product Name" />
        /// <meta property = "product:brand" content="My Brand Name" />
        /// <meta property = "og:image" content="http://path-to-thumbnail" />
        /// <meta property = "og:description" content="Some optional description!" />
        /// <meta property = "product:retailer_item_id" content="product-sku-12345" />
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<Product> FetchProductAsync(string url)
        {
            var product = new Product();
            product.ProductLink = url;

            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(url);
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(response);

            var metaTags = htmlDoc.DocumentNode.SelectNodes("//meta");

            if (metaTags != null)
            {
                foreach (var info in metaTags)
                {
                    if (IsValidProperty("title", info))
                    {
                        product.Name = info.GetAttributeValue("content", "");
                    }

                    if (IsValidProperty("product:brand", info))
                    {
                        product.Branch = info.GetAttributeValue("content", "");
                    }

                    if (IsValidProperty("image", info))
                    {
                        product.Image = info.GetAttributeValue("content", "");
                    }

                    if (IsValidProperty("description", info))
                    {
                        product.ProductDescription = info.GetAttributeValue("content", "");
                    }

                    if (IsValidProperty("url", info))
                    {
                        product.ProductLink = info.GetAttributeValue("content", "");
                    }

                    if (IsValidProperty("product:retailer_item_id", info))
                    {
                        product.SKU = info.GetAttributeValue("content", "");
                    }
                }
            }
            return product;
        }
    }
}

