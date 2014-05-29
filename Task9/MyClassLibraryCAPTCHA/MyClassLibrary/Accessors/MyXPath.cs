using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.XPath;
using MyClassLibrary.DataClasses;

namespace MyClassLibrary.Accessors
{
    public class MyXPath
    {
        //приватные методы
        #region--------------↓--------↓------------------------------------

        //- получить список номеров скважин по названию месторождения
        private List<string> getListWellsNumber(string oilName0)
        {
            //создадим пустой лист строк
            List<string> list = new List<string>();

            //создаем xpath документ
            XPathDocument doc = new XPathDocument("SerializationXML.xml");

            //создаем навигатор
            XPathNavigator navigator = doc.CreateNavigator();

            //создадим строку запроса
            string strExcpression1 = string.Format(@".//Name[text()='{0}']/..//Number", oilName0);

            //сделаем запрос
            var x = navigator.Select(strExcpression1); 

            //пока есть записи в навигаторе
            while (x.MoveNext())
            {
                //добавить в лист значение узла (номер скважины)
                list.Add(x.Current.Value);
            }

            //возврат лист
            return list;
        }

        //- получить лист дебитов скважин по названию месторождения
        private List<int> getDebitsWells(string oilName0)
        {
            //созадть пустой лист
            List<int> list = new List<int>();

            //создать документ
            XPathDocument doc = new XPathDocument("SerializationXML.xml");

            //созадть навигатор
            var navigator = doc.CreateNavigator();

            //созадть строку команды
            string commandString = string.Format(@".//Name[text()='{0}']/..//Wells//Debit", oilName0);

            //выполнить команду
            var x = navigator.Select(commandString);

            while(x.MoveNext())
                list.Add(Convert.ToInt32(x.Current.Value));

            return list;
        }

        //- получить лист насосов скважин по названию месторождения
        private List<string> getPump(string oilName0)
        {
            //созадть пустой лист
            List<string> list = new List<string>();

            //созадть документ 
            XPathDocument doc = new XPathDocument("SerializationXML.xml");

            //создать навигатор
            var navigator = doc.CreateNavigator();

            //созадть строку команды
            string commandString = string.Format(@".//Name[text()='{0}']/..//Wells//Pump", oilName0);

            //выполнить команду
            var reader = navigator.Select(commandString);

            while (reader.MoveNext())
            {
                list.Add(reader.Current.Value);
            }

            return list;
        }

        //- получить лист строк названий месторождений
        private List<String> getOilNamesList()
        {
            //создаем пустой лист
            List<string> list = new List<string>();

            //создаем xpath документ
            XPathDocument doc = new XPathDocument("SerializationXML.xml");

            //создаем навигатор
            XPathNavigator navigator = doc.CreateNavigator();

            //создаем запрос
            string strExpression = string.Format(@".//Name");

            //выполним запрос
            var x = navigator.Select(strExpression);

            while (x.MoveNext())
            {
                list.Add(x.Current.Value);
            }
            return list;
        }

        //- получить лист строк запасов месторождений
        private List<string> getListResolve()
        {
            //создать пустой лист строк
            List<string> list = new List<string>();

            //создать документ 
            XPathDocument doc = new XPathDocument("SerializationXML.xml");

            //создать навигатор
            var navigator = doc.CreateNavigator();

            //созадать строку запроса
            string commandString = string.Format(@".//OilReserves");

            //выполнить запрос
            var iterator = navigator.Select(commandString);

            while (iterator.MoveNext())
            {
                list.Add(iterator.Current.Value);
            }
            return list;
        }

        //- проверить есть такое месторождение в xml?
        private  bool checkThatExistsOil(string oilName0)
        {
            //проверить есть ли файл вообще
            if (!File.Exists("SerializationXML.xml"))
            {
                Console.WriteLine("файла xml не существует!");
                return false;
            }

            //проверить есть такое месторождение в xml?
            DALxml dal = new DALxml();
            var allOils = dal.Desirializ("SerializationXML.xml");
            foreach (var i in allOils)
            {
                if (i.Name == oilName0)
                {
                    return true;
                }
            }
            return false;
        }

