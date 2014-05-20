

namespace ConsoleApplication1.Interfaces
{
    interface IWrapContainer
    {
        //1
        void Register<TypeX>() where TypeX : class;

        //2
        MyType Resolve<MyType>();
    }
}
