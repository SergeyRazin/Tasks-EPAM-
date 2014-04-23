using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMx.AccessorsClasses;
using MyORMx.Attributes;
using MyORMx.orm;

namespace MyORMx
{
    class Program
    {
        static void Main(string[] args)
        {
            ChiefClass chief = new ChiefClass();
            chief.Do();

            Console.ReadKey();
        }
    }
}
