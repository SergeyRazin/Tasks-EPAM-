using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMx.DataClasses;

namespace MyORMx
{
    public interface IAccessor
    {
        
        bool AddPerson(Person p);
       
        bool RemovePerson(string name);
        
        bool InsertPerson(int index, Person p);
        
        List<Person> GetAllPerson();

        Person GetPersonByIndex(int i);

        int Count();
        
        bool Clear();
    }
}
