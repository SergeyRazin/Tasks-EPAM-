using MyClassLibrary.Interfaces;
using Ninject.Modules;

namespace ConsoleClient
{
    public class SimpleConfigurationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IAccessor>().To<IAccessor>();
        }
    }
}
