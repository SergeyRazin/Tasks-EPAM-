using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyClassLibrary.Interfaces;
using MyClassLibrary.DataClasses;
using MyClassLibrary.MyExceptions;

namespace MyClassLibrary.Accessors
{
    public class AccessorBinary:IAccessor
    {
        public IDAL Dal = new DALbinary();

        #region приватные методы-------↓-----------------------

        //- метод найти индекс месторождения по имени
        /// <summary>
        /// найти индекс месторождения по имени
        /// </summary>
        /// <param name="listOil0"></param>
        /// <param name="name0"></param>
        /// <returns>индекс месторождения</returns>
        /// <exception cref="MyOilfieldNameNotFoundException">1. если такого месторождения нет</exception>
        private int getIndexOil(List<Oilfield> listOil0,string name0)
        {
            //ЦИКЛ пробежаться по всем месторождениям 
            for(int i=0;i<listOil0.Count;i++)
            {
                //ЕСЛИ название совпадает ТОГДА
                if (listOil0[i].Name == name0)
                {
                    //возврат индекс этого месторождения
                    return i;
                }
            }
            //ЕСЛИ не нашли месторождение, то выброс исключения
            throw new MyOilfieldNameNotFoundException("такого месторождения нет");
        }

        //- метод проверить есть ли такое месторождение в листе
        /// <summary>
        /// проверить есть ли такое месторождение в листе
        /// </summary>
        /// <param name="listOil0"></param>
        /// <param name="name0"></param>
        /// <returns></returns>
        private bool checkOil(List<Oilfield>listOil0, string name0)
        {
            //ЦИКЛ пробежаться по всем месторождениям в листе , проверяя имена
            for (int i = 0; i < listOil0.Count; i++)
            {
                //ЕСЛИ имя совпадает ТОГДА
                if (listOil0[i].Name == name0)
                {
                    //возврат true
                    return true;
                }
                //ЕСЛИ ВСЕ
            }
            //возврат false
            return false;
        }

        //- найти индекс скважины по номеру
        private int getIndexWellByNumber(int numberWell0, List<Oilfield> list0, int idoil)
        {
            for (int i = 0; i < list0[idoil].Wells.Count; i++)
            {
                if (list0[idoil].Wells[i].Number == numberWell0)
                {
                    return i;
                }
            }
            throw new MyWellNotFoundException("Скважины с таким номером нет.");
        }

        #endregion приватные методы----↑----------------------

        /// <summary>
        /// добавить месторождение
        /// </summary>
        /// <param name="oilfield0"></param>
        /// <exception cref="MyOverlapNameException">1. месторождение уже есть в списке</exception>
        public void AddOilfield(Oilfield oilfield0)
        {
            
            //десериализовать объект(лист)
            var temp = Dal.Desirializ("SerializationBinary.dat");

            //првоерить есть ли уже такое месторождение(если есть то выкинуть исключение)
            if (checkOil(temp,oilfield0.Name))
            {
                throw new MyOverlapNameException("такое месторождение уже есть в списке");
            }

            //добавить месторождение в лист
            temp.Add(oilfield0);

            //сериализовать объект с заменой
            Dal.SerializtionWithExchengeFile("SerializationBinary.dat", temp);

        }

        /// <summary>
        /// удалить месторождение
        /// </summary>
        /// <param name="index0"></param>
        /// <exception cref="MyOilfieldNameNotFoundException">1. Месторождения с таким индексом нет</exception>
        public void RemoveOilfield(int index0)
        {
            //десериализовать объект(лист)
            var temp = Dal.Desirializ("SerializationBinary.dat");

            //проверить есть ли месторождение с таким индексом
            if (temp.Count <= index0)throw new MyOilfieldNameNotFoundException("Месторождения с таким индексом нет");
           
            //удалить месторождение из объекта (лист)
            temp.RemoveAt(index0);

            //сериализовать объект с заменой
            Dal.SerializtionWithExchengeFile("SerializationBinary.dat",temp);
        }

        /// <summary>
        /// добавить скважину
        /// </summary>
        /// <param name="well0"></param>
        /// <param name="oilfieldName0"></param>
        /// <exception cref="MyOverlapNameException">1. Месторождение с таким именени уже есть</exception>
        public void AddWell(Well well0, string oilfieldName0)
        {
            //десериализовать объект (лист)
            var temp = Dal.Desirializ("SerializationBinary.dat");

            //проверить есть ли такое месторождение (если месторождения с таким именем нет-выбрасить исключение)
            if (checkOil(temp,oilfieldName0) == false)
                throw new MyOverlapNameException("Месторождения с таким имененем нет.");

            //найти индекс месторождения по имени
            var idoil = getIndexOil(temp,oilfieldName0);

            //добавить скважину в месторождение
            temp[idoil].Wells.Add(well0);

            //сериализовать объект с заменой
            Dal.SerializtionWithExchengeFile("SerializationBinary.dat", temp);
        }

