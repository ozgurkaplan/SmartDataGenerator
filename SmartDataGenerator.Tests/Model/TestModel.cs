using System;
using System.Collections.Generic;
using System.Text;

namespace SmartDataGenerator.Tests.Model
{
    public class TestModel
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
        public Guid UniqueKey { get; set; }
        public bool IsValid { get; set; }
    }
}
