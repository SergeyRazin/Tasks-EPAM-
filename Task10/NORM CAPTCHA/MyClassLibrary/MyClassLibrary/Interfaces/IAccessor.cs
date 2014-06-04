using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibrary.DataClasses;

namespace MyClassLibrary.Interfaces
{
    public interface IAccessor
    {
        /// <summary>
        /// добавить месторождение
        /// </summary>
        /// <param name="oilfield">объект месторождения</param>
        void AddOilfield(Oilfield oilfield0);

        /// <summary>
        /// удалить месторождение
        /// </summary>
        /// <param name="index">индекс удаляемого месторождения</param>
        void RemoveOilfield(int index0);

        /// <summary>
        /// добавить скважину 
        /// </summary>
        /// <param name="well">объект скважина</param>
        void AddWell(Well well0, string oilfieldName0);

        /// <summary>
        /// удалить скважину
        /// </summary>
        /// <param name="index">индекс удаляемой скважины</param>
        void RemoveWell(int indexWell0, string oilfieldName0);

        /// <summary>
        /// обновить данные месторождения
        /// </summary>
        /// <param name="index">индекс обновляемого месторождения</param>
        /// <param name="name">имя месторождения</param>
        /// <param name="oilReserves">извлекаемые запасы месторождения</param>
        void UpdateOilfield(int index0, Oilfield oilfield0);

        /// <summary>
        /// получить все месторождения
        /// </summary>
        /// <returns>возвращает List с месторождениями</returns>
        List<Oilfield> GetAllOilfield();

        /// <summary>
        /// получить месторождение по индексу
        /// </summary>
        /// <param name="index">индекс месторождения</param>
        /// <returns>возвращает объект месторождения</returns>
        Oilfield GetOilfieldByIndex(int index0);

        /// <summary>
        /// получить количество месторождений
        /// </summary>
        /// <returns></returns>
        int CountOilfield();

        /// <summary>
        /// полчить количество скважин
        /// </summary>
        /// <returns></returns>
        int CountWells();

        /// <summary>
        /// получить количество скважин для конкретного месторождения
        /// </summary>
        /// <param name="indexOilfield">индекс месторождения</param>
        /// <returns></returns>
        int CountWellsInOilfield(int indexOilfield0);

        /// <summary>
        /// удалить все 
        /// </summary>
        void Clear();

        /// <summary>
        /// вернуть название месторождения по индексу
        /// </summary>
        /// <param name="index0"></param>
        /// <returns></returns>
        string GetNameByIndex(int index0);

    }
}
