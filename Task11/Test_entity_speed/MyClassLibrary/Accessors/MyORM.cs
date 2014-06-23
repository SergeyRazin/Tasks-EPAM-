using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Reflection;
using MyClassLibrary.Attributes;
using  MyClassLibrary.DataClasses;
using MyClassLibrary.MyExceptions;

namespace MyClassLibrary.Accessors
{
    public class MyORM
    {
        public DALdb Dal = new DALdb();

        #region приватные методы-------↓-----------------------

        //- получить соединение с БД
        private SqlCeConnection myConneciton()
        {
            string conString = ConfigurationManager.ConnectionStrings["databasecon"].ConnectionString;
            SqlCeConnection con = new SqlCeConnection(conString);
            return con;
        }

        //- получить название таблицы.
        private string getTablename(Object ob0)
        {
            string tableName = "";

            Type t = ob0.GetType();

            //если есть атрибут таблицы
            if (t.IsDefined(typeof (TableAttribute), false))
            {
                //получить название таблицы
                TableAttribute attr =
                    (TableAttribute) Attribute.GetCustomAttribute(ob0.GetType(), typeof (TableAttribute));

                tableName += " " + attr.TableName + " ";
                return tableName;
            }
            //если атрибута таблицы нет, то возврат null
            return null;
        }

        //- получить лист с названиями столбцов таблицы
        private List<String> getListColumns(object ob0)
        {
            List<string> listCol = new List<string>();
            var t = ob0.GetType();

            //проверить, что у объекта есть атрибут таблицы
            if (t.IsDefined(typeof (TableAttribute), false))
            {
                //получить все свойства объекта
                PropertyInfo[] fields = t.GetProperties();

                //перебрать все свойства
                foreach (var i in fields)
                {
                    //ЕСЛИ у этого свойства есть атрибут AttiributeColumn ТОГДА
                    if (i.IsDefined(typeof (PropertyAttribute), false))
                    {
                        //получить название этого свойства (будт название столбца таблицы)
                        PropertyAttribute atr =
                            (PropertyAttribute) Attribute.GetCustomAttribute(i, typeof (PropertyAttribute));
                        //добавить в лист
                        listCol.Add(atr.ColumnName);
                    }
                }
                return listCol;
            }
            throw new MyTableAttributeNotFound();
        }

        //- преобразовать лист в строку пригодную для SQL (для значений)
        private string getStringValueList(List<string> list0)
        {
            string str = "";

            //пробежать по всему списку столбцов
            foreach (var i in list0)
            {
                str += "'" + i + "'" + ",";
            }

            //обрезать последнюю запятую
            str = str.Trim(',');

            //возврат нужную строку
            return str;
        }

        //- преобразовать лист в строку пригодную для SQL (для столбцов)
        private string getStringColumnList(List<string> list0)
        {
            string str = "";

            //пробежать по всему списку столбцов
            foreach (var i in list0)
            {
                str += i + ",";
            }

            //обрезать последнюю запятую
            str = str.Trim(',');

            //возврат нужную строку
            return str;
        }

        //- получить лист со значениями свойств которые нужно записать в базу данных
        private List<string> getListValue(object ob0)
        {
            List<string> list = new List<string>();

            var t = ob0.GetType();

            //если нет атрибута таблицы то выбросить исключение
            if (! t.IsDefined(typeof (TableAttribute), false)) throw new MyTableAttributeNotFound();

            //получить все свойства объекта
            PropertyInfo[] fielInfos = t.GetProperties();

            //пробежаться по всем полученным свойствам 
            foreach (var i in fielInfos)
            {
                //если есть атрибут для столбцов
                if (i.IsDefined(typeof (PropertyAttribute), false))
                {
                    //получить ссылку на это поле
                    PropertyAttribute atr =
                        (PropertyAttribute) Attribute.GetCustomAttribute(i, typeof (PropertyAttribute));

                    //добавить значение поля в лист
                    list.Add(i.GetValue(ob0).ToString());
                }
            }
            return list;
        }

