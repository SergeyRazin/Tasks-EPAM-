using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ConsoleApplication1.Interfaces;

namespace ConsoleApplication1.IoCsss
{
    class WrapWinSorIoC:IWrapContainer
    {
        //создание контейнера
        WindsorContainer container = new WindsorContainer();

        public void Register<TypeX>() where TypeX : class
        {
            //настройка контейнера
            container.Register(Component.For<TypeX>().ImplementedBy<TypeX>().LifestyleTransient());
        }

        public MyType Resolve<MyType>()
        {
           return container.Resolve<MyType>();
        }
    }
}
