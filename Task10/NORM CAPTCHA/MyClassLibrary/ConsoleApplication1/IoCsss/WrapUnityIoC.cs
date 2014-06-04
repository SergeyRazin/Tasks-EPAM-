using ConsoleApplication1.Interfaces;
using Microsoft.Practices.Unity;

namespace ConsoleApplication1.IoCsss
{
    class WrapUnityIoC:IWrapContainer
    {
        IUnityContainer unity = new UnityContainer();

        public MyType Resolve<MyType>()
        {
            return unity.Resolve<MyType>();
        }

        public void Register<TypeX>() where TypeX : class
        {
            unity.RegisterType<TypeX>(new ContainerControlledLifetimeManager());
        }
    }
}
