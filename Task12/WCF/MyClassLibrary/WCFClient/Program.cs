using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.Accessors;
using MyClassLibrary.DataClasses;
using MyClassLibrary.Interfaces;
using WCFClient.ServiceReference1;

namespace WCFClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            ChiefWCF chief = new ChiefWCF();
            chief.Do();
        }

        
    }
}
