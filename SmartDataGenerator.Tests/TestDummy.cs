using System;
using SmartDataGenerator.Generators;
using Xunit;

namespace SmartDataGenerator.Tests
{
    public class TestDummy
    {
        [Fact]
        public void Test()
        {
            var generator = new SmartDataGenerator<TestClass>(1000);
            generator
                .Set(f => f.FirstName, DataTypes.FirstName)
                .Set(f => f.LastName, DataTypes.LastName)
                .Set(f => f.BirthDate, DataTypes.BirthDate)
                .Set(f => f.Country, DataTypes.Country)
                .Set(f => f.Company, DataTypes.Company);
            var response = generator.Generate();
        }
    }

    public class TestClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
    }
}