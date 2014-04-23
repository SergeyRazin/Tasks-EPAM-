using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MyORMx.DataClasses;


namespace MyORMx.AccessorsClasses
{
    public sealed class AccessorBinarry:IAccessor
    {
        Storage _storage = new Storage();

        private Storage DeserializationBinarry(string path)
        {
            /*ЕСЛИ бинарный файл существует , ТО десериализовать его и возврат объекта с данными ИНАЧЕ возврат пустой базы*/

            
            var stor = new Storage();
            var bi = new BinaryFormatter();

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
                var bi = new BinaryFormatter();

                bi.Serialize(fstream, stor);
            }
        }


        public bool AddPerson(Person p)
        {
            try
            {
                _storage = DeserializationBinarry("SerializationBinary.dat");

                //добавить в базу персону р
                _storage.L.Add(p);

                //сериализовать базу с заменой старого файла
                SerializationWithExchangeOldFile("SerializationBinary.dat", _storage);
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
                _storage = DeserializationBinarry("SerializationBinary.dat");

                for (int i = 0; i < _storage.L.Count; i++)
                {
                    if (_storage.L.ElementAt(i).Name == name)
                    {
                        _storage.L.RemoveAt(i);
                        i--;
                    }
                }

                //сериализовать базу в файл с заменой
                SerializationWithExchangeOldFile("SerializationBinary.dat", _storage);

                //возврат true
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
                _storage = DeserializationBinarry("SerializationBinary.dat");
                
                _storage.L.Insert(index, p);
                
                SerializationWithExchangeOldFile("SerializationBinary.dat", _storage);
                
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
                _storage = DeserializationBinarry("SerializationBinary.dat");

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
            _storage = DeserializationBinarry("SerializationBinary.dat");
            if (_storage.L.Count == 0)
            {
                Console.WriteLine("в базе нет записей");
                return null;
            }
            try
            {
                return _storage.L[i];
            }
            catch
            {
                return new Person { Name = "такого индекса нет!" };
            }
        }

        public int Count()
        {
            _storage = DeserializationBinarry("SerializationBinary.dat");
            return _storage.L.Count;
        }

        public bool Clear()
        {
            try
            {
                //просто удалить сам бинарный файл
                File.Delete("SerializationBinary.dat");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
