using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace EPAM_TASK_1_ATTRIBUTES
{
    

    #region КЛАССЫ АТРИБУТЫ ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    class Oracle : Attribute
    {
        public string ГодОснования = "1977";
        public string ОтцыОснователи = "Лари Эллисон, Боб Майнер, Эд Оутсом";
        public string ДопИнформация = "Компания является вторым по объёмам продаж разработчиком программного обеспечения после Microsoft";
    }

    class Microsoft : Attribute
    {
        public string ГодОснования = "1975";
        public string ОтцыОснователи = "Билл Гейтс , Пол Аллен";
        public string ДопИнформация = "В 2013 году Microsoft заняла 75 место в рейтинге 100 лучших работодателей США.";
    }

    class JavaAttribute : Attribute
    {
        public string JavaКомпилируетсяВ = "байт код";
    }

    class C_sharpAttribute : Attribute
    {
        public string C_sharpКомпилируетсяВ = "IL код";
    }

    #endregion ↑↑↑↑↑↑↑↑↑↑↑↑

    #region КЛАССЫ СТАНДАРТНЫЕ ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    class C_plus_plus
    {
        public string КомпилируетсяВ;
    }

    [Oracle]
    class Java : C_plus_plus
    {
        [JavaAttribute]
        public new string КомпилируетсяВ;
    }

    [Microsoft]
    class C_sharp : C_plus_plus
    {
        [C_sharpAttribute]
        public new string КомпилируетсяВ;
    }

    #endregion КЛАССЫ СТАНДАРТНЫЕ ↑↑↑↑↑↑↑↑↑↑↑↑

    class Program
    {
        

        public static string ПолучитьВладельца(C_plus_plus язык) 
        {
            //если нет атрибута то возврат "атрибутов нет"
            if (Attribute.GetCustomAttribute(язык.GetType(), typeof(Attribute)) == null) 
            {
                //установить цвет консоли красный
                Console.ForegroundColor = ConsoleColor.Red;

                return "атрибутов нет";
            }

            //получитьТипАтрибута языка
            Type attrType = Attribute.GetCustomAttribute(язык.GetType(), typeof(Attribute)).GetType();

            if (attrType == typeof(Oracle)) 
            {
                //установить цвет консоли magenta
                Console.ForegroundColor = ConsoleColor.Magenta;

                //получить сам атрибут
                Oracle or = (Oracle)Attribute.GetCustomAttribute(язык.GetType(), typeof(Attribute));
                //обрезать длинное название класса атрибута и оставить только Oracle (то что после точки идет)
                string temp =  or.ToString();
                return temp.Substring(temp.LastIndexOf("Oracle") );            
            }

            if (attrType == typeof(Microsoft)) 
            {
                //установить цвет консоли синий
                Console.ForegroundColor = ConsoleColor.Blue;

                //получить сам атрибут
                Microsoft mi = (Microsoft)Attribute.GetCustomAttribute(язык.GetType(), typeof(Attribute));
                //обрезать длинное название класса атрибута и оставить только Microsoft (то что после точки идет)
                string temp = mi.ToString();
                return temp.Substring(temp.LastIndexOf("Microsoft"));
            }

            return "атрибут неверного типа";
        }

        public static string ПоказатьВоЧтоКомпилируется(C_plus_plus язык) 
        {
            //получеме тип языка
            Type t = язык.GetType();

            if (язык.GetType() == typeof(C_plus_plus)) 
            {
                //установить цвет консоли красный
                Console.ForegroundColor = ConsoleColor.Red;

                язык.КомпилируетсяВ = "неуправляемый код";
                return язык.КомпилируетсяВ;
            }

            //если у языков java или c# не заданы атрибуты ( если это не проверить  будет исключение)
            if (Attribute.GetCustomAttribute(t.GetField("КомпилируетсяВ"), typeof(Attribute)) == null) 
            {
                //установить цвет консоли красный
                Console.ForegroundColor = ConsoleColor.Red;

                return "нет атрибута";
            }

            //если тип языка java
            if (язык.GetType() == typeof(Java) ) 
            {
                //установить цвет консоли magenta
                Console.ForegroundColor = ConsoleColor.Magenta;

                Java currentLanguage = (Java)язык;
                JavaAttribute jattr = (JavaAttribute)Attribute.GetCustomAttribute(t.GetField("КомпилируетсяВ"), typeof(Attribute));
                currentLanguage.КомпилируетсяВ = jattr.JavaКомпилируетсяВ;

                return currentLanguage.КомпилируетсяВ;
            }

            if(язык.GetType()==typeof(C_sharp))
            {
                //установить цвет консоли синий
                Console.ForegroundColor = ConsoleColor.Blue;

                C_sharp currentLanguage = (C_sharp)язык;
                C_sharpAttribute csattr = (C_sharpAttribute)Attribute.GetCustomAttribute(t.GetField("КомпилируетсяВ"), typeof(Attribute));
                currentLanguage.КомпилируетсяВ = csattr.C_sharpКомпилируетсяВ;

                return currentLanguage.КомпилируетсяВ;
            }

           

            return "неизвестный язык программирования во что компилируется мы не знаем";
        }

        public static string[] ПолучитьИнформациюОКомпанииВладельце(C_plus_plus язык) 
        {
            

            //получить атрибут класса
            Attribute attr = Attribute.GetCustomAttribute(язык.GetType(), typeof(Attribute));

            //если нет атрибута
            if (attr == null) 
            {
                //установить цвет консоли красный
                Console.ForegroundColor = ConsoleColor.Red;

                return new string[] { "атрибутов нет",null,null };
            }

            //если атрибут Oracle
            if (attr.GetType() == typeof(Oracle)) 
            {
                //установить цвет консоли magenta
                Console.ForegroundColor = ConsoleColor.Magenta;

                Oracle oattr  = (Oracle)attr;
                Type t        = oattr.GetType();
                FieldInfo[] поляКлассаАтрибута = t.GetFields();
                string   [] temp = new string[поляКлассаАтрибута.Length];
                
                //записать данные из массива типа FieldInfo в массив типа string
                for(int i=0;i<поляКлассаАтрибута.Length;i++)
                {
                    temp[i] = String.Format(поляКлассаАтрибута[i].Name.ToString() + ":\t" + поляКлассаАтрибута[i].GetValue(oattr).ToString());
                }

                return temp;
            }

            //если атрибут Microsoft
            if (attr is Microsoft) 
            {
                //установить синий цвет консоли
                Console.ForegroundColor = ConsoleColor.Blue;

                Microsoft miattr = (Microsoft)attr;
                Type t           = miattr.GetType();
                FieldInfo[] поляКлассаАтрибута = t.GetFields();
                string   [] temp = new string[поляКлассаАтрибута.Length];

                //записать данные из массива типа FieldInfo в массив типа string
                for(int i=0;i<поляКлассаАтрибута.Length;i++)
                {
                    temp[i] = String.Format(поляКлассаАтрибута[i].Name.ToString() + ":\t" + поляКлассаАтрибута[i].GetValue(miattr).ToString());
                }

                return temp;
            }

            return null;
        }

        static void Main(string[] args)
        {
            Java j = new Java();
            C_sharp cs = new C_sharp();
            C_plus_plus cpp = new C_plus_plus();
            

            Console.WriteLine(ПолучитьВладельца(j));
            Console.WriteLine(ПолучитьВладельца(cs));
            Console.WriteLine(ПолучитьВладельца(cpp));

            Console.WriteLine(ПоказатьВоЧтоКомпилируется(j));
            Console.WriteLine(ПоказатьВоЧтоКомпилируется(cs));
            Console.WriteLine(ПоказатьВоЧтоКомпилируется(cpp));

            ПоказатьВоЧтоКомпилируется(j);
            Console.WriteLine(j.КомпилируетсяВ);
            ПоказатьВоЧтоКомпилируется(cs);
            Console.WriteLine(cs.КомпилируетсяВ);
            ПоказатьВоЧтоКомпилируется(cpp);
            Console.WriteLine(cpp.КомпилируетсяВ);

            //вывести информацию об j
            string[] инфаОКомпании1 = ПолучитьИнформациюОКомпанииВладельце(j);
            foreach (var i in инфаОКомпании1) 
            {
                Console.WriteLine(i);
            }

            //вывести информацию об cs
            string[] инфаОКомпании2 = ПолучитьИнформациюОКомпанииВладельце(cs);
            foreach (var i in инфаОКомпании2)
            {
                Console.WriteLine(i);
            }

            //вывести информацию об cpp
            string[] инфаОКомпании3 = ПолучитьИнформациюОКомпанииВладельце(cpp);
            foreach (var i in инфаОКомпании3)
            {
                Console.WriteLine(i);
            }

            

            Console.ReadKey();
        }
    }
}
