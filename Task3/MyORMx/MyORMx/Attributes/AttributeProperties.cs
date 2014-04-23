using System;

namespace MyORMx.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    class AttributeProperties:Attribute
    {
        public string FieldName { get; private set; }
        public Type T;

        public AttributeProperties(string fieldName, Type t) 
        {
            FieldName = fieldName;
            T = t;
        }
    }
}
