using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyClassLibrary.Accessors;
using MyClassLibrary.DataClasses;
using MyClassLibrary.Interfaces;
using MyClassLibrary.MyExceptions;

namespace WCFServer
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class Service1 : IService1
    {
        //Приватные методы
        #region---------------------------------------

        //- вводить только числа
        private string enterOnlyNumber()
        {
            string str = string.Empty;
            ConsoleKeyInfo key;

            //пока не нажали ENTER
            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                char c = key.KeyChar;
                if (char.IsDigit(c))
                {
                    Console.Write(c);
                    str += c;
                }
            }
            Console.WriteLine();
            return str;
        }

        //- вводить только 1 , 2
        private string enterOnly12()
        {
            string str = string.Empty;
            ConsoleKeyInfo key;

            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                char c = key.KeyChar;
                if (c == '1' || c == '2')
                {
                    Console.Write(c);
                    str += c;
                    Console.WriteLine();
                    return str;
                }
            }
            Console.WriteLine();
            return str;
        }

        //- вводить только 1 , 2 , 3
        private string enterOnly123()
        {
            string str = string.Empty;
            ConsoleKeyInfo key;


            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {

                char c = key.KeyChar;
                if (c == '1' || c == '2' || c == '3')
                {
                    Console.Write(c);
                    str += c;
                    Console.WriteLine();//*
                    return str;//*
                }

            }
            Console.WriteLine();
            return str;
        }

        //- вводить только 1 , 2 , 3 , 4
        private string enterOnly1234()
        {
            string str = string.Empty;
            ConsoleKeyInfo key;


            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                char c = key.KeyChar;
                if (c == '1' || c == '2' || c == '3' || c == '4')
                {
                    Console.Write(c);
                    str += c;
                    Console.WriteLine();//*
                    return str;//*
                }
            }
            Console.WriteLine();
            return str;
        }

        //- вводить только 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9
        private string enterOnly123456789()
        {
            string str = string.Empty;
            ConsoleKeyInfo key;

            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                char c = key.KeyChar;
                if (c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9')
                {
                    Console.Write(c);
                    str += c;
                    Console.WriteLine();//*
                    return str;//*
                }
            }
            Console.WriteLine();
            return str;
        }

        //- выбор аксессора
        private IAccessor selectAccessor()
        {
            Console.WriteLine("С чем вы хотите работать ?");
            Console.WriteLine("1 - файл с данными в бинарном формате");
            Console.WriteLine("2 - файл с данными в XML формате");
            Console.WriteLine("3 - база данных");

            string option = enterOnly123();

            switch (option)
            {
                case ("1"): return new AccessorBinary();
                case ("2"): return new AccessorXML();
                case ("3"): return new AccessorDB();
                default:
                    Console.WriteLine("Невврный символ, попробуйте еще раз");
                    selectAccessor();
                    break;
            }
            return null;

        }

        //- ввод скважины в базу
        private Well enterDataWell()
        {
            //создание скважины
            Well temp = new Well();

            //введите название скважины
            Console.WriteLine("введите номер скважины");
            //считать номер
            temp.Number = Convert.ToInt32(enterOnlyNumber());

            //введите дебит
            Console.WriteLine("Введите дебит скважины.");
            //считать дебит
            temp.Debit = Convert.ToInt32(enterOnlyNumber());

            //введите марку насоса
            Console.WriteLine("Введите марку насоса.");
            //считать насос
            temp.Pump = Console.ReadLine();

            return temp;
        }

        //- выполнить действие
        private void selectAction(string operation, IAccessor accessor)
        {
            switch (operation)
            {
                case ("1"):
                    {
                        //пользователь вводит данные месторождения
                        var oil = enterDataOil();
                        //добавляем месторождение в базу
                        try
                        {
                            accessor.AddOilfield(oil);
                        }
                        catch (MyOilfieldNameNotFoundException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        catch (MyOverlapNameException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");

                        }
                        Console.WriteLine("ok");
                        break;
                    }

                case ("2"):
                    {
                        //введите индекс удаляемого месторждения.
                        Console.WriteLine("введите индекс удаляемого месторждения");

                        //считать индекс
                        var index = Convert.ToInt32(enterOnlyNumber());

                        //выполнить удаление
                        try
                        {
                            accessor.RemoveOilfield(index);
                        }
                        catch (MyOilfieldNameNotFoundException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        catch (MyOverlapNameException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");

                        }
                        break;
                    }

                case ("3"):
                    {
                        //ввести название месторождения куда добавить скважину
                        Console.WriteLine("Введите название месторождения куда вы хотите добавить скважину.");
                        //считать название месторожд
                        var nameOil = Console.ReadLine();

                        //ввести данные скважины
                        var well = enterDataWell();
                        //добавить скважину в базу
                        try
                        {
                            accessor.AddWell(well, nameOil);
                        }
                        catch (MyOilfieldNameNotFoundException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        catch (MyOverlapNameException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");

                        }
                        Console.WriteLine("ok");

                        break;
                    }

                case ("4"):
                    {
                        //ввести название месторождения куда добавить скважину
                        Console.WriteLine("Введите название месторождения из которого удалить скважину.");
                        //считать название месторожд
                        var nameOil = Console.ReadLine();

                        //введите индекс скважины
                        Console.WriteLine("Введите индекс скважины которую хотите удалить");
                        //считать индекс
                        var indexWell = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            accessor.RemoveWell(indexWell, nameOil);
                        }
                        catch (MyOilfieldNameNotFoundException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        catch (MyOverlapNameException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");

                        }
                        Console.WriteLine("ok");

                        break;
                    }

                case ("5"):
                    {
                        Console.WriteLine("введите индекс месторождения которое хотите обновить");
                        //введите индекс месторождения для обновления
                        var indexOil = Convert.ToInt32(enterOnlyNumber());

                        Console.WriteLine("введите данные месторождения");
                        //введите новое месторождение
                        var oil = enterDataOil();

                        try
                        {
                            accessor.UpdateOilfield(indexOil, oil);
                        }
                        catch (MyOilfieldNameNotFoundException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        catch (MyOverlapNameException e)
                        {
                            Console.WriteLine(e.Message);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");

                        }
                        Console.WriteLine("ok");

                        break;
                    }

                case ("6"):
                    {
                        try
                        {
                            var rez = accessor.GetAllOilfield();
                            foreach (var i in rez)
                            {
                                Console.WriteLine(i.Index + " " + i.Name + " " + i.OilReserves);
                                foreach (var w in i.Wells)
                                {
                                    Console.WriteLine("     " + w.Number + " " + w.Debit + " тонн " + w.Pump);
                                }
                            }
                        }
                        catch (MyOilfieldNameNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (MyOverlapNameException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");
                        }
                        break;
                    }

                case ("7"):
                    {
                        try
                        {
                            //введите индекс месторождения
                            Console.WriteLine("введите индекс месторождения которое хотите просмотреть.");

                            //считать индекс
                            var indexOil = Convert.ToInt32(enterOnlyNumber());

                            var oil = accessor.GetOilfieldByIndex(indexOil);

                            //вывести полученное месторождение на консоль
                            Console.WriteLine(oil.Index + " " + oil.Name + " " + oil.OilReserves);

                            foreach (var w in oil.Wells)
                            {
                                Console.WriteLine("     " + w.Number + " " + w.Debit + " тонн " + w.Pump);
                            }

                        }
                        catch (MyOilfieldNameNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (MyOverlapNameException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");
                        }
                        break;
                    }
                case ("8"):
                    {
                        try
                        {
                            var countOil = accessor.CountOilfield();
                            var countWells = accessor.CountWells();

                            Console.WriteLine("Количество месторождений: " + countOil + " количество скважин: " +
                                              countWells);
                        }
                        catch (MyOilfieldNameNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (MyOverlapNameException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");
                        }
                        break;
                    }

                case ("9"):
                    {
                        try
                        {
                            accessor.Clear();
                            Console.WriteLine("данные удалены");
                        }
                        catch (MyOilfieldNameNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (MyOverlapNameException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");
                        }
                        break;
                    }
            }
        }

        //- ввод данных месторождения
        private Oilfield enterDataOil()
        {
            // создание месторождения
            Oilfield temp = new Oilfield();

            //введите название месторождения
            Console.WriteLine("Введите название месторождение.");
            //считать название
            temp.Name = Console.ReadLine();

            //введите извлекаемые запасы
            Console.WriteLine("Введите извлекаемые запасы.");
            //считать извлекаемые запасы
            temp.OilReserves = Convert.ToInt32(enterOnlyNumber());

            return temp;
        }

        private void selectAccessorServer(int accessor0)
        {
            if (accessor0 == 1)
                _accessor = new AccessorBinary();
            if (accessor0 == 2)
                _accessor = new AccessorXML();
            if (accessor0 == 3)
                _accessor = new AccessorDB();
        }

        #endregion приватные методы----↑----------------------

        //аксессор
        private IAccessor _accessor;

        //метод получить все месторождения
        public List<Oilfield> GetAllOilfields(int accessor0)
        {
            selectAccessorServer(accessor0);
            Console.WriteLine("отдал лист месторождений");
            return  _accessor.GetAllOilfield();
        }

        //добавить месторождение
        public void AddOilfield(int accessor0, Oilfield oil0)
        {
            selectAccessorServer(accessor0);
            _accessor.AddOilfield(oil0);
            Console.WriteLine("добавил месторождение");
        }

        //удалить месторождение
        public void RemoveOilfield(int accessor0, int indexOil0)
        {
            selectAccessorServer(accessor0);
            _accessor.RemoveOilfield(indexOil0);
            Console.WriteLine("удалил месторождение");
        }

        //добавить скважину к месорождению
        public void AddWell(int accessor0, Well well0, string nameOil0)
        {
            selectAccessorServer(accessor0);
            _accessor.AddWell(well0,nameOil0);
            Console.WriteLine("добавил скважину к месторождению");
        }

        //удалить скважину из месторождения
        public void RemoveWell(int accessor0, int indexWell0, string nameOil0)
        {
            selectAccessorServer(accessor0);
            _accessor.RemoveWell(indexWell0,nameOil0);
            Console.WriteLine("удалил скважину из месторождения");
        }

        //обновить месторождение
        public void UpdateOilfield(int accessor0, int indexOil0, Oilfield oil0)
        {
            selectAccessorServer(accessor0);
            _accessor.UpdateOilfield(indexOil0, oil0);
            Console.WriteLine("обновил месторождение");
        }

        //вернуть все месторождения
        public List<Oilfield> GetAllOilfield(int accessor0)
        {
            selectAccessorServer(accessor0);
            Console.WriteLine("вернул лист месторождений");
            return _accessor.GetAllOilfield();
        }

        //вернуть месторождение по индексу
        public Oilfield GetOilfieldByIndex(int accessor0, int index0)
        {
            selectAccessorServer(accessor0);
            Console.WriteLine("вернул  месторождение по индексу");
            return _accessor.GetOilfieldByIndex(index0);
        }

        //вернуть количестов месторождений
        public int CountOilfield(int accessor0)
        {
            selectAccessorServer(accessor0);
            Console.WriteLine("вернул  количество месторождений");
            return _accessor.CountOilfield();
        }

        //удалить все месторождения
        public void Clear(int accessor0)
        {
            selectAccessorServer(accessor0);
            _accessor.Clear();
            Console.WriteLine("удалил данные");
        }
    }
}
