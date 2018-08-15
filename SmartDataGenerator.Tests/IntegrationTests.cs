using System;
using System.ComponentModel;
using SmartDataGenerator.Tests.Model;
using Xunit;

namespace SmartDataGenerator.Tests
{
    [Trait("Test data is requested","")]
    public class IntegrationTests
    {
        [Fact(DisplayName = "10,000 test data is generated")]
        public void Should_Generate_10000_Data()
        {
            var generator = new SmartDataGenerator<TestModel>(10000);
            generator
                .Set(f => f.FirstName, DataTypes.FirstName)
                .Set(f => f.LastName, DataTypes.LastName)
                .Set(f => f.BirthDate, DataTypes.BirthDate)
                .Set(f => f.Country, DataTypes.Country)
                .Set(f => f.Company, DataTypes.Company)
                .Set(f => f.Range, new int[] {3, 5, 7})
                .Set(f => f.Sex, new string[] {"male", "female"})
                .Set(f => f.Website, DataTypes.Website)
                .Set(f => f.Email, DataTypes.Email)
                .Set(f => f.UniqueKey, DataTypes.Guid)
                .Set(f=>f.IsValid,DataTypes.Bool);
            var responseData = generator.Generate();
            for (int i = 0; i < 10000; i++)
            {
                Assert.True(responseData[i].Country.Length > 0);
            }
        }

        [Fact(DisplayName = "1,000 test data is generated")]
        public void Should_Generate_1000_Data()
        {
            var generator = new SmartDataGenerator<TestModel>(1000);
            generator
                .Set(f => f.FirstName, DataTypes.FirstName)
                .Set(f => f.LastName, DataTypes.LastName)
                .Set(f => f.BirthDate, DataTypes.BirthDate)
                .Set(f => f.Country, DataTypes.Country)
                .Set(f => f.Company, DataTypes.Company)
                .Set(f => f.Range, new int[] { 3, 5, 7 })
                .Set(f => f.Sex, new string[] { "male", "female" })
                .Set(f => f.Website, DataTypes.Website)
                .Set(f => f.Email, DataTypes.Email)
                .Set(f => f.UniqueKey, DataTypes.Guid)
                .Set(f => f.IsValid, DataTypes.Bool); 
            var responseData = generator.Generate();
            for (int i = 0; i < 1000; i++)
            {
                Assert.True(responseData[i].Country.Length > 0);
            }
        }
    }
}