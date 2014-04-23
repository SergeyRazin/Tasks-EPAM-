using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORM
{
    class AccessorMemory:IAccessor
    {
        private Хранилище база = new Хранилище();

        //МЕТОД добавить персону в базу
        public bool AddPerson(Person p)
        {
            база.L.Add(p);
            return true;
        }

        //МЕТОД удалить персону 
        public bool RemovePerson(string name)
        {
            for (int i = 0; i < база.L.Count; i++)
            {
                if (база.L[i].Name == name) 
                {
                    база.L.RemoveAt(i);
                    i--;
                }
            }

            return true;
        }

        //МЕТОД добавить персону по индексу ( в нужное место )
        public bool InsertPerson(int index , Person p )
        {
            база.L.Insert(index, p);
            return true;
        }

        //МЕТОД вывести на экран всех персон
        public bool ShowAll()
        {
            foreach (Person i in база.L) 
            {
                Console.WriteLine(i.Name + "  " + i.Age);
            }
            return true;
        }

        //МЕТОД удалить всех персон
        public bool Clear()
        {
            база.L.Clear();
            return true;
        }


        
    }
}
