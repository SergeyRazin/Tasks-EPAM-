using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyORMx;
using NUnit.Framework;
using MyORMx.Interfaces;




namespace UnitTests
{
    class ChiefMock:Chief
    {
        Client client = new Client();
        public IAccessor accessor = new AccessorMemory();

        public void AddPERSON()
        {
            string name = "Homer";
            int age = 47;
            client.AddPerson(new Person() { Name = name, Age = age }, accessor);
        }

        public void RemovePERSON()
        {
            string name = "Homer";
            client.RemovePerson(name, accessor);
        }

        public void InsertPERSON()
        {
            string name = "Homer";
            int age = 47;
            int index = 3;
            client.InsertPerson(index, new Person() { Name = name, Age = age }, accessor);
        }

        public void showALL()
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
            chiefMock.AddPERSON();
            chiefMock.AddPERSON();
            Assert.AreEqual(2, chiefMock.accessor.Count());

        }

        [Test]
        public void RemovePersonTEST() 
        {
            chiefMock.AddPERSON();
            chiefMock.AddPERSON();
            chiefMock.accessor.AddPerson(Marge);

            chiefMock.RemovePERSON();

            Assert.AreEqual(1, chiefMock.accessor.Count());
        }

        [Test]
        public void InsertPERSONTEST() 
        {
            chiefMock.accessor.AddPerson(Homer);
            chiefMock.accessor.AddPerson(Marge);
            chiefMock.accessor.AddPerson(Bart);
            chiefMock.accessor.AddPerson(Lisa);


            chiefMock.InsertPERSON();

            Assert.AreEqual(5, chiefMock.accessor.Count());
            Assert.AreEqual("Homer", chiefMock.accessor.GetPersonByIndex(3).Name);
        }

        [Test]
        public void Clear() 
        {
            chiefMock.AddPERSON();
            chiefMock.AddPERSON();

            chiefMock.Clear();

            Assert.AreEqual(0, chiefMock.accessor.Count());
        }

        
        
    }
}