        /// <summary>
        /// удалить скважину
        /// </summary>
        /// <param name="indexWell0"></param>
        /// <param name="oilfieldName0"></param>
        /// <exception cref="MyOilfieldNameNotFoundException">1. Если месторождения с таким именем нет</exception>
        /// <exception cref="MyWellNotFoundException">2. Если cкважины с таким именем нет</exception>
        public void RemoveWell(int numberWell0, string oilfieldName0)
        {
            //десериализовать объект (лист)
            var temp = Dal.Desirializ("SerializationBinary.dat");

            //проверить есть ли такое месторождение (если месторождения с таким именем нет-выбрасить исключение)
            if (checkOil(temp, oilfieldName0) == false) throw new MyOilfieldNameNotFoundException("Месторождения с таким именем нет.");

            //найти индекс месторождения по имени
            var idoil = getIndexOil(temp, oilfieldName0);

            //проверить есть ли скважина с таким индексом в месторождении(если нет то выбросить исключение)
            //и найти индекс скважины по номеру
            var index = getIndexWellByNumber(numberWell0, temp, idoil);
            
            //удалить скважину из месторождения
            for (int i = 0; i < temp[idoil].Wells.Count; i++)
            {
                if (temp[idoil].Wells[i].Number == numberWell0)
                {
                    temp[idoil].Wells.RemoveAt(index);
                    i--;
                }

            }
            

            //сериализовать объект с заменой
            Dal.SerializtionWithExchengeFile("SerializationBinary.dat", temp);
        }

        /// <summary>
        /// 1. обновить месторождение
        /// </summary>
        /// <param name="index0">индекс месторождения</param>
        /// <param name="oilfield0">новое месторождение</param>
        /// <exception cref="MyOilfieldNameNotFoundException">1. месторождения с таким индексом нет</exception>
        public void UpdateOilfield(int index0, Oilfield oilfield0)
        {
            //десериализовать объект 
            var temp = Dal.Desirializ("SerializationBinary.dat");

            //првоерить есть ли уже такое месторождение(если есть то выкинуть исключение)
            if (checkOil(temp, oilfield0.Name))
            {
                throw new MyOverlapNameException("такое месторождение уже есть в списке");
            }

            //проверить есть ли месторождение с таким индексом(если нет то выкинуть исключение)
            if(temp.Count<=index0)
                throw new MyOilfieldNameNotFoundException("месторождения с таким индексом нет");

            //новому месторождению дать скважины старого месторождения
            oilfield0.Wells = temp[index0].Wells;

            //изменить данные месторождения на новые
            temp[index0].Name = oilfield0.Name;
            temp[index0].Index = oilfield0.Index;
            temp[index0].OilReserves = oilfield0.OilReserves;
             

            //сериализовать месторождение назад
            Dal.SerializtionWithExchengeFile("SerializationBinary.dat", temp);
        }

        /// <summary>
        /// получить лист всех месторождений
        /// </summary>
        /// <returns></returns>
        public List<Oilfield> GetAllOilfield()
        {
            //десериализовать объект
            var temp = Dal.Desirializ("SerializationBinary.dat");

            //для кажлого месторождения задать index
            for(int i=0;i<temp.Count;i++)
            {
                temp[i].Index = i;
            }

            //вернуть объект(лист)
            return temp;
        }

        /// <summary>
        /// получить месторождение по индексу
        /// </summary>
        /// <param name="index0"></param>
        /// <returns></returns>
        /// <exception cref="MyOilfieldNameNotFoundException">1. если месторождения с таким индексом нет</exception>
        public Oilfield GetOilfieldByIndex(int index0)
        {
            //получить все месторождения
            var temp = GetAllOilfield();

            //проверить есть ли месторождение с таким индексом
            if (temp.Count <= index0)
                throw new MyOilfieldNameNotFoundException("месторождения с таким индексом нет");

            return temp[index0];
        }

        /// <summary>
        /// получить количество месторждений
        /// </summary>
        /// <returns></returns>
        public int CountOilfield()
        {
            var temp = GetAllOilfield();
            return temp.Count;
        }

        /// <summary>
        /// получить количество скважин
        /// </summary>
        /// <returns></returns>
        public int CountWells()
        {
            //получить все месторождения со скважинами
            var temp = GetAllOilfield();

            return temp.Sum(i => i.Wells.Count);
        }

        /// <summary>
        /// получить количество скважин в месторождении с индексом
        /// </summary>
        /// <param name="indexOilfield0"></param>
        /// <returns>количество скважин в месторождении</returns>
        /// <exception cref="MyOilfieldNameNotFoundException">1. если месторождения с таким индексом нет</exception>
        public int CountWellsInOilfield(int indexOilfield0)
        {
            //получить все месторождения
            var temp = GetAllOilfield();

            //проверить есть ли месторождение с таким индексом
            if (temp.Count <= indexOilfield0)
                throw new MyOilfieldNameNotFoundException("месторождения с таким индексом нет");


            return temp[indexOilfield0].Wells.Count;
        }

        /// <summary>
        /// удалить все данные
        /// </summary>
        public void Clear()
        {
            //если файл существует
            if (File.Exists("SerializationBinary.dat"))
            {
                //просто удалить файл
                File.Delete("SerializationBinary.dat");
            }
        }


        public string GetNameByIndex(int index0)
        {
            //получить все месторождения
            var temp = GetAllOilfield();

            //если  месторождения с таким индексом нет, выбросить исключение
            if (temp.Count < index0) 
                throw new MyOilfieldNameNotFoundException("Месторождения с таким индексом нет.");

            return temp[index0].Name;
        }
    }
}
