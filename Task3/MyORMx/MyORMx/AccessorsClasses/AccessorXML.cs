using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using MyORMx.DataClasses;

namespace MyORMx.AccessorsClasses
{
    public class AccessorXml:IAccessor
    {
        private Storage _storage = new Storage();

        private Storage DesirializXML(string path)
        {
            /*ЕСЛИ XML файл существует , ТО десериализовать его и возврат объекта с данными ИНАЧЕ возврат пустой базы*/

            
            var storage = new Storage();
            try
            {
                var xmlserializer = new XmlSerializer(typeof(Storage), new[] { typeof(List<Person>) });

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

        private void SerializtionWithExchengeFile(string path, Storage база)
        {
            try
            {
                using (Stream fstream = new FileStream(path, FileMode.Create))
                {
                    var xmlserializer = new XmlSerializer(typeof(Storage), new[] { typeof(List<Person>) });

                    xmlserializer.Serialize(fstream, база);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool AddPerson(Person p)
        {
            try
            {
                _storage = DesirializXML("Serialization_XML.xml");
                
                _storage.L.Add(p);

                SerializtionWithExchengeFile("Serialization_XML.xml", _storage);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool RemovePerson(string name)
        {
            try
            {
                _storage = DesirializXML("Serialization_XML.xml");
                
                for (int i = 0; i < _storage.L.Count; i++)
                {
                    if (_storage.L.ElementAt(i).Name == name)
                    {
                        _storage.L.RemoveAt(i);
                        i--;
                    }
                }

                SerializtionWithExchengeFile("Serialization_XML.xml", _storage);

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool InsertPerson(int index, Person p)
        {
            try
            {
                _storage = DesirializXML("Serialization_XML.xml");

                _storage.L.Insert(index, p);

                SerializtionWithExchengeFile("Serialization_XML.xml", _storage);
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<Person> GetAllPerson()
        {
            try
            {
                 _storage = DesirializXML("Serialization_XML.xml");

                if (_storage.L.Count == 0)
                {
                    Console.WriteLine("в базе нет записей");
                    return new List<Person>();
                }
                return _storage.L;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Person>();
            }
        }

        public Person GetPersonByIndex(int i)
        {
            _storage = DesirializXML("Serialization_XML.xml");

            if (_storage.L.Count == 0)
            {
                return null;
            }
            try
            {
                return _storage.L[i];
            }
            catch 
            {
                return new Person { Name = "такого индекса нет" };
            }
        }

        public int Count()
        {
            _storage = DesirializXML("Serialization_XML.xml");

            return _storage.L.Count;
            
        }

        public bool Clear()
        {
            if (File.Exists("Serialization_XML.xml"))
            {
                File.Delete("Serialization_XML.xml");
            }
            return true;
        }
    }
}
