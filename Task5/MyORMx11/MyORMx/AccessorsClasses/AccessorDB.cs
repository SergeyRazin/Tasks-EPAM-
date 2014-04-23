using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMx.AccessorsClasses
{
    public class AccessorDB:IAccessor
    {
        private SqlCeConnection MyConncetionToDB()
        {
            String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string stringConnection =  string.Format(@"Data Source={0}\..\App_Data\Database1.sdf", path).Replace(@"file:\","");
            SqlCeConnection con = new SqlCeConnection(stringConnection);

            //Console.WriteLine("просто путь ::: "+stringConnection);

            return con;
        }


        /// <summary>
        /// System.Data.SqlServerCe.SqlCeException
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public void AddPerson(Person p)
        {
                var con = MyConncetionToDB();

                string commandString = String.Format("INSERT INTO [Person]([NameField],[AgeField]) VALUES('{0}',{1})", p.Name, p.Age);
                
                SqlCeCommand com = new SqlCeCommand(commandString, con);
                
                con.Open();
                    
                com.ExecuteNonQuery();

                con.Close();
        }

        public void RemovePerson(string name)
        {
            var con = MyConncetionToDB();

            string sqlQueryDelete = string.Format("DELETE  FROM Person WHERE NameField = '{0}';", name);

            SqlCeCommand com = new SqlCeCommand(sqlQueryDelete, con);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

    

        public void InsertPerson(int index, Person p)
        {
                this.AddPerson(p);
        }

        public List<Person> GetAllPerson()
        {
            List<Person> list = new List<Person>();

                var con = MyConncetionToDB();
                
                SqlCeCommand com = new SqlCeCommand("SELECT [NameField],[AgeField] FROM [Person];", con);
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

        public Person GetPersonByIndex(int index)
        {
                var con = MyConncetionToDB();

                string sqlString = string.Format("SELECT [NameField],[AgeField] FROM [Person] WHERE ID = {0}",index);
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

        public int Count()
        {
               var con = MyConncetionToDB();

                SqlCeCommand com = new SqlCeCommand("SELECT COUNT([NameField]) FROM [Person];", con);
                con.Open();

                var reader = com.ExecuteReader();
                int count = 0;
                reader.Read();
                count = (int)reader.GetValue(0);
               
                reader.Close();
                con.Close();

                return count;
        }

        public void Clear()
        {
            var con = MyConncetionToDB();

            SqlCeCommand com = new SqlCeCommand("Delete  FROM [Person]", con);

            con.Open();
            com.ExecuteNonQuery();
        }
    }
}
