using System;
using SmartDataGenerator.Generators;

namespace SmartDataGenerator.Models
{
    internal class Settings
    {
        public DataTypes DataType { get; set; }
        public IGenerator Generator { get; set; }
    }
}