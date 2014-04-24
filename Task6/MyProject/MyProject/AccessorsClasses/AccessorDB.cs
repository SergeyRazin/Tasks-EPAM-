using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using MyProject.DataClasses;
using MyProject.Interfaces;
using System.Configuration;


namespace MyProject.AccessorsClasses
{
    public class AccessorDB : IAccessor
    {
        #region ПРИВАТНЫЕ МЕТОДЫ

        //соединение с базой
        private SqlCeConnection MyConncetionToDB()
        {
            string conString = ConfigurationManager.ConnectionStrings["databasecon"].ConnectionString;

            SqlCeConnection con = new SqlCeConnection(conString);

            return con;
        }

        //получить индекс персоны по имени
        private int GetIDPersonByName(string name0)
        {
            var con = MyConncetionToDB();

            string sqlString = string.Format("SELECT [ID] FROM [Person] WHERE NameField = '{0}'", name0);
            SqlCeCommand com = new SqlCeCommand(sqlString, con);
            con.Open();

            SqlCeDataReader reader = com.ExecuteReader();

            reader.Read();
            int id = reader.GetInt32(0);
            

            reader.Close();
            con.Close();

            return id;
        }

        //добавить имя и возраст в таблицу Person
        private void addPers(Person p0)
        {
            var con = MyConncetionToDB();

            string commandString1 = String.Format("INSERT INTO [Person]([NameField],[AgeField]) VALUES('{0}',{1})",
                p0.Name, p0.Age);


            SqlCeCommand com1 = new SqlCeCommand(commandString1, con);

            con.Open();

            com1.ExecuteNonQuery();

            con.Close();
        }

        //добавить телефон в таблицу Phones
        private void addPhone(int IDPerson0, string phone0)
        {
            var con = MyConncetionToDB();

            string commandString1 = String.Format("INSERT INTO [Phones]([IDPerson],[Phone]) VALUES('{0}','{1}')",
                                                                                                    IDPerson0, phone0);

            SqlCeCommand com1 = new SqlCeCommand(commandString1, con);

            con.Open();

            com1.ExecuteNonQuery();

            con.Close();
        }

