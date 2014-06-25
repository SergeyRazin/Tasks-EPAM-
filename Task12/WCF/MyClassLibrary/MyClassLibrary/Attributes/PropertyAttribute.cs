using System;

namespace MyClassLibrary.Attributes
{
    public class PropertyAttribute:Attribute
    {
        /// <summary>
        /// свойство для названия СТОЛБЦА таблицы БД
        /// </summary>
        public string ColumnName { get; set; }

        public Type t;

        //КОНСТРУКТОР
        public PropertyAttribute(string columnName0)
        {
            ColumnName = columnName0;
        }
    }
}
