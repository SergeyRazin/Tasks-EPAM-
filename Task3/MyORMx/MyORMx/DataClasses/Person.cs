using System;
using MyORMx.Attributes;

namespace MyORMx.DataClasses
{
    
    [AttributeTable("Person")]
    [Serializable]
    public class Person
    {
        [AttributeProperties("NameField", typeof(string))]
        public string Name { get; set; }

        
        [AttributeProperties("AgeField", typeof(int))]
        public int Age { get; set; }

        
    }
}
