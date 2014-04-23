using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORM
{
    interface IAccessor
    {
        //добавить персону в конец
        bool AddPerson(Person p);
        //удалить персону 
        bool RemovePerson(string name);
        //добавить персону по индексу
        bool InsertPerson(int index, Person p);
        //вывести всех персон
        bool ShowAll();
        //удалить всех персон 
        bool Clear();
    }
}