        //удалить все данные персоны из таблцы Person по индексу
        private void removePerson(int index0)
        {
            var con = MyConncetionToDB();

            string sqlQueryDelete = string.Format("DELETE  FROM Person WHERE ID = {0};", index0);

            SqlCeCommand com = new SqlCeCommand(sqlQueryDelete, con);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        //очистить таблицу персон
        private void clerPerson()
        {
            var con = MyConncetionToDB();

            SqlCeCommand com = new SqlCeCommand("Delete  FROM [Person]", con);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        //очистить таблицу телефонов
        private void clearPhone()
        {
            var con = MyConncetionToDB();

            SqlCeCommand com = new SqlCeCommand("Delete  FROM [Phones]", con);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        //удалить телефон по внешнему ключу
        private void RemovePhonePersons(int idPerosn0)
        {
            var con = MyConncetionToDB();

            string sqlQueryDelete = string.Format(@"DELETE FROM Phones
                                                    WHERE  (Phones.IDPerson = {0});", idPerosn0);

            SqlCeCommand com = new SqlCeCommand(sqlQueryDelete, con);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        //корректировать персону по индексу
        private void updatePers(int index0, string name0, int age0)
        {
            var con = MyConncetionToDB();
            string comString =
                string.Format("UPDATE Person SET NameField = '{0}', AgeField = {1} WHERE (Person.ID = {2})", name0, age0,
                    index0);
            SqlCeCommand com = new SqlCeCommand(comString, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        private void UpdatePhoneByPersonID(int idPerson0, string newPhone0)
        {
            var con = MyConncetionToDB();
            string comString =
                string.Format(@"UPDATE Phones SET  Phone = N'{0}' 
                                WHERE (IDPerson = {1})", newPhone0, idPerson0);

            SqlCeCommand com = new SqlCeCommand(comString, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        //проверить есть ли уже такое имя в базе
        private bool CheckNames(string name0)
        {
            List<Person> list = GetAllPerson();
            for (int i = 0; i < list.Count; i++)
            {
                //если в базе уже есть такое имя
                if (name0 == list[i].Name)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion




        public void AddPerson(Person p0)
        {
            //проверить есть ли в таблице точно такое же имя
            if(CheckNames(p0.Name)==false)
                //заносим данные(NameField,AgeField) в таблицу Person 
                addPers(p0);

            //получаем ID персоны по имени
            int idperson = GetIDPersonByName(p0.Name);

            //заносим телефон в таблицу Phone
            addPhone(idperson,p0.Phone);
        }

        public void RemovePerson(int index0)
        {
            //сначала удаляем все телефоны для этой персоны
            RemovePhonePersons(index0);

            //потом удаляем запись в таблице Person
            removePerson(index0);
        }

        public List<Person> GetAllPerson()
        {
            List<Person> list = new List<Person>();

            var con = MyConncetionToDB();

            SqlCeCommand com = new SqlCeCommand(@"SELECT Person.ID, Person.NameField, Person.AgeField, Phones.Phone
                                                    FROM Person LEFT OUTER JOIN
                                                            Phones ON Person.ID = Phones.IDPerson", con);
            con.Open();

            SqlCeDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                Person tempPerson = new Person();

                tempPerson.ID = reader.GetInt32(0);
                tempPerson.Name = reader.GetString(1);
                tempPerson.Age = reader.GetInt32(2);
                try
                {
                    tempPerson.Phone = reader.GetString(3);
                }
                catch (Exception e)
                {
                    tempPerson.Phone = "";
                }


                list.Add(tempPerson);
            }

            reader.Close();
            con.Close();

            return list;
        }

        public Person GetPersonByIndex(int index0)
        {
            var con = MyConncetionToDB();

            string sqlString = string.Format(@"SELECT Person.ID, Person.NameField, Person.AgeField, Phones.Phone
                                                FROM  Person LEFT OUTER JOIN
                                                        Phones ON Person.ID = Phones.IDPerson
                                                               WHERE  (Person.ID = {0})
                                                                    ORDER BY Person.ID", index0);
            SqlCeCommand com = new SqlCeCommand(sqlString, con);
            con.Open();

            SqlCeDataReader reader = com.ExecuteReader();

            Person tempPerson = new Person();

            reader.Read();
            tempPerson.ID = reader.GetInt32(0);
            tempPerson.Name = reader.GetString(1);
            tempPerson.Age = reader.GetInt32(2);
            try
            {
                tempPerson.Phone = reader.GetString(3);
            }
            catch (Exception e)
            {
                tempPerson.Phone = "";
            }
            

            reader.Close();
            con.Close();

            return tempPerson;
        }

        public int Count()
        {
            var con = MyConncetionToDB();

            SqlCeCommand com = new SqlCeCommand("SELECT COUNT([NameField]) FROM [Person];", con);
            con.Open();

            var reader = com.ExecuteReader();
            int count = 0;
            reader.Read();
            count = (int) reader.GetValue(0);

            reader.Close();
            con.Close();

            return count;
        }

        public void Clear()
        {
            //сначала очистить таблицу телефонов
            clearPhone();

            //очистить таблицу персон
            clerPerson();
        }

        public void UpdatePerson(int index0, string name0, int age0,string phone0)
        {
            //корректировать таблицу Person
            updatePers(index0, name0, age0);

            //корректировать таблицу Phones
            UpdatePhoneByPersonID(index0,phone0);
        }

        

        


        //методы на всякий случай
        private void RemovePhone(int id0)
        {
            var con = MyConncetionToDB();

            string sqlQueryDelete = string.Format("DELETE  FROM Phones WHERE ID = {0};", id0);

            SqlCeCommand com = new SqlCeCommand(sqlQueryDelete, con);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        private List<Person> GetAllPersonAndPhones()
        {
            List<Person> list = new List<Person>();

            var con = MyConncetionToDB();

            SqlCeCommand com = new SqlCeCommand(@"SELECT Person.ID, Person.NameField, Person.AgeField, Phones.Phone 
                                                    FROM    Person 
                                                        INNER JOIN 
                                                            Phones ON Person.ID = Phones.IDPerson;", con);

            con.Open();

            SqlCeDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                Person tempPerson = new Person();

                tempPerson.ID = reader.GetInt32(0);
                tempPerson.Name = reader.GetString(1);
                tempPerson.Age = reader.GetInt32(2);
                tempPerson.Phone = reader.GetString(3);


                list.Add(tempPerson);
            }
            return list;
        }

        private Person GetPersonByIndexWithPhone(int index0)
        {
            var con = MyConncetionToDB();

            string sqlString = string.Format(@"SELECT   Person.ID, Person.NameField, Person.AgeField, Phones.Phone 
                                                    FROM  Person INNER JOIN
                                                            Phones ON Person.ID = Phones.IDPerson
                                                                WHERE        (Person.ID = {0})", index0);
            SqlCeCommand com = new SqlCeCommand(sqlString, con);
            con.Open();

            SqlCeDataReader reader = com.ExecuteReader();

            Person tempPerson = new Person();

            reader.Read();
            tempPerson.ID = reader.GetInt32(0);
            tempPerson.Name = reader.GetString(1);
            tempPerson.Age = reader.GetInt32(2);
            tempPerson.Phone = reader.GetString(3);

            reader.Close();
            con.Close();

            return tempPerson;
        }

        private void UpdatePhone(int index0, string newPhone0)
        {
            var con = MyConncetionToDB();
            string comString =
                string.Format(@"UPDATE  Phones
                                SET Phone = '{0}'  
                                    WHERE  (ID = {1})",newPhone0 ,index0);

            SqlCeCommand com = new SqlCeCommand(comString, con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        private List<ArrayList> ShowAll()
        {
            List<ArrayList> list = new List<ArrayList>();

            var con = MyConncetionToDB();
            string comString = string.Format("SELECT ID, NameField, AgeField FROM  Person");

            SqlCeCommand com = new SqlCeCommand(comString, con);
            con.Open();

            var reader = com.ExecuteReader();

            while (reader.Read())
            {
                ArrayList temp = new ArrayList();
                temp.Add(reader["ID"]);
                temp.Add(reader["NameField"]);
                temp.Add(reader["AgeField"]);

                list.Add(temp);
            }
            con.Close();

            return list;
        }

        


    }
}
        
    
