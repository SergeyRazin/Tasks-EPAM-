using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MyClassLibrary.DataClasses;
using MyClassLibrary.Interfaces;

namespace MyClassLibrary.Accessors
{
    public class DALxml:IDAL
    {
        public List<Oilfield> Desirializ(string path)
        {
            /*ЕСЛИ XML файл существует , ТО десериализовать его и возврат объекта с данными ИНАЧЕ возврат пустой лист */


            List<Oilfield> temp = new List<Oilfield>();

            XmlSerializer xmlserializer = new XmlSerializer(typeof (List<Oilfield>), new Type[] {typeof (Oilfield)});

            if (File.Exists(path))
            {
                using (Stream fstream = File.OpenRead(path))
                {
                    temp = (List<Oilfield>) xmlserializer.Deserialize(fstream);
                }
            }
            return temp;
        }

        public void SerializtionWithExchengeFile(string path, List<Oilfield> oilfields0)
        {
            using (Stream fstream = new FileStream(path, FileMode.Create))
            {
                XmlSerializer xmlserializer = new XmlSerializer(typeof (List<Oilfield>), new Type[] {typeof (Oilfield)});

                xmlserializer.Serialize(fstream, oilfields0);
            }
        }
    }
}
