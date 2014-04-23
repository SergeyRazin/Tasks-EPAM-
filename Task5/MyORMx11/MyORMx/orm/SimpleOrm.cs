using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMx.Attributes;
using System.Reflection;
using System.Data.SqlServerCe;

namespace MyORMx.orm
{
    class SimpleOrm
    {
        public string showAll(Object ob)
        {
            string TableName = "";
            string Column = "";
            string Value = "";

            Type t = ob.GetType();
            if (t.IsDefined(typeof(AttributeTable), false))
            {
                //получить название таблицы
                AttributeTable attr = (AttributeTable)Attribute.GetCustomAttribute(ob.GetType(), typeof(AttributeTable));
                TableName += " " + attr.TableName + " ";
                //return TableName;//**

                //получить ссылки на все поля
                FieldInfo[] fields = t.GetFields();

                //ЦИКЛ пробежаться по каждому полю
                foreach (var i in fields)
                {
                    //Type tf=i.GetType();
                    //ЕСЛИ у этого поля есть атрибут AttributeField ТОГДА
                    if (i.IsDefined(typeof(AttributeProperties), false))
                    {
                        // получить значение этого поля и значение атрибута(столбец таблицы);
                        AttributeProperties afield = (AttributeProperties)Attribute.GetCustomAttribute(i, typeof(AttributeProperties));
                        Column += afield.FieldName + " , ";
                        Value += i.GetValue(ob) + " , ";
                    }
                    //ЕСЛИ ВСЕ
                }
                //ЦИКЛ ВСЕ
                return "название таблицы " + TableName + " \nназвание столбца = " + Column + " \nзначение переменной = " + Value;

            }
            return null;
        }

        //главный метод для получения названия таблицы1
        public string GetTableName(Object ob)
        {
            string TableName = "";


            Type t = ob.GetType();
            if (t.IsDefined(typeof(AttributeTable), false))
            {
                //получить название таблицы
                AttributeTable attr = (AttributeTable)Attribute.GetCustomAttribute(ob.GetType(), typeof(AttributeTable));
                TableName += " " + attr.TableName + " ";
                return TableName;
            }
            return null;
        }

        //главный метод для получения названия таблицы2
        public string GetTableName(Type t)
        {
            string TableName = "";

            if (t.IsDefined(typeof(AttributeTable), false))
            {
                //получить название таблицы
                AttributeTable attr = (AttributeTable)Attribute.GetCustomAttribute(t, typeof(AttributeTable));
                TableName += " " + attr.TableName + " ";
                return TableName;
            }
            return null;
        }

        //1
        public List<string> GetAllColumnsName(object ob)
        {
            List<string> Columns = new List<string>();
            Type t = ob.GetType();

            if (t.IsDefined(typeof(AttributeTable), false))
            {
                PropertyInfo[] fields = t.GetProperties();

                foreach (var i in fields)
                {

                    //ЕСЛИ у этого поля есть атрибут AttributeField ТОГДА
                    if (i.IsDefined(typeof(AttributeProperties), false))
                    {
                        // получить значение этого поля и значение атрибута(столбец таблицы);
                        AttributeProperties aprop = (AttributeProperties)Attribute.GetCustomAttribute(i, typeof(AttributeProperties));
                        Columns.Add(aprop.FieldName);
                    }
                    //ЕСЛИ ВСЕ
                }
                //ЦИКЛ ВСЕ
            }
            return Columns;
        }

        //2
        public List<string> GetAllColumnsName(Type t)
        {
            List<string> Columns = new List<string>();


            if (t.IsDefined(typeof(AttributeTable), false))
            {
                PropertyInfo[] fields = t.GetProperties();

                foreach (var i in fields)
                {

                    //ЕСЛИ у этого поля есть атрибут AttributeField ТОГДА
                    if (i.IsDefined(typeof(AttributeProperties), false))
                    {
                        // получить значение этого поля и значение атрибута(столбец таблицы);
                        AttributeProperties aprop = (AttributeProperties)Attribute.GetCustomAttribute(i, typeof(AttributeProperties));
                        Columns.Add(aprop.FieldName);
                    }
                    //ЕСЛИ ВСЕ
                }
                //ЦИКЛ ВСЕ
            }
            return Columns;
        }

        public List<string> GetAllValuesString(object ob)
        {
            List<string> Columns = new List<string>();
            Type t = ob.GetType();

            if (t.IsDefined(typeof(AttributeTable), false))
            {
                PropertyInfo[] fields = t.GetProperties();

                foreach (var i in fields)
                {

                    //ЕСЛИ у этого поля есть атрибут AttributeField ТОГДА
                    if (i.IsDefined(typeof(AttributeProperties), false))
                    {
                        // получить значение этого поля и значение атрибута(столбец таблицы);
                        AttributeProperties afield = (AttributeProperties)Attribute.GetCustomAttribute(i, typeof(AttributeProperties));
                        Columns.Add(i.GetValue(ob).ToString());
                    }
                    //ЕСЛИ ВСЕ
                }
                //ЦИКЛ ВСЕ
            }
            return Columns;
        }

