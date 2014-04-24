using System.Collections.Generic;
using MyProject.DataClasses;
using MyProject.Interfaces;

namespace MyProject.AccessorsClasses
{
    public class AccessorMemory:IAccessor
    {
        //ПОЛЯ
        private Storage _storage = new Storage();

        //МЕТОДЫ
        public void AddPerson(Person p0)
        {
            _storage.L.Add(p0);
        }

        public void RemovePerson(int index0)
        {
            _storage.L.RemoveAt(index0);
        }

        public void InsertPerson(int index0, Person p0)
        {
            _storage.L.Insert(index0,p0);
        }

        public List<Person> GetAllPerson()
        {
            return _storage.L;
        }

        public Person GetPersonByIndex(int index0)
        {
            return _storage.L[index0];
        }

        public int Count()
        {
             return _storage.L.Count;
        }

        public void Clear()
        {
            _storage.L.Clear();
        }

        public void UpdatePerson(int index0,string name0,int age0,string phone0)
        {
            _storage.L[index0].Name = name0;
            _storage.L[index0].Age = age0;
            _storage.L[index0].Phone = phone0;
        }
    }
}
