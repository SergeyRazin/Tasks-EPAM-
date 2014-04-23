using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMx.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    class AttributeTable:Attribute
    {
        public string TableName { get; set; }

        public AttributeTable(string tableName) 
        {
            this.TableName = tableName;
        }
    }
}
