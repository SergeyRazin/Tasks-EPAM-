using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyClassLibrary.DataClasses;
using MyClassLibrary.Interfaces;
using MyClassLibrary.MyExceptions;

namespace MyClassLibrary.Accessors
{
    public class AccessorXML:IAccessor
    {
        public IDAL Dal = new DALxml();
        public MyXPath xpath = new MyXPath();

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

        public void AddOilfield(Oilfield oilfield0)
        {
            ////десериализовать объект(лист)
            //var temp = _dal.Desirializ("SerializationXML.XML");

            //используем xpath (если файл существуе, то получаем из него лист месторождений иначе пустой лист местор.)
            var temp = xpath.getAllOil();
            //var temp = File.Exists("SerializationXML.XML") ? 
            //                            xpath.getAllOil() : 
            //                            new List<Oilfield>();

            //првоерить есть ли уже такое месторождение(если есть то выкинуть исключение)
            if (checkOil(temp, oilfield0.Name))
            {
                throw new MyOverlapNameException("такое месторождение уже есть в списке");
            }

            //добавить месторождение в лист
            temp.Add(oilfield0);

            //сериализовать объект с заменой
            Dal.SerializtionWithExchengeFile("SerializationXML.XML", temp);
        }

        public void RemoveOilfield(int index0)
        {
            //десериализовать объект(лист)
            //var temp = _dal.Desirializ("SerializationXML.XML");

            //используем xpath
            var temp = xpath.getAllOil();

            //проверить есть ли месторождение с таким индексом
            if (temp.Count <= index0) throw new MyOilfieldNameNotFoundException("Месторождения с таким индексом нет");

            //удалить месторождение из объекта (лист)
            temp.RemoveAt(index0);

            //сериализовать объект с заменой
            Dal.SerializtionWithExchengeFile("SerializationXML.XML", temp);
        }

        public void AddWell(Well well0, string oilfieldName0)
        {
            //десериализовать объект (лист)
            //var temp = _dal.Desirializ("SerializationXML.XML");

            //используем xpath (если файл существуе, то получаем из него лист месторождений иначе пустой лист местор.)
            //var temp = File.Exists("SerializationXML.XML") ?
            //                            xpath.getAllOil() :
            //                            new List<Oilfield>();
            var temp = xpath.getAllOil();

            //проверить есть ли такое месторождение (если месторождения с таким именем нет-выбрасить исключение)
            if (checkOil(temp, oilfieldName0) == false)
                throw new MyOverlapNameException("Месторождения с таким именем нет");

            //найти индекс месторождения по имени
            var idoil = getIndexOil(temp, oilfieldName0);

            //добавить скважину в месторождение
            temp[idoil].Wells.Add(well0);

            //сериализовать объект с заменой
            Dal.SerializtionWithExchengeFile("SerializationXML.XML", temp);
        }

        public void RemoveWell(int numberWell0, string oilfieldName0)
        {
            //десериализовать объект (лист)
            //var temp = _dal.Desirializ("SerializationXML.XML");

            //используем xpath
            var temp = xpath.getAllOil();

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
            Dal.SerializtionWithExchengeFile("SerializationXML.XML", temp);
        }

        public void UpdateOilfield(int index0, Oilfield oilfield0)
        {
            //десериализовать объект 
            //var temp = _dal.Desirializ("SerializationXML.XML");

            //используем xpath
            var temp = xpath.getAllOil();

            //првоерить есть ли уже такое месторождение(если есть то выкинуть исключение)
            if (checkOil(temp, oilfield0.Name))
            {
                throw new MyOverlapNameException("такое месторождение уже есть в списке");
            }

            //проверить есть ли месторождение с таким индексом(если нет то выкинуть исключение)
            if (temp.Count <= index0)
                throw new MyOilfieldNameNotFoundException("месторождения с таким индексом нет");

            //новому месторождению дать скважины старого месторождения
            oilfield0.Wells = temp[index0].Wells;

            //изменить данные месторождения на новые
            temp[index0].Name = oilfield0.Name;
            temp[index0].Index = oilfield0.Index;
            temp[index0].OilReserves = oilfield0.OilReserves;

            //сериализовать месторождение назад
            Dal.SerializtionWithExchengeFile("SerializationXML.XML", temp);
        }

        public List<Oilfield> GetAllOilfield()
        {

            //десериализовать объект
            //var temp = _dal.Desirializ("SerializationXML.XML");//старый способ

            //используем xpath
            var temp = xpath.getAllOil();
            

            //для кажлого месторождения задать index
            for (int i = 0; i < temp.Count; i++)
            {
                temp[i].Index = i;
            }

            //вернуть объект(лист)
            return temp;
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
            //если файл существует
            if (File.Exists("SerializationXML.XML"))
            {
                //просто удалить файл
                File.Delete("SerializationXML.XML");
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
