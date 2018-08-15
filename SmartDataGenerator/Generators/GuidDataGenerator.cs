using System;

namespace SmartDataGenerator.Generators
{
    internal class GuidDataGenerator:IGenerator
    {
        public object Generate()
        {
            return Guid.NewGuid();
        }
    }
}