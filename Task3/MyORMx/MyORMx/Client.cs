using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMx.DataClasses;

namespace MyORMx
{
    public class Client
    {
        public bool AddPerson(Person p,IAccessor accessor) 
        {
            accessor.AddPerson(p);
            return true;
        }

        public bool RemovePerson(string name,IAccessor accessor) 
        {
            accessor.RemovePerson(name);
            return true;
        }

        public List<Person> GetAllPerson(IAccessor accessor) 
        {
            return accessor.GetAllPerson();
            
        }

        public bool InsertPerson(int index, Person p,IAccessor accessor) 
        {
            accessor.InsertPerson(index, p);
            return true;
        }

        public bool Clear(IAccessor accessor) 
        {
            accessor.Clear();
            return true;
        }

        public Person GetPersonByIndex(int index,IAccessor accessor) 
        {
            return accessor.GetPersonByIndex(index);
        }

        public int Count(IAccessor accessor) 
        {
            return accessor.Count();
        }
    }
}
