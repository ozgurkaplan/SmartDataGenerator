using System;

namespace SmartDataGenerator.Generators
{
    public class DefaultGenerator:IGenerator
    {
        private Type _type;
        public DefaultGenerator(Type type)
        {
            _type = type;
        }
        public object Generate()
        {
            if (_type.IsValueType)
            {
                return Activator.CreateInstance(_type);
            }
            return null;
        }
    }
}