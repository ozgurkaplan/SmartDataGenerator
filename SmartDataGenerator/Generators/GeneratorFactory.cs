using System;

namespace SmartDataGenerator.Generators
{
    internal static class GeneratorFactory
    {
        public static IGenerator GetGenerator(DataTypes type)
        {
            switch (type)
            {
                case DataTypes.FirstName:
                    return new FileDataGenerator(type);
                case DataTypes.LastName:
                    return new FileDataGenerator(type);
                case DataTypes.BirthDate:
                    return new BirthDateGenerator();
                case DataTypes.Country:
                    return new FileDataGenerator(type);
                case DataTypes.Company:
                    return new FileDataGenerator(type);
                case DataTypes.Email:
                    return new FileDataGenerator(type);
                case DataTypes.Website:
                    return new FileDataGenerator(type);
                case DataTypes.Guid:
                    return new GuidDataGenerator();
                case DataTypes.Bool:
                    return new BoolGenerator();
                default:
                    throw new ArgumentException();
            }
        }
    }
}