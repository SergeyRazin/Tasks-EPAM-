using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute:Attribute
    {
        /// <summary>
        /// свойство для задания названия ТАБЛИЦЫ БД
        /// </summary>
        public string TableName { get; set; }

        //КОНСТРУКТОР
        public TableAttribute(string tableName0)
        {
            TableName = tableName0;
        }
    }
}
