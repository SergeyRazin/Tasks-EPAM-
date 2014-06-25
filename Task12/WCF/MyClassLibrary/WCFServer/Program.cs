using System;
using System.ServiceModel;

namespace WCFServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //создать службу
            ServiceHost sh = new ServiceHost(typeof(Service1));

            //открыть службу
            sh.Open();

            Console.WriteLine("Служба работает");
            Console.ReadLine();

            //закрыть службу
            sh.Close();


        }
    }
}
