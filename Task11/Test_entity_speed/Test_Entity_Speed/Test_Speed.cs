using System;
using MyClassLibrary.Accessors;
using NUnit.Framework;

namespace Test_Entity_Speed
{
    [TestFixture]
    public class Test_Speed
    {
        //метод заполняет базу данных тестовой информацией
        public  void FillDB()
        {
            MyORM myOrm = new MyORM();


            //первый цикл создать и настроить месторождение
            for (int i = 1; i <= 100; i++)
            {
                MyClassLibrary.DataClasses.Oilfield tempOilfield = new MyClassLibrary.DataClasses.Oilfield();
                tempOilfield.Name = "Белозерское" + i;
                tempOilfield.OilReserves = 1000 + i;

                //вложенный цикл создать и настроить скважину и добавить ее месторождению
                for (int j = 1; j <= 5; j++)
                {
                    MyClassLibrary.DataClasses.Well tempWell = new MyClassLibrary.DataClasses.Well();
                    tempWell.Number = j;
                    tempWell.Debit = 10 + j;
                    tempWell.Pump = "ШГН";


                    tempOilfield.Wells.Add(tempWell);
                }

                //записать месторождение в базу данных
                myOrm.AddOilfield(tempOilfield);
            }
        }


        //тест получаем все месторождения с помощью MyORM (считываем 1000 записей)
        [Test]
        public void Test_MyORM_speed_Parents()
        {
            //объект для подстчета времени выполнения
            System.Diagnostics.Stopwatch _sw = new System.Diagnostics.Stopwatch();

            var myOrm = new MyORM();

            _sw.Start();
            for (int i = 0; i < 10; i++)
            {
                var x = myOrm.GetAllOil("Oilfield");
            }
            _sw.Stop();

            Console.WriteLine("время выполения запроса с помощью MyORM(родительские сущности ): " + _sw.Elapsed.Milliseconds);

        }

        //тест получаем все скважины с помощью MyORM
        [Test]
        public void Test_MyORM_speed_Childern()
        {
            //объект для подстчета времени выполнения
            System.Diagnostics.Stopwatch _sw = new System.Diagnostics.Stopwatch();

            var myOrm = new MyORM();

            _sw.Start();
            for (int i = 0; i < 10; i++)
            {
                var x = myOrm.GetAllWells("Well");
            }
            _sw.Stop();

            Console.WriteLine("время выполения запроса с помощью MyORM(дочерние сущности ): " + _sw.Elapsed.Milliseconds);
        }

        //тест получаем все месторождения с помощью Entity
        [Test]
        public void Test_Entity_speed_Parents()
        {
            //объект для подстчета времени выполнения
            System.Diagnostics.Stopwatch _sw = new System.Diagnostics.Stopwatch();

            var entities = new Database1Entities();

            _sw.Start();
            for(int i=0;i<10;i++)
                foreach (var j in entities.Oilfield)
                {
                    var x = j;
                }
            _sw.Stop();

            Console.WriteLine("время выполения запроса с помощью Entity(родительские сущности ): " + _sw.Elapsed.Milliseconds);
        }

        //тест получаем все скважины с помощью Entity
        [Test]
        public void Test_Entity_speed_Children()
        {
            //объект для подстчета времени выполнения
            System.Diagnostics.Stopwatch _sw = new System.Diagnostics.Stopwatch();

            var entities = new Database1Entities();

            _sw.Start();
            for (int i = 0; i < 10; i++)
                foreach (var j in entities.Well)
                {
                    var x = j;
                }
            _sw.Stop();

            Console.WriteLine("время выполения запроса с помощью Entity(дочерние сущности ): " + _sw.Elapsed.Milliseconds);
        }

        
    }
}
