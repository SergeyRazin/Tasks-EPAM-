using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Xml.Serialization;


namespace MyORM
{
    class AccessorSerializationXML : IAccessor
    {
        private Хранилище база = new Хранилище();

        private Хранилище ДесериализоватьXMLФайлЕслиОнСуществует(string path)
        {
            /*ЕСЛИ бинарный файл существует , ТО десериализовать его и возврат объекта с данными ИНАЧЕ возврат пустой базы*/

            //создать объект базы
            Хранилище база = new Хранилище();
            try
            {
                //создать бинарный форматтер
                XmlSerializer xmlserializer = new XmlSerializer(typeof(Хранилище), new Type[] { typeof(List<Person>) });

                //ЕСЛИ есть файл с объектом ТОГДА
                if (File.Exists(path))
                {
                    //получить этот объект (десериализовать его)
                    using (Stream fstream = File.OpenRead(path))
                    {
                        база = (Хранилище)xmlserializer.Deserialize(fstream);
                    }
                }
                return база;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return база;
            }
        }

        private bool СериализоватьБазуСЗаменойСтарогоФайла(string path, Хранилище база)
        {
            try
            {
                using (Stream fstream = new FileStream(path, FileMode.Create))
                {
                    //создать бинарный форматтер
                    XmlSerializer xmlserializer = new XmlSerializer(typeof(Хранилище), new Type[] { typeof(List<Person>) });

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

        public bool AddPerson(Person p)
        {
            try
            {
                база = ДесериализоватьXMLФайлЕслиОнСуществует("Serialization_XML.xml");

                //добавить в базу персону р
                база.L.Add(p);

                //сериализовать базу с заменой старого файла
                СериализоватьБазуСЗаменойСтарогоФайла("Serialization_XML.xml", база);
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
                //десериализовать объект
                база = ДесериализоватьXMLФайлЕслиОнСуществует("Serialization_XML.xml");

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
                СериализоватьБазуСЗаменойСтарогоФайла("Serialization_XML.xml", база);

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
                //десериализовать объект
                база = ДесериализоватьXMLФайлЕслиОнСуществует("Serialization_XML.xml");

                //вставить персону по индексу
                база.L.Insert(index, p);

                //сериализовать объект с заменой файла
                СериализоватьБазуСЗаменойСтарогоФайла("Serialization_XML.xml", база);

                //возврат true
                return true;
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool ShowAll()
        {
            try
            {
                Хранилище база = ДесериализоватьXMLФайлЕслиОнСуществует("Serialization_XML.xml");

                if (база.L.Count == 0)
                {
                    Console.WriteLine("в базе нет записей");
                    return false;
                }
                else
                {
                    foreach (Person i in база.L)
                    {
                        Console.WriteLine(i.Name + "  " + i.Age + " XML файл");
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

        public bool Clear()
        {
            try
            {
                File.Delete("Serialization_XML.xml");
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
