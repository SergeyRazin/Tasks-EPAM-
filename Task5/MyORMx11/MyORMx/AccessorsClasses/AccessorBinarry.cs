using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace MyORMx.AccessorsClasses
{
    public class AccessorBinarry:IAccessor
    {
        Storage storage = new Storage();

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


        public void AddPerson(Person p)
        {
                storage = DeserializationBinarry("SerializationBinary.dat");

                //добавить в базу персону р
                storage.L.Add(p);

                //сериализовать базу с заменой старого файла
                SerializationWithExchangeOldFile("SerializationBinary.dat", storage);
        }

        public void RemovePerson(string name)
        {
                storage = DeserializationBinarry("SerializationBinary.dat");

                for (int i = 0; i < storage.L.Count; i++)
                {
                    if (storage.L.ElementAt(i).Name == name)
                    {
                        storage.L.RemoveAt(i);
                        i--;
                    }
                }

                //сериализовать базу в файл с заменой
                SerializationWithExchangeOldFile("SerializationBinary.dat", storage);
        }

        public void InsertPerson(int index, Person p)
        {
            storage = DeserializationBinarry("SerializationBinary.dat");

            storage.L.Insert(index, p);

            SerializationWithExchangeOldFile("SerializationBinary.dat", storage);
        }

        public List<Person> GetAllPerson()
        {
                storage = DeserializationBinarry("SerializationBinary.dat");

            return storage.L.Count == 0 ? new List<Person>() : storage.L;
        }

        public Person GetPersonByIndex(int i)
        {
            storage = DeserializationBinarry("SerializationBinary.dat");
            return storage.L.Count == 0 ? null : storage.L[i];
        }

        public int Count()
        {
            storage = DeserializationBinarry("SerializationBinary.dat");
            return storage.L.Count;
        }

        public void Clear()
        {
            //просто удалить сам бинарный файл
            File.Delete("SerializationBinary.dat");
        }
    }
}
