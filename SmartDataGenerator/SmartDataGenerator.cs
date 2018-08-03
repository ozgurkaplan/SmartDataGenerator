using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using SmartDataGenerator.Models;
using SmartDataGenerator.Generators;

namespace SmartDataGenerator
{
    /// <summary>
    /// SmartDataGenerator class.
    /// Contains data generation setup and does the data generation. 
    /// </summary>
    /// <typeparam name="T">Type of data that will be generated.</typeparam>
    public class SmartDataGenerator<T> where T : class, new()
    {
        private readonly int _total;
        private readonly Dictionary<string, Settings> _settings;
        private Dictionary<DataTypes, IGenerator> _generators;
        private PropertyInfo[] _properties;

        /// <summary>
        /// Initializes a new instance of the SmartDataGenerator.
        /// </summary>
        /// <param name="total">Number of data to generate.</param>
        /// <exception cref="System.ArgumentException">Thrown when total is less than 1 or greater than 10,000</exception>
        public SmartDataGenerator(int total)
        {
            if (total < 1 || total > 10000)
            {
                throw new ArgumentException("Total must be between 1 and 10,000");
            }
            _total = total;
            _settings = new Dictionary<string, Settings>();
            _generators = new Dictionary<DataTypes, IGenerator>();
            _properties = typeof(T).GetProperties();
            foreach (var propertyInfo in _properties)
            {
                _settings.Add(propertyInfo.Name, new Settings()
                {
                    DataType = DataTypes.None,
                    Generator = new DefaultGenerator(propertyInfo.GetType())
                });
            }
        }
        /// <summary>
        /// Sets generation pattern for given property.
        /// </summary>
        /// <typeparam name="U">Type of property.</typeparam>
        /// <param name="expression">Property expression.</param>
        /// <param name="type">Generation type of property.</param>
        /// <returns>Current instance of SmartDataGenerator.</returns>
        public SmartDataGenerator<T> Set<U>(Expression<Func<T,U>> expression, DataTypes type)
        {
            return Set(expression, type, null);
        }

        /// <summary>
        /// Sets generation pattern for given property.
        /// </summary>
        /// <typeparam name="U">Type of property.</typeparam>
        /// <param name="expression">Property expression.</param>
        /// <param name="data">Generation data. Random data will be picked from this array.</param>
        /// <returns>Current instance of SmartDataGenerator.</returns>
        public SmartDataGenerator<T> Set<U>(Expression<Func<T, U>> expression, U[]  data)
        {
            return Set(expression,DataTypes.None,data);
        }

        private SmartDataGenerator<T> Set<U>(Expression<Func<T, U>> expression, DataTypes type, U[] data)
        {
            MemberExpression body = expression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException();
            }
            var propertyInfo = (PropertyInfo)body.Member;
            var propertyName = propertyInfo.Name;
            var setting = new Settings()
            {
                DataType = type,
            };
            _settings[propertyName] = setting;
            if (data!=null)
            {
                setting.Generator = new CustomDataGenerator<U>(data);
            }
            else
            {
                if (!_generators.ContainsKey(setting.DataType))
                {
                    _generators[setting.DataType] = GeneratorFactory.GetGenerator(setting.DataType);
                }
                setting.Generator = _generators[setting.DataType];
            }

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public T[] Generate()
        {
            var data = new T[_total];
            for (int i = 0; i < _total; i++)
            {
                data[i] = new T();
                foreach (var propertyInfo in _properties)
                {
                    var setting = _settings[propertyInfo.Name];
                    propertyInfo.SetValue(data[i], setting.Generator.Generate());
                }
            }

            return data;
        }
    }
}