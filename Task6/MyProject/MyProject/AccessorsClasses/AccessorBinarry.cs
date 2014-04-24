using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using MyProject.DataClasses;
using MyProject.Interfaces;

namespace MyProject.AccessorsClasses
{
    public class AccessorBinarry:IAccessor
    {
        Storage _storage = new Storage();

        #region ПРИВАТНЫЕ МЕТДЫ

        private Storage DeserializationBinarry(string path)
        {
            /*ЕСЛИ бинарный файл существует , ТО десериализовать его и возврат объекта с данными ИНАЧЕ возврат пустой базы*/

            Storage stor = new Storage();
            BinaryFormatter bi = new BinaryFormatter();

            if (File.Exists(path))
            {
                using (Stream fstream = File.OpenRead(path))
                {
                    stor = (Storage)bi.Deserialize(fstream);
                }
            }
            return stor;
        }

        private void SerializationWithExchangeOldFile(string path, Storage stor)
        {
            using (Stream fstream = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter bi = new BinaryFormatter();

                bi.Serialize(fstream, stor);
            }
        }

        #endregion

        public void AddPerson(Person p0)
        {
            _storage = DeserializationBinarry("SerializationBinary.dat");

            //добавить в базу персону р
            _storage.L.Add(p0);

            //сериализовать базу с заменой старого файла
            SerializationWithExchangeOldFile("SerializationBinary.dat", _storage);
        }

        public void RemovePerson(int index0)
        {
            //десериализуем файл
            _storage = DeserializationBinarry("SerializationBinary.dat");

            //удаляем персону по индексу
            _storage.L.RemoveAt(index0);

            //сериализовать  в файл с заменой
            SerializationWithExchangeOldFile("SerializationBinary.dat", _storage);
        }

        public void InsertPerson(int index0, Person p0)
        {
            _storage = DeserializationBinarry("SerializationBinary.dat");

            _storage.L.Insert(index0, p0);

            SerializationWithExchangeOldFile("SerializationBinary.dat", _storage);
        }

        public List<Person> GetAllPerson()
        {
            _storage = DeserializationBinarry("SerializationBinary.dat");

            if(_storage.L.Count == 0)return new List<Person>();

            for (int i = 0; i < _storage.L.Count; i++)
            {
                _storage.L[i].ID = i;
            }

            return _storage.L;

        }

        public Person GetPersonByIndex(int index0)
        {
            _storage = DeserializationBinarry("SerializationBinary.dat");
            return _storage.L.Count == 0 ? null : _storage.L[index0];
        }

        public int Count()
        {
            _storage = DeserializationBinarry("SerializationBinary.dat");
            return _storage.L.Count;
        }

        public void Clear()
        {
            //просто удалить сам бинарный файл
            File.Delete("SerializationBinary.dat");
        }

        public void UpdatePerson(int index0, string name0, int age0,string phone0)
        {
            _storage = DeserializationBinarry("SerializationBinary.dat");
            _storage.L[index0].Name = name0;
            _storage.L[index0].Age = age0;
            _storage.L[index0].Phone = phone0;
            SerializationWithExchangeOldFile("SerializationBinary.dat", _storage);

        }
    }
}
