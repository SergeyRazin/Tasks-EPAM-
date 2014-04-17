using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace MyORMx.AccessorsClasses
{
    public class AccessorXML:IAccessor
    {
        private Storage storage = new Storage();

        private Storage DesirializXML(string path)
        {
            /*ЕСЛИ XML файл существует , ТО десериализовать его и возврат объекта с данными ИНАЧЕ возврат пустой базы*/

            
            Storage storage = new Storage();
            try
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof(Storage), new Type[] { typeof(List<Person>) });

                if (File.Exists(path))
                {
                    using (Stream fstream = File.OpenRead(path))
                    {
                        storage = (Storage)xmlserializer.Deserialize(fstream);
                    }
                }
                return storage;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return storage;
            }
        }

        private bool SerializtionWithExchengeFile(string path, Storage база)
        {
            try
            {
                using (Stream fstream = new FileStream(path, FileMode.Create))
                {
                    XmlSerializer xmlserializer = new XmlSerializer(typeof(Storage), new Type[] { typeof(List<Person>) });

                    xmlserializer.Serialize(fstream, база);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void AddPerson(Person p)
        {
                storage = DesirializXML("Serialization_XML.xml");
                
                storage.L.Add(p);

                SerializtionWithExchengeFile("Serialization_XML.xml", storage);
        }

        public void RemovePerson(string name)
        {
                storage = DesirializXML("Serialization_XML.xml");
                
                for (int i = 0; i < storage.L.Count; i++)
                {
                    if (storage.L.ElementAt(i).Name == name)
                    {
                        storage.L.RemoveAt(i);
                        i--;
                    }
                }

                SerializtionWithExchengeFile("Serialization_XML.xml", storage);
        }

        public void InsertPerson(int index, Person p)
        {
                storage = DesirializXML("Serialization_XML.xml");

                storage.L.Insert(index, p);

                SerializtionWithExchengeFile("Serialization_XML.xml", storage);
        }

        public List<Person> GetAllPerson()
        {
                 storage = DesirializXML("Serialization_XML.xml");

                return storage.L.Count == 0 ? new List<Person>() : storage.L;
        }

        public Person GetPersonByIndex(int i)
        {
            storage = DesirializXML("Serialization_XML.xml");

            return storage.L.Count == 0 ? null : storage.L[i];
        }

        public int Count()
        {
            storage = DesirializXML("Serialization_XML.xml");

            return storage.L.Count;
            
        }

        public void Clear()
        {
            if (File.Exists("Serialization_XML.xml"))
            {
                File.Delete("Serialization_XML.xml");
            }
        }
    }
}
