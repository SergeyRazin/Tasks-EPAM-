using MyProject.Interfaces;
using Ninject.Modules;

namespace MyProject
{
    public class SimpleConfigurationModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IAccessor>().To<IAccessor>();
        }
    }
}
