using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SmartDataGenerator.Generators
{
    internal abstract class BaseDataGenerator: IGenerator
    {
        private List<string> _data;
        private readonly Random rng;
        private readonly int _length;
        protected BaseDataGenerator(string file)
        {
            _data=new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"SmartDataGenerator.Data.{file}.txt";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    _data.Add(line);
                }
            }
            _length = _data.Count;
            rng = new Random();
        }

        private IEnumerable<string> EnumerateLines(TextReader reader)
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        public virtual object Generate()
        {
            return _data[rng.Next(_length)];
        }
    }
}