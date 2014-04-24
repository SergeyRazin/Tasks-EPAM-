using System.Collections.Generic;
using MyProject.Interfaces;
using MyProject.DataClasses;


namespace MyProject
{
    public class Client
    {
        public void AddPerson(Person p0,IAccessor accessor0)
        {
            accessor0.AddPerson(p0);
        }

        public void RemovePerson(int index0,IAccessor accessor0)
        {
            accessor0.RemovePerson(index0);
        }

        public void UpdatePerson(int index0, string name0, int age0, string phone0 ,IAccessor accessor0)
        {
            accessor0.UpdatePerson(index0,name0,age0,phone0);
        }

        public List<Person> GetAllPerson(IAccessor accessor0)
        {
            return accessor0.GetAllPerson();
        }

        public Person GetPersonByIndex(int index0,IAccessor accessor0)
        {
            return accessor0.GetPersonByIndex(index0);
        }

        public int Count(IAccessor accessor0)
        {
            return accessor0.Count();
        }

        public void Clear(IAccessor accessor0)
        {
            accessor0.Clear();
        }
    }
}