        //- записать в БД инфу по месторождению
        private void insertOilIntoDB(string tableName0, string colStr0, string valueStr0)
        {
            //получить соединение
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //создать строку запроса
                string commandString = String.Format(@"INSERT INTO {0} ({1})
                                                                VALUES  ({2})", tableName0, colStr0, valueStr0);

                //создать команду
                using (var com = new SqlCeCommand(commandString, con))
                {
                    //выполнить команду
                    com.ExecuteNonQuery();
                }
            }
        }

        //- добвить "любой" объект в базу
        private void addSomphing(object ob0)
        {
            //проверить есть ли атрибут таблицы у класса.  ЕСЛИ нет то возврат
            if (ob0.GetType().IsDefined(typeof (TableAttribute), false) == false)
            {
                return;
            }

            //получить название таблицы
            var tableName = getTablename(ob0);

            //получить строку с названиями столбцов таблицы, разделенные запятой
            var colStr = getStringColumnList(getListColumns(ob0));

            //получить строку с значениями которые нужно записать в БД 
            var valueStr = getStringValueList(getListValue(ob0));

            //SQL записать в ТАБЛИЦУ такую-то в такие-то СТОЛБЦЫ такие-то ЗНАЧЕНИЯ
            insertOilIntoDB(tableName, colStr, valueStr);
        }

