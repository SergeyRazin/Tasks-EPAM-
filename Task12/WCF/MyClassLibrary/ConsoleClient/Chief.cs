using System;
using MyClassLibrary.DataClasses;
using MyClassLibrary.Accessors;
using MyClassLibrary.Interfaces;
using MyClassLibrary.MyExceptions;
using Ninject;
using NLog;


namespace ConsoleClient
{
   public class Chief
   {
       //поля класса
       #region----------------↓----------------------------------

       //ioc
       IKernel ninjectKernel = new StandardKernel(new SimpleConfigurationModule());

       //логер
       private Logger log = LogManager.GetCurrentClassLogger();

       #endregion поля класса-↑-------------------------------------------------

       #region приватные методы-------↓-----------------------

       //- вводить только числа
        private string enterOnlyNumber()
        {
            string str = string.Empty;
            ConsoleKeyInfo key;

            //пока не нажали ENTER
            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                char c = key.KeyChar;
                if (char.IsDigit(c) )
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
                if (c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9' )
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
                case ("1"): return ninjectKernel.Get<AccessorBinary>();
                case ("2"): return ninjectKernel.Get<AccessorXML>();
                case ("3"): return ninjectKernel.Get<AccessorDB>();
                default:
                    Console.WriteLine("Невврный символ, попробуйте еще раз");
                    selectAccessor();
                    break;
            }
            return null;

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
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (MyOverlapNameException e)
                   {
                       Console.WriteLine(e.Message);
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
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
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (MyOverlapNameException e)
                   {
                       Console.WriteLine(e.Message);
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
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
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (MyOverlapNameException e)
                   {
                       Console.WriteLine(e.Message);
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
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
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (MyOverlapNameException e)
                   {
                       Console.WriteLine(e.Message);
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
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
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (MyOverlapNameException e)
                   {
                       Console.WriteLine(e.Message);
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
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
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (MyOverlapNameException e)
                   {
                       Console.WriteLine(e.Message);
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
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
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (MyOverlapNameException e)
                   {
                       Console.WriteLine(e.Message);
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
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
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (MyOverlapNameException e)
                   {
                       Console.WriteLine(e.Message);
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
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
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (MyOverlapNameException e)
                   {
                       Console.WriteLine(e.Message);
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   catch (Exception e)
                   {
                       Console.WriteLine("ОШИБКА БАЗЫ ДАННЫХ");
                       log.Error(e.Message);
                       log.Error(e.StackTrace);
                   }
                   break;
               }
           }
       }

       #endregion приватные методы----↑----------------------

        public void Do()
        {
            //пользователь выбирает аксессор
            var accessor = selectAccessor();

            //сообщение пользователю какую операцию выбрать
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Выберите операцию:");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1 -  Добавить месторождение в базу(AddOilfield)");
            Console.WriteLine("2 -  Удалить месторождение из базы(RemoveOilfield)");
            Console.WriteLine("3 -  Добавить скважину к месторождению(AddWell)");
            Console.WriteLine("4 -  Удалить скважину из месторождения(RemoveWell)");
            Console.WriteLine("5 -  Обновить данные месторождения(UpdateOilfield)");
            Console.WriteLine("6 -  Показать все месторождения и скважины(GetAllOilfield)");
            Console.WriteLine("7 -  Вывести месторождение и скважины(GetOilfieldByIndex)");
            Console.WriteLine("8 -  Вывести количество месторождений и скважины(CountOilfield and wells)");
            Console.WriteLine("9 -  Удалить все записи(Clear)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            //пользователь вводит числа
            var operation = enterOnly123456789();

            //определяется операция
            selectAction(operation, accessor);
                
           //выполнить еще операцию?
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Выполнить еще операцию?");
            Console.WriteLine("1 - да");
            Console.WriteLine("2 - нет");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            var ogen = enterOnly12();

            switch (ogen)
            {
                case ("1"):Do();break;
                case ("2"):System.Diagnostics.Process.GetCurrentProcess().Kill(); break;
            }
        }
    }
}
