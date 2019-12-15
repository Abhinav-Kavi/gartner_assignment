using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportProductsLib
{
    public class Enumerations
    {
        public enum SourceType
        {
            capterra = 0,
            softwareadivce = 1,
            other = 2
        }

        public static SourceType GetSourceType(string type)
        {
            SourceType sourceType;
            switch (type)
            {
                case "capterra":  sourceType =  SourceType.capterra;
                                  break;
                case "softwareadvice":sourceType = SourceType.softwareadivce;
                                      break;
                default:   sourceType = SourceType.other;
                           break;
            }
            return sourceType;
        }
    }
}
