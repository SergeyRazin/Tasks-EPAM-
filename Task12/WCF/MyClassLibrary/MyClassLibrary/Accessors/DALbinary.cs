using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.DataClasses;
using MyClassLibrary.Interfaces;

namespace MyClassLibrary.Accessors
{
    public class DALbinary:IDAL
    {
        /// <summary>
        /// 1. метод если бинарный файл существует , ТО десериализовать его и возврат объекта с данными ИНАЧЕ возврат пустого листа месторождений
        /// </summary>
        /// <param name="path0">относительный путь к файлу</param>
        /// <returns></returns>
        public List<Oilfield> Desirializ(string path0)
        {
            var temp = new List<Oilfield>();
            var bi = new BinaryFormatter();

            if (File.Exists(path0))
            {
                using (Stream fstream = File.OpenRead(path0))
                {
                    temp = (List<Oilfield>)bi.Deserialize(fstream);
                }
            }
            return temp;
        }

        /// <summary>
        ///  метод сериализовать объект месторождения
        /// </summary>
        /// <param name="path0">относительный путь к файлу</param>
        /// <param name="oil0">лист месторождений</param>
        public void SerializtionWithExchengeFile(string path0, List<Oilfield> oil0)
        {
            using (Stream fstream = new FileStream(path0, FileMode.Create))
            {
                BinaryFormatter bi = new BinaryFormatter();

                bi.Serialize(fstream, oil0);
            }
        }

        
    }
}
