using System;
using MyClassLibrary.Accessors;
using MyClassLibrary.DataClasses;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //ChifMyConsole ch = new ChifMyConsole();
            //ch.Do();


            var myOrm = new MyORM();
            var x = myOrm.GetAllOil("Oilfield");


            var y = myOrm.GetAllWells("Well");




        }
    }
}