        //- добавить скважины в базу для месторождения
        private void insertWells(Oilfield oilfield0)
        {
            //получить индекс месторождения
            var idoil = Dal.getOilfieldID(oilfield0.Name);

            //получить все члены класса
            var member = typeof (Oilfield).GetFields();

            //пробежаться по всем member
            foreach (var imember in member)
            {
                //ЕСЛИ у какого нибудь мембера есть атрибут CollectionAttribute ТОГДА
                if (imember.IsDefined(typeof (CollectionAttribute), false))
                {
                    //получить ссылку на этот мембер
                    var rez = (CollectionAttribute) Attribute.GetCustomAttribute(imember, typeof (CollectionAttribute));

                    var wells = (List<Well>) (imember.GetValue(oilfield0));

                    //пробежаться по всем элементам этой коллекции
                    foreach (var i in wells)
                    {
                        //получить название таблицы
                        var tableWells = getTablename(i);

                        //получить строку столбцов
                        var columnStr = getStringColumnList(getListColumns(i));

                        //получить строку значений
                        var valueStrWell = getStringValueList(getListValue(i));

                        //выполнить SQL КОМАДУ++

                        //получить соединение
                        using (var con = myConneciton())
                        {
                            //открыть соединение
                            con.Open();

                            //создать строку запроса
                            var commandStirng = String.Format(@"INSERT INTO {0} (IDOilfield, {1})
                                                                    VALUES  ( {2},{3})", tableWells, columnStr, idoil,
                                valueStrWell);

                            //создать команду
                            using (var com = new SqlCeCommand(commandStirng, con))
                            {
                                com.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        //- удалить скважиы из базы для месторождения
        private void removeWells(Oilfield oilfield0)
        {
            //получить индекс месторождения
            var idoil = Dal.getOilfieldID(oilfield0.Name);

            //получить все члены класса
            var member = typeof (Oilfield).GetFields();

            //пробежаться по всем member
            foreach (var imember in member)
            {
                //ЕСЛИ у какого нибудь мембера есть атрибут CollectionAttribute ТОГДА
                if (imember.IsDefined(typeof (CollectionAttribute), false))
                {
                    var wells = (List<Well>) (imember.GetValue(oilfield0));

                    //пробежаться по всем элементам этой коллекции
                    foreach (var i in wells)
                    {
                        //получить название таблицы
                        var tableWells = getTablename(i);

                        //выполнить SQL КОМАДУ++

                        //получить соединение
                        using (var con = myConneciton())
                        {
                            //открыть соединение
                            con.Open();

                            //создать строку запроса
                            var commandStirng = String.Format(@"DELETE FROM {0}
                                                                WHERE  (Well.IDOilfield = {1})", tableWells, idoil);

                            //создать команду
                            using (var com = new SqlCeCommand(commandStirng, con))
                            {
                                com.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        //- удалить месторождение
        private void removeOil(Oilfield oilfield0)
        {
            //получить индекс месторождения
            var idoil = Dal.getOilfieldID(oilfield0.Name);

            //ЕСЛИ класса есть атрибут TableAttribute ТОГДА
            if (oilfield0.GetType().IsDefined(typeof (TableAttribute), false))
            {
                //получить название таблицы
                var tableOil = getTablename(oilfield0);

                //выполнить SQL КОМАДУ++

                //получить соединение
                using (var con = myConneciton())
                {
                    //открыть соединение
                    con.Open();

                    //создать строку запроса
                    var commandStirng = String.Format(@"DELETE FROM {0}
                                                                WHERE  (ID = {1})", tableOil, idoil);

                    //создать команду
                    using (var com = new SqlCeCommand(commandStirng, con))
                    {
                        //выполнить команду
                        com.ExecuteNonQuery();
                    }
                }

            }

        }

        //- получить название таблицы для скважин
        public string getTableNameWells(Oilfield oilfield0)
        {
            //получить индекс месторождения
            var idoil = Dal.getOilfieldID(oilfield0.Name);

            //получить все члены класса
            var member = typeof (Oilfield).GetFields();

            //пробежаться по всем member
            foreach (var imember in member)
            {
                //ЕСЛИ у какого нибудь мембера есть атрибут CollectionAttribute ТОГДА
                if (imember.IsDefined(typeof (CollectionAttribute), false))
                {
                    var wells = (List<Well>) (imember.GetValue(oilfield0));

                    //пробежаться по всем элементам этой коллекции
                    foreach (var i in wells)
                    {
                        //получить название таблицы
                        var tableWells = getTablename(i);

                        //вернуть название таблицы для скважин
                        return tableWells;
                    }
                }
            }
            return null;
        }

        //- получить месторождения с пустым листом скважин
        

        #endregion приватные методы----↑-----------------------

        //1. добавить месторождение в базу
        public void AddOilfield(Oilfield oilfield0)
        {
            //проверить есть ли атрибут таблицы у класса.  ЕСЛИ нет то возврат
            if (oilfield0.GetType().IsDefined(typeof (TableAttribute), false) == false)
            {
                return;
            }

            //получить название таблицы
            var tableName = getTablename(oilfield0);

            //получить строку с названиями столбцов таблицы, разделенные запятой
            var colStr = getStringColumnList(getListColumns(oilfield0));

            //получить строку с значениями которые нужно записать в БД 
            var valueStr = getStringValueList(getListValue(oilfield0));

            //SQL записать в ТАБЛИЦУ такую-то в такие-то СТОЛБЦЫ такие-то ЗНАЧЕНИЯ
            insertOilIntoDB(tableName, colStr, valueStr);

            //добавить скважины к месторождению
            insertWells(oilfield0);
        }

        //2. удалить месторождение из базы
        public void RemoveOilfield(int index0, Oilfield oilfield0)
        {
            //проверить есть ли атрибут таблицы у класса.  ЕСЛИ нет то возврат
            if (oilfield0.GetType().IsDefined(typeof (TableAttribute), false) == false)
            {
                return;
            }

            //получить название таблицы
            var tableName = getTablename(oilfield0);

            //получить строку с названиями столбцов таблицы, разделенные запятой
            var colStr = getStringColumnList(getListColumns(oilfield0));

            //получить строку с значениями которые нужно записать в БД 
            var valueStr = getStringValueList(getListValue(oilfield0));

            //SQL удалить скважины месторождения
            removeWells(oilfield0);

            //удалить само месторождение
            removeOil(oilfield0);
        }

        //3. добавить скважину к месторождению
        public void AddWell(Well well0, Oilfield oilfield0)
        {
            //получить названия столбцов скважины
            var columns = getStringColumnList(getListColumns(well0));

            //получить значения столбцов
            var value = getStringValueList(getListValue(well0));

            //получить название таблицы для скважин
            var tableWell = getTableNameWells(oilfield0);

            //получить индекс месторождения
            var IDOil = Dal.getOilfieldID(oilfield0.Name);

            //SQL

            //получить соединение
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //создать строку запроса
                var commandStirng = String.Format(@"INSERT INTO {0}
                                                       (IDOilfield,{1})
                                                            VALUES  ({2}, {3})", tableWell, columns, IDOil, value);

                //создать команду
                using (var com = new SqlCeCommand(commandStirng, con))
                {
                    //выполнить команду
                    com.ExecuteNonQuery();
                }
            }
        }

        //4. удалить скважину из месторождения
        public void RemoveWell(Well well0, Oilfield oilfield0)
        {
            //получить индекс месторождение
            var idOil = Dal.getOilfieldID(oilfield0.Name);

            //получить названия столбцов скважины
            var columns = getStringColumnList(getListColumns(well0));

            //получить значения столбцов
            var value = getStringValueList(getListValue(well0));

            //получить название таблицы для скважин
            var tableWell = getTableNameWells(oilfield0);

            //получить индекс месторождения
            var IDOil = Dal.getOilfieldID(oilfield0.Name);

            //SQL

            //получить соединение
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //создать строку запроса
                var commandStirng = String.Format(@"DELETE FROM {0}
                                                        WHERE  (Well.Number = {1}) AND (Well.IDOilfield = {2})",
                    tableWell, well0.Number, idOil);

                //создать команду
                using (var com = new SqlCeCommand(commandStirng, con))
                {
                    //выполнить команду
                    com.ExecuteNonQuery();
                }
            }
        }

        //5. обновить даынне об месторождении
        public void UpdateOilfield(int index0, Oilfield oilfield0)
        {
            //удалить все скважины и само месторождение
            removeWells(oilfield0);
            //удалить месторождение
            removeOil(oilfield0);

            //записать новое месторождение и все скважины
            AddOilfield(oilfield0);
        }

        //6. получить лист месторождений со скважинами
        public List<Oilfield> GetAllOilfield()
        {
            //получить месторождение с пустым листом скважин
            var allOil = GetAllOil("Oilfield");

            //для каждого месторождения
            foreach (var i in allOil)
            {
                //получить лист скважин из БД по индексу месторождения
                var wellsList = Dal.getAllWellsByOilfieldId(i.Index);
                //сослаться на этот лист (Месторождение.Wells=ПолученыйЛист)
                i.Wells = wellsList;
            }
            return allOil;
        }

        //7. удалить все данные из таблицы
        public void Clear(string nameTable0)
        {
            //удалть все данные в этой таблице→→→

            //получить соединение
            using (var con = myConneciton()) 
            {
                //открыть соединение
                con.Open();

                //создать строку запроса
                var commandString = string.Format(@"DELETE FROM {0}", nameTable0);

                //созадть команду
                using (var com = new SqlCeCommand(commandString,con))
                {
                    //выполнить команду
                    com.ExecuteNonQuery();
                }
            }
        }

        //8. получить лист месторождений без скважин
        public List<Oilfield> GetAllOil(string nameTableOil0)
        {
            //создать пустой лист месторождений
            var list = new List<Oilfield>();

            //получить соединение
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //создать строку команды
                var commandString = String.Format(@"SELECT  *
                                                            FROM  {0}", nameTableOil0);

                //создать команду
                using (var com = new SqlCeCommand(commandString, con))
                {
                    //выполнить команду
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var temp = new Oilfield();

                            temp.Index = Convert.ToInt32(reader["ID"]);
                            temp.Name = reader["Name"].ToString();
                            temp.OilReserves = Convert.ToInt32(reader["OilResolv"]);

                            list.Add(temp);
                        }

                    }

                }
            }
            return list;
        }

        //9. получить лист скважин
        public List<Well> GetAllWells(string TableNameWells0)
        {
            //создать пустой лист скважин
            var list = new List<Well>();

            //получить соединение
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //создать строку команды
                var commandString = String.Format(@"SELECT  *
                                                            FROM  {0}", TableNameWells0);

                //создать команду
                using (var com = new SqlCeCommand(commandString, con))
                {
                    //выполнить команду
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var temp = new Well();

                            temp.Number = Convert.ToInt32(reader["Number"]);
                            temp.Debit = Convert.ToInt32(reader["Debit"]);
                            temp.Pump = reader["Pump"].ToString();

                            list.Add(temp);
                        }
                    }
                }
            }
            return list;
        }
    }
}
