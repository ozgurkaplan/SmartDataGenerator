using System;

namespace SmartDataGenerator.Generators
{
    internal class BoolGenerator : IGenerator
    {
        private readonly Random _random;
        public BoolGenerator()
        {
            _random = new Random();
        }
        public object Generate()
        {
            return _random.NextDouble() >= 0.5;
        }
    }
}