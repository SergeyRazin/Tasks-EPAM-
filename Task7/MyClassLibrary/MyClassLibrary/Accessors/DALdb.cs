using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlServerCe;
using MyClassLibrary.DataClasses;
using MyClassLibrary.MyExceptions;



namespace MyClassLibrary.Accessors
{
    public class DALdb
    {
        //ПРИВАТНЫЕ МЕТОДЫ
        #region --------↓---------------------------↓-----------------

        //-метод - получить соединение с БД
        private SqlCeConnection myConneciton()
        {
            string conString = ConfigurationManager.ConnectionStrings["databasecon"].ConnectionString;
            SqlCeConnection con = new SqlCeConnection(conString);
            return con;
        }

        //-метод проверить имя месторождение(чтобы небыло совпадений)
        private bool checkNameOilfield(String name0)
        {
            /* ЕСЛИ есть месторождение в БД с таким же именем 
                 * ТОГДА возврат true 
                 * ИНЧЕ возврат false;
             */

            //получить соединение с БД
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //созадть строку запроса
                var commandString = String.Format(@"SELECT  Name
                                                    FROM  Oilfield");

                //созать команду
                using (var com = new SqlCeCommand(commandString, con))
                {

                    //выполнить команду
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["Name"].ToString() == name0)
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                }
            }
        }

        //-метод добавить месторождение в БД(скважины не трогаем)
        private void addOilfield(Oilfield oilfield0)
        {
            //получить соединение с БД
            using (var con = myConneciton())
            {
                //открыть соединение с БД
                con.Open();

                //строка запроса
                var commandString = String.Format(@"INSERT INTO Oilfield (Name, OilResolv) 
                                                    VALUES ('{0}', {1})", oilfield0.Name, oilfield0.OilReserves);
                //создать команду
                using (var com = new SqlCeCommand(commandString, con))
                {
                    //выполнить команду
                    com.ExecuteNonQuery();
                }
            }
        }

        //-метод добавить скважину в БД
        private void addWell(Well well0, int oilfieldId0)
        {
            //создать соединение с БД
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //создать строку команды
                var commandString = String.Format(@"INSERT INTO 
                                                    Well (IDOilfield, Number, Debit, Pump)
                                                        VALUES ({0}, {1}, {2}, '{3}')", oilfieldId0, well0.Number,
                    well0.Debit, well0.Pump);

                //создать команду
                using (var com = new SqlCeCommand(commandString, con))
                {
                    //выполнить команду
                    com.ExecuteNonQuery();
                }
            }
        }

