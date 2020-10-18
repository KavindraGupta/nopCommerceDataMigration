using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Product
    {
        public string barcode { get; set; }
        public string title { get; set; }
        public string productMainId { get; set; }
        public int brandId { get; set; }
        public int categoryId { get; set; }
        public int quantity { get; set; }
        public string stockCode { get; set; }
        public int dimensionalWeight { get; set; }
        public string description { get; set; }
        public string currencyType { get; set; }
        public double listPrice { get; set; }
        public double salePrice { get; set; }
        public int vatRate { get; set; }
        public int cargoCompanyId { get; set; }
        public int shipmentAddressId { get; set; }
        public int returningAddressId { get; set; }
        public List<ProductImage> images { get; set; }
        public List<ProductAttribute> attributes { get; set; }
    }


    public class Root
    {
        public List<Product> items { get; set; }
    }


}
