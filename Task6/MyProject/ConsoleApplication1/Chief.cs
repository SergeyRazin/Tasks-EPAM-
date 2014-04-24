using System;
using MyProject;
using MyProject.AccessorsClasses;
using MyProject.DataClasses;
using MyProject.Interfaces;
using Ninject;
using NLog;

namespace ConsoleApplication1
{
    class Chief
    {
        //создаем объект (маршрутизатор)
        IKernel ninjectKernel = new StandardKernel(new SimpleConfigurationModule());

        Client client = new Client();
        private Logger logger = LogManager.GetCurrentClassLogger();

        #region ПРИВАТНЫЕ МЕТОДЫ

        private string EnterOnlyNumber()
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

        private string EnterOnly12()
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
                    Console.WriteLine();//*
                    return str;//*
                }
            }
            Console.WriteLine();
            return str;
        }

        private string EnterOnly123()
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

        private string EnterOnly1234()
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

        private string EnterOnly1234567()
        {
            string str = string.Empty;
            ConsoleKeyInfo key;

            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                char c = key.KeyChar;
                if (c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7')
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

        private IAccessor SelectAccessor()
        {

            Console.WriteLine("С чем вы хотите работать ?");
            Console.WriteLine("1 - файл с данными в бинарном формате");
            Console.WriteLine("2 - файл с данными в XML формате");
            Console.WriteLine("3 - база данных");

            string option = EnterOnly123();

            switch (option)
            {
                case ("1"): return ninjectKernel.Get<AccessorBinarry>();
                case ("2"): return ninjectKernel.Get<AccessorXML>();
                case ("3"): return ninjectKernel.Get<AccessorDB>(); 
                default:
                    Console.WriteLine("Невврный символ, попробуйте еще раз");
                    SelectAccessor();
                    break;
            }
            return null;

        }

        #endregion


        public void AddPerson()
        {
            IAccessor accessor = SelectAccessor();

            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст");
            int age = Convert.ToInt32(EnterOnlyNumber());
            Console.WriteLine("Введите телефон");
            string phone = Console.ReadLine();

            try
            {
                client.AddPerson(new Person() { Name = name, Age = age,Phone = phone}, accessor);
                Console.WriteLine("ok");
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }


        }

        public void RemovePerson()
        {
            IAccessor accessor = SelectAccessor();

            Console.WriteLine("Введите имя персоны , которую хотите удалить.");
            int index = Convert.ToInt32(EnterOnlyNumber());
            try
            {
                client.RemovePerson(index, accessor);
                Console.WriteLine("ok");
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }

        }

        public void UpdatePerson()
        {
            IAccessor accessor = SelectAccessor();

            Console.WriteLine("введите индекс персоны которую хотите обновить");
            int index = Convert.ToInt32(EnterOnlyNumber());

            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст");
            int age = Convert.ToInt32(EnterOnlyNumber());

            Console.WriteLine("Введите телефон");
            string phone = Console.ReadLine();

            try
            {
                client.UpdatePerson(index, name, age,  phone,  accessor);
                Console.WriteLine("ok");
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }


        }

        public void ShowALL()
        {
            IAccessor accessor = SelectAccessor();

            try
            {
                var person = client.GetAllPerson(accessor);
                foreach (var i in person)
                {
                    Console.WriteLine("{0} {1} {2} {3}", i.ID, i.Name, i.Age, i.Phone);
                }
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }
        }

        public void Clear()
        {
            IAccessor accessor = SelectAccessor();

            try
            {
                client.Clear(accessor);
                Console.WriteLine("ok");
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }


        }

        public void GetPersonByIndex()
        {
            IAccessor accessor = SelectAccessor();
            Console.WriteLine("Введите индекс");
            int index = Convert.ToInt32(EnterOnlyNumber());
            try
            {
                Person p = client.GetPersonByIndex(index, accessor);
                Console.WriteLine(p.ID+" "+p.Name + " " + p.Age+" "+p.Phone);
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }


        }

        public void Count()
        {
            IAccessor accessor = SelectAccessor();
            try
            {
                int count = client.Count(accessor);
                Console.WriteLine("Количество записей " + count);
            }
            catch (System.Data.SqlServerCe.SqlCeException e)
            {
                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }
            catch (Exception e)
            {

                Console.WriteLine("ERROR");
                logger.Error(e.Message);
                logger.Error(e.StackTrace);
            }

        }



        public void Do()
        {
            Console.WriteLine("Какую операцию вы хотите выполнить?");
            Console.WriteLine("1 - AddPerson");
            Console.WriteLine("2 - RemovePerson");
            Console.WriteLine("3 - UpdatePerson");
            Console.WriteLine("4 - GetPersonByIndex");
            Console.WriteLine("5 - showAll");
            Console.WriteLine("6 - Count");
            Console.WriteLine("7 - Clear");

            string option = EnterOnly1234567();

            switch (option)
            {
                case ("1"): this.AddPerson(); break;
                case ("2"): this.RemovePerson(); break;
                case ("3"): this.UpdatePerson(); break;
                case ("4"): this.GetPersonByIndex(); break;
                case ("5"): this.ShowALL(); break;
                case ("6"): this.Count(); break;
                case ("7"): this.Clear(); break;
                default:
                    Console.WriteLine("Неверный символ, попробуйте снова.");
                    Do();
                    break;
            }

            //**
            Console.WriteLine("Выполнить еще операцию?");
            Console.WriteLine("1 - да");
            Console.WriteLine("2 - нет");
            string ansver = EnterOnly12();
            switch (ansver)
            {
                case ("1"): Do(); break;
                case ("2"): System.Diagnostics.Process.GetCurrentProcess().Kill(); break;
            }
        }
    }
}
