using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMx.AccessorsClasses;
using MyORMx.DataClasses;
using MyORMx.Interfaces;

namespace MyORMx
{
    public class ChiefClass:IChief
    {
        #region private Methods

        Client client = new Client();

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
                if (c == '1' || c == '2' )
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
                if (c == '1'|| c=='2'|| c=='3')
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

        private  string EnterOnly1234567()
        {
            string str = string.Empty;
            ConsoleKeyInfo key;

            while ((key = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            {
                char c = key.KeyChar;
                if (c == '1' || c == '2' || c == '3' || c == '4'||c=='5'||c=='6'||c=='7')
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
                case ("1"): return new AccessorBinarry(); 
                case ("2"): return new AccessorXml(); 
                case ("3"): return new AccessorDb(); 
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

            client.AddPerson(new Person() { Name = name, Age = age },accessor);
            Console.WriteLine("ok");
            
        }

        public void RemovePerson() 
        {
            IAccessor accessor = SelectAccessor();

            Console.WriteLine("Введите имя персоны , которую хотите удалить.");
            string name = Console.ReadLine();
            client.RemovePerson(name,accessor);
            Console.WriteLine("ok");
        }

        public void InsertPerson() 
        {
            IAccessor accessor = SelectAccessor();

            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите возраст");
            int age = Convert.ToInt32( EnterOnlyNumber());

            Console.WriteLine("введите индекс");
            int index = Convert.ToInt32( EnterOnlyNumber());

            client.InsertPerson(index, new Person() { Name = name, Age = age }, accessor);
            Console.WriteLine("ok");

        }

        public void ShowAll() 
        {
            IAccessor accessor = SelectAccessor();
            var person = client.GetAllPerson(accessor);
            foreach (var i in person) 
            {
                Console.WriteLine(i.Name+" "+i.Age);
            }
        }

        public void Clear() 
        {
            IAccessor accessor = SelectAccessor();
            client.Clear(accessor);
            Console.WriteLine("ok");
        }

        public void GetPersonByIndex() 
        {
            IAccessor accessor = SelectAccessor();
            Console.WriteLine("Введите индекс");
            int index = Convert.ToInt32(EnterOnlyNumber());
            Person p = client.GetPersonByIndex(index, accessor);
            Console.WriteLine(p.Name + " " + p.Age);

        }

        public void Count() 
        {
            IAccessor accessor = SelectAccessor();
            Console.WriteLine("Количество записей "+client.Count(accessor));
        }



        public void Do() 
        {
            Console.WriteLine("Какую операцию вы хотите выполнить?");
            Console.WriteLine("1 - AddPerson");
            Console.WriteLine("2 - RemovePerson");
            Console.WriteLine("3 - InsertPerson");
            Console.WriteLine("4 - GetPersonByIndex");
            Console.WriteLine("5 - showAll");
            Console.WriteLine("6 - Count");
            Console.WriteLine("7 - Clear");

            string option = EnterOnly1234567();

            switch (option)
            {
                case ("1"): this.AddPerson(); break;
                case ("2"): this.RemovePerson(); break;
                case ("3"): this.InsertPerson(); break;
                case ("4"): this.GetPersonByIndex(); break;
                case ("5"): this.ShowAll(); break;
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
