using System;

namespace SmartDataGenerator.Generators
{
    internal static class GeneratorFactory
    {
        public static IGenerator GetGenerator(DataTypes type)
        {
            switch (type)
            {
                case DataTypes.BirthDate:
                    return new BirthDateGenerator();
                case DataTypes.Guid:
                    return new GuidDataGenerator();
                case DataTypes.Bool:
                    return new BoolGenerator();
                default:
                    return new FileDataGenerator(type);
            }
        }
    }
}