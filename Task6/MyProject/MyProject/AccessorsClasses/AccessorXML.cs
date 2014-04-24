using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MyProject.DataClasses;
using MyProject.Interfaces;

namespace MyProject.AccessorsClasses
{
    public class AccessorXML : IAccessor
    {
        private Storage _storage = new Storage();

        #region ПРИВАТНЫЕ МЕТОДЫ

        private Storage DesirializXML(string path)
        {
            /*ЕСЛИ XML файл существует , ТО десериализовать его и возврат объекта с данными ИНАЧЕ возврат пустой базы*/


            Storage storage = new Storage();

            XmlSerializer xmlserializer = new XmlSerializer(typeof (Storage), new Type[] {typeof (List<Person>)});

            if (File.Exists(path))
            {
                using (Stream fstream = File.OpenRead(path))
                {
                    storage = (Storage) xmlserializer.Deserialize(fstream);
                }
            }
            return storage;
        }

        private bool SerializtionWithExchengeFile(string path, Storage база)
        {
            using (Stream fstream = new FileStream(path, FileMode.Create))
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof (Storage), new Type[] {typeof (List<Person>)});

                xmlserializer.Serialize(fstream, база);
            }
            return true;
        }

        #endregion


        public void AddPerson(Person p0)
        {
            _storage = DesirializXML("Serialization_XML.xml");

            _storage.L.Add(p0);

            SerializtionWithExchengeFile("Serialization_XML.xml", _storage);
        }

        public void RemovePerson(int index0)
        {
            _storage = DesirializXML("Serialization_XML.xml");

            _storage.L.RemoveAt(index0);

            SerializtionWithExchengeFile("Serialization_XML.xml", _storage);
        }

        public void InsertPerson(int index0, Person p0)
        {
            _storage = DesirializXML("Serialization_XML.xml");

            _storage.L.Insert(index0, p0);

            SerializtionWithExchengeFile("Serialization_XML.xml", _storage);
        }

        public List<Person> GetAllPerson()
        {
            _storage = DesirializXML("Serialization_XML.xml");

            for (int i = 0; i < _storage.L.Count; i++)
            {
                _storage.L[i].ID = i;
            }

            return _storage.L.Count == 0 ? new List<Person>() : _storage.L;
        }

        public Person GetPersonByIndex(int index0)
        {
            _storage = DesirializXML("Serialization_XML.xml");

            return _storage.L.Count == 0 ? null : _storage.L[index0]; 
        }

        public int Count()
        {
            _storage = DesirializXML("Serialization_XML.xml");

            return _storage.L.Count;
        }

        public void Clear()
        {
            //просто удаляем файл
            if (File.Exists("Serialization_XML.xml"))
            {
                File.Delete("Serialization_XML.xml");
            }
        }

        public void UpdatePerson(int index0, string name0, int age0,string phone0)
        {
            _storage = DesirializXML("Serialization_XML.xml");
            _storage.L[index0].Name = name0;
            _storage.L[index0].Age = age0;
            _storage.L[index0].Phone = phone0;

            SerializtionWithExchengeFile("Serialization_XML.xml", _storage);
        }
    }
}
