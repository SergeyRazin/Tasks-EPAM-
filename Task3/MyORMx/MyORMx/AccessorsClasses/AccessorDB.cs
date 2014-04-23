using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using MyORMx.DataClasses;

namespace MyORMx.AccessorsClasses
{
    public class AccessorDb:IAccessor
    {
        public bool AddPerson(Person p)
        {
            try
            {
                /*записать в таблицу бд имя и возраст персоны*/
                
                var con = new SqlCeConnection(@"Data Source=..\..\Source\Database1.sdf");
                
                string commandString = String.Format("INSERT INTO [Person]([NameField],[AgeField]) VALUES('{0}',{1})", p.Name, p.Age);
                
                var com = new SqlCeCommand(commandString, con);
                
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

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool RemovePerson(string name)
        {
            try
            {
                var con = new SqlCeConnection(@"Data Source=..\..\Source\Database1.sdf");
                
                string sqlQueryDelete = string.Format("DELETE  FROM Person WHERE NameField = '{0}';", name);
                
                var com = new SqlCeCommand(sqlQueryDelete, con);

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

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool InsertPerson(int index, Person p)
        {
            try
            {
                AddPerson(p);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<Person> GetAllPerson()
        {
            var list = new List<Person>();

            try
            {
                var con = new SqlCeConnection(@"Data Source=..\..\Source\Database1.sdf");
                
                var com = new SqlCeCommand("SELECT [NameField],[AgeField] FROM [Person];", con);
                con.Open();
                
                SqlCeDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    var tempPerson = new Person {Name = reader.GetString(0), Age = reader.GetInt32(1)};

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

        public Person GetPersonByIndex(int index)
        {
            try
            {
                var con = new SqlCeConnection(@"Data Source=..\..\Source\Database1.sdf");

                string sqlString = string.Format("SELECT [NameField],[AgeField] FROM [Person] WHERE ID = {0}",index);
                var com = new SqlCeCommand(sqlString, con);
                con.Open();

                SqlCeDataReader reader = com.ExecuteReader();
                
                var tempPerson = new Person();

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
                return null;
            }
        }

        public int Count()
        {
            try
            {
                var con = new SqlCeConnection(@"Data Source=..\..\Source\Database1.sdf");

                var com = new SqlCeCommand("SELECT COUNT([NameField]) FROM [Person];", con);
                con.Open();

                var reader = com.ExecuteReader();
                reader.Read();
                var count = (int)reader.GetValue(0);
               
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

        public bool Clear()
        {
            try
            {
                var con = new SqlCeConnection(@"Data Source=..\..\Source\Database1.sdf");
                
                var com = new SqlCeCommand("Delete  FROM [Person]", con);
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
