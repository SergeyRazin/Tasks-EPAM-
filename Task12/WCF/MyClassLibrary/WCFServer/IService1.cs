using System.Collections.Generic;
using System.ServiceModel;
using MyClassLibrary.DataClasses;
using MyClassLibrary.Interfaces;

namespace WCFServer
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Oilfield> GetAllOilfields(int accessor0);

        [OperationContract]
        void AddOilfield(int accessor0, Oilfield oil0);

        [OperationContract]
        void RemoveOilfield(int accessor0, int indexOil0);

        [OperationContract]
        void AddWell(int accessor0, Well well0, string nameOil0);

        [OperationContract]
        void RemoveWell(int accessor0, int indexWell0 , string nameOil0 );

        [OperationContract]
        void UpdateOilfield(int accessor0, int indexOil0 , Oilfield oil0 );

        [OperationContract]
        List<Oilfield> GetAllOilfield(int accessor0);

        [OperationContract]
        Oilfield GetOilfieldByIndex(int accessor0, int index0);

        [OperationContract]
        int CountOilfield(int accessor0);

        [OperationContract]
        void Clear(int accessor0);

    }
}
