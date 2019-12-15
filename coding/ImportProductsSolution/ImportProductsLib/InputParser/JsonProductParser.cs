using ImportProductsLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ImportProductsLib.InputParser
{
    public class JsonProductParser : ProductParser
    {
        public override void ImportProducts(string filePath)
        {
            try
            {
                using (StreamReader r = new StreamReader(filePath))
                {
                    string json = r.ReadToEnd();
                    var products = JsonConvert.DeserializeObject<JsonProductModel>(json);
                    Products = new List<ProductModel>();
                    foreach (var product in products.Products)
                    {
                        var outputProduct = new ProductModel
                        {
                            Categories = String.Join(",", product.Categories.ToArray()),
                            Name = product.Title,
                            Twitter = product.Twitter
                        };

                        Console.WriteLine($"importing: Name: {outputProduct.Name}; Categories: {outputProduct.Categories}; Twitter: {outputProduct.Twitter}");
                        Products.Add(outputProduct);
                    }
                    GenerateOutputFile();
                }
            }
            catch (Exception e)
            {
                throw;
            }


        }
    }
}
