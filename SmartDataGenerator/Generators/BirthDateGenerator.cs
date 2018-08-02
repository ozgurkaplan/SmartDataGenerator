using System;

namespace SmartDataGenerator.Generators
{
    internal class BirthDateGenerator : IGenerator
    {
        private Random _random;
        private DateTime _start;
        private int _range;
        public BirthDateGenerator()
        {
            _random = new Random();
            _start = new DateTime(DateTime.Now.Year - 90, 1, 1);
            _range = (DateTime.Today - _start).Days;
        }
        public object Generate()
        {
            return _start.AddDays(_random.Next(_range));
        }
    }
}