        //главный метод для столбцов1
        public string GetStringColumns(object ob)
        {
            List<string> columnsname = GetAllColumnsName(ob);
            string strColumns = "";
            foreach (var i in columnsname)
            {
                strColumns += i + ",";
            }

            strColumns = strColumns.Trim(',');
            return strColumns;
        }

        //главный метод для столбцов2
        public string GetStringColumns(Type t)
        {
            List<string> columnsname = GetAllColumnsName(t);
            string strColumns = "";
            foreach (var i in columnsname)
            {
                strColumns += i + ",";
            }

            strColumns = strColumns.Trim(',');
            return strColumns;
        }


        //главный метод для значений
        public string GetStringValues(object ob)
        {
            List<string> values = GetAllValuesString(ob);
            string strValues = "";


            foreach (var i in values)
            {
                strValues += "'" + i + "'" + ",";
            }


            strValues = strValues.Trim(',');
            return strValues;
        }


        public bool AddPerson(object ob)
        {
            try
            {
                if (!ob.GetType().IsDefined(typeof(AttributeTable)))
                {
                    return false;
                }

                string tableName = GetTableName(ob);
                string columnsTarget = GetStringColumns(ob);
                string values = GetStringValues(ob);

                SqlCeConnection con = new SqlCeConnection(@"Data Source=..\..\Source\Database1.sdf");

                con.Open();

                string sqlCommand = String.Format("INSERT INTO {0}( {1} ) VALUES( {2} )", tableName, columnsTarget, values);
                SqlCeCommand com = new SqlCeCommand(sqlCommand, con);
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    con.Close();

                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool RemovePerson(string name, Type t)
        {
            try
            {
                if (!t.IsDefined(typeof(AttributeTable)))
                {
                    return false;
                }

                string tableName = GetTableName(t);
                string columnsTarget = GetStringColumns(t);





                SqlCeConnection con = new SqlCeConnection(@"Data Source=..\..\Source\Database1.sdf");

                con.Open();


                string sqlCommand = String.Format("DELETE  FROM {0} WHERE NameField = '{1}';", tableName, name);
                SqlCeCommand com = new SqlCeCommand(sqlCommand, con);
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    con.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<object> GetAllPerson(Type t)
        {
            List<object> list = new List<object>();

            try
            {
                SqlCeConnection con = new SqlCeConnection(@"Data Source=..\..\Source\Database1.sdf");

                var TAttribute = GetTableName(t);
                var columns = GetStringColumns(t);

                string commandString = string.Format("SELECT {0} FROM {1}", columns, TAttribute);
                SqlCeCommand com = new SqlCeCommand(commandString, con);
                con.Open();

                SqlCeDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Person tempPerson = new Person();

                    tempPerson.Name = reader.GetString(0);
                    tempPerson.Age = reader.GetInt32(1);

                    list.Add(tempPerson);
                }


                reader.Close();
                con.Close();

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Person GetPersonByIndex(int index, Type t)
        {
            try
            {
                if (!t.IsDefined(typeof(AttributeTable)))
                {
                    return null;
                }

                SqlCeConnection con = new SqlCeConnection(@"Data Source=..\..\Source\Database1.sdf");

                AttributeTable atable = (AttributeTable)Attribute.GetCustomAttribute(t, typeof(AttributeTable));
                string columns = GetStringColumns(t);



                string sqlString = string.Format("SELECT {0} FROM {1} WHERE ID = {2}", columns, atable.TableName, index);
                SqlCeCommand com = new SqlCeCommand(sqlString, con);
                con.Open();

                SqlCeDataReader reader = com.ExecuteReader();

                Person tempPerson = new Person();

                reader.Read();
                tempPerson.Name = reader.GetString(0);
                tempPerson.Age = reader.GetInt32(1);

                reader.Close();
                con.Close();

                return tempPerson;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new Person();
            }
        }

        public int Count(Type t)
        {
            try
            {
                if (!t.IsDefined(typeof(AttributeTable)))
                {
                    return 0;
                }

                SqlCeConnection con = new SqlCeConnection(@"Data Source=..\..\Source\Database1.sdf");

                AttributeTable atable = (AttributeTable)Attribute.GetCustomAttribute(t, typeof(AttributeTable));
                var columns = GetAllColumnsName(t);

                string sqlCommand = string.Format("SELECT COUNT({0}) FROM {1};", columns[0], atable.TableName);
                SqlCeCommand com = new SqlCeCommand(sqlCommand, con);
                con.Open();

                var reader = com.ExecuteReader();
                int count = 0;
                reader.Read();
                count = (int)reader.GetValue(0);

                reader.Close();
                con.Close();

                return count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

        public bool Clear(Type t)
        {
            try
            {
                SqlCeConnection con = new SqlCeConnection(@"Data Source=..\..\Source\Database1.sdf");

                string atable = GetTableName(t);

                string sqlCommand = string.Format("Delete  FROM {0}", atable);
                SqlCeCommand com = new SqlCeCommand(sqlCommand, con);
                try
                {
                    con.Open();
                    com.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    con.Close();
                }

                Console.WriteLine("Данные в таблице удалены");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
