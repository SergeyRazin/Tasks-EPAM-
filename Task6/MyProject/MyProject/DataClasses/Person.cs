using System;
using MyProject.AccessorsClasses;
using MyProject.Attributes;

namespace MyProject.DataClasses
{
    [Serializable]
    [TableAttribute("Person")]
    public class Person
    {
        [PropertiesAttribute("NameField")]
        public string Name { get; set; }

        [PropertiesAttribute("AgeField")]
        public int Age { get; set; }

        public string Phone { get; set; }

        public int ID { get; set; }
    }
}
