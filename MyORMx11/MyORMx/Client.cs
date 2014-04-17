using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMx
{
    public class Client
    {
        public void AddPerson(Person p, IAccessor accessor)
        {
            accessor.AddPerson(p);
        }

        public void RemovePerson(string name, IAccessor accessor)
        {
            accessor.RemovePerson(name);
        }

        public List<Person> GetAllPerson(IAccessor accessor) 
        {
            return accessor.GetAllPerson();
        }

        public void InsertPerson(int index, Person p, IAccessor accessor) 
        {
            accessor.InsertPerson(index, p);
        }

        public void Clear(IAccessor accessor)
        {
            accessor.Clear();
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
