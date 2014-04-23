using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyORM
{
    class Program
    {
        static void Main(string[] args)
        {
            Person Homer = new Person();
            Homer.Name = "Homer";
            Homer.Age = 47;

            Person Marge = new Person();
            Marge.Name = "Marge";
            Marge.Age = 40;

            AccessorMemory memoryAccessor = new AccessorMemory();
            AccessorSerializationBinary binary = new AccessorSerializationBinary();
            AccessorSerializationXML xmlAccessor = new AccessorSerializationXML();
            AccessorDateBaseSimple dbAccessor = new AccessorDateBaseSimple();
            Клиент клиент = new Клиент();

            
            
            клиент.AddPerson(Homer, xmlAccessor);
            клиент.AddPerson(Homer, xmlAccessor);
            клиент.AddPerson(Homer, xmlAccessor);
            клиент.AddPerson(Marge, xmlAccessor);

            клиент.RemovePerson("Homer", xmlAccessor);
            //клиент.Clear(xmlAccessor);
            клиент.ShowAll(xmlAccessor);

            Console.ReadKey();
        }
    }
}
