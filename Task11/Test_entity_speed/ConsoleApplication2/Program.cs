using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.Accessors;
using MyClassLibrary.DataClasses;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyORM myOrm = new MyORM();

            Oilfield tempOil = new Oilfield();
            tempOil.Name = "тестовое месторождение";

            Well well1 = new Well();
            well1.Number = 1;
            well1.Debit = 100;
            well1.Pump = "ШГН";


            tempOil.Wells.Add(well1);

            myOrm.AddOilfield(tempOil);
        }
    }
}
