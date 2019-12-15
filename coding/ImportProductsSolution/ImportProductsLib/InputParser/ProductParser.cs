using ImportProductsLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportProductsLib.InputParser
{
    public abstract class ProductParser
    {
        protected List<ProductModel> Products { get; set; }
        public abstract void ImportProducts(string filePath);

        protected void GenerateOutputFile()
        {
            string _directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            string outputPath = _directory + @"\ImportedProducts.txt";
            try
            {
                using (FileStream fs = File.Create((outputPath)))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes("Imported Products:");
                    fs.Write(info, 0, info.Length);
                    byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                    fs.Write(newline, 0, newline.Length);
                    fs.Write(newline, 0, newline.Length);
                    foreach (var product in Products)
                    {
                        var details = $"Name : {product.Name} \n Categories : {product.Categories} \n Twitter : {product.Twitter}";
                        info = new UTF8Encoding(true).GetBytes(details);
                        fs.Write(info, 0, info.Length);
                        fs.Write(newline, 0, newline.Length);
                    }

                    Console.WriteLine("\n\nAll products are successfully imported! Please check the output file at below location");
                    Console.WriteLine(outputPath);
                }
            }
            catch (Exception)
            {
                throw new Exception("Some error occured while generating output file. Please try Again!");
            }

        }


    }
}
