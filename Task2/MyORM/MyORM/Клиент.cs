using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORM
{
    class Клиент
    {
        //МЕТОД добавить персону в конец
        public bool AddPerson(Person p,IAccessor accessor) 
        {
            accessor.AddPerson(p);
            return true;
        }
        //МЕТОД удалить персону 
        public bool RemovePerson(string name, IAccessor accessor) 
        {
            accessor.RemovePerson(name);
            return true;
        }
        //МЕТОД добавить персону по индексу
        public bool InsertPerson(int index, Person p, IAccessor accessor) 
        {
            accessor.InsertPerson(index, p);
            return true;
        }
        //МЕТОД вывести всех персон
        public bool ShowAll(IAccessor accessor) 
        {
            accessor.ShowAll();
            return true;
        }
        //МЕТОД удалить всех персон 
        public bool Clear(IAccessor accessor) 
        {
            accessor.Clear();
            return true;
        }
    }
}
