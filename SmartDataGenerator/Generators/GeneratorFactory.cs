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
                    return new FirstNameGenerator();
                case DataTypes.LastName:
                    return new LastNameGenerator();
                case DataTypes.BirthDate:
                    return new BirthDateGenerator();
                case DataTypes.Country:
                    return new CountryGenerator();
                case DataTypes.Company:
                    return new CompanyGenerator();
                case DataTypes.Email:
                    return new EmailGenerator();
                case DataTypes.Website:
                    return new WebsiteGenerator();
                default:
                    throw new ArgumentException();
            }
        }
    }
}