        //- поулчить запасы месторождения 
        private int getRezolve(string oilName0)
        {
            //создать xpath документ
            XPathDocument doc = new XPathDocument("SerializationXML.xml");

            //создать навигатор
            var navigator = doc.CreateNavigator();

            //создать строку запроса
            var strCommand = string.Format(@".//Name[text()='{0}']/..//OilReserves", oilName0);
            //string strExcpression1 = string.Format(@".//Name[text()='{0}']/..//Number", str0);

            //выполнить запрос
            var x = navigator.Select(strCommand);

            //если узел есть
            if (x.MoveNext())
            {
                return Convert.ToInt32(x.Current.Value);
            }

            throw new Exception("извлекаемых запасов нет.");
            
        }

        //- получить список полноценных скважин
        private List<Well> getListWells(string oilName0)
        {
            //созадть пустой лист скважин
            List<Well> list = new List<Well>();

            //получить лист номеров скважин
            var numbers = getListWellsNumber(oilName0);

            //получить лист дебитов скважин
            var debits = getDebitsWells(oilName0);

            //получить лист насосов скважин
            var pumps = getPump(oilName0);

            //првоерить длину листов с данными (она должна быть одинаковая)
            if (!(numbers.Count == debits.Count && debits.Count == pumps.Count))
            {
                throw new Exception("в листах с данными по скважинам разная длина.");
            }

            //цикл повторять сколько номеров скважин
            for (int i = 0; i < numbers.Count; i++)
            {
                //создать новую скважину
                var temp = new Well();
                //присвоить этой скважине инфу из 3 листов под одинаковым индексом
                temp.Number = Convert.ToInt32(numbers[i]);
                temp.Debit = Convert.ToInt32(debits[i]);
                temp.Pump = pumps[i];

                //добавить скважину в лист
                list.Add(temp);
            }
            return list;
        }

        #endregion приватные методы-----↑--------------------------------


        //получить месторождение со скважинами
        public virtual Oilfield getOil(string oilName0)
        {
           
            //првоерить существует месторождение или нет в xml
            if (!checkThatExistsOil(oilName0))
            {
                Console.WriteLine("Такого месторождения нет.");
                return null;
            }

            //создать месторождение temp
            var oil = new Oilfield();

            //получить название месторождения и засунуть его в temp
            oil.Name = oilName0;

            //получить запасы месторождения и засунуть его в темп
            oil.OilReserves = getRezolve(oilName0);

            //получить список скважин и сделать ссылку из темп на них
            oil.Wells = getListWells(oilName0);

            //вернуть темп
            return oil;
        }

        //получить все месторождения со скважинами
        public virtual List<Oilfield> getAllOil()
        {
            //создать пустой лист месторождений
            var list = new List<Oilfield>();

            //если файла не существует, то вернуть пустой лист месторождений
            if (!File.Exists("SerializationXML.XML"))
            {
                return list;
            }
            //получить лист строк с названиями
            var names = getOilNamesList();

            //получить лист  строк с запасами
            var resolv = getListResolve();

            //проверить одинаковой ли длины листы
            if (names.Count != resolv.Count )
            {
                throw new Exception("в листах с данными по месторождениям разная длина.");
            }
            
            //в цикле присвоить данные  месторождению
            for (int i = 0; i < names.Count; i++)
            {
                //создать temp месторождение
                var temp = new Oilfield();

                //присвоить даные
                temp.Index = i;
                temp.Name = names[i];
                temp.OilReserves = Convert.ToInt32(resolv[i]);

                //скважины
                temp.Wells = getListWells(temp.Name);

                list.Add(temp);
            }
            return list;
        }

        
    }
}
