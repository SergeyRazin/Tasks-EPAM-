using System;

namespace MyProject.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertiesAttribute:Attribute
    {
        /// <summary>
        /// свойство для названия СТОЛБЦА таблицы БД
        /// </summary>
        public string FieldName { get; set; }

        //КОНСТРУКТОР
        public PropertiesAttribute(string fieldName0)
        {
            this.FieldName = fieldName0;
        }
    }
}
