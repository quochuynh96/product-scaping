using System;
namespace ProductScraping.Models
{
    public class Product
    {
        public Product() {}
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Image { get; set; }
        public string? ProductDescription { get; set; }
        public string? Branch { get; set; }
        public string? ProductLink { get; set; }
        public string? PromotionPrice { get; set; }
        public string? DiscountPercentage { get; set; }
        public string? SKU { get; set; }
    }
}

