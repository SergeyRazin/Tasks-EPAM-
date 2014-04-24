using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Reflection;
using MyProject.DataClasses;
using MyProject.Attributes;

namespace MyProject.AccessorsClasses
{
    public class MyORM
    {

        #region ПРИВАТНЫЕ МЕТОДЫ

        private SqlCeConnection MyConncetionToDB()
        {
            string conString = ConfigurationManager.ConnectionStrings["databasecon"].ConnectionString;

            SqlCeConnection con = new SqlCeConnection(conString);

            return con;
        }

        public string ShowAll(Object ob0)
        {
            string TableName = "";
            string Column = "";
            string Value = "";

            Type t = ob0.GetType();
            if (t.IsDefined(typeof (TableAttribute), false))
            {
                //получить название таблицы
                TableAttribute attr =
                    (TableAttribute) Attribute.GetCustomAttribute(ob0.GetType(), typeof (TableAttribute));
                TableName += " " + attr.TableName + " ";
                //return TableName;//**

                //получить ссылки на все поля
                FieldInfo[] fields = t.GetFields();

                //ЦИКЛ пробежаться по каждому полю
                foreach (var i in fields)
                {
                    //Type tf=i.GetType();
                    //ЕСЛИ у этого поля есть атрибут AttributeField ТОГДА
                    if (i.IsDefined(typeof (PropertiesAttribute), false))
                    {
                        // получить значение этого поля и значение атрибута(столбец таблицы);
                        PropertiesAttribute afield =
                            (PropertiesAttribute) Attribute.GetCustomAttribute(i, typeof (PropertiesAttribute));
                        Column += afield.FieldName + " , ";
                        Value += i.GetValue(ob0) + " , ";
                    }
                    //ЕСЛИ ВСЕ
                }
                //ЦИКЛ ВСЕ
                return "название таблицы " + TableName + " \nназвание столбца = " + Column + " \nзначение переменной = " +
                       Value;

            }
            return null;
        }

        //главный метод для получения названия таблицы1
        private string GetTableName(Object ob0)
        {
            string TableName = "";


            Type t = ob0.GetType();
            if (t.IsDefined(typeof (TableAttribute), false))
            {
                //получить название таблицы
                TableAttribute attr =
                    (TableAttribute) Attribute.GetCustomAttribute(ob0.GetType(), typeof (TableAttribute));
                TableName += " " + attr.TableName + " ";
                return TableName;
            }
            return null;
        }

        //главный метод для получения названия таблицы2
        private string GetTableName(Type t0)
        {
            string TableName = "";

            if (t0.IsDefined(typeof (TableAttribute), false))
            {
                //получить название таблицы
                TableAttribute attr = (TableAttribute) Attribute.GetCustomAttribute(t0, typeof (TableAttribute));
                TableName += " " + attr.TableName + " ";
                return TableName;
            }
            return null;
        }

        //1
        private List<string> GetAllColumnsName(object ob0)
        {
            List<string> Columns = new List<string>();
            Type t = ob0.GetType();

            if (t.IsDefined(typeof (TableAttribute), false))
            {
                PropertyInfo[] fields = t.GetProperties();

                foreach (var i in fields)
                {

                    //ЕСЛИ у этого поля есть атрибут AttributeField ТОГДА
                    if (i.IsDefined(typeof (PropertiesAttribute), false))
                    {
                        // получить значение этого поля и значение атрибута(столбец таблицы);
                        PropertiesAttribute aprop =
                            (PropertiesAttribute) Attribute.GetCustomAttribute(i, typeof (PropertiesAttribute));
                        Columns.Add(aprop.FieldName);
                    }
                    //ЕСЛИ ВСЕ
                }
                //ЦИКЛ ВСЕ
            }
            return Columns;
        }

        //2
        private List<string> GetAllColumnsName(Type t0)
        {
            List<string> Columns = new List<string>();


            if (t0.IsDefined(typeof (TableAttribute), false))
            {
                PropertyInfo[] fields = t0.GetProperties();

                foreach (var i in fields)
                {

                    //ЕСЛИ у этого поля есть атрибут AttributeField ТОГДА
                    if (i.IsDefined(typeof (PropertiesAttribute), false))
                    {
                        // получить значение этого поля и значение атрибута(столбец таблицы);
                        PropertiesAttribute aprop =
                            (PropertiesAttribute) Attribute.GetCustomAttribute(i, typeof (PropertiesAttribute));
                        Columns.Add(aprop.FieldName);
                    }
                    //ЕСЛИ ВСЕ
                }
                //ЦИКЛ ВСЕ
            }
            return Columns;
        }

