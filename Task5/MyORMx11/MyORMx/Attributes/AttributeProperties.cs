using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMx.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class AttributeProperties:Attribute
    {
        public string FieldName { get; set; }
        public Type t;

        public AttributeProperties(string fieldName, Type t) 
        {
            this.FieldName = fieldName;
            this.t = t;
        }
    }
}
