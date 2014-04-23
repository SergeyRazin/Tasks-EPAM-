using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMx.Attributes;

namespace MyORMx
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