        private List<string> GetAllValuesString(object ob0)
        {
            List<string> Columns = new List<string>();
            Type t = ob0.GetType();

            if (t.IsDefined(typeof (TableAttribute), false))
            {
                PropertyInfo[] fields = t.GetProperties();

                foreach (var i in fields)
                {

                    //ЕСЛИ у этого поля есть атрибут AttributeField ТОГДА
                    if (i.IsDefined(typeof (PropertiesAttribute), false))
                    {
                        // получить значение этого поля и значение атрибута(столбец таблицы);
                        PropertiesAttribute afield =
                            (PropertiesAttribute) Attribute.GetCustomAttribute(i, typeof (PropertiesAttribute));
                        Columns.Add(i.GetValue(ob0).ToString());
                    }
                    //ЕСЛИ ВСЕ
                }
                //ЦИКЛ ВСЕ
            }
            return Columns;
        }

        //главный метод для столбцов1
        private string GetStringColumns(object ob0)
        {
            List<string> columnsname = GetAllColumnsName(ob0);
            string strColumns = "";
            foreach (var i in columnsname)
            {
                strColumns += i + ",";
            }

            strColumns = strColumns.Trim(',');
            return strColumns;
        }

        //главный метод для столбцов2
        private string GetStringColumns(Type t0)
        {
            List<string> columnsname = GetAllColumnsName(t0);
            string strColumns = "";
            foreach (var i in columnsname)
            {
                strColumns += i + ",";
            }

            strColumns = strColumns.Trim(',');
            return strColumns;
        }

        //главный метод для значений
        private string GetStringValues(object ob0)
        {
            List<string> values = GetAllValuesString(ob0);
            string strValues = "";


            foreach (var i in values)
            {
                strValues += "'" + i + "'" + ",";
            }


            strValues = strValues.Trim(',');
            return strValues;
        }

        #endregion


        public void AddPerson(object ob0)
        {
            try
            {
                //если у класса нет атрибута TableAttribute тогда возврат.
                if (!ob0.GetType().IsDefined(typeof (TableAttribute)))
                {
                    return;
                }

                //получить название таблицы
                string tableName = GetTableName(ob0);

                //получить строку столбцов, разделенных запятыми
                string columnsTarget = GetStringColumns(ob0);

                //получить строку значений полей у которых есть атрибут PropertyAttribute
                string values = GetStringValues(ob0);

                var con = MyConncetionToDB();

                con.Open();

                string sqlCommand = String.Format("INSERT INTO {0}( {1} ) VALUES( {2} )", tableName, columnsTarget,
                    values);
                SqlCeCommand com = new SqlCeCommand(sqlCommand, con);
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    con.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RemovePerson(string name0, Type t0)
        {
            try
            {
                //если у класса нет атрибута TableAttribute , тогда return
                if (!t0.IsDefined(typeof (TableAttribute)))
                {
                    return;
                }

                //получить название таблицы
                string tableName = GetTableName(t0);

                var con = MyConncetionToDB();

                con.Open();


                string sqlCommand = String.Format("DELETE  FROM {0} WHERE NameField = '{1}';", tableName, name0);
                SqlCeCommand com = new SqlCeCommand(sqlCommand, con);
                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                finally
                {
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<object> GetAllPerson(Type t0)
        {
            List<object> list = new List<object>();

            try
            {
                var con = MyConncetionToDB();

                var TAttribute = GetTableName(t0);
                var columns = GetStringColumns(t0);

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

        public Person GetPersonByIndex(int index0, Type t0)
        {
            try
            {
                if (!t0.IsDefined(typeof (TableAttribute)))
                {
                    return null;
                }

                var con = MyConncetionToDB();

                TableAttribute atable = (TableAttribute) Attribute.GetCustomAttribute(t0, typeof (TableAttribute));
                string columns = GetStringColumns(t0);



                string sqlString = string.Format("SELECT {0} FROM {1} WHERE ID = {2}", columns, atable.TableName, index0);
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

        public int Count(Type t0)
        {
            try
            {
                if (!t0.IsDefined(typeof (TableAttribute)))
                {
                    return 0;
                }

                var con = MyConncetionToDB();

                TableAttribute atable = (TableAttribute) Attribute.GetCustomAttribute(t0, typeof (TableAttribute));
                var columns = GetAllColumnsName(t0);

                string sqlCommand = string.Format("SELECT COUNT({0}) FROM {1};", columns[0], atable.TableName);
                SqlCeCommand com = new SqlCeCommand(sqlCommand, con);
                con.Open();

                var reader = com.ExecuteReader();
                int count = 0;
                reader.Read();
                count = (int) reader.GetValue(0);

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

        public void Clear(Type t0)
        {
            try
            {
                var con = MyConncetionToDB();

                string atable = GetTableName(t0);

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
                }
                finally
                {
                    con.Close();
                }

                Console.WriteLine("Данные в таблице удалены");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
