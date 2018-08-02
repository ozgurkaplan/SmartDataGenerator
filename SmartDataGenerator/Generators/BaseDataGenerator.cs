using System;
using System.Collections.Generic;
using System.IO;

namespace SmartDataGenerator.Generators
{
    internal abstract class BaseDataGenerator: IGenerator
    {
        private string[] _data;
        private readonly Random rng;
        private readonly int _length;
        protected BaseDataGenerator(string filePath)
        {
            _data = File.ReadAllLines(filePath);
            _length = _data.Length;
            rng = new Random();
        }

        public virtual object Generate()
        {
            return _data[rng.Next(_length)];
        }
    }
}