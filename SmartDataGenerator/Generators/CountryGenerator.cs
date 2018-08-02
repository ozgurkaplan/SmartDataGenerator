using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmartDataGenerator.Generators
{
    internal class CountryGenerator : BaseDataGenerator
    {
        public CountryGenerator():base("Data/Country.txt")
        {

        }
    }
}