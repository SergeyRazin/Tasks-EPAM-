using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.DataClasses;

namespace MyClassLibrary.Interfaces
{
    public interface IDAL
    {
        //десериализовать
        List<Oilfield> Desirializ(string path);

        //сериализовать
        void  SerializtionWithExchengeFile(string path, List<Oilfield> oilfields0);

        
    }
}
