using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MyORM
{
    class AccessorSerializationBinary:IAccessor
    {
        private Хранилище ДесериализоватьБинарныйФайлЕслиОнСуществует(string path) 
        {
            /*ЕСЛИ бинарный файл существует , ТО десериализовать его и возврат объекта с данными ИНАЧЕ возврат пустой базы*/

            //создать объект базы
            Хранилище база = new Хранилище();

            //создать бинарный форматтер
            BinaryFormatter bi = new BinaryFormatter();

            //ЕСЛИ есть файл с объектом ТОГДА
            if (File.Exists(path))
            {
                //получить этот объект (десериализовать его)
                using (Stream fstream = File.OpenRead(path))
                {
                    база = (Хранилище)bi.Deserialize(fstream);
                }
            }
            return база;
        }

        private bool СериализоватьБазуСЗаменойСтарогоФайла(string path, Хранилище база) 
        {
            using (Stream fstream = new FileStream(path, FileMode.Create))
            {
                //создать бинарный форматтер
                BinaryFormatter bi = new BinaryFormatter();

                bi.Serialize(fstream, база);
            }
            return true;
        }

        private Хранилище база = new Хранилище();

        //МЕТОД добавить персону
        public bool AddPerson(Person p)
        {
            try
            {
                база = ДесериализоватьБинарныйФайлЕслиОнСуществует("SerializationBinary.dat");

                //добавить в базу персону р
                база.L.Add(p);

                //сериализовать базу с заменой старого файла
                СериализоватьБазуСЗаменойСтарогоФайла("SerializationBinary.dat", база);
                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //МЕТОД удалить всех персон по имени
        public bool RemovePerson(String name)
        {
            try
            {
                //десериализовать объект
                база = ДесериализоватьБинарныйФайлЕслиОнСуществует("SerializationBinary.dat");

                //найти и удалить ОДИН элемент с указанным имененм
                for (int i = 0; i < база.L.Count; i++)
                {
                    if (база.L.ElementAt(i).Name == name)
                    {
                        база.L.RemoveAt(i);
                        i--;
                    }
                }

                //сериализовать базу в файл с заменой
                СериализоватьБазуСЗаменойСтарогоФайла("SerializationBinary.dat", база);

                //возврат true
                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        //МЕТОД вставить персону по индексу
        public bool InsertPerson(int index, Person p)
        {
            try
            {
                //десериализовать объект
                база = ДесериализоватьБинарныйФайлЕслиОнСуществует("SerializationBinary.dat");

                //вставить персону по индексу
                база.L.Insert(index, p);

                //сериализовать объект с заменой файла
                СериализоватьБазуСЗаменойСтарогоФайла("SerializationBinary.dat", база);

                //возврат true
                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //МЕТОД показать всех персон
        public bool ShowAll()
        {
            try
            {
                Хранилище база = ДесериализоватьБинарныйФайлЕслиОнСуществует("SerializationBinary.dat");

                if (база.L.Count == 0)
                {
                    Console.WriteLine("в базе нет записей");
                    return false;
                }
                else
                {
                    foreach (Person i in база.L)
                    {
                        Console.WriteLine(i.Name + "  " + i.Age + " бинарный файл");
                    }
                    return true;
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return false;
            }

            
        }

        //МЕТОД удалить всех персон
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
