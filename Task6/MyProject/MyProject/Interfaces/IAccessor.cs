using System.Collections.Generic;
using MyProject.DataClasses;

namespace MyProject.Interfaces
{
    public interface IAccessor
    {
        /// <summary>
        /// метод добавить персону в хранилище
        /// </summary>
        /// <param name="p0"></param>
        void AddPerson(Person p0);

        /// <summary>
        /// метод удалить персону по индексу из хранилища
        /// </summary>
        /// <param name="index0">индекс персоны</param>
        void RemovePerson(int index0);

        /// <summary>
        /// метод изменить данные персоны по индексу
        /// </summary>
        /// <param name="index0"></param>
        void UpdatePerson(int index0,string name0,int age0,string phone0);

        /// <summary>
        /// метод возвращает коллекцию List заполненную всеми персонами в хранилище
        /// </summary>
        /// <returns></returns>
        List<Person> GetAllPerson();

        /// <summary>
        /// метод получить персону по индексу
        /// </summary>
        /// <param name="index0">индекс</param>
        /// <returns></returns>
        Person GetPersonByIndex(int index0);

        /// <summary>
        /// метод получить число персон в хранилище
        /// </summary>
        /// <returns>int</returns>
        int Count();

        /// <summary>
        /// метод удалить всех персон в хранилище
        /// </summary>
        void Clear();
    }
}
