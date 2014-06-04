using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Interfaces;
using Autofac;

namespace ConsoleApplication1.IoCsss
{
    class WrapAutoFacIoC:IWrapContainer
    {
        //создаем билдер для контейнера
        ContainerBuilder builder = new ContainerBuilder();

        public void Register<TypeX>() where TypeX : class
        {
            builder.RegisterType<TypeX>().AsSelf();
        }

        public MyType Resolve<MyType>()
        {
            //создаем контейнер
            var container = builder.Build();

            //используем
            return container.Resolve<MyType>();
        }
    }
}