        //-метод получить лист всех месторождений 
        private List<Oilfield> getAllOifieldWithouthWells()
        {
            //созадем пустой лист
            List<Oilfield> listoilfList = new List<Oilfield>();

            //получть соединение с БД
            using (var con = myConneciton())
            {
                //открыть соединение с БД
                con.Open();

                //созадть строку команды
                var commandString = String.Format(@"SELECT ID, Name, OilResolv
                                                    FROM  Oilfield");

                //созадть команду
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

                            listoilfList.Add(temp);
                        }
                    }
                }
            }
            return listoilfList;
        }

        //-метод получить месторождение по индексу (без скважин)
        private Oilfield getOilfieldByIdWithouthWells(int id0)
        {
            //создать пустое месторождение 
            var temp = new Oilfield();

            //получить соединение с БД
            using (var con = myConneciton())
            {
                //открыть соединение с БД
                con.Open();

                //создать строку команды
                var commandString = String.Format(@"SELECT  ID, Name, OilResolv
                                                        FROM   Oilfield
                                                            WHERE   (ID = {0})",id0);

                //создать команду
                using (var com = new SqlCeCommand(commandString, con))
                {
                    //выполнить команду 
                    var reader = com.ExecuteReader();
                    reader.Read();

                    temp.Index = Convert.ToInt32(reader["ID"]);
                    temp.Name = reader["Name"].ToString();
                    temp.OilReserves = Convert.ToInt32(reader["OilResolv"]);
                }

            }
            return temp;
        }

        //-метод получить месторождение по имени (без скважин)
        private Oilfield getOilfieldByNameWithoutWells(string name0)
        {
            //создать пустое месторождение
            var temp = new Oilfield();

            //получить соединение с БД
            using (var con=myConneciton())
            {
                //открыть соединение
                con.Open();

                //создать строку команды
                var commandString = String.Format(@"SELECT  ID, Name, OilResolv
                                                        FROM  Oilfield
                                                            WHERE  (Name = N'{0}')",name0);

                //созадть команду
                using (var com = new SqlCeCommand(commandString,con))
                {
                    //выполнить команду
                    var reader = com.ExecuteReader();
                    reader.Read();

                    temp.Index = Convert.ToInt32(reader["ID"]);
                    temp.Name = reader["Name"].ToString();
                    temp.OilReserves = Convert.ToInt32(reader["OilResolv"]);

                }
            }
            return temp;
        }

        //-метод получить скважины для даннго месторождения(по имени)
        private List<Well> getWellsByOilfieldName(string name0)
        {
            //создаем путой лист скважин
            List<Well> wellList = new List<Well>();

            //получить соединение
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //получить строку команды
                var commandString = String.Format(@"SELECT Well.Number, Well.Debit, Well.Pump
                                                        FROM   Oilfield INNER JOIN
                                                            Well  ON   Oilfield.ID = Well.IDOilfield
                                                                WHERE (Oilfield.Name = N'{0}')",name0);

                //создать команду
                using (var com = new SqlCeCommand(commandString,con))
                {
                    //выполнить команду
                    var reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        var temp = new Well();

                        temp.Number = Convert.ToInt32(reader["Number"]);
                        temp.Debit = Convert.ToInt32(reader["Debit"]);
                        temp.Pump = reader["Pump"].ToString();

                        wellList.Add(temp);
                    }
                }
            }
            return wellList;
        }

        //-метод удалить все скважины
        private void deleteAllWells()
        {
            //получить соединение
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //созадть строку команды
                var commandString = String.Format(@"DELETE FROM Well");

                //выполнить команду
                using (var com = new SqlCeCommand(commandString,con))
                {
                    com.ExecuteNonQuery();
                }
            }
        }

        //-метод удалить все месторождения
        private void deleteAllOilfields()
        {
            //получить соединение
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //создать строку команды
                var commandString = string.Format(@"DELETE FROM Oilfield");

                //создать команду
                using (var com = new SqlCeCommand(commandString,con))
                {
                    //выполинть команду
                    com.ExecuteNonQuery();
                }
            }
        }

        //-метод обновить данные по месторождению(скважины не трогать)(использовать индекс месторождения)
        private void updateOilFieldByIndex(int index0, Oilfield oilfield0)
        {
            //получить соединение
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //созадть строку команды
                var commandString = String.Format(@"UPDATE  Oilfield
                                                    SET  Name = N'{0}', OilResolv = {1}
                                                         WHERE (Oilfield.ID = {2})",oilfield0.Name, oilfield0.OilReserves, index0);

                //создать команду
                using (var com = new SqlCeCommand(commandString,con))
                {
                    //выполнить команду
                    com.ExecuteNonQuery();
                }
            }
        }

        //-метод удалить все скважины конкретного месторождения(по индексу месторождения)
        private void removeWellsByOilfieldId(int oilfieldId0)
        {
            //создать соединение 
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //созадать строку команды
                var commandString = String.Format(@"DELETE FROM Well
                                                        WHERE (Well.IDOilfield = {0})",oilfieldId0);

                //создать команду
                using (var com = new SqlCeCommand(commandString,con) )
                {
                    //выполнить команду
                    com.ExecuteNonQuery();
                }
            }
        }

        //-метод удалить все скважины конкретного месторождения (по имени месторождения)
        private void removeWellsByOilfieldName(string oilfieldName0)
        {
            //получить индекс месторождения по названию
            var oilfieldID = getOilfieldID(oilfieldName0);

            //создать соединение с БД
            using (var con = myConneciton())
            {
                //открыть соединение с БД
                con.Open();

                //создать строку команды
                string commandString = String.Format(@"DELETE FROM Well
                                                           WHERE  (Well.IDOilfield = {0})",oilfieldID);

                //создать команду
                using (var com = new SqlCeCommand(commandString,con))
                {
                    //выполнить команду
                    com.ExecuteNonQuery();
                }
            }
        }

        //-метод удалить месторождение по индексу
        private void removeOilfieldBiId(int index0)
        {
            //создать соединение
            using (var con = myConneciton())
            {
                //открыь соединение
                con.Open();

                //создать строку комнды
                string commandString = String.Format(@"DELETE FROM Oilfield
                                                            WHERE  (Oilfield.ID = {0})", index0);

                //создать команду
                using (var com = new SqlCeCommand(commandString, con))
                {
                    //выполнить команду
                    com.ExecuteNonQuery();
                }
            }
        }

        //-метод удалить скважину по НОМЕРУ
        private void removeWell(int idWell0, int oilfieldId0)
        {
            //получить соединение
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //создать строку команды
                string commandString = string.Format(@"DELETE FROM Well
                                                        WHERE   (Well.Number = {0}) AND (Well.IDOilfield = {1})", idWell0,oilfieldId0);

                //создать команду
                using (var com = new SqlCeCommand(commandString,con))
                {
                    //выполнить команду
                    com.ExecuteNonQuery();
                }
            }
        }

        #endregion----------------------------------------------------------

        //ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ
        #region ----------------------↓--------------------------------------
        //-метод получить ID месторождения
        /// <summary>
        /// метод получить ID месторождения по названию
        /// </summary>
        /// <param name="name0">название месторождения</param>
        /// <returns></returns>
        /// <exception cref="MyOilfieldNameNotFoundException">когда месторождение не найдено</exception>
        public int getOilfieldID(string name0)
        {
            //создать соединение с БД
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //создать строку запроса
                var commandString = String.Format(@"SELECT  ID 
                                                    FROM  Oilfield
                                                        WHERE (Name = '{0}')", name0);

                //создать команду
                using (var com = new SqlCeCommand(commandString, con))
                {

                    //выполнить команду
                    using (var reader = com.ExecuteReader())
                    {
                        //прочитать результат
                        if (reader.Read())
                        {
                            if (reader["ID"] != null)
                            {
                                return (Convert.ToInt32(reader["ID"]));
                            }
                        }

                        //если месторождение не найдено ТО выбросить исключение
                        throw new MyOilfieldNameNotFoundException("месторождение с таким именеи не найдено");
                    }
                }
            }
        }

        //-метод получить лист скважин из БД по индексу месторождения
        public List<Well> getAllWellsByOilfieldId(int oilfieldId0)
        {
            //созадть пустой лист скважин
            List<Well> wellslList = new List<Well>();

            //создать соединение с БД
            using (var con = myConneciton())
            {
                //открыть соединение 
                con.Open();

                //создать строку команды
                var commandString = String.Format(@"SELECT Number, Debit, Pump
                                                        FROM   Well
                                                            WHERE  (IDOilfield = {0})", oilfieldId0);

                //выполнить команду
                using (var com = new SqlCeCommand(commandString, con))
                {
                    using (var reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var temp = new Well();

                            temp.Number = Convert.ToInt32(reader["Number"]);
                            temp.Debit = Convert.ToInt32(reader["Debit"]);
                            temp.Pump = reader["Pump"].ToString();

                            wellslList.Add(temp);
                        }
                    }
                }
            }
            return wellslList;
        }

        //- метод плучить название месторождения по индексу
        public string GetNameByIndex(int index0)
        {
            var name = "";

            //получить соединение
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //создать строку команды
                var commandString = string.Format(@"SELECT Name
                                                        FROM  Oilfield
                                                            WHERE  (ID = {0})",index0);
                //создаь команду
                using (var com = new SqlCeCommand(commandString,con))
                {
                    //выполнить команду
                    var reader = com.ExecuteReader();

                    if (reader.Read())
                    {
                        name = reader["Name"].ToString();
                    }
                    else
                        throw new MyOilfieldNameNotFoundException("Месторождения с таким индексом нет.");
                }
            }
            return name;
        }

        #endregion ----↑------------------------------------------------------

        //ГЛАВНЫЕ МЕТОДЫ
        #region-------↓-----------------------------------↓-----------------------------------
        //1. метод добавить месторожденин со скважинами в БД
        public virtual void AddOilfield(Oilfield oilfield0)
        {
            //залезть в базу проверить , есть ли месторождение с таким же названием(если есть, то ВЫБРОС ИСКЛЮЧЕНИЯ)
            if(checkNameOilfield(oilfield0.Name)) 
                throw new MyOverlapNameException("Месторождение с таким именем уже существует.");

            //записать данные чисто месторождения(лист скважин не трогать)
            addOilfield(oilfield0);

            //получить индекс (по названию) месторождения  которое мы только что записали
            var idOilfield = getOilfieldID(oilfield0.Name);

            //записать каждую скважину месторождения в базу данных по полученному индексу месторождения
            foreach (var w in oilfield0.Wells)
            {
                addWell(w, idOilfield);
            }

        }

        //2. метод получить список всех месторождений со скважинами
        public virtual List<Oilfield> GetAllOilfield()
        {
            //получить лист месторождений без скважин
            var oilfields = getAllOifieldWithouthWells();

            //для каждого месторождения
            foreach (var i in oilfields)
            {
                //получить лист скважин из БД по индексу месторождения
                var wellsList = getAllWellsByOilfieldId(i.Index);
                //сослаться на этот лист (Месторождение.Wells=ПолученыйЛист)
                i.Wells = wellsList;
            }
            
            //вернуть лист месторождений(они уже будут со скважинами)
            return oilfields;
        }

        //3. получить месторождение по индексу
        public virtual  Oilfield GetOilfieldById(int id0)
        {
            //получить месторождение по индексу без скважин
            var oilfield = getOilfieldByIdWithouthWells(id0);

            //получить лист скважин(по идексу ) для данного месторождения
           var wellsList = getAllWellsByOilfieldId(id0);

           //сделать ссылку: месторождение.скважины = полученныйЛистСкважин
            oilfield.Wells = wellsList;

            return oilfield;
        }

        //4. получить месторождение по имени
        public Oilfield GetOilfieldByName(string name0)
        {
            //получить месторождение(по имени) без скважин
            var oilfield = getOilfieldByNameWithoutWells(name0);

            //получить скважины для даннго месторождения(по имени)
            var wellsList = getWellsByOilfieldName(name0);

            //сделать ссылку: месторождение.скважины = полученныйЛистСкважин
            oilfield.Wells = wellsList;

            //вернуть месторождение
            return oilfield;
        }

        //5. очистить базу данных
        public void Clear()
        {
            //удалить все скважины
            deleteAllWells();

            //удалить все месторождения
            deleteAllOilfields();
        }

        //6. обновить данные по месторождению (используется удаление скважин) (на основе ID местоождения)
        public virtual void UpdateOilfield(int index0, Oilfield oilfield0)
        {
            //залезть в базу проверить , есть ли месторождение с таким же названием(если есть, то ВЫБРОС ИСКЛЮЧЕНИЯ)
            if (checkNameOilfield(oilfield0.Name))
                throw new MyOverlapNameException("Месторождение с таким именем уже существует.");

           /*обновить данные месторождения с индексом index0 на данные месторождения oilfield0*/

            //обновить данные только по месторождению(скважины не трогать)
            updateOilFieldByIndex(index0, oilfield0 );
        }

        //7. обновить данные по месторождению и по его скважинам (используется удаление скважин) (на основе имени меторождения)
        public void UpdateOilField(string nameOilfield0, Oilfield oilfield0)
        {
            //получить индекс месторождения
            var oilfieldID = getOilfieldID(nameOilfield0);

            //обновить данные только по месторождению(скважины не трогать)(использовать имя месторождения)
            updateOilFieldByIndex(oilfieldID, oilfield0);

            //удалить все скважины этого месторождения
            removeWellsByOilfieldName(nameOilfield0);

            //добавить в БД скважины oilfield0.wells 
            foreach (var w in oilfield0.Wells)
            {
                addWell(w, oilfieldID);
            }


        }

        //8.удалить месторождение по индексу
        public virtual void DeleteOilfield(int index0)
        {
            //удалить все скважины месторождения
            removeWellsByOilfieldId(index0);

            //удалить месторождение
            removeOilfieldBiId(index0);
        }

        //9. добавить скважину к месторождению
        public virtual void AddWell(Well well0, string oilfieldName0)
        {
            //получить ID месторождения
            var idOilfield = getOilfieldID(oilfieldName0);

            //добавить скважину в месторождение (внешний ключ = idOilfield)
            addWell(well0,idOilfield);
        }

        //10. удалить скважину из месторождения
        public virtual void RemoveWell(int idWell0, string oilfieldName0)
        {   
            //получить ID месторождения
            var oilfieldID = getOilfieldID(oilfieldName0);

            //удалить скважину по индексу
            removeWell(idWell0,oilfieldID);

        }

        //11. получить все скважины
        public virtual List<Well> GetAllWells()
        {
            //создать лист скважин
            var listWells = new List<Well>();

            //создать соединение
            using (var con = myConneciton())
            {
                //открыть соединение
                con.Open();

                //создать строку команды
                var commadnString = String.Format(@"SELECT  Number, Debit, Pump
                                                            FROM  Well");

                //создать команду
                using (var com = new SqlCeCommand(commadnString,con))
                {
                    //выполнить команду
                    var reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        var temp = new Well();

                        temp.Number = Convert.ToInt32(reader["Number"]);
                        temp.Debit = Convert.ToInt32(reader["Debit"]);
                        temp.Pump = reader["Pump"].ToString();

                        listWells.Add(temp);
                    }
                }
            }
            return listWells;
        }

        #endregion главные методы----↑---------------------↑---------------------

    }
}
