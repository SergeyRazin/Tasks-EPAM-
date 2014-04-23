using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORMx
{
    public interface IAccessor
    {
        
        void AddPerson(Person p);

        void RemovePerson(string name);

        void InsertPerson(int index, Person p);
        
        List<Person> GetAllPerson();

        Person GetPersonByIndex(int i);

        int Count();

        void Clear();
    }
}
