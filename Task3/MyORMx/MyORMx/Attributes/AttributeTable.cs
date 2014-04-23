using System;

namespace MyORMx.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    class AttributeTable:Attribute
    {
        public string TableName { get; private set; }

        public AttributeTable(string tableName) 
        {
            TableName = tableName;
        }
    }
}
