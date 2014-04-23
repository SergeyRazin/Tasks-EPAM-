using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMx;
using MyORMx.AccessorsClasses;
using MyORMx.DataClasses;
using NUnit.Framework;
using MyORMx.Interfaces;




namespace UnitTests
{
    class ChiefMock:IChief
    {
        Client client = new Client();
        public IAccessor accessor = new AccessorMemory();

        public void AddPerson()
        {
            string name = "Homer";
            int age = 47;
            client.AddPerson(new Person() { Name = name, Age = age }, accessor);
        }

        public void RemovePerson()
        {
            string name = "Homer";
            client.RemovePerson(name, accessor);
        }

        public void InsertPerson()
        {
            string name = "Homer";
            int age = 47;
            int index = 3;
            client.InsertPerson(index, new Person() { Name = name, Age = age }, accessor);
        }

        public void ShowAll()
        {
            var person = client.GetAllPerson(accessor);
        }

        public void Clear()
        {
            client.Clear(accessor);
        }

        public void GetPersonByIndex()
        {
            int index = 0;
            Person p = client.GetPersonByIndex(index, accessor);
        }

        public void Count()
        {
            
        }
    }

    [TestFixture]
    class ChiefClassTEST
    {
        Person Homer = new Person() { Name = "Homer", Age = 47 };
        Person Marge = new Person() { Name = "Marge", Age = 40 };
        Person Bart = new Person() { Name = "Bart", Age = 9 };
        Person Lisa = new Person() { Name = "Lisa", Age = 8 };

        ChiefMock chiefMock = new ChiefMock();

        [SetUp]
        public void DeleteBegin()
        {
            chiefMock.Clear();
        }

        [TearDown]
        public void DeleteEnd()
        {
            chiefMock.Clear();
        }

        [Test]
        public void AddPersonTEST() 
        {
            chiefMock.AddPerson();
            chiefMock.AddPerson();
            Assert.AreEqual(2, chiefMock.accessor.Count());

        }

        [Test]
        public void RemovePersonTEST() 
        {
            chiefMock.AddPerson();
            chiefMock.AddPerson();
            chiefMock.accessor.AddPerson(Marge);

            chiefMock.RemovePerson();

            Assert.AreEqual(1, chiefMock.accessor.Count());
        }

        [Test]
        public void InsertPERSONTEST() 
        {
            chiefMock.accessor.AddPerson(Homer);
            chiefMock.accessor.AddPerson(Marge);
            chiefMock.accessor.AddPerson(Bart);
            chiefMock.accessor.AddPerson(Lisa);


            chiefMock.InsertPerson();

            Assert.AreEqual(5, chiefMock.accessor.Count());
            Assert.AreEqual("Homer", chiefMock.accessor.GetPersonByIndex(3).Name);
        }

        [Test]
        public void Clear() 
        {
            chiefMock.AddPerson();
            chiefMock.AddPerson();

            chiefMock.Clear();

            Assert.AreEqual(0, chiefMock.accessor.Count());
        }

        
        
    }
}
