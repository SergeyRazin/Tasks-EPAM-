using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Interfaces;

namespace ConsoleApplication1.IoCsss
{
    class WrapMyIoC:IWrapContainer
    {
        MyIoC ioc = new MyIoC();

        public MyType Resolve<MyType>()
        {
            return ioc.Resolve<MyType>();
        }

        public void Register<TypeX>() where TypeX : class
        {
            ioc.Register<TypeX>();
        }
    }
}
