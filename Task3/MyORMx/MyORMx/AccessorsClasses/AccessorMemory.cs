using System.Collections.Generic;
using System.Linq;
using MyORMx.DataClasses;

namespace MyORMx.AccessorsClasses
{
    public class AccessorMemory:IAccessor
    {
        readonly Storage _stor = new Storage();

        public bool AddPerson(Person p)
        {
            _stor.L.Add(p);
            return true;
        }

        public bool RemovePerson(string name)
        {
            for (int i = 0; i < _stor.L.Count; i++)
            {
                if (_stor.L[i].Name == name)
                {
                    _stor.L.RemoveAt(i);
                    i--;
                }
            }

            return true;
        }

        public bool InsertPerson(int index, Person p)
        {
            _stor.L.Insert(index, p);
            return true;
        }

        public List<Person> GetAllPerson()
        {
            return _stor.L;
        }

        public bool Clear()
        {
            _stor.L.Clear();
            return true;
        }

        public Person GetPersonByIndex(int i)
        {
            return _stor.L[i];
        }

        public int Count()
        {
            return _stor.L.Count();
        }
    }
}
