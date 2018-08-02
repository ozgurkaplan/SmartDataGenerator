using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmartDataGenerator.Generators
{
    public class CountryGenerator : BaseDataGenerator
    {
        public CountryGenerator():base("Data/Countries.txt")
        {

        }
    }
}