using System;
using Xunit;

namespace SmartDataGenerator.Tests
{
    public class TestDummy
    {
        [Fact]
        public void Test()
        {
            var generator = new SmartDataGenerator<TestClass>(10000);
            generator
                .Set(f => f.FirstName, DataTypes.FirstName)
                .Set(f => f.LastName, DataTypes.LastName)
                .Set(f => f.BirthDate, DataTypes.BirthDate)
                .Set(f => f.Country, DataTypes.Country)
                .Set(f => f.Company, DataTypes.Company)
                .Set(f => f.Range, new int[] {3, 5, 7})
                .Set(f => f.Sex, new string[] {"male", "female"})
                .Set(f => f.Website, DataTypes.Website)
                .Set(f => f.Email, DataTypes.Email);
            var responseData = generator.Generate();
            for (int i = 0; i < 10000; i++)
            {
                Assert.True(responseData[i].Country.Length > 0);
            }
        }
    }

    public class TestClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public int DefaultNumber { get; set; }
        public int Range { get; set; }
        public string Sex { get; set; }
    }
}