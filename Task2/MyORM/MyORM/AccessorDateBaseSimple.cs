using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace MyORM
{
    class AccessorDateBaseSimple:IAccessor
    {
        public bool AddPerson(Person p)
        {
            try
            {
                /*записать в таблицу бд имя и возраст персоны*/

                //создать соединение с бд
                SqlCeConnection con = new SqlCeConnection(@"Data Source=Database1.sdf");
                ////открыть соединение с бд
                //con.Open();

                //строка команды
                string commandString = String.Format("INSERT INTO [Person]([NameField],[AgeField]) VALUES('{0}',{1})", p.Name.ToString(), p.Age.ToString());

                //создать команду записи в бд
                SqlCeCommand com = new SqlCeCommand(commandString, con);
                //записать в БД данные
                try
                {
                    //открыть соединение с бд
                    con.Open();
                    //выполнить команду
                    com.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    //закрыть соединение с БД
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
                /*удалить из таблицы БД первую строку с именем name*/

                //создать соединение с БД
                SqlCeConnection con = new SqlCeConnection(@"Data Source=Database1.sdf");
                //открыть соединение с БД
                con.Open();

                //строка команды удаления
                string sqlQueryDelete = string.Format("DELETE  FROM Person WHERE NameField = '{0}';", name);
                //создать команду удаления
                SqlCeCommand com = new SqlCeCommand(sqlQueryDelete, con);

                try
                {
                    //выполнить команду удаления
                    com.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }



                //закрыть соединение с бд.
                con.Close();

                //возврат true
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
                this.AddPerson(p);
                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ShowAll()
        {
            try
            {
                //создать соединение с БД
                SqlCeConnection con = new SqlCeConnection(@"Data Source=Database1.sdf");
                //открыть соединение с БД
                con.Open();

                //создать команду
                SqlCeCommand com = new SqlCeCommand("SELECT [NameField],[AgeField] FROM [Person];", con);
                //выполнить команду
                SqlCeDataReader reader = com.ExecuteReader();

                //вывести в консоль данные о персоне
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetValue(i) + " ");
                    }
                    Console.WriteLine();
                }

                //закрыть соединение
                con.Close();

                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool Clear()
        {
            try
            {
                //создать соединение с бд
                SqlCeConnection con = new SqlCeConnection(@"Data Source=Database1.sdf");
                //открыть соединение
                con.Open();

                //создать команду
                SqlCeCommand com = new SqlCeCommand("Delete  FROM [Person]", con);
                try
                {
                    //выполнить команду
                    com.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                finally
                {
                    //закрыть соединение
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
