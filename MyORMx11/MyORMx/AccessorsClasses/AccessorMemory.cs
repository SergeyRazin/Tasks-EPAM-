using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMx
{
    public class AccessorMemory:IAccessor
    {
        Storage stor = new Storage();

        public void AddPerson(Person p)
        {
            stor.L.Add(p);
        }

        public void RemovePerson(string name)
        {
            for (int i = 0; i < stor.L.Count; i++)
            {
                if (stor.L[i].Name == name)
                {
                    stor.L.RemoveAt(i);
                    i--;
                }
            }
        }

        public void InsertPerson(int index, Person p)
        {
            stor.L.Insert(index, p);
        }

        public List<Person> GetAllPerson()
        {
            return stor.L;
        }

        public void Clear()
        {
            stor.L.Clear();
        }

        public Person GetPersonByIndex(int i)
        {
            return stor.L[i];
        }

        public int Count()
        {
            return stor.L.Count();
        }
    }
}
