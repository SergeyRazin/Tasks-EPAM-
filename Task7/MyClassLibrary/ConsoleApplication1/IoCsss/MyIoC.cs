using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.IoCsss
{
    class MyIoC
    {
        //поля класса
        #region--------↓------------------------------

        //дикшинери
        private readonly IDictionary<Type, RegisteredObject> _registeredObjects = new Dictionary<Type, RegisteredObject>();

        #endregion-----↑---------------------------------

        //приватные методы
        #region -------↓-----------------------------------

        private void register<TType, TConcrete>(bool isSingleton, TConcrete instance)
        {
            Type type = typeof(TType);

            //если уже такоей тим содержится в дикшенери, то удалить его
            if (_registeredObjects.ContainsKey(type))
                _registeredObjects.Remove(type);

            //добавить в дикшенери новый объект
            _registeredObjects.Add(type, new RegisteredObject(typeof(TConcrete), isSingleton, instance));
        }

        private object resolveObject(Type type)
        {
            //получить объект
            var registeredObject = _registeredObjects[type];

            //если объект не зарегистрирован выброс исключения
            if (registeredObject == null)
            {
                throw new ArgumentOutOfRangeException(string.Format("The type {0} has not been registered", type.Name));
            }
            return getInstance(registeredObject);
        }

        private object getInstance(RegisteredObject registeredObject)
        {
            object instance = registeredObject.SingletonInstance;
            if (instance == null)
            {
                var parameters = resolveConstructorParameters(registeredObject);
                instance = registeredObject.CreateInstance(parameters.ToArray());
            } return instance;
        }

        private IEnumerable<object> resolveConstructorParameters(RegisteredObject registeredObject)
        {
            var constructorInfo = registeredObject.ConcreteType.GetConstructors().First();
            return constructorInfo.GetParameters().Select(parameter => resolveObject(parameter.ParameterType));
        }

        #endregion приватные методы----↑----------------------



        //регистр
        public void Register<TType>() where TType : class
        {
            register<TType, TType>(false, null);
        }

        //резолв
        public TTypeToResolve Resolve<TTypeToResolve>()
        {
            //выдать объект из дикшенери (если объекта нет, то выкинуть исключение)
            return (TTypeToResolve)resolveObject(typeof(TTypeToResolve));
        }


        // ВНУТРЕННИЙ КЛАСС регистрация объекта
        private class RegisteredObject
        {
            private readonly bool _isSinglton;

            public Type ConcreteType { get; private set; }
            public object SingletonInstance { get; private set; }

            public RegisteredObject(Type concreteType, bool isSingleton, object instance)
            {
                _isSinglton = isSingleton;
                ConcreteType = concreteType;
                SingletonInstance = instance;
            }

            public object CreateInstance(params object[] args)
            {
                object instance = Activator.CreateInstance(ConcreteType, args);
                if (_isSinglton)
                    SingletonInstance = instance;
                return instance;
            }
        }
    }
}
