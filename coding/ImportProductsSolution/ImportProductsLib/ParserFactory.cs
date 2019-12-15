using ImportProductsLib.InputParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ImportProductsLib.Enumerations;

namespace ImportProductsLib
{
    public static class ParserFactory
    {
        public static ProductParser GetParser(SourceType sourceType)
        {
            ProductParser parser;
            switch (sourceType)
            {
                case SourceType.capterra: parser = new YamlProductParser();
                    break;

                case SourceType.softwareadivce: parser = new JsonProductParser();
                    break;

                default: parser = null;
                    break;

            }
            return parser;
        }
    }
}
