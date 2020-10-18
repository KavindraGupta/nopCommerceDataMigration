using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Helper;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Net.Http.Headers;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View("AddProduct");
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            Root root = new Root();
            Product product = new Product();
            List<ProductImage> productImages = new List<ProductImage>();
            List<ProductAttribute> attributes = new List<ProductAttribute>();

            try
            {
                //foreach(string key in collection.Keys)
                //{
                    product.barcode = collection["barcode"];
                    product.title = collection["title"];
                    product.productMainId = collection["productMainId"];
                    product.brandId = Convert.ToInt32(collection["brandId"]);
                    product.barcode = collection["barcode"];
                    product.categoryId = Convert.ToInt32(collection["categoryId"]);
                    product.quantity = Convert.ToInt32(collection["quantity"]);
                    product.stockCode = collection["stockCode"];
                    product.dimensionalWeight = Convert.ToInt32(collection["dimensionalWeight"]);
                    product.description = collection["description"];
                    product.currencyType = collection["currencyType"];
                    product.listPrice = Convert.ToDouble(collection["listPrice"]);
                    product.salePrice = Convert.ToDouble(collection["salePrice"]);
                    product.vatRate = Convert.ToInt32(collection["vatRate"]);
                    product.cargoCompanyId = Convert.ToInt32(collection["cargoCompanyId"]);
                    product.shipmentAddressId = Convert.ToInt32(collection["shipmentAddressId"]);
                    product.returningAddressId = Convert.ToInt32(collection["returningAddressId"]);
                    
                    int len = collection["DynamicAttributeIdTextBox"].Count();

                    for(int i=0; i<len; i++)
                    {
                       
                        ProductAttribute productAttribute = new ProductAttribute();
                        productAttribute.AttributeId = Convert.ToInt32(collection["DynamicAttributeIdTextBox"][i]);
                        productAttribute.AttributeValueId = Convert.ToInt32(collection["DynamicAttributeValueTextBox"][i]);
                        attributes.Add(productAttribute);
                    }
              
                //}
                
                product.images = productImages;
                product.attributes = attributes;
                List<Product> items = new List<Product>();
                items.Add(product);
                root.items = items;
                string json = JsonConvert.SerializeObject(root);
                string url = string.Format("https://api.trendyol.com/sapigw/suppliers/{0}/v2/products", 130188);
                var r = ApiCall.PostGenericMessage<Root>(url, "VsSY3KtZ6BijgOCfyws8", "Q7FfKUSDb6SpHJw4ufxs", root);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //private HttpResponseMessage PostData<T>(string apiUrl, string userName, string password, Root root)
        //{
        //    string response = string.Empty;
        //    var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", userName, password)));
            
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(apiUrl);
        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
               
        //        var postTask = client.PostAsJsonAsync<Root>("root", root);
        //        postTask.Wait();

        //        var result = postTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return result;
        //        }
        //    }
        //    return new HttpResponseMessage(HttpStatusCode.OK);
        //}
        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
