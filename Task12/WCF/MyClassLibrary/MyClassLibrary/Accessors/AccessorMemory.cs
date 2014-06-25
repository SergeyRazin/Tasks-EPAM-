using System.Collections.Generic;
using System.Linq;
using MyClassLibrary.DataClasses;
using MyClassLibrary.Interfaces;
using MyClassLibrary.MyExceptions;

namespace MyClassLibrary.Accessors
{
    public class AccessorMemory:IAccessor
    {
        private List<Oilfield> oilList= new List<Oilfield>();

        #region приватные методы-------↓-----------------------

        //- метод найти индекс месторождения по имени
        /// <summary>
        /// найти индекс месторождения по имени
        /// </summary>
        /// <param name="listOil0"></param>
        /// <param name="name0"></param>
        /// <returns>индекс месторождения</returns>
        /// <exception cref="MyOilfieldNameNotFoundException">1. если такого месторождения нет</exception>
        private int getIndexOil(List<Oilfield> listOil0, string name0)
        {
            //ЦИКЛ пробежаться по всем месторождениям 
            for (int i = 0; i < listOil0.Count; i++)
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
        private bool checkOil(List<Oilfield> listOil0, string name0)
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

        #endregion приватные методы----↑----------------------

        public void AddOilfield(Oilfield oilfield0)
        {
            oilList.Add(oilfield0);
        }

        public void RemoveOilfield(int index0)
        {
            //проверить есть ли месторождение с таким индексом
            if(oilList.Count<=index0)
                throw new MyOilfieldNameNotFoundException("месторождения с таким индексом нет");

            oilList.RemoveAt(index0);
        }

        public void AddWell(Well well0, string oilfieldName0)
        {
            //проверить есть ли такое месторождение в листе
            if (checkOil(oilList, oilfieldName0) == false)
                throw new MyOilfieldNameNotFoundException();

            //получить индекс месторождения по имени
            var id = getIndexOil(oilList, oilfieldName0);

            //добавить скважину
            oilList[id].Wells.Add(well0);

        }

        public void RemoveWell(int indexWell0, string oilfieldName0)
        {
            //проверить есть ли такое месторождение (если месторождения с таким именем нет-выбрасить исключение)
            if (checkOil(oilList, oilfieldName0) == false) throw new MyOilfieldNameNotFoundException("Месторождения с таким именем нет.");

            //найти индекс месторождения по имени
            var idoil = getIndexOil(oilList, oilfieldName0);

            //проверить есть ли скважина с таким индексом в месторождении(если нет то выбросить исключение)
            if (oilList[idoil].Wells.Count <= indexWell0)
            {
                throw new MyWellNotFoundException("Скважины с таким именем нет.");
            }

            //удалить скважину из месторождения
            oilList[idoil].Wells.RemoveAt(indexWell0);
        }

        public void UpdateOilfield(int index0, Oilfield oilfield0)
        {
            //проверить есть ли месторождение с таким индексом(если нет то выкинуть исключение)
            if (oilList.Count <= index0)
                throw new MyOilfieldNameNotFoundException("месторождения с таким индексом нет");

            //новому месторождению даем скважины старого месторождения
            oilfield0.Wells = oilList[index0].Wells;

            //изменить данные месторождения на новые
            oilList[index0].Name = oilfield0.Name;
            oilList[index0].Index = oilfield0.Index;
            oilList[index0].OilReserves = oilfield0.OilReserves;
        }

        public List<Oilfield> GetAllOilfield()
        {
            //для кажлого месторождения задать index
            for (int i = 0; i < oilList.Count; i++)
            {
                oilList[i].Index = i;
            }

            //вернуть объект(лист)
            return oilList;

        }

        public Oilfield GetOilfieldByIndex(int index0)
        {
            //получить все месторождения
            var temp = GetAllOilfield();

            //проверить есть ли месторождение с таким индексом
            if (temp.Count <= index0)
                throw new MyOilfieldNameNotFoundException("месторождения с таким индексом нет");

            return temp[index0];
        }

        public int CountOilfield()
        {
            var temp = GetAllOilfield();
            return temp.Count;
        }

        public int CountWells()
        {
            //получить все месторождения со скважинами
            var temp = GetAllOilfield();

            return temp.Sum(i => i.Wells.Count);
        }

        public int CountWellsInOilfield(int indexOilfield0)
        {
            //получить все месторождения
            var temp = GetAllOilfield();

            //проверить есть ли месторождение с таким индексом
            if (temp.Count <= indexOilfield0)
                throw new MyOilfieldNameNotFoundException("месторождения с таким индексом нет");


            return temp[indexOilfield0].Wells.Count;
        }

        public void Clear()
        {
            oilList.Clear();
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
