using System;
using ImportProductsLib;
using static ImportProductsLib.Enumerations;

namespace ImportProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            //Take parser type from the args
            var sourceType = args.Length > 0 ? args[0].ToLower() : null;
            var filePath = args.Length > 1 ? args[1] : null;

            if (string.IsNullOrWhiteSpace(sourceType)) {
                Console.WriteLine("Enter the source type : 1. capterra  2. softwareadvice");
                sourceType = Console.ReadLine().ToLower();
            }

            var sourceTypeValue = GetSourceType(sourceType);

            //check for valid sources
            while (sourceTypeValue.Equals(SourceType.other))
            {
                Console.WriteLine("Please enter a valid source");
                Console.WriteLine("Enter the source type. Following are some valid options : 1. capterra 2. softwareadvice");
                sourceType = Console.ReadLine().ToLower();
                sourceTypeValue = GetSourceType(sourceType);
            }

            while (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Please enter the input file path");
                filePath = Console.ReadLine().ToLower();
            }


            var parser = ParserFactory.GetParser(sourceTypeValue);

            if(parser != null){
                try
                {
                    parser.ImportProducts(filePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error occured while importing products :"+ e.Message);
                }
            }
          
        }
    }
}
