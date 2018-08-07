# SmartDataGenerator
SmartDataGenerator lets you generate up to 10,000 items of test data.

### Installation
Install-Package SmartDataGenerator 

### Supported Types
* FirstName
* LastName
* BirthDate
* Country
* Company
* Email
* Website   
You can also set your own array which then will be used in generation.

### Sample Usage
```
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
TestClass[] response = generator.Generate();
```
