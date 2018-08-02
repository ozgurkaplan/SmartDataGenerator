using System;

namespace SmartDataGenerator.Generators
{
    public class CustomDataGenerator<T>:IGenerator
    {
        private T[] _data;
        private int _length;
        private readonly Random _random;
        public CustomDataGenerator(T[] data)
        {
            _data = data;
            _length = data.Length;
            _random = new Random();
        }
        public object Generate()
        {
             return _data[_random.Next(_length)];
        }
    }
}