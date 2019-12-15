using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImportProductsLib.Models;
using System.IO;
using YamlDotNet.RepresentationModel;


namespace ImportProductsLib.InputParser
{
    public class YamlProductParser: ProductParser
    {
        
        public override void ImportProducts(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    var yaml = new YamlStream();
                    yaml.Load(reader);

                    var rootNode =(YamlSequenceNode) yaml.Documents[0].RootNode;

                    Products = new List<ProductModel>();
                 
                    foreach(var product in rootNode.Children)
                    {
                        var outputProduct = new ProductModel();
                       foreach(var props in ((YamlMappingNode)product).Children)
                        {
                            switch (props.Key.ToString())
                            {
                                case "tags": outputProduct.Categories = props.Value.ToString();
                                    break;
                                case "name":
                                    outputProduct.Name = props.Value.ToString();
                                    break;
                                case "twitter":
                                    outputProduct.Twitter = props.Value.ToString();
                                    break;
                            }
                        }

                        Console.WriteLine($"importing: Name: {outputProduct.Name}; Categories: {outputProduct.Categories}; Twitter: {outputProduct.Twitter}");
                        Products.Add(outputProduct);
                    }
                    GenerateOutputFile();
                
                }

            }
            catch(Exception e)
            {
                throw;
            }
            
        }
    }
}
