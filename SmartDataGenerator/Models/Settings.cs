using System;
using SmartDataGenerator.Generators;

namespace SmartDataGenerator.Models
{
    public class Settings
    {
        public DataTypes DataType { get; set; }
        public GenerationStrategy GenerationStrategy { get; set; }
        public IGenerator Generator { get; set; }
    }
}